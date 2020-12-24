using System;
namespace ZeaEye.API.Models.Request6
{
  public class ControllerID
  {
    public string stringValue { get; set; }
  }

  public class PartnerId
  {
    public string stringValue { get; set; }
  }

  public class UserId
  {
    public string stringValue { get; set; }
  }

  public class Removed
  {
    public bool booleanValue { get; set; }
  }

  public class Fields
  {
    public ControllerID ControllerID { get; set; }
    public PartnerId partnerId { get; set; }
    public UserId userId { get; set; }
    public Removed removed { get; set; }
  }

  public class SaveControllerMapping
  {
    public Fields fields { get; set; }
  }

}