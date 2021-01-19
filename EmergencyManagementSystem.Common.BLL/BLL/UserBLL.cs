using AutoMapper;
using EmergencyManagementSystem.Common.BLL.Validations;
using EmergencyManagementSystem.Common.Common.Models;
using EmergencyManagementSystem.Common.DAL.DAL;
using EmergencyManagementSystem.Common.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyManagementSystem.Common.BLL.BLL
{
    public class UserBLL
    {
        private readonly IMapper _mapper;
        private readonly UserDAL _userDAL;
        private readonly UserValidation _userValidation;
        public UserBLL(UserDAL userDAL, UserValidation userValidation, IMapper mapper)
        {
            _userDAL = userDAL;
            _userValidation = userValidation;
            _mapper = mapper;
        }

        public Result Register(UserModel userModel)
        {
            try
            {
                var user = _mapper.Map<User>(userModel);

                var result = _userValidation.Validate(user);
                if (!result.Success)
                    return result;

                _userDAL.Insert(user);
                return _userDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro no momento de registar o usuário.", error);
            }
        }
    }
}
