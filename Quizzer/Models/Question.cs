using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzer.Models
{
    [Table("Question")]
    public partial class Question
    {

        public Question()
        {
            Answer = new HashSet<Answer>();
        }
        public int Id { get; set; }
        public string Content { get; set; }
        public ICollection<Answer> Answer { get; set; }
    }
}
