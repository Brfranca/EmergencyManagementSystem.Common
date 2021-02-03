using AutoMapper;
using EmergencyManagementSystem.Common.BLL.Validations;
using EmergencyManagementSystem.Common.Common.Filters;
using EmergencyManagementSystem.Common.Common.Interfaces.BLL;
using EmergencyManagementSystem.Common.Common.Interfaces.DAL;
using EmergencyManagementSystem.Common.Common.Models;
using EmergencyManagementSystem.Common.Entities.Entities;
using System;

namespace EmergencyManagementSystem.Common.BLL.BLL
{
    public class RequesterBLL : BaseBLL<RequesterModel>, IRequesterBLL
    {
        private readonly IMapper _mapper;
        private readonly IRequesterDAL _requesterDAL;
        private readonly RequesterValidation _requesterValidation;
        public RequesterBLL(IMapper mapper, IRequesterDAL requesterDAL, RequesterValidation requesterValidation)
        {
            _mapper = mapper;
            _requesterDAL = requesterDAL;
            _requesterValidation = requesterValidation;
        }

        public override Result Delete(RequesterModel model)
        {
            try
            {
                Requester requester = _mapper.Map<Requester>(model);
                _requesterDAL.Delete(requester);
                return _requesterDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao deletar o registro do solicitante.", error);
            }
        }

        public override Result<RequesterModel> Find(IFilter filter)
        {
            try
            {
                Requester requester = _requesterDAL.Find((RequesterFilter)filter);
                RequesterModel requesterModel = _mapper.Map<RequesterModel>(requester);
                return Result<RequesterModel>.BuildSuccess(requesterModel);
            }
            catch (Exception error)
            {
                return Result<RequesterModel>.BuildError("Erro ao localizar o solicitante.", error);
            }
        }

        public override Result Register(RequesterModel model)
        {
            try
            {
                Requester requester = _mapper.Map<Requester>(model);

                Result result = _requesterValidation.Validate(requester);
                if (!result.Success)
                    return result;

                _requesterDAL.Insert(requester);
                return _requesterDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro no momento de registrar o solicitante.", error);
            }
        }

        public override Result Update(RequesterModel model)
        {
            try
            {
                Requester requester = _mapper.Map<Requester>(model);
                _requesterDAL.Update(requester);
                return _requesterDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao alterar o registro do solicitante.", error);
            }
        }
    }
}
