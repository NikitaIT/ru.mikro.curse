using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wizitka.Models;

namespace Wizitka.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        PerformanceContext db = new PerformanceContext();

        public ActionResult Index()
        {
            // получаем из бд все объекты Performance
            IEnumerable<Performance> performances = db.Performances;

            // получаем из бд все объекты Performance
            IEnumerable<Actor> actors = db.Actors;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Performances = performances;
            ViewBag.Actors = actors;
            // возвращаем представление
            return View();
        }
       
    public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //Performance
        public ActionResult Details(int id = 0)
        {
            Performance performance = db.Performances.Find(id);
            if (performance == null)
            {
                return HttpNotFound();
            }
            return View(performance);
        }
        //
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        //Performance
        public ActionResult Edit(int id = 0)
        {
            Performance performance = db.Performances.Find(id);
            if (performance == null)
            {
                return HttpNotFound();
            }
            ViewBag.Actors = db.Performances.ToList();
            return View(performance);
        }
        //Performance
        [HttpPost]
        public ActionResult Edit(Performance performance, int[] selectedActors)
        {
            Performance newPerformance = db.Performances.Find(performance.Id);
            newPerformance.Name = performance.Name;
            newPerformance.Price = performance.Price;
            newPerformance.DateTimeTuples = performance.DateTimeTuples;

            newPerformance.Actors.Clear();
            if (selectedActors != null)
            {
                //получаем выбраннх авторов
                foreach (var c in db.Actors.Where(co => selectedActors.Contains(co.Id)))
                {
                    newPerformance.Actors.Add(c);
                }
            }

            db.Entry(newPerformance).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Performance
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        //Performance
        [HttpPost]
        public ActionResult Create(Performance performance)
        {
            db.Performances.Add(performance);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        //Performance
        public ActionResult Delete(int id)
        {
            Performance b = db.Performances.Find(id);
            if (b != null)
            {
                db.Performances.Remove(b);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //Actors
        [HttpGet]
        public ActionResult CreateActors()
        {
            return View();
        }
        //Actors
        [HttpPost]
        public ActionResult CreateActors(Actor actor)
        {
            db.Actors.Add(actor);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        //Actors
        public ActionResult DeleteActors(int id)
        {
            Actor b = db.Actors.Find(id);
            if (b != null)
            {
                db.Actors.Remove(b);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //Actors
        public ActionResult EditActors(int id = 0)
        {
            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            ViewBag.Actors = db.Actors.ToList();
            return View(actor);
        }
        //Actors
        [HttpPost]
        public ActionResult EditActors(Actor actor, int[] selectedPerformances)
        {
            Actor newActor = db.Actors.Find(actor.Id);
            newActor.Name = actor.Name;
            newActor.Info = actor.Info;

            newActor.Performances.Clear();
            if (selectedPerformances != null)
            {
                //получаем выбраннх спектаклей
                foreach (var c in db.Performances.Where(co => selectedPerformances.Contains(co.Id)))
                {
                    newActor.Performances.Add(c);
                }
            }

            db.Entry(newActor).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Actors
        public ActionResult DetailsActors(int id = 0)
        {
            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }
    }
}