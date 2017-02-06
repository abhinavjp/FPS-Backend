using FPS.Data;
using RepositoryFoundation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPS.Service
{
    public static class RepositoryGetterHelper
    {
        public static IGenericRepository<FPSDBDevEntities, Resident, int> GetResidentRepository(this IUnitOfWork<FPSDBDevEntities> unitOfWork)
        {
            return unitOfWork.GetRepository<Resident, int>((resident) => resident.Id);
        }
        public static IGenericRepository<FPSDBDevEntities, Apartment, int> GetApartmentRepository(this IUnitOfWork<FPSDBDevEntities> unitOfWork)
        {
            return unitOfWork.GetRepository<Apartment, int>((apartment) => apartment.Id);
        }
    }
}
