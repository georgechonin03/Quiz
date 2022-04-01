using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzer.Models
{
    [Table("Answer")]
    public partial class Answer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool? Correct { get; set; }
        public int? QuestionId { get; set; }
        public Question Question{ get; set; }//promqna
    }
}
