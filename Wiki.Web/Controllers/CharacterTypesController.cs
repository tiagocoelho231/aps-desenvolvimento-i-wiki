using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wiki.Business;
using Wiki.Data.Entity.Context;
using Wiki.Repositories.Common;
using Wiki.Repositories.Entity;
using Wiki.Web.ViewModels.CharacterType;

namespace Wiki.Web.Controllers
{
    public class CharacterTypesController : Controller
    {
        private IBaseRepository<CharacterType, int> repositoryCharacterTypes = new CharacterTypesRepository(new WikiDbContext());

        // GET: CharacterTypes
        public ActionResult Index()
        {
            return View(Mapper.Map<List<CharacterType>, List<CharacterTypeIndexViewModel>>(repositoryCharacterTypes.List()));
        }

        // GET: CharacterTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacterType characterType = repositoryCharacterTypes.Find(id.Value);
            if (characterType == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<CharacterType, CharacterTypeIndexViewModel>(characterType));
        }

        // GET: CharacterTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CharacterTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] CharacterTypeViewModel characterTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                CharacterType characterType = Mapper.Map<CharacterTypeViewModel, CharacterType>(characterTypeViewModel);
                repositoryCharacterTypes.Add(characterType);
                return RedirectToAction("Index");
            }

            return View(characterTypeViewModel);
        }

        // GET: CharacterTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacterType characterType = repositoryCharacterTypes.Find(id.Value);
            if (characterType == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<CharacterType, CharacterTypeIndexViewModel>(characterType));
        }

        // POST: CharacterTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] CharacterTypeViewModel characterTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                CharacterType characterType = Mapper.Map<CharacterTypeViewModel, CharacterType>(characterTypeViewModel);
                repositoryCharacterTypes.Edit(characterType);
                return RedirectToAction("Index");
            }
            return View(characterTypeViewModel);
        }

        // GET: CharacterTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacterType characterType = repositoryCharacterTypes.Find(id.Value);
            if (characterType == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<CharacterType, CharacterTypeIndexViewModel>(characterType));
        }

        // POST: CharacterTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repositoryCharacterTypes.RemoveById(id);
            return RedirectToAction("Index");
        }
    }
}
