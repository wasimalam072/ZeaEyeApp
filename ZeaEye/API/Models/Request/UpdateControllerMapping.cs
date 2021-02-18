using System;
namespace ZeaEye.API.Models.RequestControllerMapping
{ 
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
