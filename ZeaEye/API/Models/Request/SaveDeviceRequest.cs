using System;
using System.Collections.Generic;
using System.Text;

namespace ZeaEye.API.Models.Request
{
    public class SaveDevice
    {
        public string controllerId { get; set; }
        public string type { get; set; }
        public string mac { get; set; }
    }
}
