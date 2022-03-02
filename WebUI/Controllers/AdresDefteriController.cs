using DataAccess.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class AdresDefteriController : Controller
    {
        private readonly IAdresRepository _adresDefteriRepository;
        public AdresDefteriController(IAdresRepository adresDefteriRepository)
        {
            _adresDefteriRepository = adresDefteriRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View(_adresDefteriRepository.AdresDefteriler.Where(x => x.IsActive == true));
        }
        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(AdresDefteri nesne)
        {
            _adresDefteriRepository.AdresDefteriEkle(nesne);
          nesne.KisiId = Convert.ToInt32( HttpContext.Session.GetInt32("Id"));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id) => View(_adresDefteriRepository.GetirAdresDefteriIdIle(id));
        [HttpPost]
        public IActionResult Edit(AdresDefteri nesne)
        {
            _adresDefteriRepository.AdresDefteriGuncelle(nesne);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _adresDefteriRepository.AdresDefteriSil(id);
            return RedirectToAction("Index");
        }
        public IActionResult SoftDelete(AdresDefteri nesne)
        {
            nesne.IsActive = false;
            nesne.KisiId = 4;
            _adresDefteriRepository.AdresDefteriGuncelle(nesne);
            return RedirectToAction("Index");
        }


    }
}
