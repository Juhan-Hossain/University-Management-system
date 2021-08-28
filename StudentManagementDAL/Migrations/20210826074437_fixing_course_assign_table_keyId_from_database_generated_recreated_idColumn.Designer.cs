﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentManagementDAL;

namespace StudentManagementDAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210826074437_fixing_course_assign_table_keyId_from_database_generated_recreated_idColumn")]
    partial class fixing_course_assign_table_keyId_from_database_generated_recreated_idColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.Property<string>("CoursesCode")
                        .HasColumnType("nvarchar(9)");

                    b.Property<int>("CoursesDepartmentId")
                        .HasColumnType("int");

                    b.HasKey("StudentsId", "CoursesCode", "CoursesDepartmentId");

                    b.HasIndex("CoursesCode", "CoursesDepartmentId");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("StudentManagementEntity.Course", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("AssignTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Credit")
                        .HasColumnType("real");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("SemesterId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Code", "DepartmentId");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("DepartmentId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");

                    b.HasCheckConstraint("CHK_LengthOfCodeOfCourse", "LEN(Code) >= 5");

                    b.HasCheckConstraint("CHK_CreditRangeOfCourse", "Credit BETWEEN 0.5 AND 5.0");

                    b.HasData(
                        new
                        {
                            Code = "CSE-1102",
                            DepartmentId = 2,
                            Credit = 3f,
                            Description = "",
                            Id = 0,
                            Name = "C Lab",
                            SemesterId = 1
                        },
                        new
                        {
                            Code = "CSE-1103",
                            DepartmentId = 2,
                            Credit = 3f,
                            Description = "",
                            Id = 0,
                            Name = "C++",
                            SemesterId = 1
                        },
                        new
                        {
                            Code = "CSE-1104",
                            DepartmentId = 2,
                            Credit = 1.5f,
                            Description = "",
                            Id = 0,
                            Name = "C++ Lab",
                            SemesterId = 1
                        });
                });

            modelBuilder.Entity("StudentManagementEntity.CourseAssignment", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IsAssigned")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Code", "DepartmentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("CourseAssignments");
                });

            modelBuilder.Entity("StudentManagementEntity.CourseEnroll", b =>
                {
                    b.Property<string>("StudentRegNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseCode")
                        .HasColumnType("nvarchar(9)");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EnrolledCourseId")
                        .HasColumnType("int");

                    b.Property<int?>("EnrolledStudentId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsEnrolled")
                        .HasColumnType("bit");

                    b.HasKey("StudentRegNo", "CourseCode", "DepartmentId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EnrolledStudentId");

                    b.HasIndex("CourseCode", "DepartmentId");

                    b.ToTable("CourseEnrolls");
                });

            modelBuilder.Entity("StudentManagementEntity.DeletedCourseAssign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("IsAssigned")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DeletedCourseAssigns");
                });

            modelBuilder.Entity("StudentManagementEntity.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "EEE",
                            Name = "Electronics & Electrical Engineering"
                        },
                        new
                        {
                            Id = 2,
                            Code = "CSE",
                            Name = "Computer Science & Engineering"
                        },
                        new
                        {
                            Id = 3,
                            Code = "CE",
                            Name = "Civil Engineering"
                        },
                        new
                        {
                            Id = 4,
                            Code = "ME",
                            Name = "Mechanical Engineering"
                        },
                        new
                        {
                            Id = 5,
                            Code = "MTE",
                            Name = "Mechatronics Engineering"
                        },
                        new
                        {
                            Id = 6,
                            Code = "IPE",
                            Name = "Industrial Production & Engineering"
                        },
                        new
                        {
                            Id = 7,
                            Code = "MME",
                            Name = "Department of Materials and Metallurgical Engineering"
                        });
                });

            modelBuilder.Entity("StudentManagementEntity.Designation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Designations");
                });

            modelBuilder.Entity("StudentManagementEntity.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("StudentManagementEntity.RoomAllocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseCode")
                        .HasColumnType("nvarchar(9)");

                    b.Property<int?>("CourseDepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.Property<string>("EndTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromMeridiem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<string>("StartTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToMeridiem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("RoomId");

                    b.HasIndex("CourseCode", "CourseDepartmentId");

                    b.ToTable("RoomAllocations");
                });

            modelBuilder.Entity("StudentManagementEntity.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("Name");

                    b.ToTable("Semesters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "1st"
                        },
                        new
                        {
                            Id = 2,
                            Name = "2nd"
                        },
                        new
                        {
                            Id = 3,
                            Name = "3rd"
                        },
                        new
                        {
                            Id = 4,
                            Name = "4th"
                        },
                        new
                        {
                            Id = 5,
                            Name = "5th"
                        },
                        new
                        {
                            Id = 6,
                            Name = "6th"
                        },
                        new
                        {
                            Id = 7,
                            Name = "7th"
                        },
                        new
                        {
                            Id = 8,
                            Name = "8th"
                        });
                });

            modelBuilder.Entity("StudentManagementEntity.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContactNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ContactNumber")
                        .IsUnique();

                    b.HasIndex("DepartmentId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RegistrationNumber")
                        .IsUnique()
                        .HasFilter("[RegistrationNumber] IS NOT NULL");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentManagementEntity.StudentGrade", b =>
                {
                    b.Property<string>("Grade")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StudentGradeGrade")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Grade");

                    b.HasIndex("StudentGradeGrade");

                    b.ToTable("StudentGrades");

                    b.HasData(
                        new
                        {
                            Grade = "A+"
                        },
                        new
                        {
                            Grade = "A"
                        },
                        new
                        {
                            Grade = "A-"
                        },
                        new
                        {
                            Grade = "B+"
                        },
                        new
                        {
                            Grade = "B"
                        },
                        new
                        {
                            Grade = "B-"
                        },
                        new
                        {
                            Grade = "C+"
                        },
                        new
                        {
                            Grade = "C"
                        },
                        new
                        {
                            Grade = "C-"
                        },
                        new
                        {
                            Grade = "D+"
                        },
                        new
                        {
                            Grade = "D"
                        },
                        new
                        {
                            Grade = "D-"
                        },
                        new
                        {
                            Grade = "F"
                        });
                });

            modelBuilder.Entity("StudentManagementEntity.StudentResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GradeLetter")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Result")
                        .HasColumnType("bit");

                    b.Property<string>("StudentRegNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("GradeLetter");

                    b.HasIndex("CourseName", "StudentRegNo")
                        .IsUnique();

                    b.ToTable("StudentResults");
                });

            modelBuilder.Entity("StudentManagementEntity.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Contact")
                        .HasColumnType("bigint");

                    b.Property<double>("CreditToBeTaken")
                        .HasColumnType("float");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("DesignationId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("RemainingCredit")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DesignationId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.HasOne("StudentManagementEntity.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagementEntity.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesCode", "CoursesDepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudentManagementEntity.Course", b =>
                {
                    b.HasOne("StudentManagementEntity.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagementEntity.Teacher", null)
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("StudentManagementEntity.CourseAssignment", b =>
                {
                    b.HasOne("StudentManagementEntity.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("StudentManagementEntity.CourseEnroll", b =>
                {
                    b.HasOne("StudentManagementEntity.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagementEntity.Student", "Student")
                        .WithMany("CourseEnrolls")
                        .HasForeignKey("EnrolledStudentId");

                    b.HasOne("StudentManagementEntity.Course", "Course")
                        .WithMany("CourseEnrolls")
                        .HasForeignKey("CourseCode", "DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Department");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentManagementEntity.RoomAllocation", b =>
                {
                    b.HasOne("StudentManagementEntity.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("StudentManagementEntity.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagementEntity.Course", null)
                        .WithMany("RoomAllocationList")
                        .HasForeignKey("CourseCode", "CourseDepartmentId");

                    b.Navigation("Department");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("StudentManagementEntity.Student", b =>
                {
                    b.HasOne("StudentManagementEntity.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("StudentManagementEntity.StudentGrade", b =>
                {
                    b.HasOne("StudentManagementEntity.StudentGrade", null)
                        .WithMany("StudentResults")
                        .HasForeignKey("StudentGradeGrade");
                });

            modelBuilder.Entity("StudentManagementEntity.StudentResult", b =>
                {
                    b.HasOne("StudentManagementEntity.StudentGrade", "StudentGrade")
                        .WithMany()
                        .HasForeignKey("GradeLetter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentGrade");
                });

            modelBuilder.Entity("StudentManagementEntity.Teacher", b =>
                {
                    b.HasOne("StudentManagementEntity.Department", "Department")
                        .WithMany("Teachers")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("StudentManagementEntity.Designation", "Designation")
                        .WithMany()
                        .HasForeignKey("DesignationId");

                    b.Navigation("Department");

                    b.Navigation("Designation");
                });

            modelBuilder.Entity("StudentManagementEntity.Course", b =>
                {
                    b.Navigation("CourseEnrolls");

                    b.Navigation("RoomAllocationList");
                });

            modelBuilder.Entity("StudentManagementEntity.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("StudentManagementEntity.Student", b =>
                {
                    b.Navigation("CourseEnrolls");
                });

            modelBuilder.Entity("StudentManagementEntity.StudentGrade", b =>
                {
                    b.Navigation("StudentResults");
                });

            modelBuilder.Entity("StudentManagementEntity.Teacher", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
