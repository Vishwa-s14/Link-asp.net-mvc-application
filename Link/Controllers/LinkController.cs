using Link.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Link.Controllers
{
    public class LinkController : Controller
    {
        LinkEntities linkEntities = new LinkEntities();
        // GET: Link
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(LinksTable model)
        {
          
            linkEntities.vs_InsertLINk(model.Description, model.Links);
            linkEntities.SaveChanges();
            ViewBag.Success = "Added your LINK..!";
            return View("Index");
        }

        public ActionResult ShowLinks()
        {
            
            var data = (from c in linkEntities.LinksTables
                        select c).ToList();
            return View(data);
        }
        public ActionResult Delete(string Description)
        {
            var Data = (from d in linkEntities.LinksTables
                        where d.Description == Description
                        select d).FirstOrDefault();
            linkEntities.LinksTables.Remove(Data);
            linkEntities.SaveChanges();
            return RedirectToAction("ShowLinks");
        }

        public ActionResult Edit(string Description)
        {
            return RedirectToAction("ShowLinks");
        }

    }
}