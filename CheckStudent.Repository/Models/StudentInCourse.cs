﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CheckStudent.Repository.Models;

public partial class StudentInCourse
{
    public int Id { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public int? Grade { get; set; }

    public string Note { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public virtual Course Course { get; set; }

    public virtual Student Student { get; set; }
}