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
    public class AddressBLL : BaseBLL<AddressModel>, IAddressBLL
    {
        private readonly IMapper _mapper;
        private readonly IAddressDAL _addressDAL;
        private readonly AddressValidation _addressValidation;

        public AddressBLL(IAddressDAL addressDAL, AddressValidation addressValidation, IMapper mapper)
        {
            _addressDAL = addressDAL;
            _addressValidation = addressValidation;
            _mapper = mapper;
        }

        public override Result Delete(AddressModel model)
        {
            return Result.BuildSucess();
        }

        public override Result<AddressModel> Find(params object[] Id)
        {
            return Result<AddressModel>.BuildSucess(null);
        }

        public override Result Register(AddressModel addressModel)
        {
            try
            {
                var address = _mapper.Map<Address>(addressModel);

                var result = _addressValidation.Validate(address);
                if (!result.Success)
                    return result;

                _addressDAL.Insert(address);
                return _addressDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro no momento de registar o endereço.", error);
            }
        }

        public override Result Update(AddressModel model)
        {
            return Result.BuildSucess();
        }
    }
}
