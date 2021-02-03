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
    public class OccupationBLL : BaseBLL<OccupationModel>, IOccupationBLL
    {
        private readonly IMapper _mapper;
        private readonly IOccupationDAL _occupationDAL;
        private readonly OccupationValidation _occupationValidation;

        public OccupationBLL(IMapper mapper, IOccupationDAL occupationDAL, OccupationValidation occupationValidation)
        {
            _mapper = mapper;
            _occupationDAL = occupationDAL;
            _occupationValidation = occupationValidation;
        }

        public override Result Delete(OccupationModel model)
        {
            try
            {
                Occupation occupation = _mapper.Map<Occupation>(model);
                _occupationDAL.Delete(occupation);
                return _occupationDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao deletar o cargo profissional.", error);
            }
        }

        public override Result<OccupationModel> Find(IFilter filter)
        {
            try
            {
                Occupation occupation = _occupationDAL.Find((OccupationFilter)filter);
                OccupationModel occupationModel = _mapper.Map<OccupationModel>(occupation);
                return Result<OccupationModel>.BuildSuccess(occupationModel);
            }
            catch (Exception error)
            {
                return Result<OccupationModel>.BuildError("Erro ao localizar o cargo profissional.", error);
            }
        }

        public override Result Register(OccupationModel occupationModel)
        {
            try
            {
                Occupation occupation = _mapper.Map<Occupation>(occupationModel);

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

        public override Result Update(OccupationModel model)
        {
            try
            {
                Occupation occupation = _mapper.Map<Occupation>(model);
                _occupationDAL.Update(occupation);
                return _occupationDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao alterar o registro do cargo profissional.", error);
            }
        }
    }
}
