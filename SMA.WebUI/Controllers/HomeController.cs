using SMA.Core.Contracts;
using SMA.Core.Models;
using SMA.Core.ViewModels;
using SMA.SQl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMA.WebUI.Controllers
{

    public class HomeController : Controller
    {
        AppDbContext db = new AppDbContext();
        IRepository<Post> context;
        IRepository<Category> contextCategory;

        public HomeController(IRepository<Post> context, IRepository<Category> contextCategory)
        {
            this.context = context;
            this.contextCategory = contextCategory;
        }
     
        public ActionResult Index(string option,string search,string category=null)
        {
            List<Post> posts;
            List<Category> categories= contextCategory.Collection().ToList();
            if (option == "Title")
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                return View(db.Posts.Where(x =>x.Title == search || search == null).ToList());
            }
            else if (option == "Category")
            {
                return View(db.Posts.Where(x =>x.Category == search || search == null).ToList());
            }
            

            if (category == null)
            {
                posts = context.Collection().ToList();
            }
            else
            {
                posts = context.Collection().Where(p => p.Category == category).ToList(); 
            }
            PostListViewModal model=new PostListViewModal();
            model.Posts = posts;
            model.Categories= categories;
            return View(model);
        }

        

        public ActionResult Details(string Id)
        {
            Post post = context.Find(Id);
            if (post == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(post);
            }
        }
    }
}