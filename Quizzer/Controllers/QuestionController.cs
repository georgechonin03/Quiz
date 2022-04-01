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
        public IActionResult Index()
        {
            ViewBag.Questions = _db.Question.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddQuestion(QuestionVM model)
        {/*
            var question = new Question
            {
                Content = model.Content
            };*/
            string mainConnection = _configuration.GetConnectionString("DefaultConnection");
            _sqlConnection = new SqlConnection(mainConnection);
            _sqlQuery = "INSERT INTO [dbo].[Question] VALUES (@Content)";
            _sqlCommand = new SqlCommand(_sqlQuery, _sqlConnection);

            _sqlConnection.Open();
            _sqlCommand.Parameters.AddWithValue("@Content",model.Content);
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();

            return RedirectToAction("Index","Question");
        }

        [HttpPost]
        public IActionResult AddAnswer(AnswerVM model)
        {
            string mainConnection = _configuration.GetConnectionString("DefaultConnection");
            _sqlConnection = new SqlConnection(mainConnection);
            _sqlQuery = "INSERT INTO [dbo].[Answer] VALUES (@Content, @Correct)";
            _sqlCommand = new SqlCommand(_sqlQuery, _sqlConnection);

            _sqlConnection.Open();
            _sqlCommand.Parameters.AddWithValue("@Content", model.Content);
            _sqlCommand.Parameters.AddWithValue("@Correct", model.Correct);
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();

            return RedirectToAction("Index","Question");
        }
        public IActionResult AddQuestion()
        {
            return View();
        }
    }
}
