namespace NET_CORE_DAY_3.Services
{
    public interface IFileService
    {
        void SaveToFile(string name, string content);
        string ReadFromFile(string filename);

    }
}
