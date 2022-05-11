using FamilyTimeSuites.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
using System.Text;
using System.Net;
using Microsoft.Extensions.Options;

namespace FamilyTimeSuites.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHtmlLocalizer<HomeController> _localizer;
        private readonly ILogger<HomeController> _logger;

        private readonly IOptions<OptionsModel> _appSettings;



        public HomeController(ILogger<HomeController> logger, IHtmlLocalizer<HomeController> localizer, IOptions<OptionsModel> appSettings)
        {
            _logger = logger;
            _localizer = localizer;
            _appSettings = appSettings;
        }

        public IActionResult Index()
        {
            var test = _localizer["Merhaba"];
            ViewData["Merhaba"] = test;
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Rooms()
        {
            return View();
        }
        public IActionResult Gallery()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Contact(FormModel model)
        {
            try
            {
                MailMessage _mm = new MailMessage();
                _mm.SubjectEncoding = Encoding.Default;
                _mm.Subject = model.Email;
                _mm.BodyEncoding = Encoding.Default;
                _mm.Body = "Adı: " + model.Adi + "\nSoyadı: " + model.Soyadi + "\nTelefon: " + model.Tel + "\nMesaj:" + model.Mesaj;
                _mm.From = new MailAddress(_appSettings.Value.EmailAccount);
                _mm.To.Add(_appSettings.Value.EmailTo);
                var smtpClient = new SmtpClient(_appSettings.Value.EmailHost)
                {
                    Port = _appSettings.Value.EmailPort,
                    Credentials = new NetworkCredential(_appSettings.Value.EmailAccount, _appSettings.Value.EmailPassword),
                    EnableSsl = true
                };
                smtpClient.Send(_mm);
               
                //SmtpClient _smtpClient = new SmtpClient();
                //_smtpClient.Host = _appSettings.Value.EmailHost;
                //_smtpClient.Port = _appSettings.Value.EmailPort;
                //_smtpClient.UseDefaultCredentials = false;
                //NetworkCredential AccountInfo = new NetworkCredential(_appSettings.Value.EmailAccount, _appSettings.Value.EmailPassword);
                //_smtpClient.Credentials = AccountInfo;
                //_smtpClient.EnableSsl = _appSettings.Value.EmailSslEnable;
                //await _smtpClient.SendMailAsync(_mm);
                TempData["Başarılı"] = "";
        }
            catch (Exception e)
            {

                TempData["Hata"] = e.Message;
            }

            return RedirectToAction("Contact");
        }

        [HttpPost]
        public IActionResult CultureManagement(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });
            return LocalRedirect(returnUrl);


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
