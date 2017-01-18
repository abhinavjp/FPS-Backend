using FPS.Data;
using StructureMap.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using static FPS.Service.Infrastructure.StructureMapConfigurator;
using static FPS.Helper.ErrorHandler.ProcessResultHelper;
using FPS.Service.Interface;
using FPS.Service.Models;
using FPS.Helper.ErrorHandler;
using AutoMapper;
using RepositoryFoundation.Repository.Interface;

namespace FPS.Service.Services
{
    public class ResidentService : IResidentService
    {
        private readonly FPSDBDevEntities _context;
        private readonly ExplicitArguments args;
        public ResidentService()
        {
            _context = new FPSDBDevEntities();
            args = new ExplicitArguments();
            args.Set(_context);
        }

        public ProcessResult<List<ResidentServiceModel>> GetResident(ResidentFilterServiceModel residentFilters)
        {
            try
            {
                List<ResidentServiceModel> residentModels = null;
                using (var unitOfWork = GetInstance<IUnitOfWork<FPSDBDevEntities>>(args))
                {
                    var residentRepository = unitOfWork.GetRepository<Resident, int>((resident) => resident.Id);
                    var residents = residentRepository.GetAll();
                    if (residentFilters == null)
                    {
                        residentModels = Mapper.Map<List<ResidentServiceModel>>(residents.ToList());
                    }
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
                ResidentServiceModel residentModel;
                using (var unitOfWork = GetInstance<IUnitOfWork<FPSDBDevEntities>>(args))
                {
                    var residentRepository = unitOfWork.GetRepository<Resident, int>((resident) => resident.Id);
                    var residentItem = residentRepository.Find(id);
                    residentModel = Mapper.Map<ResidentServiceModel>(residentItem);
                }
                return residentModel.GetResult();
            }
            catch (Exception exception)
            {
                return ProcessResult<ResidentServiceModel>.GetExceptionResult(exception);
            }
        }

        public ProcessResult CreateResident(ResidentServiceModel residentModel)
        {
            try
            {

                using (var unitOfWork = GetInstance<IUnitOfWork<FPSDBDevEntities>>(args))
                {
                    var residentRepository = unitOfWork.GetRepository<Resident, int>((resident) => resident.Id);
                    residentRepository.InsertOrUpdate(Mapper.Map<Resident>(residentModel));
                    unitOfWork.Commit();
                }

                return ProcessResult.AllOk;
            }
            catch (Exception exception)
            {
                return ProcessResult.GetExceptionResult(exception);
            }
        }

        public ProcessResult UpdateResident(ResidentServiceModel residentModel)
        {
            try
            {
                using (var unitOfWork = GetInstance<IUnitOfWork<FPSDBDevEntities>>(args))
                {
                    var residentRepository = unitOfWork.GetRepository<Resident, int>((resident) => resident.Id);
                    residentRepository.InsertOrUpdate(Mapper.Map<Resident>(residentModel));
                    unitOfWork.Commit();
                }

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
                using (var unitOfWork = GetInstance<IUnitOfWork<FPSDBDevEntities>>(args))
                {
                    var apartmentRepository = unitOfWork.GetRepository<Apartment, int>((apartment) => apartment.Id);
                    if (apartmentRepository.HasData(a => a.ResidentId == id))
                    {
                        return GetNegativeResult("An apartment is linked to this resident.\nPlease unlink the selected resident with the apartment, then try deleting again", HttpStatusCode.PreconditionFailed);
                    }
                    var residentRepository = unitOfWork.GetRepository<Resident, int>((resident) => resident.Id);
                    var residentItem = residentRepository.Find(id);
                    residentItem.IsDeleted = true;
                    residentRepository.InsertOrUpdate(residentItem);
                    unitOfWork.Commit();
                }
                return ProcessResult.AllOk;
            }
            catch (Exception exception)
            {
                return ProcessResult.GetExceptionResult(exception);
            }
        }


    }
}
