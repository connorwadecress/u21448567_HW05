using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u21448567_HW05.Models;
using System.Data.SqlClient;
using System.Data;

namespace u21448567_HW05.Controllers
{
    public class HomeController : Controller
    {
        private DataService dataService = DataService.getInstance();

        //----------------------------- INDEX ----------------------------

        // GET: Home
        public ActionResult Index()
        {
            List<Books> books = dataService.getBooks();
            return View(books);
        }
        
        [HttpPost]
        public ActionResult searchBooks(string bookName)
        {
            List<Books> books = dataService.searchBooks(bookName);
            return View("Index", books);
        }

        public ActionResult clearBooks()
        {
            List<Books> books = dataService.getBooks();
            return RedirectToAction("Index", books);
        }



        //---------------------------------------------------------

        //----------------------------- BOOK DETAILS ----------------------------

        [HttpGet]
        public ActionResult BookDetails(int ID)
        {
            List<Borrows> borrows = dataService.getBookDetails(ID);
            return View(borrows); 
        }


        //---------------------------------------------------------

        //----------------------------- VIEW STUDENTS ----------------------------

        [HttpGet]
        public ActionResult ViewStudents()
        {
            List<Students> students = dataService.getStudents();
            return View(students);
        }

        [HttpPost]
        public ActionResult searchStudents(string studentName)
        {
            List<Students> students = dataService.searchStudents(studentName);
            return View("ViewStudents", students);
        }

        public ActionResult clearStudents()
        {
            List<Students> students = dataService.getStudents();
            return RedirectToAction("ViewStudents", students);
        }

        //---------------------------------------------------------







    }
}