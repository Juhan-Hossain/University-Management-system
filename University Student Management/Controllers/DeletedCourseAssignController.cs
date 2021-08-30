﻿using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using StudentManagementBLL.DeletedCourseAssignServiceBLL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace University_Student_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeletedCourseAssignController:ControllerBase
    {
        private readonly IDeletedCourseAssignBLL _service;
        public DeletedCourseAssignController(IDeletedCourseAssignBLL service)
        {
            _service = service;

        }

        [HttpDelete("UnAssaignAllCourses")]

        public ActionResult<ServiceResponse<DeletedCourseAssign>> UnAssaignAllCourses()
        {

            var response = _service.UnassignTeacher();
            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }




    }
}
