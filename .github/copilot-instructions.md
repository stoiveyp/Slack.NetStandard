# Copilot Instructions for Slack.NetStandard

## Project Overview

**Slack.NetStandard** is a comprehensive .NET Standard 2.0 NuGet package providing a full-featured Slack API client for C#/.NET. It covers:

- **Web API** – 50+ method groups (Chat, Conversations, Users, Admin, Files, Views, Workflows, etc.)
- **Events API** – 50+ real-time event types for Slack app events
- **Interactive Components** – Slash commands, block actions, modals, shortcuts
- **Socket Mode** – WebSocket-based Slack communication
- **Message Building** – Rich message formatting with Blocks, Elements, and Rich Text
- **Request Verification** – HMAC-SHA256 cryptographic verification of incoming Slack requests
- **OAuth 2.0** – Authorization code exchange and OAuth flows

Current version: **11.1.0** | License: MIT | NuGet: `Slack.NetStandard`

---

## Repository Structure

```
Slack.NetStandard/                  # Main library (920 C# files, ~22k LOC)
  WebApi/                           # API method group implementations (~50 groups)
    Chat/                           # e.g. ChatApi.cs, IChatApi.cs, PostMessageRequest.cs
    Conversations/
    Users/
    Admin/                          # Nested sub-groups (Admin.Users, Admin.Channels, …)
    ...
  EventsApi/
    CallbackEvents/                 # Individual event types (AppMention, MessageReceived, …)
  Interaction/                      # Interactive payload types
  Messages/
    Blocks/                         # IMessageBlock implementations
    Elements/                       # IMessageElement implementations
    Objects/                        # TextObject, ConfirmationObject, etc.
  JsonConverters/                   # Custom Newtonsoft.Json converters
  RequestVerification/              # Request signature verification
  TextParsing/                      # Mention/link/channel text parsing
  SocketMode/                       # Socket Mode envelope types
Slack.NetStandard.Tests/            # Test suite (60 C# files, ~6k LOC)
  Examples/                         # 200+ real Slack JSON response fixtures
  Utility.cs                        # Shared test helpers
  WebApiTests_*.cs                  # Per-group API tests
  EventsApiTests.cs
  BlockTests.cs
  InteractionTests.cs
  SocketTests.cs
  ...
Slack.NetStandard.Analyzers/        # Custom Roslyn analyzers (bundled as private assets)
.github/workflows/
  main.yml                          # Build → Test → Deploy to NuGet.org + GitHub Packages
  beta.yml                          # Same pipeline targeting beta branch
```

---

## Build, Test, and Lint

```bash
# Restore dependencies
dotnet restore

# Build (warnings are errors in both Debug and Release)
dotnet build -c Release

# Run all tests
dotnet test

# Run tests with verbose output
dotnet test -v detailed
```

- **Target frameworks**: Library → .NET Standard 2.0; Tests → .NET 8.0
- `TreatWarningsAsErrors=True` is enforced in all configurations – fix every warning.
- The main library auto-generates a `.nupkg` on every build (`GeneratePackageOnBuild=true`).
- No `.editorconfig` or StyleCop; code quality is enforced via the bundled Roslyn analyzers in `Slack.NetStandard.Analyzers/`.
- CI skips when commit message includes `***NO_CI***`, `[ci skip]`, or `[skip ci]`.

---

## Core Architecture

### Entry Point – `SlackWebApiClient`

The primary public class. Implements `ISlackApiClient` and `IWebApiClient`. It:
- Accepts a Bearer token string **or** a custom `HttpClient`.
- Lazy-initialises each API group on first access.
- Delegates HTTP transport to its own `IWebApiClient` methods.

```csharp
var client = new SlackWebApiClient("xoxb-token");
var result = await client.Chat.Post(new PostMessageRequest { Channel = "C123", Text = "Hi" });
```

### Facade + Lazy Initialization Pattern

Every API group is exposed as a property on `SlackWebApiClient`, backed by a nullable field:

```csharp
private IChatApi _chat;
public IChatApi Chat => _chat ??= new ChatApi(this);
```

All API implementation classes (`ChatApi`, `ConversationsApi`, …) are **`internal`**. They are accessed only through their public interfaces.

### HTTP Transport – `IWebApiClient`

Four call patterns used throughout:

| Method | Usage |
|---|---|
| `MakeJsonCall<TReq, TRes>(method, request)` | JSON POST (most common) |
| `MakeUrlEncodedCall<TRes>(method, dict)` | Form-encoded POST |
| `MakeGetCall<TReq, TRes>(method, request)` | GET with query string |
| `MakeMultiPartCall<TRes>(method, data, files)` | Multipart / file upload |

### Request / Response Pattern

- **Request**: POCO with `[JsonProperty("snake_case")]` attributes; optional properties use `NullValueHandling = NullValueHandling.Ignore`.
- **Response**: Inherits from `WebApiResponseBase` (provides `OK`, `Error`, `Warning`, `Errors`, `RetryAfter`). Pagination uses `ResponseMetadata` with a `NextCursor`.

---

## Key Code Conventions

### Naming

| Element | Convention | Example |
|---|---|---|
| Interfaces | `I` prefix | `ISlackApiClient`, `IChatApi` |
| Classes | PascalCase | `SlackWebApiClient`, `PostMessageRequest` |
| Methods | PascalCase | `Post()`, `Delete()`, `AccessLogs()` |
| Properties | PascalCase | `Text`, `BlockId`, `ResponseUrl` |
| Private fields | `_camelCase` | `_client`, `_conversations` |
| JSON keys | snake_case via attribute | `[JsonProperty("block_id")]` |

