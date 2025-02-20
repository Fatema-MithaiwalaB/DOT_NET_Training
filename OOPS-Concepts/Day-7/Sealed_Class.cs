
//Sealed class
sealed class LibraryManagement
{

    public void LogTransaction(string message)
    {
        Console.WriteLine($"Sealed class Log Transaction says: {message}");
    }
}
