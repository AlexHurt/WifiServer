using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WifiServer.Models
{
    [Table("wificonnections")]
    public class WifiConnection
    {
        [Key]
        public int ConnectionId { get; set; }
        public string DeviceName { get; set; }
        public string Date { get; set; }
        public string Nets { get; set; }
    }
}