### Serialization

- **Newtonsoft.Json** (JSON.NET) throughout – do **not** use `System.Text.Json`.
- Always use `[JsonProperty("name")]` for every serialized property.
- Use `NullValueHandling = NullValueHandling.Ignore` for all optional properties.
- Custom converters live in `JsonConverters/` (e.g., `EventTypeConverter`, `BlockTypeConverter`).
- `[JsonExtensionData]` captures unknown Slack API fields to avoid deserialization failures.

### One class per file

Keep one primary class per `.cs` file. Name the file after the class.

---

## Patterns for Adding New Features

### Adding a New API Endpoint to an Existing Group

1. **Request & Response classes** in `WebApi/<GroupName>/`:

   ```csharp
   public class MyNewRequest
   {
       [JsonProperty("channel")]
       public string Channel { get; set; }

       [JsonProperty("optional_param", NullValueHandling = NullValueHandling.Ignore)]
       public string OptionalParam { get; set; }
   }

   public class MyNewResponse : WebApiResponse
   {
       [JsonProperty("result", NullValueHandling = NullValueHandling.Ignore)]
       public string Result { get; set; }
   }
   ```

2. **Interface** – add method signature to `I<GroupName>Api.cs`:

   ```csharp
   Task<MyNewResponse> NewMethod(MyNewRequest request);
   ```

3. **Implementation** – add method to the `internal` `<GroupName>Api.cs`:

   ```csharp
   public Task<MyNewResponse> NewMethod(MyNewRequest request) =>
       _client.MakeJsonCall<MyNewRequest, MyNewResponse>("group.newMethod", request);
   ```

4. **Test** in `WebApiTests_<GroupName>.cs`:

   ```csharp
   [Fact]
   public async Task GroupName_NewMethod()
   {
       await Utility.AssertWebApi(
           c => c.GroupName.NewMethod(new MyNewRequest { Channel = "C123" }),
           "group.newMethod",
           "Web_GroupName_NewMethod.json",
           jobject => Assert.Equal("C123", jobject.Value<string>("channel")));
   }
   ```

5. **Fixture** – add `Examples/Web_GroupName_NewMethod.json` with a representative Slack API response.

### Adding a New API Group

Follow all five steps above, plus:

6. Add a lazy-init property to `SlackWebApiClient`:

   ```csharp
   private INewGroupApi _newGroup;
   public INewGroupApi NewGroup => _newGroup ??= new NewGroupApi(this);
   ```

7. Add the property to the `ISlackApiClient` interface.

### Adding a New Event Type

1. Create class in `EventsApi/CallbackEvents/`:

   ```csharp
   public class MyNewEvent : CallbackEvent
   {
       public override string Type => "my_new_event";

       [JsonProperty("property", NullValueHandling = NullValueHandling.Ignore)]
       public string Property { get; set; }
   }
   ```

2. Register the type string in `EventTypeConverter` (in `JsonConverters/`).

3. Add a test to `EventsApiTests.cs` and a fixture `Examples/Events_MyNewEvent.json`.

### Adding a New Message Block

1. Create class in `Messages/Blocks/` implementing `IMessageBlock`.
2. Add the type string to `BlockTypeConverter`.
3. Add a round-trip test to `BlockTests.cs` and fixture `Examples/Blocks_MyBlock.json`.

---

## Test Helpers

`Utility.cs` provides:

| Helper | Purpose |
|---|---|
| `Utility.AssertWebApi(call, method, fixture, checks)` | Verifies a Web API call serialises/deserialises correctly against a JSON fixture |
| `Utility.AssertSubType<TBase, TDerived>(fixture)` | Verifies polymorphic JSON deserialises to the correct derived type |
| `Utility.CompareJson(obj, fixture)` | Serialises `obj` and asserts it matches the fixture JSON |

All fixture files live in `Slack.NetStandard.Tests/Examples/`. Naming conventions:

| Prefix | Area |
|---|---|
| `Web_` | Web API requests/responses |
| `Events_` | Events API payloads |
| `Blocks_` | Message blocks |
| `Cells_` | SlackLists cell types |
| `Socket_` | Socket Mode envelopes |
| `WorkObjects_` | Workflow objects |

---

## CI/CD

- **`main` branch**: build → test → push to NuGet.org (`NUGET_KEY` secret) and GitHub Packages.
- **`beta` branch**: same pipeline with a `-beta` suffix package.
- Deployments only happen on a direct push to `main`/`beta`; PRs run build + test only.

---

## Common Pitfalls & Known Workarounds

- **Treat warnings as errors**: Any new compiler warning will break the build. Always resolve analyzer and compiler warnings before committing.
- **Use `NullValueHandling.Ignore`** on every optional JSON property or Slack's strict field presence rules may cause unexpected serialisation behaviour.
- **Do not use `System.Text.Json`**: The entire library depends on Newtonsoft.Json conventions and custom converters.
- **Internal API classes**: Never make `*Api` implementation classes `public`. They must remain `internal` and only be accessible via their `I*Api` interface.
- **Polymorphic event/block deserialization**: Adding a new event or block type without registering it in the corresponding `*TypeConverter` will cause it to silently deserialise as `null` or the base type.
- **Admin API nesting**: The `Admin` group has sub-groups (`Admin.Users`, `Admin.Apps`, `Admin.Conversations`, …). Follow the same nested lazy-init pattern used there when adding further sub-groups.
