using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ZeaEye.API.Models.Request4
{
    public class PartnerId
    {
        public string stringValue { get; set; }
    }

    // WASIM ALAM Add this field for Update Mobile Number Information  28 Dec 2020
    public class MobileNumber
    {
        public string stringValue { get; set; }
    }

    // WASIM ALAM Add this field for Update Alternative Mobile Number Information  28 Dec 2020
    public class AlternativeMobileNumber
    {
        public string stringValue { get; set; }
    }

    // WASIM ALAM Add this field for Update User Name Information  28 Dec 2020
    public class FullName
    {
        public string stringValue { get; set; }
    }

    public class Fields
    {
        public PartnerId partnerId { get; set; }

        // WASIM ALAM Add this field for Update Mobile Number Information  28 Dec 2020
        public MobileNumber MobileNumber { get; set; }

        // WASIM ALAM Add this field for Update Alternative Mobile Number Information  28 Dec 2020
        public AlternativeMobileNumber AlternativeMobileNumber { get; set; }

        // WASIM ALAM Add this field for Update User Name Information  28 Dec 2020
        [JsonProperty("Name")]
        public FullName FullName { get; set; }
    }

    public class updatePartnerId
    {
        public Fields fields { get; set; }
    }


}
