using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ZeaEye.API.Models.Request;
using ZeaEye.API.Models.Response;

namespace ZeaEye.API.Services
{
   public class BaseApiServices
    {
        
        string XAPIKey = "B9467C541CF04DD28D36EFA0A4B3A48F";
        string Baseurl = "https://api.zeaeye.com";

        #region Devices
        public async Task<Root> GetDevices(string partnerId)
        {
            Root device = new Root();
            // partnerId = "6a9edec0-168e-43ba-a62c-c67b78deef1c";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-Api-Key", XAPIKey);
                //GET Method  
                HttpResponseMessage response = await client.GetAsync("/api/v1/web/devices/?partnerId=" + partnerId + "");
                if (response.IsSuccessStatusCode)
                {
                    string Result = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<Root>(Result);
                    return data;
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        #region Locate Controller
        public async Task<LocateControllerResponse> LocateController(string zeserialnr)
        {
            LocateControllerResponse Con = new LocateControllerResponse();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-Api-Key", XAPIKey);
                //GET Method  
                HttpResponseMessage response = await client.GetAsync("/api/v1/admin/controller/find?zeserialnr=" + zeserialnr + "");
                if (response.IsSuccessStatusCode)
                {
                    string Result = await response.Content.ReadAsStringAsync();
                    return Con = JsonConvert.DeserializeObject<LocateControllerResponse>(Result);

                }
                else
                {
                    return new LocateControllerResponse { IsErrorcode = false };
                }
            }
        }
        #endregion

        #region SaveController
        public async Task<string> SaveController(string controllerId, string partnerId)
        {
            string url = Baseurl + "/api/v1/admin/partner/controller";
            using (var client = new HttpClient())
            {
                var reqJson = JsonConvert.SerializeObject(new
                {
                    partnerId = partnerId,
                    controllerId = controllerId
                });
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-Api-Key", XAPIKey);
                var httpcontent = new StringContent(reqJson, Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync(url, httpcontent);
                //var resStr = await response.Content.ReadAsStringAsync();
                //var data = JsonConvert.DeserializeObject(resStr);
                string msg = "";
                if ((int)res.StatusCode == 201)
                {
                     msg = "Connected";
                }
                if ((int)res.StatusCode == 409)
                {
                    msg = "Conflict";
                }
                return msg;
            }
        }
        #endregion

        #region CreateDocument
        public async Task<string> SaveDocument(string Email, string partnerId, string userId, string name)
        {
            string url = "https://firestore.googleapis.com/v1beta1/projects/zeaeye-development/databases/(default)/documents/user_data?key=AIzaSyDFsKxTp9Iy9ahegMAIHIn8atPKrbbLM70";
            using (var client = new HttpClient())
            {
                var model = new SaveDoc
                {
                    fields = new Fields
                    {
                        partnerId = new PartnerId { stringValue = partnerId },
                        userId = new UserId { stringValue = userId },
                        Email = new Email { stringValue = Email },
                        Name = new Name { stringValue = name }
                    }
                };

                var reqJson = JsonConvert.SerializeObject(model);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-Api-Key", XAPIKey);
                var httpcontent = new StringContent(reqJson, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, httpcontent);
                var resStr = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject(resStr);
                if (data != null)
                {
                    return "ok";
                }
                else
                {
                    return "Some error";
                }
            }
        }
    #endregion

    #region Controller Maping
    public async Task<string> SaveControllerDocument(string ControllerID, string partnerId, string userId, bool removed)
    {
      string url = "https://firestore.googleapis.com/v1beta1/projects/zeaeye-development/databases/(default)/documents/user_controllers?key=AIzaSyDFsKxTp9Iy9ahegMAIHIn8atPKrbbLM70";
      using (var client = new HttpClient())
      {
        var model = new Models.Request6.SaveControllerMapping
        {
          fields = new Models.Request6.Fields
          {
            ControllerID = new Models.Request6.ControllerID { stringValue = ControllerID },
            partnerId = new Models.Request6.PartnerId { stringValue = partnerId },
            userId = new Models.Request6.UserId { stringValue = userId },
            removed = new Models.Request6.Removed { booleanValue = removed }
          }
        };

        var reqJson = JsonConvert.SerializeObject(model);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("X-Api-Key", XAPIKey);
        var httpcontent = new StringContent(reqJson, Encoding.UTF8, "application/json");
        var response = await client.PostAsync(url, httpcontent);
        var resStr = await response.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject(resStr);
        if (data != null)
        {
          return "ok";
        }
        else
        {
          return "Some error";
        }
      }
    }
    #endregion
    #region Check Controller Mapping Existanency
    public async Task<Tuple<string, string>> CheckControllerMapingExisting(string ControllerID,string PartnerId,bool Removed)
    {
      string url = "https://firestore.googleapis.com/v1/projects/zeaeye-development/databases/(default)/documents:runQuery";
      using (var client = new HttpClient())
      {
        var mode = new Models.RequestMapping.Root
        {
          structuredQuery = new Models.RequestMapping.StructuredQuery
          {
            from = new List<Models.RequestMapping.From>
                  {
                      new Models.RequestMapping.From
                      {
                          collectionId ="user_controllers"
                      }
                  },
            where = new Models.RequestMapping.Where
            {
              compositeFilter = new Models.RequestMapping.CompositeFilter
              {
                filters = new List<Models.RequestMapping.Filter>
                          {
                              new Models.RequestMapping.Filter
                              {
                                  fieldFilter = new Models.RequestMapping.FieldFilter
                                  {
                                      field = new Models.RequestMapping.Field
                                      {
                                          fieldPath ="ControllerID"
                                      },
                                      op="EQUAL",
                                      value = new Models.RequestMapping.Value
                                      {
                                          stringValue =ControllerID
                                      }
                                  }
                              }, new Models.RequestMapping.Filter
                              {
                                  fieldFilter = new Models.RequestMapping.FieldFilter
                                  {
                                      field = new Models.RequestMapping.Field
                                      {
                                          fieldPath ="partnerId"
                                      },
                                      op="EQUAL",
                                      value = new Models.RequestMapping.Value
                                      {
                                          stringValue =PartnerId
                                      }
                                  }
                              }, new Models.RequestMapping.Filter
                              {
                                  fieldFilter = new Models.RequestMapping.FieldFilter
                                  {
                                      field = new Models.RequestMapping.Field
                                      {
                                          fieldPath ="removed"
                                      },
                                      op="EQUAL",
                                      value = new Models.RequestMapping.Value
                                      {
                                          booleanValue  =Removed
                                      }
                                  }
                              }
                          },
                op = "AND"
              }
            },
            limit = 1
          }
        };
        string res = "";
        string name = "";
        string arr = "";

        var reqJson = JsonConvert.SerializeObject(mode);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("X-Api-Key", XAPIKey);
        var httpcontent = new StringContent(reqJson, Encoding.UTF8, "application/json");
        var response = await client.PostAsync(url, httpcontent);
        var resStr = await response.Content.ReadAsStringAsync();
        try
        {

          var p = JsonConvert.DeserializeObject<List<ZeaEye.API.Models.ResponseMapping.Root>>(resStr);
                    if(p[0].Document==null)
                    {
                        res = "";
                        name = "";
                    }
                    else
                    {
                        res = p[0].Document.Fields.PartnerId.StringValue;
                        name = p[0].Document.Name;
                    }
          

        }
        catch (Exception exe)
        {

        }
        return new Tuple<string, string>(res, name);
      }
    }
    #endregion

    #region update Controller Mapping     
    public async Task<string> UpdateControllerMapping(string DocId, bool removed)
    {
      string url = "https://firestore.googleapis.com/v1beta1/projects/zeaeye-development/databases/(default)/documents/user_controllers/" + DocId + "?updateMask.fieldPaths=removed";
      var client = new HttpClient();
      var model = new Models.RequestControllerMapping.updateControler
      {
        fields = new Models.RequestControllerMapping.Fields
        {
          removed = new Models.RequestControllerMapping.Removed
          {
            booleanValue = removed
          }
        }
      };

      var method = new HttpMethod("PATCH");

      var request = new HttpRequestMessage(method, url)
      {
        Content = new StringContent(
                          JsonConvert.SerializeObject(model),
                          Encoding.UTF8, "application/json")
      };

      var response = await client.SendAsync(request);

      var responseString = await response.Content.ReadAsStringAsync();
      return responseString;
    }

    #endregion

    #region GetPartnerId
    public async Task<Tuple<string, string>> GetPartnerId(string UId)
        {
            string url = "https://firestore.googleapis.com/v1/projects/zeaeye-development/databases/(default)/documents:runQuery";
            using (var client = new HttpClient())
            {
                var model = new GetPartnerId
                {
                    structuredQuery = new StructuredQuery
                    {
                        from = new List<From> { new From { collectionId = "user_data" } },
                        where = new Where
                        {
                            compositeFilter = new CompositeFilter
                            {
                                filters = new List<Filter>
                            {
                                new Filter
                                {
                                    fieldFilter =new FieldFilter
                                    {
                                        field =new Field{
                                            fieldPath ="userId",

                                        },op ="EQUAL",
                                        value =new Value
                                        {
                                            stringValue =UId
                                        }
                                    }
                                }
                            },
                                op = "AND"
                            }
                        },
                        limit = 1
                    },
                };
                string res = "";
                string name = "";
                string arr = "";

                var reqJson = JsonConvert.SerializeObject(model);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-Api-Key", XAPIKey);
                var httpcontent = new StringContent(reqJson, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, httpcontent);
                var resStr = await response.Content.ReadAsStringAsync();
                try
                {

                    var p = JsonConvert.DeserializeObject<List<ZeaEye.API.Models.Request1.Root>>(resStr);
                    res = p[0].Document.Fields.PartnerId.StringValue;
                    name = p[0].Document.Name;

                }
                catch (Exception exe)
                {

                }
                return new Tuple<string, string>(res, name);
            }
        }
        #endregion

        #region CreatePartnerId
        public async Task<GetpartnerId> CreatePartnerId(string Email)
        {
            string url = Baseurl + "/api/v1/admin/partner";
            using (var client = new HttpClient())
            {
                var model = new CreatePartnerId
                {
                    name = Email
                };
                var reqJson = JsonConvert.SerializeObject(model);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-Api-Key", XAPIKey);
                var httpcontent = new StringContent(reqJson, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, httpcontent);
                var resStr = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<GetpartnerId>(resStr);
                return data;
            }
        }
        #endregion

        #region update Partner Id using Email     
        public async Task<string> UpdatePartnerId(string DocId, String partnerId)
        {
            string url = "https://firestore.googleapis.com/v1beta1/projects/zeaeye-development/databases/(default)/documents/user_data/" + DocId + "?updateMask.fieldPaths=partnerId";
            var client = new HttpClient();
            var model = new ZeaEye.API.Models.Request4.updatePartnerId
            {
                fields = new ZeaEye.API.Models.Request4.Fields
                {
                    partnerId = new ZeaEye.API.Models.Request4.PartnerId
                    {
                        stringValue = partnerId
                    }
                }
            };

            var method = new HttpMethod("PATCH");

            var request = new HttpRequestMessage(method, url)
            {
                Content = new StringContent(
                                JsonConvert.SerializeObject(model),
                                Encoding.UTF8, "application/json")
            };

            var response = await client.SendAsync(request);

            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }

        #endregion

        #region Add devices
        public async Task<string> SaveDevice(string ControllerId, String type, string mac)
        {
            string url = Baseurl + "/api/v1/admin/device";
            using (var client = new HttpClient())
            {
                var model = new SaveDevice
                {
                    controllerId = ControllerId,
                    type = type,
                    mac = mac
                };
                var reqJson = JsonConvert.SerializeObject(model);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-Api-Key", XAPIKey);
                var httpcontent = new StringContent(reqJson, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, httpcontent);
                var resStr = await response.Content.ReadAsStringAsync();
                if (resStr == null || resStr == "")
                {
                    return "created";
                }
                else
                {
                    return "conflict";
                }
            }

        }
        #endregion

    }
}
