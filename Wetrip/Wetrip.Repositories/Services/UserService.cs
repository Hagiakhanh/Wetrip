using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Wetrip.Data.Entities;
using Wetrip.Data.IRepositories;
using Wetrip.Data.UnitOfWork;
using Wetrip.Service.IServices;
using Wetrip.Services.DTO.RequestDTO.UserModel;
using Wetrip.Services.DTO.ResponseDTO;
using Wetrip.Services.Ultils;

namespace Wetrip.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ISmsService _smsService;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, IRoleRepository roleRepository,
            ISmsService smsService)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _smsService = smsService;
        }

        public async Task<ResponseRegisterAccount> RegisterAccountCustomer(RequestRegisterAccount requestRegisterAccount)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                // Kiem tra xem email hoac phone da ton tai chua
                if (!requestRegisterAccount.EmailAddress.IsNullOrEmpty())
                {
                    var user = await _userRepository.GetUserByEmail(requestRegisterAccount.EmailAddress);
                    if (user != null)
                    {
                        throw new Exception($"Email address '{requestRegisterAccount.EmailAddress}' already exists");
                    }
                }
                else if (!requestRegisterAccount.Phone.IsNullOrEmpty())
                {
                    var user = await _userRepository.GetUserByPhone(requestRegisterAccount.Phone);
                    if (user != null)
                    {
                        throw new Exception($"Phone '{requestRegisterAccount.Phone}' already exists");
                    }
                }

                // Tạo mới tài khoản
                var role = await _roleRepository.GetRoleByName("Customer");
                if (role == null)
                {
                    throw new Exception("Role 'Customer' not found");
                }

                var newUser = new User()
                {
                    FirstName = requestRegisterAccount.FirstName,
                    LastName = requestRegisterAccount.LastName,
                    Password = PasswordUtils.HashPassword(requestRegisterAccount.Password),
                    Birthday = requestRegisterAccount.Birthday,
                    Gender = requestRegisterAccount.Gender.ToString(),
                    Phone = requestRegisterAccount.Phone,
                    EmailAddress = requestRegisterAccount.EmailAddress,
                    RoleId = role.RoleId,
                    ConfirmToken = GenerateFourDigitNumber.GenerateNumber(),
                    IsAccountConfirm = false,
                    RequestId = Guid.NewGuid()
                };
                await _userRepository.InsertAsync(newUser);

                // Gửi phone OTP xác minh điện thoại
                var smsResult =  _smsService.SpeedSMSApi(newUser.ConfirmToken, requestRegisterAccount.Phone);
                
                var result = await _unitOfWork.SaveChanges();
                await _unitOfWork.CommitTransactionAsync();
                return new ResponseRegisterAccount()
                {
                    Message = "Send OTP",
                    RequestId = newUser.RequestId.ToString()
                };
            }
            catch (Exception e)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<int> ConfirmAccountCustomer(RequestConfirmAccount requestConfirmAccount)
        {
            if (string.IsNullOrEmpty(requestConfirmAccount.OtpCode))
            {
                throw new Exception($"Otp Code '{requestConfirmAccount.OtpCode}' not found");
            }
            if (string.IsNullOrEmpty(requestConfirmAccount.RequestId))
            {
                throw new Exception("Invalid RequestId");
            }
            
            var user = await _userRepository.GetUserByRequestId(requestConfirmAccount.RequestId);
            if (user == null)
            {
                throw new Exception($"RequestId '{requestConfirmAccount.RequestId}' not found");
            }
            if(user.IsAccountConfirm == false && user.ConfirmToken == requestConfirmAccount.OtpCode)
            {
                user.IsAccountConfirm = true;
                user.ConfirmToken = string.Empty;
                await _userRepository.UpdateAsync(user);
                var result = await _unitOfWork.SaveChanges();
                if (result <= 0)
                {
                    throw new Exception("Confirm account failed");
                }
                return result;
            }
            return 0;
        }
    }
}