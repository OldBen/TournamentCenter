using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TournamentCenter.Models;

namespace TounamentCenter.Controllers
{
    public class TournamentsController : Controller
    {
        private TournamentDbContext db = new TournamentDbContext();

        // GET: Tournaments
        public ActionResult Index(string query)
        {
            if (!String.IsNullOrEmpty(query))
            {
                var tournaments = from t in db.Tournament
                                  where (t.TournamentName.Contains(query) && t.Deadline > DateTime.Now)
                                  orderby t.Deadline ascending
                                  select t;
                return View(tournaments);
            }
            else
            {
                var tournaments = from t in db.Tournament
                                  where t.Deadline > DateTime.Now
                                  orderby t.Deadline ascending
                                  select t;
                return View(tournaments);
            }
        }

        // GET: Tournaments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = db.Tournament.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // GET: Tournaments/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tournaments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Players,SponsorLogoUrl,Deadline,Sport,TournamentName,Date,Location,ParticipantsLimit")] Tournament tournament)
        {
            tournament.Players = 0;
            tournament.Organizer = User.Identity.Name;
            if (tournament.Deadline == null) tournament.Deadline = tournament.Date;
            if (tournament.Deadline > tournament.Date)
            {
                ViewBag.errorMessage = "Deadline must be placed before start of the tournament.";
                return View(tournament);
            }
            if(tournament.Date < DateTime.Now)
            {
                ViewBag.errorMessage = "You can't upload past tournaments.";
                return View(tournament);
            }
            ModelState.Clear();
            TryValidateModel(tournament);
            if (ModelState.IsValid)
            {
                db.Tournament.Add(tournament);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tournament);
        }

        // GET: Tournaments/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = db.Tournament.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            if(tournament.Organizer != User.Identity.Name)
            {
                ViewBag.errorMessage = "You are not allowed to edit this tournament.";
                return RedirectToAction("Index");
            }
            else return View(tournament);
        }

        // POST: Tournaments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Players,SponsorLogoUrl,Organizer,Deadline,Sport,TournamentName,Date,Location,ParticipantsLimit")] Tournament tournament)
        {
            if (tournament.Deadline == null) tournament.Deadline = tournament.Date;
            if (tournament.Deadline > tournament.Date)
            {
                ViewBag.errorMessage = "Deadline must be placed before start of the tournament.";
                return View(tournament);
            }
            if (tournament.Date < DateTime.Now)
            {
                ViewBag.errorMessage = "You can't upload past tournaments.";
                return View(tournament);
            }
            ModelState.Clear();
            TryValidateModel(tournament);
            if (ModelState.IsValid)
            {
                db.Entry(tournament).State = EntityState.Modified;
                db.SaveChanges();
                return View("Index", db.Tournament.ToList());
            }
            return View(tournament);
        }

        // GET: Tournaments/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = db.Tournament.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            if (tournament.Organizer != User.Identity.Name)
            {
                ViewBag.errorMessage = "You are not allowed to delete this tournament.";
                return View("Index", db.Tournament.ToList());
            }
            return View(tournament);
        }

        // POST: Tournaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tournament tournament = db.Tournament.Find(id);
            db.Tournament.Remove(tournament);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
