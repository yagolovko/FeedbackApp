using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackApp.Models
{
    public class UserFeedback
    {

        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string UserName { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        public string UserEmail { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string UserTelephone { get; set; }
    }
}
