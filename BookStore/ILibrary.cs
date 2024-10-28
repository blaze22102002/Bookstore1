using System.Collections.Generic;


namespace BookStore
{
   
public interface ILibrary
    {
        void DisplayAllBooks();
        Books SearchBookByISBN(string isbn);
        void AddNewBook(Books book);
    }


}