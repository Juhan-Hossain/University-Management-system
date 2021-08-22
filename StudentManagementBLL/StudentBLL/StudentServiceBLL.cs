﻿using RepositoryLayer;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.StudentBLL
{
    public class StudentServiceBLL : Repository<Student,ApplicationDbContext>,IStudentServiceBLL
    {
        public StudentServiceBLL(ApplicationDbContext dbContext):base(dbContext)
        {

        }

        /*//GET:GetAllStudentRegNo:
        public ServiceResponse<IEnumerable<Student>> GetAllStudentRegNo()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Student>>();
            try
            {

                *//*var aDepartment = _dbContext.Departments.ToList();
                var aCourse=_dbContext.Courses
                var  = _dbContext.Students.Select(x=>x.DepartmentId);*//*
                serviceResponse.Message = "Student Reg No loaded in ServiceResponse.Data Successfully";
            }
            catch (Exception exception)
            {

                serviceResponse.Message = "Error occurred while loading Student Reg No." +
                    "\nError message: " + exception.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;

        }*/



        public override ServiceResponse<Student> Add(Student student)
        {
            var serviceResponse = new ServiceResponse<Student>();

            try
            {
               

                 //finding corresponding department for code
                 var adepartment = _dbContext.Departments.Find(student.DepartmentId);
                
                
                var count = _dbContext.Students.Count();
                count++;
                //adding registration number for new student
                if (count<10) student.RegistrationNumber = $"{adepartment.Code}-{student.Date.Date.Year}-00{count}";
                else if (count >= 10 && count<100) student.RegistrationNumber = $"{adepartment.Code}-{student.Date.Date.Year}-0{count}";
                else if(count>=100) student.RegistrationNumber = $"{adepartment.Code}-{student.Date.Date.Year}-{count}";


                serviceResponse.Data = student;
                _dbContext.Students.Add(student);
                _dbContext.SaveChanges();
                 
                
                serviceResponse.Message = "Student created successfully in DB";
            }
            catch (Exception exception)
            {
                serviceResponse.Message = $"Storing student failed in the database for given student\n" +
                    $"Error Message: {exception.Message}";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

       


    }
}
