using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quizzer.Data;
using Quizzer.Models;
using Quizzer.Models.ViewModels;

namespace Quizzer.Controllers
{
    [Route("question")]
    public class QuestionController : Controller
    {
       
        [HttpPost]
        public IActionResult AddQuestion(QuestionVM model)
        {
            var question = new Question
            {
                Content = model.Content
            };
            return View(model);
        }
        public IActionResult AddQuestion()
        {
            return View();
        }
    }
}
