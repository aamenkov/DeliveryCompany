using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Tasks;
using DeliveryCompanyData.Entities;
using DeliveryCompanyDataAccessEF.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        /// <summary>
        /// Retrieve the Department by their id.
        /// </summary>
        /// <param name="id">id of Department</param>
        /// <returns>ATM</returns>
        /// <response code="200">Returns the Department</response>
        /// <response code="204">Department not found</response>
        // GET api/Department/<id>
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid? id)
        {
            if (id == null)
            {
                return BadRequest("Ошибка ввода.");
            }

            var department = await _unitOfWork.Department.Get(id);

            if (department == null) return BadRequest("Ошибка ввода. Не найдено отделение.");
            return Ok(department);
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
            if (Validation.Validation.CheckApplicationList(department.ApplicationList))
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
        // PUT api/ATM/<id>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Department department)
        {
            if (Validation.Validation.CheckApplicationList(department.ApplicationList))
            {
                await _unitOfWork.Department.Update(department);
                return Ok(department);
            }
            return BadRequest("Отделение не обновлено");
        }

        /// <summary>
        /// Deletes a specific Department by their id.
        /// </summary>
        /// <param name="id">id of Department</param>
        // DELETE api/Department/<id>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await _unitOfWork.Department.Get(id);
            if (item != null)
            {
                await _unitOfWork.Department.Delete(id);
                return Ok("Удаление прошло успешно");
            }
            return BadRequest("Удаление не произошло");
        }
    }
}

