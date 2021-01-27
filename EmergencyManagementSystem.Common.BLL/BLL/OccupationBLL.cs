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
    public class OccupationBLL
    {
        private readonly IMapper _mapper;
        private readonly OccupationDAL _occupationDAL;
        private readonly OccupationValidation _occupationValidation;

        public OccupationBLL(IMapper mapper, OccupationDAL occupationDAL, OccupationValidation occupationValidation)
        {
            _mapper = mapper;
            _occupationDAL = occupationDAL;
            _occupationValidation = occupationValidation;
        }

        public Result Register(OccupationModel occupationModel)
        {
            try
            {
                var occupation = _mapper.Map<Occupation>(occupationModel);

                var result = _occupationValidation.Validate(occupation);
                if (!result.Success)
                    return result;

                _occupationDAL.Insert(occupation);
                return _occupationDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro no momento de registar o cargo profissional.", error);
            }
        }
    }
}
