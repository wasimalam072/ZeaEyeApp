using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ZeaEye.API.Models.RequestMapping
{
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
    public bool? booleanValue { get; set; } = null;
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
    public List<From> from { get; set; }
    public Where where { get; set; }
    public int limit { get; set; }
  }

  public class Root
  {
    public StructuredQuery structuredQuery { get; set; }
  }
}
