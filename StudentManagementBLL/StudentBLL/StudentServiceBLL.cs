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
        private readonly ApplicationDbContext Context;

        public StudentServiceBLL(ApplicationDbContext dbContext):base(dbContext)
        {
            this.Context = dbContext;
        }

        public ServiceResponse<IEnumerable<string>> StudentDDl(string str)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<string>>();
            List<Student> ddl = new List<Student>();
            List<string> fddl = new List<string>();
            ddl = Context.Students.Where(x => x.RegistrationNumber.Contains(str)).ToList();
            var x = 0;
            if (ddl.Count <= 0)
            {
                serviceResponse.Message = "no student with given registration no. exists!!";
                serviceResponse.Success = false;
            }
            if (ddl.Count >= 10)
            {
                x = 10;
            }
            else
            {
                x = ddl.Count;
            }
            for (int i = 0; i < x; i++)
            {
                fddl.Add(ddl[i].RegistrationNumber);
            }
            if (serviceResponse.Success)
            {
                serviceResponse.Data = fddl;
                serviceResponse.Message = " ddl load success";
            }
            return serviceResponse;
        }

        //POST:Add Student
        public override ServiceResponse<Student> Add(Student student)
        {
            var serviceResponse = new ServiceResponse<Student>();
            var studentContact = Context.Students.SingleOrDefault(a => a.ContactNumber == student.ContactNumber);

            

            var studentEmail = Context.Students.SingleOrDefault(a => a.Email == student.Email);
            if(studentEmail !=null)
            {
                serviceResponse.Message = "please enter unique email for student registration";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            if (studentContact != null)
            {
                serviceResponse.Message = "please enter unique contact no. for student registration";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            

            try
            {
                 //finding corresponding department for code
                 var adepartment = Context.Departments.Find(student.DepartmentId);
                
                
                var count = Context.Students.Count();
                count++;
                //adding registration number for new student
                if (count<10) student.RegistrationNumber = $"{adepartment.Code}-{student.Date.Date.Year}-00{count}";
                else if (count >= 10 && count<100) student.RegistrationNumber = $"{adepartment.Code}-{student.Date.Date.Year}-0{count}";
                else if(count>=100) student.RegistrationNumber = $"{adepartment.Code}-{student.Date.Date.Year}-{count}";

                if(Context.Students.SingleOrDefault(a => a.Name == student.RegistrationNumber)!=null)
                {
                    if (student.Id < 10) student.RegistrationNumber = $"{adepartment.Code}-{student.Date.Date.Year}-00{student.Id}";
                    else if (student.Id >= 10 && count < 100) student.RegistrationNumber = $"{adepartment.Code}-{student.Date.Date.Year}-0{student.Id}";
                    else if (student.Id >= 100) student.RegistrationNumber = $"{adepartment.Code}-{student.Date.Date.Year}-{student.Id}";
                }

                serviceResponse.Data = student;
                Context.Students.Add(student);
                Context.SaveChanges();
                 
                
                serviceResponse.Message = "Student created successfully in DB";
            }
            catch (Exception exception)
            {
                serviceResponse.Message = $"student already stored in database\n" +
                    $"Error Message: {exception.Message}";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

    }
}
