using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6
{
    public class Book
    {
        //fields for book
        public string Title
        {
            get; set;
        }

        public string Author {
            get; set;
        }

        private string isbn;
        public string ISBN 
        {
            get
            {
                return isbn;
            }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("This value cannot be null");
                }
                else
                {
                    isbn = value;
                }
            }
        }

        private int AvailableCopies;
        public int AvailCopies
        {
            get { return AvailableCopies; }
            set
            {
                if (value > 0 || value == 0)
                {
                    AvailableCopies = value;
                }
                else
                {
                    Console.WriteLine("Copies of the book must be atleast 1");
                }
            }
        }
        public string Type 
        {
           get; set;
        }

        //GetAvail GetTitle SetAvail Getter Setter Methods 
        public string GetTitle()
        {
            return Title;
        }

        public int GetAvailableCopies()
        {
            return AvailableCopies;
        }

        public void SetAvailableCopies(int value)
        {
            if (value >= 0)
            {
                AvailableCopies = value;
                Console.WriteLine("\n Operation Successful");
            }
            else
            {
                Console.WriteLine("No copies left to issue the book");
            }
        }


        ~Book()
        {
            Console.WriteLine("Destroying the Book");
        }

        public Book(string title, string author, string isbn, int copies, string type)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            AvailableCopies = copies;
            Type = type;
        }
    }
}
