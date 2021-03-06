﻿using AutoMapper;
using EmergencyManagementSystem.Common.BLL.Validations;
using EmergencyManagementSystem.Common.Common.Filters;
using EmergencyManagementSystem.Common.Common.Interfaces;
using EmergencyManagementSystem.Common.Common.Interfaces.BLL;
using EmergencyManagementSystem.Common.Common.Models;
using EmergencyManagementSystem.Common.Common.Utils;
using EmergencyManagementSystem.Common.Entities.Entities;
using System;
using System.Linq;

namespace EmergencyManagementSystem.Common.BLL.BLL
{
    public class UserBLL : BaseBLL<UserModel, User>, IUserBLL
    {
        private readonly IMapper _mapper;
        private readonly IUserDAL _userDAL;
        private readonly UserValidation _userValidation;
        public UserBLL(IUserDAL userDAL, UserValidation userValidation, IMapper mapper) 
            : base(userDAL)
        {
            _userDAL = userDAL;
            _userValidation = userValidation;
            _mapper = mapper;
        }

        public override IQueryable<UserModel> ApplyFilterPagination(IQueryable<User> query, IFilter filer)
        {
            throw new NotImplementedException();
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
                if (user == null)
                    return Result<UserModel>.BuildError("Usuário não encontrado");

                UserModel userModel = _mapper.Map<UserModel>(user);
                return Result<UserModel>.BuildSuccess(userModel);
            }
            catch (Exception error)
            {
                return Result<UserModel>.BuildError("Erro ao localizar o usuário.", error);
            }
        }

        public override Result<User> Register(UserModel userModel)
        {
            try
            {
                User user = _mapper.Map<User>(userModel);
                var result = _userValidation.Validate(user);
                user.Password = Hash.Create(userModel.Password);

                if (!result.Success)
                    return result;

                _userDAL.Insert(user);
                var resultSave = _userDAL.Save();
                if (!resultSave.Success)
                    return Result<User>.BuildError(resultSave.Messages);

                return Result<User>.BuildSuccess(user);
            }
            catch (Exception error)
            {
                return Result<User>.BuildError("Erro no momento de registrar o usuário.", error);
            }
        }

        public override Result<User> Update(UserModel userModel)
        {
            try
            {
                User user = _mapper.Map<User>(userModel);

                var result = _userValidation.Validate(user);
                user.Password = Hash.Create(userModel.Password);
                if (!result.Success)
                    return result;

                _userDAL.Update(user);
                var resultSave = _userDAL.Save();
                if (!resultSave.Success)
                    return Result<User>.BuildError(resultSave.Messages);

                return Result<User>.BuildSuccess(user);
            }
            catch (Exception error)
            {
                return Result<User>.BuildError("Erro ao alterar o registro do usuário.", error);
            }
        }
    }
}
