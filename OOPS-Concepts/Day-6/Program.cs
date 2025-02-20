using Day_6;

public class Inventory
{
    //Creates List to store book info
    public List<Book> books = new List<Book>
        {
            new Book ("The Great Gatsby","F. Scott Fitzgerald", "9780743273565", 1, "Printed" ),
            new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084", 5, "Printed"),
            new Book("1984", "George Orwell", "9780451524935", 2, "eBook"),
            new Book("The Catcher in the Rye", "J.D. Salinger", "9780316769488", 4, "Printed"),
            new Book("Atomic Habits", "James Clear", "9780735211292", 3, "eBook")
        };
    public static void Main(string[] args)
    {
        Inventory inventory = new Inventory();
        inventory.MainMenu();
        inventory.Dispose();
    }
    static Inventory()
    {
        Console.WriteLine("Welcome to Library Management System");
    }

    ~Inventory()
    {
        Console.WriteLine("Destroying the Inventory");
    }

    public void Dispose()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("Destroying the Inventory");
    }
    public void MainMenu()
    {
        Console.WriteLine("--------------------------------------------------------------------------------------------------------");
        Console.WriteLine("**Main Menu:**");
        Console.WriteLine("\n1. Create Books \n2. Show All Books  \n3. Issue Book  \n4. Return Book \n5. Check Availability of Book \n6. Exit");
        Console.Write("Enter choice: ");
        int choice;
        try
        {
            choice = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine("Please enter a number");
            return;
        }

        switch (choice)
        {
            case 1: CreateBooks(); break;
            case 2: ShowAllBook(); break;
            case 3: IssueBook(); break;
            case 4: ReturnBook(); break;
            case 5: GetAvailCopies(); break;
            case 6: return;
            default:
                Console.WriteLine("Enter valid Choice");
                MainMenu();
                break;
        }

    }
    public void CreateBooks()
    {

        Console.WriteLine("\nCreate Books:");
        Console.WriteLine("Enter title:");
        string? title = Console.ReadLine();
        Console.WriteLine("Enter Author:");
        string? author = Console.ReadLine();
        Console.WriteLine("Enter isbn:");
        string? isbn = Console.ReadLine();
        Console.WriteLine("Enter Available copies: ");
        int copies;
        while (true)
        {
            string? cpy = Console.ReadLine();
            if (int.TryParse(cpy, out copies) && copies > 0)
            {
                break; // Valid input, exit the loop
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number.");
            }
        }
        Console.WriteLine("Enter Type:");
        string? type = Console.ReadLine();

        books.Add(new Book(title, author, isbn, copies, type));
        Console.WriteLine("Book has been Successfully created");
        MainMenu();
    }
    public void ShowAllBook()
    {
        Console.WriteLine("\n Showing all the books:");
        if (books.Count == 0)
        { Console.WriteLine("There is no books in inventory"); }
        else
        {
            books.ForEach(book => Console.WriteLine($"Title : {book.Title}  Author: {book.Author}  ISBN: {book.ISBN} Available Copies: {book.AvailCopies}  Type:{book.Type}"));
        }

        MainMenu();
    }
    public void IssueBook()
    {
        Console.WriteLine("\nEnter the book name to be issued:");
        string? bookName = Console.ReadLine();
        bool flag = false;
        foreach (Book book in books)
        {
            if (book.GetTitle() == bookName)
            {
                flag = true;
                if (book.GetAvailableCopies() < 0)

                {
                    Console.WriteLine("Sorry no book copies is left for issue");
                }
                else
                {
                    book.SetAvailableCopies(book.GetAvailableCopies() - 1);
                    Console.WriteLine($"\nRemaining copies of {book.GetTitle()} is {book.GetAvailableCopies()}");
                }
                break;
            }
            else
            {
                flag = false;
            }
        }
        if (flag == false)
        {
            Console.WriteLine("Book not found");
        }
        MainMenu();
    }

    public void ReturnBook()
    {
        Console.WriteLine("\nEnter the book name to be returned:");
        string? bookName = Console.ReadLine();
        bool flag = false;
        foreach (Book book in books)
        {
            if (book.GetTitle() == bookName)
            {
                flag = true;
                if (book.GetAvailableCopies() == 0)
                {
                    book.AvailCopies = 1;
                    Console.WriteLine("\nBook has been returned");
                    Console.WriteLine($"\n Remaining copies of {book.GetTitle()} is {book.GetAvailableCopies()}");
                    break;
                }
                else
                {
                    book.SetAvailableCopies(book.GetAvailableCopies() + 1);
                    Console.WriteLine($"\n Remaining copies of {book.GetTitle()} is {book.GetAvailableCopies()}");
                    break;
                }

            }
            else
            {
                flag = false;
            }
        }

        if (flag == false)
        {
            Console.WriteLine("Book not found");
        }
        MainMenu();

    }

    public void GetAvailCopies()
    {
        Console.WriteLine("\nEnter the book name:");
        string? bookName = Console.ReadLine();
        bool flag = false;
        foreach (Book book in books)
        {
            if (book.GetTitle() == bookName)
            {
                flag = true;
                Console.WriteLine($"Book copies of {book.GetTitle()} is {book.GetAvailableCopies()}");
                break;
            }
            else
            {
                flag = false;
            }
        }
        
        if (flag == false)
        {
            Console.WriteLine("Book not found");
        }
        MainMenu();
    }
}
