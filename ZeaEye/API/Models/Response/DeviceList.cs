using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ZeaEye.ViewModels;

namespace ZeaEye.API.Models.Response
{
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class LastPosition
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class LifeBand
        {
            public string mac { get; set; }
            public object batteryLevelPercent { get; set; }
            public bool isConnected { get; set; }
        }

        public class Controller : BaseViewModel
        {

            private int _height;

            public int Height
            {
                get
                {

                    if (lifeBands.Count == 1)
                    {
                        _height = 75;
                    }
                    else if (lifeBands.Count == 2)
                    {
                        _height = 150;
                    }
                    else if (lifeBands.Count == 3)
                    {
                        _height = 205;
                    }
                    else if (lifeBands.Count == 4)
                    {
                        _height = 205;
                    }
                    else if (lifeBands.Count == 0)
                    {
                        _height = 0;
                    }
                    else
                    {
                        _height = 205;
                    }
                    return _height;
                }
                set { _height = value; RaisePropertyChanged(); }
            }

            public string controllerId { get; set; }
            public string serialNumber { get; set; }
            public string zeaEyeSerialNumber { get; set; }
            public int? batteryLevelPercent { get; set; }
            public string firmwareVersion { get; set; }
            public DateTime? lastSync { get; set; }
            public LastPosition lastPosition { get; set; }
            public int? directionOfSailing { get; set; }
            public ObservableCollection<LifeBand> lifeBands { get; set; }
            public object bms { get; set; }
            public double? currentSpeedKnots { get; set; }
            public int? tilt { get; set; }
            public double? currentTripDistanceNm { get; set; }
            public double? currentTripAvgSpeedKt { get; set; }
        }

        public class Root
        {
            public ObservableCollection<Controller> controllers { get; set; }
        }
}

