﻿using RepositoryLayer;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.CourseAssignBLL
{
    public interface ICourseAssignServiceBLL:IRepository<CourseAssignment>
    {
        public ServiceResponse<CourseAssignment> GetByCompositeKey(int departmentId, string CourseCode, int teacherId);
      
    }
}