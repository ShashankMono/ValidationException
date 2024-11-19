using ValidationExample.Models;

namespace ValidationExample.Services
{
    public interface IStudentService
    {
        public Student GetStudent(Guid id);
        public Task<Student> AddStudent(Student student);
        public List<Student> GetAllStudents();
    }
}
