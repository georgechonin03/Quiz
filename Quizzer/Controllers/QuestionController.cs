using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quizzer.Data;

namespace Quizzer.Controllers
{
    [Route("question")]
    public class QuestionController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        [Route("index")]
        [Route("")]
        [Route("~/")]
        public IActionResult Index()
        {
            ViewBag.Questions = _db.Question.ToList();
            return View();
        }
    }
}
