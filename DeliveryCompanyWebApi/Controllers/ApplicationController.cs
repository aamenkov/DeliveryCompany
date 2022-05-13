using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeliveryCompanyData.Entities;
using DeliveryCompanyDataAccessEF.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DeliveryCompanyWebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ApplicationController> _logger;
        public ApplicationController(IUnitOfWork unitOfWork, ILogger<ApplicationController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// Retrieve the Application list.
        /// </summary>
        /// <returns>Department list</returns>
        /// <response code="200">Returns the Application list</response>
        /// <response code="400">Application list not found</response>
        // GET api/Application
        [HttpGet("")]
        public async Task<ActionResult> GetApplications()
        {
            try
            {
                var applicationList = await _unitOfWork.Application.GetAll();
                if (applicationList == null) return BadRequest("Ошибка ввода. Не найдены заявки.");
                return Ok(applicationList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }

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
            try
            {
                if (id == null)
                {
                    return BadRequest("Ошибка");
                }

                var application = await _unitOfWork.Application.Get(id);

                if (application == null) return BadRequest("Ошибка ввода");
                return Ok(application);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }

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
            try
            {
                if (Validation.Validation.CheckApplication(application))
                {
                    await _unitOfWork.Application.Add(application);
                    return Ok(application);
                }
                return BadRequest("Заявка не создана");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
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
            try
            {
                var applicationOld = await _unitOfWork.Application.Get(application.ApplicationId);
                if (applicationOld == null) return BadRequest("Ошибка ввода");

                if (Validation.Validation.CheckApplication(application) && (applicationOld.Status.Equals("Новая")))
                {
                    await _unitOfWork.Application.Update(application);
                    return Ok(application);
                }
                return BadRequest("Заявка не обновлена");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Edit a status of Application.
        /// </summary>
        /// <param name="id">ID of Changable Application.</param>
        /// <param name="idOfApplicationStatus">id of Application Status.</param>
        /// <param name="Comment">Comment to Application.</param>
        /// <remarks>
        /// idOfApplicationStatus:
        /// '1' - "Новая",
        /// '2' - "Передано на выполнение",
        /// '3' - "Выполнена",
        /// '4' - "Отменена".
        /// </remarks>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        // POST: api/Application/<id>/<idOfApplicationStatus>
        [HttpPost("{id}/{idOfApplicationStatus}")]
        public async Task<IActionResult> ChangeStatus(Guid id, int idOfApplicationStatus, string Comment)
        {
            string[] expectedStatusInput = { "Новая", "Передано на выполнение", "Выполнена", "Отменена" };
            try
            {
                Application applicationOld = await _unitOfWork.Application.Get(id);
                if (applicationOld == null) return BadRequest("Ошибка ввода");

                if (idOfApplicationStatus <= 4)
                {
                    applicationOld.Status = expectedStatusInput[idOfApplicationStatus-1];
                    applicationOld.Message = Comment;
                    await _unitOfWork.Application.Update(applicationOld);
                    return Ok(applicationOld);
                }
                return BadRequest("Cтатус не был обновлен");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
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
            try
            {
                var item = await _unitOfWork.Application.Get(id);
                if (item != null)
                {
                    await _unitOfWork.Application.Delete(id);
                    return Ok("Удаление прошло успешно");
                }
                return BadRequest("Удаление не произошло");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }
    }
}
