using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZeaEye.API.Interfaces;
using ZeaEye.API.Models.Response;

namespace ZeaEye.API.Services
{
   public class ApiServices : IApiServices
    {
        BaseApiServices baseAPI = new BaseApiServices();



        #region Devices
        public async Task<Root> GetAllDevices(string PartnerId)
        {
            return await baseAPI.GetDevices(PartnerId);
        }
        #endregion


        #region LocateController
        public async Task<LocateControllerResponse> LocateController(string zeserialnr)
        {
            return await baseAPI.LocateController(zeserialnr);
        }
        #endregion
        #region Save Controller
        public async Task<string> SaveController(string controllerId, string partnerId)
        {
            return await baseAPI.SaveController(controllerId, partnerId);
        }
        #endregion
        #region SaveDocument
        public async Task<string> SaveDocument(string Email, string partnerId, string userId, string name)
        {
            return await baseAPI.SaveDocument(Email, partnerId, userId, name);
        }
        #endregion
        #region GetPartnerId
        public async Task<Tuple<string, string>> GetPartnerId(string userId)
        {
            return await baseAPI.GetPartnerId(userId);

        }
        #endregion
        #region CreatePartnerId
        public async Task<GetpartnerId> CreatePartnerId(string Email)
        {
            return await baseAPI.CreatePartnerId(Email);
        }
        #endregion
        #region UpdatePartnerId
        public async Task<string> UpdatePartnerId(string DocId, String partnerId)
        {
            return await baseAPI.UpdatePartnerId(DocId, partnerId);
        }
        #endregion

    }
}
