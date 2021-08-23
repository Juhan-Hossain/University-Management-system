﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementEntity
{
    public class DeletedCourseAssign
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public int DepartmentId { get; set; }


        public int TeacherId { get; set; }

        public int? CourseId { get; set; }

        public bool IsAssigned { get; set; } = false;

        [NotMapped]
        public bool IsValidOperation { get; set; } = false;
        [Required]
        public string Code { get; set; }
    }
}
