using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeliveryCompanyData.Entities;
using DeliveryCompanyDataAccessEF.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryCompanyWebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ApplicationController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Retrieve the Application by their id.
        /// </summary>
        /// <param name="id">id of Application</param>
        /// <returns>Application</returns>
        /// <response code="200">Returns the Application</response>
        /// <response code="400">Application not found</response>
        // GET: api/Application/<id>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid? id)
        {
            if (id == null)
            {
                return BadRequest("Ошибка");
            }

            var application = await _unitOfWork.Application.Get(id);

            if (application == null) return BadRequest("Ошибка ввода");
            return Ok(application);
        }

        /// <summary>
        /// Creates a new Application.
        /// </summary>
        /// <param name="application"></param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        // POST: api/Application
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Application application)
        {
            if (Validation.Validation.CheckApplication(application))
            {
                await _unitOfWork.Application.Add(application);
                return Ok(application);
            }
            return BadRequest("Заявка не создана");
        }

        /// <summary>
        /// Edit an Application.
        /// </summary>
        /// <param name="application">Changable Application.</param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        // PUT: api/Application/<id>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Application application)
        {
            if (Validation.Validation.CheckApplication(application))
            {
                await _unitOfWork.Application.Update(application);
                return Ok(application);
            }
            return BadRequest("Заявка не обновлена");
        }

        /// <summary>
        /// Deletes a specific Application by their id.
        /// </summary>
        /// <param name="id">id of Application</param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        // DELETE: api/Application/<id>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await _unitOfWork.Application.Get(id);
            if (item != null)
            {
                await _unitOfWork.Application.Delete(id);
                return Ok("Удаление прошло успешно");
            }
            return BadRequest("Удаление не произошло");
        }
    }
}
