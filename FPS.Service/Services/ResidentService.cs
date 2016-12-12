using FPS.Data;
using FPS.Service.Repository.Interface;
using StructureMap.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using static FPS.Service.Infrastructure.StructureMapConfigurator;
using static FPS.Helper.ErrorHandler.ProcessResultHelper;
using FPS.Service.Interface;
using FPS.Service.Models;
using FPS.Helper.ErrorHandler;
using AutoMapper;

namespace FPS.Service.Services
{
    public class ResidentService: IResidentService
    {
        private readonly FPSDBDevEntities _context;
        private readonly IGenericRepository<Resident, FPSDBDevEntities> _residentRepository;
        private readonly IGenericRepository<Apartment, FPSDBDevEntities> _apartmentRepository;
        private readonly IUnitOfWork<FPSDBDevEntities> _unitOfWork;
        public ResidentService()
        {
            _context = new FPSDBDevEntities();
            var args = new ExplicitArguments();
            args.Set(_context);
            _unitOfWork = GetInstance<IUnitOfWork<FPSDBDevEntities>>(args);
            _residentRepository = _unitOfWork.GetRepository<Resident, FPSDBDevEntities>();
            _apartmentRepository = _unitOfWork.GetRepository<Apartment, FPSDBDevEntities>();
        }

        public ProcessResult<List<ResidentServiceModel>> GetResident(ResidentFilterServiceModel residentFilters)
        {
            try
            {
                var residents = _residentRepository.All;
                List<ResidentServiceModel> residentModels = null;
                if(residentFilters == null)
                {
                    residentModels = Mapper.Map<List<ResidentServiceModel>>(residents.ToList());
                }

                return residentModels.GetResult();
            }
            catch (Exception exception)
            {
                return ProcessResult<List<ResidentServiceModel>>.GetExceptionResult(exception);
            }
        }

        public ProcessResult<ResidentServiceModel> GetResident(int id)
        {
            try
            {
                var resident = _residentRepository.Find(id);
                var residentModel = Mapper.Map<ResidentServiceModel>(resident);

                return residentModel.GetResult();
            }
            catch (Exception exception)
            {
                return ProcessResult<ResidentServiceModel>.GetExceptionResult(exception);
            }
        }

        public ProcessResult CreateResident(ResidentServiceModel resident)
        {
            try
            {
                _residentRepository.Insert(Mapper.Map<Resident>(resident));
                _unitOfWork.Commit();

                return ProcessResult.AllOk;
            }
            catch (Exception exception)
            {
                return ProcessResult.GetExceptionResult(exception);
            }
        }

        public ProcessResult UpdateResident(ResidentServiceModel resident)
        {
            try
            {
                _residentRepository.Update(Mapper.Map<Resident>(resident));
                _unitOfWork.Commit();

                return ProcessResult.AllOk;
            }
            catch (Exception exception)
            {
                return ProcessResult.GetExceptionResult(exception);
            }
        }

        public ProcessResult DeleteResident(int id)
        {
            try
            {
                if(_apartmentRepository.All.Where(a => a.ResidentId == id).Any())
                {
                    return GetNegativeResult("An apartment is linked to this resident.\nPlease unlink the selected resident with the apartment, then try deleting again", HttpStatusCode.PreconditionFailed);
                }

                var resident = _residentRepository.Find(id);
                resident.IsDeleted = true;
                _residentRepository.Update(resident);
                _unitOfWork.Commit();

                return ProcessResult.AllOk;
            }
            catch (Exception exception)
            {
                return ProcessResult.GetExceptionResult(exception);
            }
        }


    }
}
