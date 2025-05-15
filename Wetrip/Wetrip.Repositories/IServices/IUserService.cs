using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wetrip.Services.DTO.RequestDTO.UserModel;
using Wetrip.Services.DTO.ResponseDTO;

namespace Wetrip.Service.IServices
{
    public interface IUserService
    {
        public Task<ResponseRegisterAccount> RegisterAccountCustomer(RequestRegisterAccount requestRegisterAccount);
        public Task<int> ConfirmAccountCustomer(RequestConfirmAccount requestConfirmAccount);
    }
}
