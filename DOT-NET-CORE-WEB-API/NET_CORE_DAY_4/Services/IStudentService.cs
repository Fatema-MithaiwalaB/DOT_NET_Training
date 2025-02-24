namespace NET_CORE_DAY_4.Services
{
    public interface IStudentService
    {
        void AddStudent(Student student);
        List<Student> GetAllStudents();
    }
}
