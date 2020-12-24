using System;
using System.Collections.Generic;
using System.Text;
using ZeaEye.ViewModels;
using ZeaEye.Models;

namespace ZeaEye.Models
{
    public class YourDeviceList1
    {
        public string ImageDevices { get; set; }
        public string serialNumber { get; set; }
    }
    public class YourTypeDeviceList
    {
        public string ImageDevices { get; set; }
        public string serialNumber { get; set; }
    }
    public class YourDeviceList : BaseModel
    {
        public string ImageDevices { get; set; }
        public object MacAddress { get; set; }
        public string DeviceName { get; set; }
    }

    public class YourControllerList
    {
        public string ImageController { get; set; }
        public string serialNumber { get; set; }
    }

}
