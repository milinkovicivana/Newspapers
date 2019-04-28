using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newspapers.Data;
using Newspapers.Models;

namespace Newspapers.Controllers
{
    public class ArticlesController : Controller
    {
        private Article article = new Article();

        public IActionResult Index()
        {
            var articles = article.findAll();

            return View(articles);
        }
    }
}