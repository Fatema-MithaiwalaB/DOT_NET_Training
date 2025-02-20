//Partial class 1
public partial class LibraryOperation
{
    List<LibraryItem> books = new List<LibraryItem>();
    LibraryManager libraryManager = new LibraryManager();
    //Add Book
    public void AddBook(LibraryItem Book)
    {
        libraryManager.AddBook(Book);
        Console.WriteLine("Book Added successfully");
    }

    //Issue Book
    public void IssueBook(string isbn)
    {
        libraryManager.IssueBook(isbn);
    }
}



//Partial class 2
public partial class LibraryOperation
{
    //return book
    public void ReturnBook(string isbn)
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
                if (book.ISBN == isbn)
                {
                    if (book is PrintedBook printedBook)
                    {
                        printedBook.AvailableCopies = (int.Parse(printedBook.AvailableCopies) + 1).ToString();
                        Console.WriteLine("Book returned successfully");
                    }
                    else
                    {
                        Console.WriteLine("Book is not for return purpose");
                    }
                    flag = true;
                    break;
                }
                else
                {
                    flag = false;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("No such book found");
            }
        }
    }

    //Displaying Books
    public void DisplayBooks()
    {
        libraryManager.DisplayBooks();
    }
}

