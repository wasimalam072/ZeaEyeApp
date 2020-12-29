using System;
using Newtonsoft.Json;

namespace ZeaEye.API.Models.Request10
{
    // WASIM ALAM Add this field for Update Mobile Number Information  28 Dec 2020
    public class MobileNumber
    {
        public string stringValue { get; set; }
    }

    public class AlternativePhoneNumber
    {
        public string stringValue { get; set; }
    }

    public class FullName
    {
        public string stringValue { get; set; }
    }

    public class Fields
    {
        [JsonProperty("MobileNumber")]
        public MobileNumber MobileNumber { get; set; }

        [JsonProperty("AlternativePhoneNumber")]
        public AlternativePhoneNumber AlternativePhoneNumber { get; set; }

        [JsonProperty("Name")]
        public FullName FullName { get; set; }
    }

    public class updatePartnerId
    {
        public Fields fields { get; set; }
    }
}
