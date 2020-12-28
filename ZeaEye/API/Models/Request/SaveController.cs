using System;
using System.Collections.Generic;
using System.Text;

namespace ZeaEye.API.Models.Request
{
    public class SaveController
    {
        public string controllerId { get; set; }
        public string partnerId { get; set; }
    }
    public class PartnerId
    {
        public string stringValue { get; set; }
    }

    public class UserId
    {
        public string stringValue { get; set; }
    }

    public class Email
    {
        public string stringValue { get; set; }
    }
    

    public class Name
    {
        public string stringValue { get; set; }
    }

    // WASIM ALAM Add this field for Get Mobile Number Information  28 Dec 2020
    public class MobileNumber
    {
        public string stringValue { get; set; }
    }

    // WASIM ALAM Add this field for Get Alternative Mobile Number Information  28 Dec 2020
    public class AlternativeMobileNumber
    {
        public string stringValue { get; set; }
    }

    public class Fields
    {
        public PartnerId partnerId { get; set; }
        public UserId userId { get; set; }
        public Email Email { get; set; }
        public Name Name { get; set; }

        // WASIM ALAM Add this field for Get Mobile Number Information  28 Dec 2020
        public MobileNumber MobileNumber { get; set; }
        // WASIM ALAM Add this field for Get Alternative Mobile Number Information  28 Dec 2020
        public AlternativeMobileNumber AlternativeMobileNumber { get; set; }
    }

    public class SaveDoc
    {
        public Fields fields { get; set; }
    }

}
