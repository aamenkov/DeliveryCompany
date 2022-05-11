using DeliveryCompanyDataAccessEF.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryCompanyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


    }
}
