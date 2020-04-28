# Slack.NetStandard
.NET Core NuGet package that helps with Slack interactions
AVailable at https://www.nuget.org/packages/Slack.NetStandard

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


## Make Web API Call

```csharp
using Slack.NetStandard;

var client = new SlackWebApiClient(accessToken);
await client.Chat.Post(postMessageRequest);
```
