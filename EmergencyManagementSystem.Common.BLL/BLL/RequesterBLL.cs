﻿using AutoMapper;
using EmergencyManagementSystem.Common.BLL.Validations;
using EmergencyManagementSystem.Common.Common.Filters;
using EmergencyManagementSystem.Common.Common.Interfaces;
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
        private readonly IAddressBLL _addressBLL;
        public RequesterBLL(IMapper mapper, IRequesterDAL requesterDAL,
            RequesterValidation requesterValidation, IAddressBLL addressBLL) : base(requesterDAL)
        {
            _mapper = mapper;
            _requesterDAL = requesterDAL;
            _requesterValidation = requesterValidation;
            _addressBLL = addressBLL;
        }

        //exemplo de query e aplicacao de filtro e converversao de modelo.
        public override IQueryable<RequesterModel> ApplyFilterPagination(IQueryable<Requester> query, IFilter filter)
        {
            var filtro = (RequesterFilter)filter;
            if (!string.IsNullOrWhiteSpace(filtro.Telephone))
                query = query.Where(d => d.Telephone == filtro.Telephone);

            return query.Select(d => _mapper.Map<RequesterModel>(d));
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
                requester.Guid = Guid.NewGuid();

                var resultAdress = _addressBLL.Register(model.AddressModel);
                if (!resultAdress.Success)
                    return Result<Requester>.BuildError(resultAdress.Messages);

                requester.Address = resultAdress.Model;

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

        public override Result<Requester> Update(RequesterModel model)
        {
            try
            {
                if (model.AddressId > 0)
                    model.AddressModel.Id = model.AddressId;

                Requester requester = _mapper.Map<Requester>(model);
                var resultAddress = _addressBLL.Update(model.AddressModel);
                if (!resultAddress.Success)
                    return Result<Requester>.BuildError(resultAddress.Messages);

                requester.Address = resultAddress.Model;

                var result = _requesterValidation.Validate(requester);
                if (!result.Success)
                    return result;

                _requesterDAL.Update(requester);
                var resultSave = _requesterDAL.Save();
                if (!resultSave.Success)
                    return Result<Requester>.BuildError(resultSave.Messages);

                return Result<Requester>.BuildSuccess(requester);
            }
            catch (Exception error)
            {
                return Result<Requester>.BuildError("Erro ao alterar o registro do solicitante.", error);
            }
        }
    }
}
