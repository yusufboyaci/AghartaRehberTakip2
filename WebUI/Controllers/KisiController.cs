using DataAccess.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class KisiController : Controller
    {
        private readonly IKisiRepository _kisiRepository;
        public KisiController(IKisiRepository kisiRepository)
        {
            _kisiRepository = kisiRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View(_kisiRepository.Kisiler.Where(x => x.IsActive == true));
        }
        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(Kisi kisi)
        {
            _kisiRepository.KisiEkle(kisi);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id) => View(_kisiRepository.GetirKisiIdIle(id));
        [HttpPost]
        public IActionResult Edit(Kisi kisi)
        {
            _kisiRepository.KisiGuncelle(kisi);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _kisiRepository.KisiSil(id);
            return RedirectToAction("Index");
        }
        public IActionResult SoftDelete(Kisi kisi)
        {
            kisi.IsActive = false;
            _kisiRepository.KisiGuncelle(kisi);
            return RedirectToAction("Index");
        }
    }
}
