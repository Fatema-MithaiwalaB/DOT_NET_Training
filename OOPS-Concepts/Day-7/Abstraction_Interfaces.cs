//Abstraction & Interfaces

public abstract class LibraryResource
{
    public abstract void GetResourcetype();

    public void PrintLibraryInfo()
    {
        Console.WriteLine("Printing Library Information");
    }
}

//Creating Interface
interface ILibraryOperation
{

    public void AddBook(LibraryItem book);
    public void IssueBook(string isbn);
    public void DisplayBooks();

}

public class LibraryManager : ILibraryOperation
{

    List<LibraryItem> books = new List<LibraryItem>();
    public void AddBook(LibraryItem Book)
    {
        books.Add(Book);
        Console.WriteLine("Book Added successfully");
    }

    public void DisplayBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("There is no book in the library");
        }
        else
        {
            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
            }
        }
    }

    public void IssueBook(string isbn)
    {
        if (books.Count == 0)
        {
            Console.WriteLine("\nNo books to issue");
        }
        else
        {
            bool flag = false;
            foreach (var book in books)
            {
                flag = true;
                if (book.ISBN == isbn)
                {
                    if (book is PrintedBook printedBook && int.Parse(printedBook.AvailableCopies) >= 1)
                    {
                        printedBook.AvailableCopies = (int.Parse(printedBook.AvailableCopies) - 1).ToString();
                        Console.WriteLine("Book issued successfully");
                    }
                    else
                    {
                        Console.WriteLine("Book is not for issuing");
                    }
                    
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine("No such book found");
            }
        }
    }
}
