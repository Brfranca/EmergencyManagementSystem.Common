using AutoMapper;
using EmergencyManagementSystem.Common.BLL.Validations;
using EmergencyManagementSystem.Common.Common.Interfaces;
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
    public class UserBLL : BaseBLL<UserModel>, IUserBLL
    {
        private readonly IMapper _mapper;
        private readonly IUserDAL _userDAL;
        private readonly UserValidation _userValidation;
        public UserBLL(IUserDAL userDAL, UserValidation userValidation, IMapper mapper)
        {
            _userDAL = userDAL;
            _userValidation = userValidation;
            _mapper = mapper;
        }

        public override Result Delete(UserModel model)
        {
            throw new NotImplementedException();
        }

        public override Result<UserModel> Find(params object[] Id)
        {
            throw new NotImplementedException();
        }

        public override Result Register(UserModel userModel)
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

        public override Result Update(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
