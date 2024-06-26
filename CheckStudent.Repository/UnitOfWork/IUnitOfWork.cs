﻿using CheckStudent.Repository.Models;
using CheckStudent.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckStudent.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        Task<int> SaveAsync();
        public GenericRepository<Student> StudentRepository { get; }
        public GenericRepository<StudentFace> StudentFaceRepository { get; }
        public GenericRepository<Course> CourseRepository { get; }
        public GenericRepository<Semester> SemesterRepository { get; }
        public GenericRepository<StudentInCourse> StudentInCourseRepository { get; }
        public GenericRepository<Subject> SubjectRepository { get; }
    }
}
