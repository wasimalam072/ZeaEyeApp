using System;
namespace ZeaEye.API.Models.RequestControllerMapping
{
  // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
  public class Removed
  {
    public bool booleanValue { get; set; }
  }

  public class Fields
  {
    public Removed removed { get; set; }
  }

  public class updateControler
  {
    public Fields fields { get; set; }
  }
}
