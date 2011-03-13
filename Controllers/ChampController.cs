using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMT.Models;

namespace CMT.Controllers
{
    public class ChampController : BaseController
    {
        //
        // GET: /Champ/

        public ActionResult Index()
        {
            var champs = mStorage.GetChamps();

            return View(champs);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Champ champ)
        {
            mStorage.CreateChamp(champ);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var champ = mStorage.GetChamp(c => c.Id == id);

            return View(champ);
        }

        [HttpPost]
        public ActionResult Edit(Champ champ)
        {
            mStorage.UpdateChamp(champ);

            return RedirectToAction("Index");
        }
    }
}
