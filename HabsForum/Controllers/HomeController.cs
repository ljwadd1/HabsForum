using HabsForum.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HabsForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly HabsForumContext _context;

        // Home Constructor
        public HomeController(HabsForumContext context)
        {
            _context = context;
        }

        // Home: All discussions
        public async Task <IActionResult> Index()
        {
            // get list of all discussions from db
            var discussions = await _context.Discussion.Include("Comments")
                .ToListAsync();

            // pass discussions to view
            return View(discussions);
        }

        // Home: GetDiscussion - One discussion by id
        public async Task<IActionResult> GetDiscussion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // get discussion by id
            var discussion = await _context.Discussion.Include("Comments")
                .FirstOrDefaultAsync(m => m.DiscussionId == id);

            if (discussion == null)
            {
                return NotFound();
            }

            return View(discussion);
        }


    }
}
