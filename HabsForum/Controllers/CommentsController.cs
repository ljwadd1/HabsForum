using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HabsForum.Data;
using HabsForum.Models;
using Azure;

namespace HabsForum.Controllers
{
    public class CommentsController : Controller
    {
        private readonly HabsForumContext _context;

        public CommentsController(HabsForumContext context)
        {
            _context = context;
        }

        // GET: Comments/Create
        // Display the form to add a comment
        public IActionResult Create(int? id)
        {
            // id = discussion id, not comment id
            if (id == null)
            {
                return NotFound();
            }

            ViewData["DiscussionId"] = id;
            return View();
        }

        // POST: Comments/Create
        // Create the new comment and re-direct to "Get Discussion" page on success
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,Content,CreateDate,DiscussionId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction("GetDiscussion", "Home", new { id = comment.DiscussionId});
                
            }


            ViewData["DiscussionId"] = comment.DiscussionId;

            return View(comment);
        }
    }
}
