﻿using RepositoryLayer;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.StudentResultBLL
{
    public class StudentResultBLL : Repository<StudentResult, ApplicationDbContext>, IStudentResultBLL
    {
        public StudentResultBLL(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public override ServiceResponse<StudentResult> Add(StudentResult studentResult)
        {
            var serviceresponse = new ServiceResponse<StudentResult>();
            try
            {
                var aStudentRegNo = _dbContext.Students.SingleOrDefault(x => x.RegistrationNumber == studentResult.StudentRegNo).ToString();
                var aCourseId = _dbContext.Courses.SingleOrDefault(x => x.Name == studentResult.CourseName).Id;
                var astudentName = _dbContext.Students
                        .SingleOrDefault(x => x.RegistrationNumber == studentResult.StudentRegNo)
                        .Name;
                var acourseName = _dbContext.Courses
                    .SingleOrDefault(x => x.Name == studentResult.CourseName)
                    .Name;
                var acourseCode = _dbContext.Courses
                    .SingleOrDefault(x => x.Name == studentResult.CourseName).Code;
                var aDepartmentId = _dbContext.Students
                        .SingleOrDefault(x => x.RegistrationNumber == studentResult.StudentRegNo)
                        .DepartmentId;
                var aDepartmentName = _dbContext.Departments.SingleOrDefault(x => x.Id == aDepartmentId).Name;
                StudentResult aResult = new StudentResult();
                var astudentEmail = _dbContext.Students
                        .SingleOrDefault(x => x.RegistrationNumber == studentResult.StudentRegNo)
                        .Email;


                serviceresponse.Data = _dbContext.StudentResults.SingleOrDefault(x =>
                x.CourseName == studentResult.CourseName
                && x.StudentRegNo == studentResult.StudentRegNo);

                if (studentResult.CourseName is null)
                {
                    serviceresponse.Message = "this Course does not exist.";
                    serviceresponse.Success = false;
                }
                else if (studentResult.StudentRegNo is null)
                {
                    serviceresponse.Message = "this aStudentRegNo does not exist.";
                    serviceresponse.Success = false;
                }

                else if (serviceresponse.Data == null)
                {
                    if (!serviceresponse.Success)
                    {
                        serviceresponse.Message = "Course is already assigned.";
                        serviceresponse.Success = false;
                    }
                    else
                    {
                        aResult.StudentRegNo = studentResult.StudentRegNo;

                        aResult.Name = astudentName;
                        aResult.CourseName = studentResult.CourseName;
                        aResult.Email = astudentEmail;
                        aResult.DepartmentName = aDepartmentName;
                        aResult.GradeLetter = studentResult.GradeLetter;
                        aResult.Result = true;





                        _dbContext.StudentResults.Add(aResult);
                        _dbContext.SaveChanges();
                        serviceresponse.Data = aResult;
                        serviceresponse.Success = true;

                        serviceresponse.Message = $"{astudentName} will start taking {acourseName}";
                    }
                }
                else if (serviceresponse.Data.Result)
                {
                    serviceresponse.Message = "Course is already Enrolled";
                    serviceresponse.Success = false;
                }
                else
                {

                    aResult.StudentRegNo = studentResult.StudentRegNo;

                    aResult.Name = astudentName;
                    aResult.CourseName = studentResult.CourseName;
                    aResult.Email = astudentEmail;
                    aResult.DepartmentName = aDepartmentName;
                    aResult.GradeLetter = studentResult.GradeLetter;
                    aResult.Result = true;


                    _dbContext.StudentResults.Update(aResult);
                    _dbContext.SaveChanges();
                    serviceresponse.Data = aResult;
                    serviceresponse.Message = "Course Enrollment Updated";
                }

            }
            catch (Exception ex)
            {
                serviceresponse.Message = "Error occured when fetching data from course enroll table" +
                    ex.Message;
                serviceresponse.Success = false;
            }
            return serviceresponse;
        }

    }
}
