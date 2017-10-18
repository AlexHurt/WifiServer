using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using WifiServer.Models;

namespace WifiServer.Controllers
{
    public class WifiController : ApiController
    {
        public WifiConnection[] Get(string device)
        {
            var context = WifiFactory.GetContext();                                          
            return context.WifiConnections.Where(arg => arg.DeviceName == device).ToArray();
        }
    }
}
