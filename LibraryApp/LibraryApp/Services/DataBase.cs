using LibraryApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
namespace LibraryApp.Services
{
    public class DataBase
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public bool createDatabase()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "librarydb.db");
                var connection = new SQLiteConnection(path);
                connection.CreateTable<User>();
                connection.CreateTable<Book>();
                connection.CreateTable<Cart>();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddNewUser(User newUser)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "librarydb.db");
                var connection = new SQLiteConnection(path);
                connection.Insert(newUser);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CheckUser(string username, string password)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "librarydb.db");
                var connection = new SQLiteConnection(path);
                List<User> users = connection.Query<User>("select * from User where UserName= ? AND PassWord = ? ", new string[2] { username, password });
                Console.WriteLine(users[0].Name);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool CheckRoleAdmin(string username, string password)
        {

            string path = System.IO.Path.Combine(folder, "librarydb.db");
            var connection = new SQLiteConnection(path);
            List<User> users = connection.Query<User>("select * from User where UserName= ? AND PassWord = ? ", new string[2] { username, password });
            Console.WriteLine(users[0].Admin);
            return users[0].Admin;

        }

        public bool AddBook(Book book)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "librarydb.db");
                var connection = new SQLiteConnection(path);
                connection.Insert(book);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public List<Book> GetAllBooks()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "librarydb.db");
                var connection = new SQLiteConnection(path);
                return connection.Table<Book>().ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool DeleteOnebook(Book book)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "librarydb.db");
                var connection = new SQLiteConnection(path);
                connection.Delete(book);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateOnebook(Book book)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "librarydb.db");
                var connection = new SQLiteConnection(path);
                connection.Update(book);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddCart(Cart cart)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "librarydb.db");
                var connection = new SQLiteConnection(path);
                connection.Insert(cart);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public List<Cart> GetCart()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "librarydb.db");
                var connection = new SQLiteConnection(path);
                return connection.Table<Cart>().ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<Book> GetOneBook(int bId)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "librarydb.db");
                var connection = new SQLiteConnection(path);
                return connection.Query<Book>("select * from Book where bId=" + bId.ToString());
            }
            catch
            {
                return null;
            }
        }
        public bool DeleteOneCark(Cart cart)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "librarydb.db");
                var connection = new SQLiteConnection(path);
                connection.Delete(cart);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}
