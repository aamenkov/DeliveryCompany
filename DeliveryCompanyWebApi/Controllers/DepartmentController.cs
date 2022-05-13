using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Tasks;
using DeliveryCompanyData.Entities;
using DeliveryCompanyDataAccessEF.Interface;
using DeliveryCompanyWebApi.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DeliveryCompanyWebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DepartmentController> _logger;
        public DepartmentController(IUnitOfWork unitOfWork, ILogger<DepartmentController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// Retrieve the Application list by their DepartmentId.
        /// </summary>
        /// <returns>Application list</returns>
        /// <response code="200">Returns the Application list</response>
        /// <response code="400">Application list not found</response>
        // GET api/Department/Applications
        [HttpGet("Applications")]
        public async Task<ActionResult> GetApplications(int id)
        {
            try
            {
                var departmentList = await _unitOfWork.Department.GetApplications(id);

                if (departmentList.Count == 0) return BadRequest("Ошибка. Заявок для данного отделениия не существует.");
                return Ok(departmentList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Retrieve the Department list.
        /// </summary>
        /// <returns>Department list</returns>
        /// <response code="200">Returns the Department list</response>
        /// <response code="400">Department list not found</response>
        // GET api/Department
        [HttpGet("")]
        public async Task<ActionResult> GetDepartments()
        {
            try
            {
                var departmentList = await _unitOfWork.Department.GetAll();

                if (departmentList == null) return BadRequest("Ошибка ввода. Не найдены отделения.");
                return Ok(departmentList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Retrieve the Department by their id.
        /// </summary>
        /// <param name="id">id of Department</param>
        /// <returns>ATM</returns>
        /// <response code="200">Returns the Department</response>
        /// <response code="400">Department not found</response>
        // GET api/Department/<id>
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var department = await _unitOfWork.Department.Get(id);

                if (department == null) return BadRequest("Ошибка ввода. Не найдено отделение.");
                return Ok(department);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }


        /// <summary>
        /// Creates a new Department.
        /// </summary>
        /// <param name="department">new Department</param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        // POST api/Department
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Department department)
        {
            if (ApplicationValidation.CheckList(department.ApplicationList))
            {
                await _unitOfWork.Department.Add(department);
                return Ok(department);
            }

            return BadRequest("Отделение не создан");
        }

        /// <summary>
        /// Edit a Department.
        /// </summary>
        /// <param name="department">Changable Department.</param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        // PUT api/Department/<id>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Department department)
        {
            try
            {
                if (ApplicationValidation.CheckList(department.ApplicationList))
                {
                    await _unitOfWork.Department.Update(department);
                    return Ok(department);
                }
                return BadRequest("Отделение не обновлено");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Deletes a specific Department by their id.
        /// </summary>
        /// <param name="id">id of Department</param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        // DELETE api/Department/<id>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await _unitOfWork.Department.Get(id);
                if (item != null)
                {
                    await _unitOfWork.Department.Delete(id);
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

