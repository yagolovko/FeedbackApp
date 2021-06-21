using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackApp.Models
{
    public class FeedbackContext:DbContext
    {
        public FeedbackContext(DbContextOptions<FeedbackContext> options):base(options)
        {

        }

        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<UserFeedback> UserFeedbacks { get; set; }
        public DbSet<FeedbackDb> FeedbackDbs { get; set; }
        public DbSet<ThemeFeedback> ThemeFeedbacks { get; set; }
    }
}
