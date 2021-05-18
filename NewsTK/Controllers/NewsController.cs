using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsTK.Models;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace NewsTK.Controllers
{

    public class NewsController : Controller
    {
        readonly UserManager<User> _userManager;
        public NewsController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        NewsAndComments newsAndComments = new NewsAndComments();
        NewsContext db = new NewsContext();

        [Authorize]
        public JsonResult Like(int Id)
        {
            db.News.Find(Id).Like += 1;
            db.SaveChanges();
            return Json(db.News.Find(Id).Like);
        }
        [Authorize]
        public JsonResult Dislike(int Id)
        {
            db.News.Find(Id).Dislike += 1;
            db.SaveChanges();
            return Json(db.News.Find(Id).Dislike);
        }

        [HttpGet]
        public IActionResult Read(int Id)
        {
            db.News.Find(Id).Views++;
            db.SaveChanges();
            newsAndComments.news = db.News.Find(Id);
            newsAndComments.comments = db.Comments.Where(n => n.HaberId == Id).ToList();
            return View("Read", newsAndComments);            
        }

        [HttpPost]
        public IActionResult Read(Comment comment)
        {
            if (comment != null)
            {
                using (var db = new NewsContext())
                {
                    Comment cm = new Comment()
                    {
                        CommentText = comment.CommentText,
                        Date = comment.Date,
                        HaberId = comment.HaberId,
                        UserName = comment.UserName,
                    };
                    db.Comments.Add(cm);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Read","News",comment.HaberId);
        }


        [HttpGet]
        [Authorize(Roles = "Reporter")]
        public async Task<IActionResult> Add()
        {
            var users = await _userManager.GetUsersInRoleAsync("Journalist");
            if (users != null)
            {
                return View(users.ToList());
            }
            return View();
        }

        [HttpPost]
        public IActionResult Add(PendingNews pendingNews)
        {
            if (pendingNews != null)
            {
                using (var db = new NewsContext())
                {
                    db.PendingNews.Add(pendingNews);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(pendingNews);
        }

        [HttpGet]
        [Authorize(Roles = "Journalist")]
        public IActionResult CreateNews()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNews(News news)
        {
            if (news != null)
            {
                using (var db = new NewsContext())
                {
                    db.News.Add(news);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(news);
        }

        [HttpGet]
        [Authorize(Roles = "Journalist")]
        public IActionResult PendingNews()
        {
            var pendingNews = db.PendingNews.Where(pn => pn.JournalistUserName == User.Identity.Name).ToList();
            return View(pendingNews);
        }

        [HttpGet]
        [Authorize(Roles = "Journalist")]
        public IActionResult ReadPendingNews(int Id)
        {
            PendingNews pn = db.PendingNews.Where(p => p.Id == Id).FirstOrDefault();
            return View(pn);
        }

        [Authorize(Roles = "Journalist")]
        public void ApproveNews(int Id)
        {
            var pn = db.PendingNews.FirstOrDefault(p => p.Id == Id);
            if (User.Identity.Name == pn.JournalistUserName)
            {
                var news = new News() {
                    Title = pn.Title,
                    FirstParagraph = pn.FirstParagraph,
                    NewsText = pn.NewsText,
                    ImageUrl = pn.ImageUrl,
                    UserName = pn.AuthorUserName,
                };
                db.News.Add(news);
                db.PendingNews.Remove(pn);
                db.SaveChanges();
                
            }
        }
        [Authorize(Roles = "Journalist")]
        public void DeleteNews(int Id)
        {
            var pn = db.PendingNews.FirstOrDefault(p => p.Id == Id);
            if (User.Identity.Name == pn.JournalistUserName)
            {
                db.PendingNews.Remove(pn);
                db.SaveChanges();
            }
        }



    }
}
