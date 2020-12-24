using System;
using Newtonsoft.Json;

namespace ZeaEye.API.Models.ResponseMapping
{
    public partial class GetMappingResponse
    {
        [JsonProperty("document")]
        public Document Document { get; set; }

        [JsonProperty("readTime")]
        public DateTimeOffset ReadTime { get; set; }
    }

    public partial class Document
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("fields")]
        public Fields Fields { get; set; }

        [JsonProperty("createTime")]
        public DateTimeOffset CreateTime { get; set; }

        [JsonProperty("updateTime")]
        public DateTimeOffset UpdateTime { get; set; }
    }

    public partial class Fields
    {
        [JsonProperty("ControllerID")]
        public ErId ControllerId { get; set; }

        [JsonProperty("removed")]
        public Removed Removed { get; set; }

        [JsonProperty("userId")]
        public ErId UserId { get; set; }

        [JsonProperty("partnerId")]
        public ErId PartnerId { get; set; }
    }

    public partial class ErId
    {
        [JsonProperty("stringValue")]
        public string StringValue { get; set; }
    }

    public partial class Removed
    {
        [JsonProperty("booleanValue")]
        public bool BooleanValue { get; set; }
    }
}
