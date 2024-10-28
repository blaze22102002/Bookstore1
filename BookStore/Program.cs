using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
                Library library = new Library();
                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("\nLibrary Menu:");
                    Console.WriteLine("1. Add a new book");
                    Console.WriteLine("2. Display all books");
                    Console.WriteLine("3. Search for a book by ISBN");
                    Console.WriteLine("4. Display total number of books");
                    Console.WriteLine("5. Exit");
                    Console.Write("Enter your choice: ");

                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter Title: ");
                            string title = Console.ReadLine();

                            Console.Write("Enter Author: ");
                            string author = Console.ReadLine();

                            Console.Write("Enter Publication Year: ");
                            int publicationYear = int.Parse(Console.ReadLine());

                            Console.Write("Enter ISBN: ");
                            string isbn = Console.ReadLine();

                            Console.Write("Enter Number of Pages: ");
                            int numberOfPages = int.Parse(Console.ReadLine());

                            Books newBook = new Books(title, author, publicationYear, isbn, numberOfPages);
                            library.AddNewBook(newBook);
                            break;

                        case "2":
                            library.DisplayAllBooks();
                            break;

                        case "3":
                            Console.Write("Enter ISBN to search: ");
                            string searchIsbn = Console.ReadLine();
                            Books foundBook = library.SearchBookByISBN(searchIsbn);
                            if (foundBook != null)
                            {
                                foundBook.PrintDetails();
                            }
                            break;

                        case "4":
                            Books.DisplayTotalBooks();
                            break;

                        case "5":
                            exit = true;
                            Console.WriteLine("Exiting...");
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
        }

    }
