using AutoMapper;
using EmergencyManagementSystem.Common.BLL.Validations;
using EmergencyManagementSystem.Common.Common.Filters;
using EmergencyManagementSystem.Common.Common.Interfaces.BLL;
using EmergencyManagementSystem.Common.Common.Interfaces.DAL;
using EmergencyManagementSystem.Common.Common.Models;
using EmergencyManagementSystem.Common.Entities.Entities;
using System;
using System.Linq;

namespace EmergencyManagementSystem.Common.BLL.BLL
{
    public class RequesterBLL : BaseBLL<RequesterModel, Requester>, IRequesterBLL
    {
        private readonly IMapper _mapper;
        private readonly IRequesterDAL _requesterDAL;
        private readonly RequesterValidation _requesterValidation;
        public RequesterBLL(IMapper mapper, IRequesterDAL requesterDAL,
            RequesterValidation requesterValidation) : base(requesterDAL)
        {
            _mapper = mapper;
            _requesterDAL = requesterDAL;
            _requesterValidation = requesterValidation;
        }

        public override IQueryable<RequesterModel> ApplyFilterPagination(IQueryable<Requester> query, IFilter filter)
        {
            throw new NotImplementedException();
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

        public override Result<Requester> Register(RequesterModel model)
        {
            try
            {
                Requester requester = _mapper.Map<Requester>(model);
                var result = _requesterValidation.Validate(requester);
                if (!result.Success)
                    return result;

                _requesterDAL.Insert(requester);
                var resultSave = _requesterDAL.Save();
                if (!resultSave.Success)
                    return Result<Requester>.BuildError(resultSave.Messages);

                return Result<Requester>.BuildSuccess(requester);
            }
            catch (Exception error)
            {
                return Result<Requester>.BuildError("Erro no momento de registrar o solicitante.", error);
            }
        }

        public override Result Update(RequesterModel model)
        {
            try
            {
                Requester requester = _mapper.Map<Requester>(model);

                Result result = _requesterValidation.Validate(requester);
                if (!result.Success)
                    return result;

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
