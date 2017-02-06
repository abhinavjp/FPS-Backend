using FPS.Service.Models;
using HelperFoundation.ErrorHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPS.Service.Interface
{
    public interface IResidentService
    {
        ProcessResult<List<ResidentServiceModel>> GetResident(ResidentFilterServiceModel residentFilters);
        ProcessResult<ResidentServiceModel> GetResident(int id);
        ProcessResult CreateResident(ResidentServiceModel resident);
        ProcessResult UpdateResident(ResidentServiceModel resident);
        ProcessResult DeleteResident(int id);

    }
}
