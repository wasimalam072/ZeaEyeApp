using System;
using System.Collections.Generic;
using System.Text;

namespace ZeaEye.API.Models.Request
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class From
    {
        public string collectionId { get; set; }
    }

    public class Field
    {
        public string fieldPath { get; set; }
    }

    public class Value
    {
        public string stringValue { get; set; }
    }

    public class FieldFilter
    {
        public Field field { get; set; }
        public string op { get; set; }
        public Value value { get; set; }
    }

    public class Filter
    {
        public FieldFilter fieldFilter { get; set; }
    }

    public class CompositeFilter
    {
        public List<Filter> filters { get; set; }
        public string op { get; set; }
    }

    public class Where
    {
        public CompositeFilter compositeFilter { get; set; }
    }

    public class StructuredQuery
    {
        public List<From> from { get; set; } = new List<From>();
        public Where where { get; set; }
        public int limit { get; set; }
    }

    public class GetPartnerId
    {
        public StructuredQuery structuredQuery { get; set; }
    }

}
