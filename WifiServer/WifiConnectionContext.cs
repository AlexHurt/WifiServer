using System.Data.Entity;
using WifiServer.Models;

namespace WifiServer
{
    public class WifiConnectionContext : DbContext
    {
        public DbSet<WifiConnection> WifiConnections { get; set; }
    }
}