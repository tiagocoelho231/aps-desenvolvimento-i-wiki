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
using Wiki.Web.ViewModels.Character;
using Wiki.Web.ViewModels.CharacterType;

namespace Wiki.Web.Controllers
{
    [Authorize]
    public class CharactersController : Controller
    {
        private IBaseRepository<Character, int> repositoryCharacters = new CharactersRepository(new WikiDbContext());
        private IBaseRepository<CharacterType, int> repositoryCharacterTypes = new CharacterTypesRepository(new WikiDbContext());

        // GET: Characters
        public ActionResult Index()
        {

            return View(Mapper.Map<List<Character>, List<CharacterIndexViewModel>>(repositoryCharacters.List()));
        }
        public ActionResult FilterByName(string name)
        {
            List<Character> characters = repositoryCharacters.List();
            if (name != null)
            {
                characters = characters.Where(a => a.Name.Contains(name)).ToList();
            }

            return Json(Mapper.Map<List<Character>, List<CharacterIndexViewModel>>(characters), JsonRequestBehavior.AllowGet);
        }



        // GET: Characters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = repositoryCharacters.Find(id.Value);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Character, CharacterIndexViewModel>(character));
        }

        // GET: Characters/Create
        public ActionResult Create()
        {
            ViewBag.IdType = new SelectList(Mapper.Map<List<CharacterType>, List<CharacterTypeIndexViewModel>>(repositoryCharacterTypes.List()), "Id", "Name");
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,IdType,Origin")] CharacterViewModel characterViewModel)
        {
            if (ModelState.IsValid)
            {
                repositoryCharacters.Add(Mapper.Map<CharacterViewModel, Character>(characterViewModel));
                return RedirectToAction("Index");
            }

            ViewBag.IdType = new SelectList(Mapper.Map<List<CharacterType>, List<CharacterTypeIndexViewModel>>(repositoryCharacterTypes.List()), "Id", "Name", characterViewModel.IdType);
            return View(characterViewModel);
        }

        // GET: Characters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = repositoryCharacters.Find(id.Value);
            if (character == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdType = new SelectList(Mapper.Map<List<CharacterType>, List<CharacterTypeIndexViewModel>>(repositoryCharacterTypes.List()), "Id", "Name", character.IdType);
            return View(Mapper.Map<Character, CharacterViewModel>(character));
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,IdType,Origin")] CharacterViewModel characterViewModel)
        {
            if (ModelState.IsValid)
            {
                repositoryCharacters.Edit(Mapper.Map<CharacterViewModel, Character>(characterViewModel));
                return RedirectToAction("Index");
            }
            ViewBag.IdType = new SelectList(Mapper.Map<List<CharacterType>, List<CharacterTypeIndexViewModel>>(repositoryCharacterTypes.List()), "Id", "Name", characterViewModel.IdType);
            return View(characterViewModel);
        }

        // GET: Characters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = repositoryCharacters.Find(id.Value);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Character, CharacterIndexViewModel>(character));
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repositoryCharacters.RemoveById(id);
            return RedirectToAction("Index");
        }
    }
}
