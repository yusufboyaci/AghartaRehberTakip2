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
    public class LoginController : Controller
    {
        private readonly IKisiRepository _kisiRepository;
        public LoginController(IKisiRepository kisiRepository)
        {
            _kisiRepository = kisiRepository;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string ad, string soyad)
        {
            //if (ad.Equals(_kisiRepository.Kisiler.FirstOrDefault().Ad) && soyad.Equals(_kisiRepository.Kisiler.FirstOrDefault().Soyad))
            //{
                HttpContext.Session.SetInt32("Id", _kisiRepository.Kisiler.FirstOrDefault().Id);
            //}
            return RedirectToAction("Index","Kisi");
        }

    }
}
