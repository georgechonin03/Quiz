using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Quizzer.Controllers;
using Quizzer.Data;
using Quizzer.Models;
using Quizzer.Models.ViewModels;

namespace QuizTests
{
    public class Tests
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private IConfiguration _configuration { get; }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var controller = new QuestionController(_db, _configuration);
            var question = new QuestionVM();
            question.Content = "test";
            controller.AddQuestion(question);

            Assert.That(question.Content.Length > 0);
        }
    }
}