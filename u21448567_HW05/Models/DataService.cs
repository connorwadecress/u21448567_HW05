using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace u21448567_HW05.Models
{
    public class DataService
    {
        //----------------------------------------------------------------------------------connecting the database and using connection strings----------------------------------------------------------------------------------

        //Data Source=IG-11\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True

        SqlConnection myConnection = new SqlConnection("Data Source=IG-11\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True");
        public string connectionString;
        //The code below 'declares' the DataSevice class as a singleton
        private static DataService instance;

        public static DataService getInstance()
        {
            if (instance == null)
            {
                instance = new DataService();
            }
            return instance;
        }


        public void getConnectionString(string tempConnStr)
        {
            connectionString = tempConnStr;
        }

        //----------------------------------------------------------------------------------reading from database to display in tables----------------------------------------------------------------------------------


        public List<Books> getBooks()
        {
            List<Books> dataBooks = new List<Books>();

            try
            {
                myConnection.Open();
                SqlCommand cmdReadBooks = new SqlCommand(
                "Select books.bookId, books.name, authors.surname, types.name AS typename, books.pagecount, books.point FROM books Join authors on books.authorId = authors.authorId  join types on books.typeId = types.typeId"
                , myConnection
                );
                SqlDataReader read = cmdReadBooks.ExecuteReader();

                while(read.Read())
                {
                    Books books = new Books();

                    books.bookId = (int)read["bookId"];
                    books.name = (string)read["name"];
                    books.authorId = (string)read["surname"];
                    books.typeId = (string)read["typename"];
                    books.pagecount = (int)read["pagecount"];
                    books.point = (int)read["point"];

                    dataBooks.Add(books); 
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                myConnection.Close();
            }
            return dataBooks;
        }

        public List<Borrows> getBookDetails(int ID)
        {
            List<Borrows> dataBorrows = new List<Borrows>();

            try
            {
                myConnection.Open();
                SqlCommand cmdReadBorrows = new SqlCommand(
                    /*"SELECT * FROM Borrows WHERE bookId = " + ID + ";", myConnection*/

                    "Select borrowiD, takenDate, broughtDate, students.name + ' ' + students.surname AS 'Borrowed By', books.name " +
                    "From BORROWS " +
                    "INNER JOIN STUDENTS " +
                    "ON BORROWS.STUDENTID = STUDENTS.STUDENTID " +
                    "INNER JOIN books " +
                    "ON borrows.bookId = books.bookId " +
                    "WHERE BORROWS.BOOKID = " + ID, myConnection
                    );
                SqlDataReader read = cmdReadBorrows.ExecuteReader();

                //SqlCommand cmdCount = new SqlCommand(
                //    "SELECT COUNT(*) FROM Borrows", myConnection
                //    );
                //SqlDataReader count = cmdCount.ExecuteReader();


                while (read.Read())
                {
                    Borrows borrows = new Borrows();

                    borrows.borrowId = (int)read["borrowId"];
                    borrows.borrowedBy = (string)read["Borrowed By"];
                    borrows.takenDate = (DateTime)read["takenDate"];
                    borrows.broughtDate = (DateTime)read["broughtDate"];
                    borrows.Name = (string)read["Name"];
                    
                    dataBorrows.Add(borrows);
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                myConnection.Close();
            }
            return dataBorrows;
        }

        public List<Students> getStudents()
        {
            List<Students> dataStudents = new List<Students>();

            try
            {
                myConnection.Open();
                SqlCommand cmdReadStudents = new SqlCommand("SELECT * FROM students", myConnection);
                SqlDataReader read = cmdReadStudents.ExecuteReader();

                while (read.Read())
                {
                    Students students = new Students();

                    students.studentId = (int)read["studentId"];
                    students.name = (string)read["name"];
                    students.surname = (string)read["surname"];
                    students.stdClass = (string)read["class"];
                    students.point = (int)read["point"];

                    dataStudents.Add(students);
                }

            }
            catch (Exception e)
            {

            }
            finally
            {
                myConnection.Close();
            }
            return dataStudents;
        }

        //----------------------------------------------------------------------------------Search functions----------------------------------------------------------------------------------

        public List<Books> searchBooks(string bookName)
        {
            List<Books> books = new List<Books>();
            try
            {
                myConnection.Open();
                SqlCommand command = new SqlCommand("select " + "books.bookId, " + "books.name, " + "authors.surname, " + "types.name AS typename, " + "books.pagecount, " +
                "books.point " + "from books " + "Join authors " + "on books.authorId = authors.authorId " + "join types " + "on books.typeId = types.typeId where books.name like '"
                + bookName + "%';", myConnection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Books libraryBooks = new Books();

                    libraryBooks.bookId = (int)reader["bookId"];
                    libraryBooks.name = (string)reader["name"];
                    libraryBooks.authorId = (string)reader["surname"];
                    libraryBooks.typeId = (string)reader["typename"];
                    libraryBooks.pagecount = (int)reader["pagecount"];
                    libraryBooks.point = (int)reader["point"];

                    books.Add(libraryBooks);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                myConnection.Close();
            }
            return books;
        }

        public List<Students> searchStudents(string studentName)
        {
            List<Students> students = new List<Students>();
            try
            {
                myConnection.Open();
                SqlCommand command = new SqlCommand("Select * From students where name like '" + studentName + "%';", myConnection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Students libraryStudents = new Students();

                    libraryStudents.studentId = (int)reader["studentId"];
                    libraryStudents.name = (string)reader["name"];
                    libraryStudents.surname = (string)reader["surname"];
                    libraryStudents.stdClass = (string)reader["class"];
                    libraryStudents.point = (int)reader["point"];

                    students.Add(libraryStudents);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                myConnection.Close();
            }
            return students;


        }

    }




}