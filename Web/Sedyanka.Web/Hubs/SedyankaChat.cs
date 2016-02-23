namespace MvcTemplate.Web.Hubs
{
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;

    [HubName("chat")]
    public class SedyankaChat : Hub
    {

        public void NewMessage(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }
    }
}