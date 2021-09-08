using Microsoft.EntityFrameworkCore;
using RepositoryLayer;

using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.CourseBLL
{
    public class CourseServiceBLL : Repository<Course, ApplicationDbContext>, ICourseServiceBLL
    {
        private readonly ApplicationDbContext Context;

        public CourseServiceBLL(ApplicationDbContext dbContext):base(dbContext)
        {
            this.Context = dbContext;
        }





        //POST:Course
        public override ServiceResponse<Course> Add(Course course)
        {
            var serviceResponse = new ServiceResponse<Course>();

            try
            {
                serviceResponse.Data = course;
                Context.Courses.Add(serviceResponse.Data);
                Context.SaveChanges();
                serviceResponse.Message = "Course created successfully in DB";
            }
            catch (Exception exception)
            {
                serviceResponse.Message = $"{course.Code}/{course.Name} already stored in the Db\n" +
                    $"Error Message: {exception.Message}";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }



        


        //GetCoursesByDept:
        public ServiceResponse<IEnumerable<Course>> GetCourseByDepartment(int departmentId,string courseCode)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Course>>();
            try
            {
                serviceResponse.Data = Context.Courses
                    .Include(x => x.Department)
                    .Where(x => x.DepartmentId == departmentId).ToList();

                serviceResponse.Message = "Data  with the given id was fetched successfully from the database";
            }
            catch (Exception exception)
            {

                serviceResponse.Message = "Some error occurred while fetching data.\nError message: " + exception.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }


        //ViewCourseByDept:
        public ServiceResponse<IEnumerable<Course>> ViewCoursesByDept(int departmentId)
        {


            var serviceResponse = new ServiceResponse<IEnumerable<Course>>();
            try
            {
                var courses = Context.Courses.Where(x => x.DepartmentId == departmentId).Include(x => x.RoomAllocationLists).ToList();
                serviceResponse.Data = courses;
                if (courses.Count() > 0)
                {
                    serviceResponse.Message = "Data  with the given id was fetched successfully from the database";
                }
                else
                {
                    serviceResponse.Message = "This dept does not have any data!";
                    serviceResponse.Success = false;
                }
            }
            catch (Exception exception)
            {

                serviceResponse.Message = "Some error occurred while fetching data.\nError message: " + exception.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }


        //ViewCourseByDept:
        public ServiceResponse<IEnumerable<Course>> AssignedCoursesByDepartment(int departmentId)
        {


            var serviceResponse = new ServiceResponse<IEnumerable<Course>>();
            try
            {
                List<Course> data = new List<Course>();
                DbSet<Course> courses = Context.Courses;
                foreach (Course course in courses)
                {
                    if (course.DepartmentId == departmentId)
                    {
                        /*if (course.AssignTo != null)
                        {
                            data.Add(course);
                        }*/
                        if (course.AssignTo == null)
                        {
                            course.AssignTo = "Not Assigned Yet!";
                        }
                        
                        data.Add(course);
                    }
                }

                serviceResponse.Data = data;


                if (data.Count() > 0)
                {
                    serviceResponse.Message = "Data  with the given id was fetched successfully from the database";
                }
                else
                {
                    serviceResponse.Message = "This dept does not have any data!";
                    serviceResponse.Success = false;
                }


            }
            catch (Exception exception)
            {

                serviceResponse.Message = "Some error occurred while fetching data.\nError message: " + exception.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        //GetCourseByStdRegNo
        public ServiceResponse<IEnumerable<Course>> ViewCourseBystdRegNo(string stdRegNo)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Course>>();
            try
            {
                Student aStudent;
                 aStudent = Context.Students
                   .SingleOrDefault(x => x.RegistrationNumber == stdRegNo);
                if(aStudent != null)
                {
                    var tempcourses = Context.Courses
                        .Include(x => x.Department)
                    .Where(x => x.DepartmentId == aStudent.DepartmentId).ToList(); ;

                    if (tempcourses is null)
                    {
                        serviceResponse.Message = "department does not have courses now";
                        serviceResponse.Success = false;
                    }
                    serviceResponse.Data = tempcourses;
                    serviceResponse.Message = "this student department courses fetched successfully from Db";
                }
                else
                {
                    serviceResponse.Message = "Student does not exist";
                    serviceResponse.Success = false;
                }

                
            }
            catch (Exception exception)
            {

                serviceResponse.Message = "Some error occurred while fetching data.\nError message: " + exception.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        //Get Enrolled Courses By StdReg No:

        //GetCourseByStdRegNo:
        public ServiceResponse<IEnumerable<Course>> GetEnrolledCoursesBystdRegNo(string stdRegNo)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Course>>();
            try
            {
                List<Course> EnrolledCourses = new List<Course>();

                foreach (var enroll in Context.CourseEnrolls)
                {
                    if(enroll.StudentRegNo==stdRegNo)
                    {
                        var selectedCourse = Context.Courses.SingleOrDefault(x => x.Code == enroll.CourseCode);
                        EnrolledCourses.Add(selectedCourse);
                    }
                }

              
                
                    
                if (EnrolledCourses != null)
                {

                    serviceResponse.Data = EnrolledCourses;
                    serviceResponse.Message = "enrolled courses fetched successfully";
                }
                else
                {
                    serviceResponse.Message = "student do not have any enrolled course";
                    serviceResponse.Success = false;
                }


            }
            catch (Exception ex)
            {
                serviceResponse.Message = "Error occurred while fetching data from DB for\n" + ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }



    }
}
