using System;
namespace BookStore
{


    public class Books
    {

        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; }
        public int NumberOfPages { get; set; }


        private static int totalBooks = 0;


        public Books(string title, string author, int publicationYear, string isbn, int numberOfPages)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            ISBN = isbn;
            NumberOfPages = numberOfPages;
            totalBooks++;
        }


        public void ChangePublicationYear(int newYear)
        {
            PublicationYear = newYear;
        }


        public void ChangeAuthorName(string newAuthor)
        {
            Author = newAuthor;
        }


        public static void DisplayTotalBooks()
        {
            Console.WriteLine($"Total number of books: {totalBooks}");
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Title: {Title}, Author: {Author}, Publication Year: {PublicationYear}, ISBN: {ISBN}, Pages: {NumberOfPages}");
        }
    }
}
