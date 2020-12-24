using System;
using System.Collections.Generic;
using System.Text;

namespace ZeaEye.API.Models.Request4
{
    public class PartnerId
    {
        public string stringValue { get; set; }
    }

    public class Fields
    {
        public PartnerId partnerId { get; set; }
    }

    public class updatePartnerId
    {
        public Fields fields { get; set; }
    }


}
