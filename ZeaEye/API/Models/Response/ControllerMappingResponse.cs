using System;
using Newtonsoft.Json;

namespace ZeaEye.API.Models.ResponseMapping
{
    public partial class Root
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
        public Email ControllerID { get; set; }
        [JsonProperty("partnerId")]
        public Email PartnerId { get; set; }

        [JsonProperty("userId")]
        public Email UserId { get; set; }

       [JsonProperty("removed")]
        public Remove Remove { get; set; }
    }

    public partial class Email
    {
        [JsonProperty("stringValue")]
        public string StringValue { get; set; }
    }
    public partial class Remove
    {
        [JsonProperty("booleanValue")]
        public string BooleanValue { get; set; }
    }

}
