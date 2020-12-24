using System;
using System.Collections.Generic;
using System.Text;

namespace ZeaEye.API.Models.Response
{
    public class LocateControllerResponse
    {
        public bool IsErrorcode { get; set; } = true;
        public string controllerId { get; set; }
        public string partnerId { get; set; }
    }
}
