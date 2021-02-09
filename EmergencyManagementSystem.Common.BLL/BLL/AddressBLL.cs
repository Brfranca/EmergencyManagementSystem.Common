using AutoMapper;
using EmergencyManagementSystem.Common.BLL.Validations;
using EmergencyManagementSystem.Common.Common.Filters;
using EmergencyManagementSystem.Common.Common.Interfaces;
using EmergencyManagementSystem.Common.Common.Interfaces.BLL;
using EmergencyManagementSystem.Common.Common.Models;
using EmergencyManagementSystem.Common.Entities.Entities;
using System;
using System.Linq;

namespace EmergencyManagementSystem.Common.BLL.BLL
{
    public class AddressBLL : BaseBLL<AddressModel, Address>, IAddressBLL
    {
        private readonly IMapper _mapper;
        private readonly IAddressDAL _addressDAL;
        private readonly AddressValidation _addressValidation;

        public AddressBLL(IAddressDAL addressDAL, AddressValidation addressValidation, IMapper mapper)
            : base(addressDAL)
        {
            _addressDAL = addressDAL;
            _addressValidation = addressValidation;
            _mapper = mapper;
        }

        public override IQueryable<AddressModel> ApplyFilterPagination(IQueryable<Address> query, IFilter filter)
        {
            throw new NotImplementedException();
        }

        public override Result Delete(AddressModel model)
        {
            try
            {
                Address address = _mapper.Map<Address>(model);
                _addressDAL.Delete(address);
                return _addressDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao deletar o registro do endereço.", error);
            }
        }

        public override Result<AddressModel> Find(IFilter filter)
        {
            try
            {
                Address address = _addressDAL.Find((AddressFilter)filter);
                AddressModel addressModel = _mapper.Map<AddressModel>(address);
                return Result<AddressModel>.BuildSuccess(addressModel);
            }
            catch (Exception error)
            {
                return Result<AddressModel>.BuildError("Erro ao localizar o endereço.", error);
            }
        }

        public override Result<Address> Register(AddressModel addressModel)
        {
            try
            {
                Address address = _mapper.Map<Address>(addressModel);

                var result = _addressValidation.Validate(address);
                if (!result.Success)
                    return result;

                _addressDAL.Insert(address);

                var resultSave = _addressDAL.Save();
                if (!resultSave.Success)
                    return Result<Address>.BuildError(resultSave.Messages);

                return Result<Address>.BuildSuccess(address);
            }
            catch (Exception error)
            {
                return Result<Address>.BuildError("Erro no momento de registar o endereço.", error);
            }
        }

        public override Result Update(AddressModel model)
        {
            try
            {
                Address address = _mapper.Map<Address>(model);

                var result = _addressValidation.Validate(address);
                if (!result.Success)
                    return result;

                _addressDAL.Insert(address);

                var resultSave = _addressDAL.Save();
                if (!resultSave.Success)
                    return Result<Address>.BuildError(resultSave.Messages);

                return Result<Address>.BuildSuccess(address);
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao alterar o registro do endereço.", error);
            }
        }
    }
}
