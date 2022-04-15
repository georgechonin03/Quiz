using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Quizzer.Data;
using Quizzer.Models;
using Quizzer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzer.Controllers
{
    public class QuestionController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private IConfiguration _configuration { get; }
        private SqlConnection _sqlConnection;
        private string _sqlQuery;
        private SqlCommand _sqlCommand;
        public QuestionController(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }
        /// <summary>
        /// Parses the questions & answers in the database to ViewBag
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            ViewBag.Questions = _db.Question.ToList();
            ViewBag.Answers = _db.Answer.ToList();
            return View();
        }
        /// <summary>
        /// Method to add questions to the page
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddQuestion(QuestionVM model)
        {
            string mainConnection = _configuration.GetConnectionString("DefaultConnection");
            _sqlConnection = new SqlConnection(mainConnection);
            _sqlQuery = "INSERT INTO [dbo].[Question] VALUES (@Content)";
            _sqlCommand = new SqlCommand(_sqlQuery, _sqlConnection);

            _sqlConnection.Open();
            _sqlCommand.Parameters.AddWithValue("@Content", model.Content);
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();

            return RedirectToAction("Index", "Question");
        }
        /// <summary>
        /// Add answers to specified questions
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddAnswer(Answer model)
        {
            string mainConnection = _configuration.GetConnectionString("DefaultConnection");
            _sqlConnection = new SqlConnection(mainConnection);
            _sqlQuery = "INSERT INTO [dbo].[Answer] VALUES (@Content, @Correct, @QuestionId)";
            _sqlCommand = new SqlCommand(_sqlQuery, _sqlConnection);

            _sqlConnection.Open();
            _sqlCommand.Parameters.AddWithValue("@Content", model.Content);
            _sqlCommand.Parameters.AddWithValue("@Correct", model.Correct);
            _sqlCommand.Parameters.AddWithValue("@QuestionId", model.QuestionId);
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();

            return RedirectToAction("Index", "Question");
        }
        public IActionResult AddAnswer()
        {
            return View();
        }
        public IActionResult AddQuestion()
        {
            return View();
        }
    }
}
