using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicTacToe.Models;

namespace TicTacToe.Controllers
{
    public class GameController : Controller
    {
        private Context db = new Context();    

        [HttpGet]
        public ActionResult StartGame()
        {
            var game = Start();
            return View(game);
        }

        public ActionResult StartGame(GameModels models, int square)
        {
            var game = Start(square);
            game.Play(game, square);

            if (game.IsGameOver())
            {
                db.GameModelses.Add(new GameModels
                {
                    Winner = game.Winner().ToString()
                });
                
                //db.GameStoryModelses.Add(new GameStoryModels
                //{ 
                //    GameId = models,
                //    Story = square
                //});
                db.SaveChanges(); 
            }


            return RedirectToAction("StartGame");
        }
        private Game Start(int square = 0)
        {
            Game game;

            if (Session["game"] == null || square == -1)
            {
                game = new Game();
                Session["game"] = game;
            }
            else
            {
                game = Session["game"] as Game;
            }

            return game;
        }
        // GET: Game
        public ActionResult Index()
        {
            return View(db.GameModelses.ToList());
        }

        // GET: Game/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameModels gameModels = db.GameModelses.Find(id);
            if (gameModels == null)
            {
                return HttpNotFound();
            }
            return View(gameModels);
        }

        // GET: Game/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Game/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Winner")] Game gameModels)
        {
            if (ModelState.IsValid)
            {
                db.GameModelses.Add(new GameModels
                {
                    Winner = gameModels.Winner().ToString()
                });
                db.SaveChanges();
                return RedirectToAction("StartGame");
            }

            return View();
        }

        // GET: Game/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameModels gameModels = db.GameModelses.Find(id);
            if (gameModels == null)
            {
                return HttpNotFound();
            }
            return View(gameModels);
        }

        // POST: Game/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Winner")] GameModels gameModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gameModels);
        }

        // GET: Game/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameModels gameModels = db.GameModelses.Find(id);
            if (gameModels == null)
            {
                return HttpNotFound();
            }
            return View(gameModels);
        }

        // POST: Game/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameModels gameModels = db.GameModelses.Find(id);
            db.GameModelses.Remove(gameModels);
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
