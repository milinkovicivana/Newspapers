using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newspapers.Data;
using Newspapers.Models;

namespace Newspapers.Controllers
{
    public class ArticlesController : Controller
    {
        private Article article = new Article();

        public IActionResult Index()
        {
            var articles = article.findAll().OrderByDescending(a => a.Id);

            return View(articles);
        }

        public IActionResult Details(string id)
        {
            var art = article.find(id);

            return View(art);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("Add", new Article());
        }

        [HttpPost]
        public IActionResult Add(Article a)
        {
            article.create(a);
            return RedirectToAction("Index", "Articles");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            return View("Edit", article.find(id));
        }

        [HttpPost]
        public IActionResult Edit(string id, Article a)
        {
            var articleId = new ObjectId(id);
            a.Id = articleId;
            article.update(a);
            return RedirectToAction("Details", "Articles", new { id = id});
        }

        public IActionResult Delete(string id)
        {
            article.delete(id);
            return RedirectToAction("Index", "Articles");
        }


    }
}