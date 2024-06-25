namespace Slack.NetStandard.WebApi.Canvases
{
    public class CanvasDeleteAccessRequest : CanvasAccessRequest
    {
        public CanvasDeleteAccessRequest(string canvasId)
        {
            CanvasId = canvasId;
        }
    }
}
