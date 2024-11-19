using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Xml.Schema;
using ValidationExample.Exceptions;
using ValidationExample.Models;
using ValidationExample.Repository;

namespace ValidationExample.Services
{
    public class StudentService : IStudentService
    {
        private readonly  IRepository<Student> _repository;
        public StudentService(IRepository<Student> repository)
        {
            _repository = repository;
        }
        public async Task<Student> AddStudent(Student student)
        {
            
            return await _repository.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return _repository.GetAll().ToList();
        }

        public Student GetStudent(Guid id)
        {
            var student = _repository.GetById(id);
            if (student == null) {
                throw new StudentNotFoundException("Student Not found!");
            }
            return student;
        }
    }
}
