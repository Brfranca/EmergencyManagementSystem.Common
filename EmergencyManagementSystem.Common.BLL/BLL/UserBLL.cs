using AutoMapper;
using EmergencyManagementSystem.Common.BLL.Validations;
using EmergencyManagementSystem.Common.Common.Filters;
using EmergencyManagementSystem.Common.Common.Interfaces;
using EmergencyManagementSystem.Common.Common.Interfaces.BLL;
using EmergencyManagementSystem.Common.Common.Models;
using EmergencyManagementSystem.Common.Entities.Entities;
using System;

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
            try
            {
                User user = _mapper.Map<User>(model);
                _userDAL.Delete(user);
                return _userDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao deletar o registro do usuário.", error);
            }
        }

        public override Result<UserModel> Find(IFilter filter)
        {
            try
            {
                User user = _userDAL.Find((UserFilter)filter);
                UserModel userModel = _mapper.Map<UserModel>(user);
                return Result<UserModel>.BuildSuccess(userModel);
            }
            catch (Exception error)
            {
                return Result<UserModel>.BuildError("Erro ao localizar o usuário.", error);
            }
        }

        public override Result Register(UserModel userModel)
        {
            try
            {
                User user = _mapper.Map<User>(userModel);

                Result result = _userValidation.Validate(user);
                if (!result.Success)
                    return result;

                _userDAL.Insert(user);
                return _userDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro no momento de registrar o usuário.", error);
            }
        }

        public override Result Update(UserModel userModel)
        {
            try
            {
                User user = _mapper.Map<User>(userModel);
                _userDAL.Update(user);
                return _userDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao alterar o registro do usuário.", error);
            }
        }
    }
}
