//Demonstrate Inheritance & Method Overriding

using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to library");


        //Inheritance & Polymorphism
        List<LibraryItem> books = new List<LibraryItem>();

        //Adding Printed Books
        books.Add(new PrintedBook("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565", "Printed", "1"));
        books.Add(new PrintedBook("To Kill a Mockingbird", "Harper Lee", "9780061120084", "Printed", "5"));

        // Adding EBooks
        books.Add(new EBook("1984", "George Orwell", "9780451524935", "eBook"));
        books.Add(new EBook("The Catcher in the Rye", "J.D. Salinger", "9780316769488", "eBook"));


        //Displaying Books
        Console.WriteLine("\n--- Library Books ---");
        foreach (var book in books)
        {
            book.DisplayDetails();
        }


        //Abstraction & interface
        LibraryItem libraryitem = new LibraryItem("Dune", "Frank Herbert", "ISO10101");
        libraryitem.GetResourcetype();
        libraryitem.PrintLibraryInfo();

        //Sealed class to print log messages 
        LibraryManagement libraryManagement = new LibraryManagement();

        //Adding Books 
        LibraryItem Book1 = new EBook("Dune", "Frank Herbert", "ISO10101", "eBook");
        LibraryItem Book2 = new PrintedBook("Journey to the west", "Jane Austin", "ISO11122", "Printed", "4");
        LibraryOperation libraryOperation = new LibraryOperation();
        LibraryManager libraryManager = new LibraryManager();
        Console.WriteLine("Interface Adding Books:");
        libraryManager.AddBook(Book1);
        libraryManager.AddBook(Book2);
        libraryManagement.LogTransaction("Books created");


        //IssueBook
        Console.WriteLine("Interface Issuing Book \"ISO11122\" Journey to the west");
        libraryManager.IssueBook("ISO11122");
        libraryManager.IssueBook("ISO11122");
        libraryManagement.LogTransaction("Book issued");

        //Displaying Books
        Console.WriteLine(" Interface Displaying Books");
        libraryManager.DisplayBooks();

        //Partial Class
        Console.WriteLine("Partial class adding books");
        libraryOperation.AddBook(Book1);
        libraryOperation.AddBook(Book2);
        libraryManagement.LogTransaction("Book added in partial class");

        Console.WriteLine("Partial class Book \"ISO11122\" Journey to the west");
        libraryOperation.IssueBook("ISO11122");
        libraryOperation.IssueBook("ISO11122");
        libraryManagement.LogTransaction("Book issued");

        Console.WriteLine("Partial class displaying books");
        libraryOperation.DisplayBooks(); 
    }
   


}
