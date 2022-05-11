using System.Collections.Generic;
using DeliveryCompanyData.Entities;
using DeliveryCompanyDataAccessEF.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryCompanyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ApplicationController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Application> GetAllPersons()
        {
            return _unitOfWork.Application.GetAll();
        }
    }
}
