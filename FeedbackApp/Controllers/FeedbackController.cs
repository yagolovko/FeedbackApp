using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FeedbackApp.Models;

namespace FeedbackApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackContext _context;

        public FeedbackController(FeedbackContext context)
        {
            _context = context;
        }

        // GET: api/Feedback
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedbacks()
        {
            return await _context.Feedbacks.ToListAsync();
        }

        // GET: api/Feedback/theme
        [HttpGet("theme")]
        public async Task<ActionResult<IEnumerable<ThemeFeedback>>> GetThemeFeedbacks()
        {
            return await _context.ThemeFeedbacks.ToListAsync();
        }



        // GET: api/Feedback/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetFeedback(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);

            if (feedback == null)
            {
                return NotFound();
            }

            return feedback;
        }

        // POST: api/Feedback
        [HttpPost]
        public async Task<ActionResult<Feedback>> PostFeedback(Feedback feedback)
        {
            var findtheme = _context.ThemeFeedbacks.ToList().Find(f => f.Theme == feedback.Theme);
            FeedbackDb feedbackdb = new FeedbackDb
            {
                FeedbackDbId = feedback.FeedbackId,
                ThemeFeedbackId = findtheme.Id,
                DbMessage = feedback.Message,
                UserFeedbackId = 0
            };
            // Проверка существования пользователя с заданным номером телефона и электронной почтой
            var finduser = _context.UserFeedbacks.Where(f => f.UserTelephone == feedback.Telephone && f.UserEmail == feedback.Email).Select(i => i.Id).ToList();
            if (finduser.Count() == 0)
            {
                // Если пользователь не найден, создается новый
                UserFeedback userfeedback = new UserFeedback
                {
                    Id = feedback.FeedbackId,
                    UserName = feedback.Name,
                    UserEmail = feedback.Email,
                    UserTelephone = feedback.Telephone
                };
                _context.UserFeedbacks.Add(userfeedback);
                await _context.SaveChangesAsync();
                // id нового пользователя добавляется в таблицу FeedbackDb
                feedbackdb.UserFeedbackId = userfeedback.Id;
                _context.FeedbackDbs.Add(feedbackdb);
                await _context.SaveChangesAsync();
            }
            else
            {
                // Если пользователь найден, его id добавляется в таблицу FeedbackDb
                var findid = finduser[0];
                feedbackdb.UserFeedbackId = findid;
                _context.FeedbackDbs.Add(feedbackdb);
                await _context.SaveChangesAsync();

            }
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetFeedback", new { id = feedback.FeedbackId }, feedback);
        }
    }
}
