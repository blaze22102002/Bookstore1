using static BookStore.Library;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using System.Configuration;

namespace BookStore
{


    public class Library : ILibrary
    {
        private List<Books>books = new List<Books>();

        private string conString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        // Add new book to the list and database
        public void AddNewBook(Books book)
        {
            // Add book to the local list
            //books.Add(book);

            // Insert the book into the database
            using (SqlConnection connection = new SqlConnection(conString))
            {
                string query = "INSERT INTO Books (Title, Author, PublicationYear, ISBN, NumberOfPages) VALUES (@Title, @Author, @PublicationYear, @ISBN, @NumberOfPages)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Title", book.Title);
                    cmd.Parameters.AddWithValue("@Author", book.Author);
                    cmd.Parameters.AddWithValue("@PublicationYear", book.PublicationYear);
                    cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
                    cmd.Parameters.AddWithValue("@NumberOfPages", book.NumberOfPages);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Book added to the database successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message+ex);
                    }
                }
            }
        }

       
        public void DisplayAllBooks()
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                string query = "SELECT * FROM Books";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            Console.WriteLine("\nAll Books in Library:");
                            Console.WriteLine("-------------------------------------------------------------");
                            Console.WriteLine("| {0,-20} | {1,-20} | {2,-5} | {3,-13} | {4,-6} |", "Title", "Author", "Year", "ISBN", "Pages");
                            Console.WriteLine("-------------------------------------------------------------");

                            while (reader.Read())
                            {
                                Console.WriteLine("| {0,-20} | {1,-20} | {2,-5} | {3,-13} | {4,-6} |",
                                    reader["Title"], reader["Author"], reader["PublicationYear"], reader["ISBN"], reader["NumberOfPages"]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No books found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }

        
        public Books SearchBookByISBN(string isbn)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                string query = "SELECT * FROM Books WHERE ISBN = @ISBN";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ISBN", isbn);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows && reader.Read())
                        {
                            // Create a book object from the database data
                            Books foundBook = new Books(
                                reader["Title"].ToString(),
                                reader["Author"].ToString(),
                                int.Parse(reader["PublicationYear"].ToString()),
                                reader["ISBN"].ToString(),
                                int.Parse(reader["NumberOfPages"].ToString())
                            );
                            return foundBook;
                        }
                        else
                        {
                            Console.WriteLine("Book not found.");
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        return null;
                    }
                }
            }
        }
    }
}