public class LibraryItem : LibraryResource
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public LibraryItem(string title, string author, string isbn)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, ISBN: {ISBN}");
    }

    public override void GetResourcetype()
    {
        Console.WriteLine("Getting Resource Type : abstraction Performed");
    }

}

public class PrintedBook : LibraryItem
{
    private string type;
    public string Type
    {
        get { return type; }
        set { type = value; }
    }
    private string availableCopies;
    public string AvailableCopies
    {
        get { return availableCopies; }
        set { availableCopies = value; }
    }

    public PrintedBook(string title, string author, string isbn, string type, string availableCopies) : base(title, author, isbn)
    {
        Type = type;
        AvailableCopies = availableCopies;
    }

    //override display details
    public override void DisplayDetails()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, ISBN: {ISBN}, Type: {Type}, Available_Copies: {AvailableCopies}");
    }
}

public class EBook : LibraryItem
{
    private string Type;
    public string type
    {
        get { return type; }
        set { type = value; }
    }

    public EBook(string title, string author, string isbn, string type) : base(title, author, isbn)
    {
        Type = type;
    }
    //override display details
    public override void DisplayDetails()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, ISBN: {ISBN}, Type: {Type}");
    }
}



