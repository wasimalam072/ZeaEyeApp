using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZeaEye.API.Models.Response;

namespace ZeaEye.API.Interfaces
{
   public interface IApiServices
    {
        //Use partnerid:6a9edec0-168e-43ba-a62c-c67b78deef1c
        #region GetDevices
        Task<Root> GetAllDevices(string PartnerId);
        #endregion
        //use zeserialnr:RP-1
        #region LocateDevice
        Task<LocateControllerResponse> LocateController(string zeserialnr);
        #endregion
        #region SaveCntroller
        Task<string> SaveController(string controllerId, string partnerId);
        #endregion
        #region Save DOcument
        Task<string> SaveDocument(string Email, string partnerId, string userId, string name);
        #endregion
        #region GetPartnerId
        Task<Tuple<string, string>> GetPartnerId(string userId);
        #endregion
        #region Createpartner Id
        Task<GetpartnerId> CreatePartnerId(string Email);
        #endregion
        #region UpdatepartnerId
        Task<string> UpdatePartnerId(string DocId, String partnerId);
        #endregion

    }
}
