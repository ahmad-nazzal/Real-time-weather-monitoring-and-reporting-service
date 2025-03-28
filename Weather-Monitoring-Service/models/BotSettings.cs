using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Monitoring_Service.models
{
    public class BotSettings
    {
        public bool Enabled { get; set; }
        public required string Message { get; set; }
    }
}
