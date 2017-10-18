using System.Linq;
using System.Web.Http;
using WifiServer.Models;

namespace WifiServer.Controllers
{
    public class WifiController : ApiController
    {
        public WifiConnection[] Get()
        {
            var context = WifiFactory.GetContext();                                          
            context.WifiConnections.Add(new WifiConnection { DeviceName = "iPhoneX", Date = "fdsfsd", Nets = "fdssdf"});
            context.SaveChanges();
            return context.WifiConnections.Where(arg => arg.DeviceName == "iPhoneX").ToArray();
        }
    }
}
