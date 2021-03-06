﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeaEye.API.Models.Request1
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
        [JsonProperty("Name")]
        public Email Name { get; set; }

        [JsonProperty("userId")]
        public Email UserId { get; set; }

        [JsonProperty("Email")]
        public Email Email { get; set; }

        [JsonProperty("partnerId")]
        public Email PartnerId { get; set; }
    }

    public partial class Email
    {
        [JsonProperty("stringValue")]
        public string StringValue { get; set; }
    }

}
