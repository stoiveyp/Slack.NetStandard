# Slack.NetStandard
.NET Core NuGet package that helps with Slack interactions
Available at https://www.nuget.org/packages/Slack.NetStandard

## Create OAuth URL

```csharp
using Slack.NetStandard.Auth;

var builder = new OAuthV2Builder("clientId")
{
    State = "stateGoesHere", 
    BotScope = "channels:read"
};
var redirectUri = builder.BuildUri();
```

## Get OAuth Access Token from Code

```csharp
using Slack.NetStandard.Auth;

var token = await OAuthV2Builder.Exchange(code,clientId,clientSecret);
```


## Verify Incoming Request is from Slack

```csharp
using Slack.NetStandard;

var verifier = new RequestVerifier(signingSecret);
var verified = Verifier.Verify(request.Headers["X-Slack-Signature"], long.Parse(request.Headers["X-Slack-Request-Timestamp"]), request.Body);
```

## Receive/Respond to a slash command payload

```csharp
var command = new SlashCommand(payloadText);

var message = new InteractionMessage();
message.Blocks.Add(new Section{Text = new PlainText("Only title is required")});
message.Blocks.Add(new Divider());
message.Send(command.ResponseUrl);

await command.Respond(message);

// or - if it's not from a slash command, any response url can use
await command.Response(responseUrl);
```

## Building & sending a modal

```csharp
var view = new View
{
    Type = "modal",
    Title = "Create New Story",
    Close = "Cancel",
    Submit = "Submit",
    Blocks = new IMessageBlock[]
    {
       new Section{Text = new PlainText("Only title is required")}
    }
};

var client = new SlackWebApiClient(accessToken);
var response = await client.View.Open(triggerId,view);
```

## Sending a new message to a channel

```csharp
var request = new PostMessageRequest {Channel = "C123456"};
request.Blocks.Add(new Section{Text = new PlainText("Hi There!")});

var client = new SlackWebApiClient("token");
await client.Chat.Post(request);
```

## Parse Events API Body

```csharp
using Slack.NetStandard.EventsApi;
using Slack.NetStandard.EventsApi.CallbackEvents;

var eventObject = JsonConvert.DeserializeObject<Event>(input.Body);

if (eventObject is EventCallback callback)
{
    switch(callback.Event)
    {
        case AppHomeOpened appHome:
            break;
        case GroupClose groupClose:
            break;

    }
}
```

## Parse incoming text for entities (channels, users, links etc.)
```
var entities = TextParser.FindEntities("<@W123456|Steven>").First();
if(entity is UserMention mention)
{
    var userId = mention.UserId //W123456
    var label = mention.Label //Steven
}
```
