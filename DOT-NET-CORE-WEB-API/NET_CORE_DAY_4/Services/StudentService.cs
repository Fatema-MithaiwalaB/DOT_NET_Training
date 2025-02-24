namespace NET_CORE_DAY_4.Services
{
    public class StudentService : IStudentService
    {
        private readonly List<Student> _students = new();

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return _students;
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
