namespace NET_CORE_DAY_3
{
    public class FileService:IFileService
    {
        private readonly string _directoryPath;
        public FileService()
        {
            _directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "SavedFile");
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }
        } 

        public void SaveToFile(string filename, string content)
        {
            string filePath = Path.Combine(_directoryPath, filename);
            File.WriteAllText(filePath, content);
        }

        public string ReadFromFile(string filename)
        {
            string filePath = Path.Combine(_directoryPath, filename);
            if (!File.Exists(filePath))
            {
                return $"{filename} not found!";            
            }
            return File.ReadAllText(filePath);
        }


    }
}
