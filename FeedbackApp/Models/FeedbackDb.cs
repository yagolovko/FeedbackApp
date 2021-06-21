using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackApp.Models
{
    public class FeedbackDb
    {

        [Key]
        public int FeedbackDbId { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string DbMessage { get; set; }

        [Column(TypeName = "int")]
        public int ThemeFeedbackId { get; set; }
        public ThemeFeedback ThemeFeedback { get; set; }

        [Column(TypeName = "int")]
        public int UserFeedbackId { get; set; }
        public UserFeedback UserFeedback { get; set; }
    }
}
