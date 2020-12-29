﻿using System;
using Newtonsoft.Json;

namespace ZeaEye.API.Models.Response11
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
        [JsonProperty("Name")]
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


        // WASIM ALAM Add this field for Get Mobile Number Information  28 Dec 2020
        [JsonProperty("AlternativePhoneNumber")]
        public Email AlternativePhoneNumber { get; set; }

        // WASIM ALAM Add this field for Get Mobile Number Information  28 Dec 2020
        [JsonProperty("MobileNumber")]
        public Email MobileNumber { get; set; }
    }

    public partial class Email
    {
        [JsonProperty("stringValue")]
        public string StringValue { get; set; }
    }

}