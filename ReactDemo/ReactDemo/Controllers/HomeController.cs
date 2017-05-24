using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactDemo.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReactDemo.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IList<CommentModel> _comments;
        private static readonly List<CommentModel> _commentsInterval;
        private static int _count;

        static HomeController()
        {
            _comments = new List<CommentModel>
            {
                new CommentModel
                {
                    Id = 1,
                    Author = "Thomas BB",
                    Text = "Hello ReactJS.NET World!"
                },
                new CommentModel
                {
                    Id = 2,
                    Author = "Rudy Elton",
                    Text = "This is one comment"
                },
                new CommentModel
                {
                    Id = 3,
                    Author = "Roman Peter",
                    Text = "This is *another* comment"
                },
            };

            _commentsInterval = new List<CommentModel>
            {
                new CommentModel
                {
                    Id = 1,
                    Author = "Aufruf 0",
                    Text = "Hello ReactJS.NET World!"
                },
                new CommentModel
                {
                    Id = 2,
                    Author = "Aufruf 0",
                    Text = "This is one comment"
                },
                new CommentModel
                {
                    Id = 3,
                    Author = "Aufruf 0",
                    Text = "This is *another* comment"
                },
            };

            _count = 0;
        }

        [Route("comments")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Comments()
        {
            return Json(_comments);
        }

        [Route("commentsInterval")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult CommentsInterval()
        {
            _count++;

            _commentsInterval.ForEach(x => x.Author = string.Format("Aufruf {0}", _count));

            return Json(_commentsInterval);
        }

        [Route("commentsInterval/new")]
        [HttpPost]
        public ActionResult AddComment(CommentModel comment)
        {
            // Create a fake ID for this comment
            comment.Id = _commentsInterval.Count + 1;
            _commentsInterval.Add(comment);
            return Content("Success :)");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
