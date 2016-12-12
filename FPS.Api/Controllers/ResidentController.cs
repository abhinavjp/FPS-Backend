using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FPS.Service.Interface;
using FPS.Service.Models;
using static FPS.Service.Infrastructure.StructureMapConfigurator;

namespace FPS.Api.Controllers
{
    public class ResidentController : CoreController
    {
        private readonly IResidentService _residentService;
        public ResidentController()
        {
            _residentService = GetInstance<IResidentService>();
        }



        [ActionName("GetList")]
        [HttpGet]
        public HttpResponseMessage GetResidentList()
        {
            return GenerateResponse(_residentService.GetResident(null));
        }

        [ActionName("GetList")]
        [HttpPost]
        public HttpResponseMessage GetResidentList(ResidentFilterServiceModel residentFilter)
        {
            return GenerateResponse(_residentService.GetResident(residentFilter));
        }

        [ActionName("GetById")]
        [HttpGet]
        public HttpResponseMessage GetResidentById(int id)
        {
            return GenerateResponse(_residentService.GetResident(id));
        }

        [ActionName("Create")]
        [HttpPost]
        public HttpResponseMessage CreateResident(ResidentServiceModel resident)
        {
            return GenerateResponse(_residentService.CreateResident(resident));
        }

        [ActionName("Update")]
        [HttpPost]
        public HttpResponseMessage UpdateResident(ResidentServiceModel resident)
        {
            return GenerateResponse(_residentService.UpdateResident(resident));
        }

        [ActionName("Delete")]
        [HttpPost]
        public HttpResponseMessage DeleteResident(int id)
        {
            return GenerateResponse(_residentService.DeleteResident(id));
        }
    }
}
