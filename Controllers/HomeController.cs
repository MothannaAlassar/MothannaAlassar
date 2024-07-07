using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MothannaCV.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MothannaCV.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [Route("en")]
        [Route("ar")]
        public ActionResult Index()
        {
            var url = Request.Path.Value;// Request.Url.ToString();
            if (url.Contains("ar"))
                return View("ar/Index");
            if (url.Contains("en"))
                return View("en/Index");
            var isParcking = Startup.IsParcking;
            if (isParcking == "1")
                return View("en/ParckingPage");
            else
            {
                if (url.Contains("ar"))
                    return View("ar/Index");
                return View("en/Index");
            }
            //if (url.Contains("ar"))
            //    return View("ar/Index");
            //return View();
        }
        [Route("en/home")]
        [Route("ar/home")]
        public ActionResult Index2()
        {
            var url = Request.Path.Value;
            if (url.Contains("en"))
                return View("en/Index");
            return View("ar/Index");
        }
        [Route("en/ParckingPage")]
        [Route("ar/ParckingPage")]
        public ActionResult ParckingPage()
        {
            return View("en/ParckingPage.cshtml");
        }
        [Route("en/About")]
        [Route("ar/About")]
        public ActionResult About()
        {
            var url = Request.Path.ToUriComponent();
            if (url.Contains("ar"))
                return View("ar/About");
            return View("en/About");
        }
        [Route("en/Contact")]
        [Route("ar/Contact")]
        public ActionResult contact(int msg_id = 0, string lang = "en")
        {
            ContactModel model = new ContactModel();

            if (msg_id == 1)
            {
                model.title = "Thank You";
                model.Message = " Your email has been sent successfully";
            }
            var url = Request.Path.ToUriComponent();// Request.Url.ToString();
            if (lang.Contains("ar") || url.Contains("ar"))
                return View("ar/Contact", model);
            return View("en/Contact", model);
        }
        [Route("en/services")]
        [Route("ar/services")]
        public ActionResult services()
        {
            var url = Request.Path.ToUriComponent();
            if (url.Contains("ar"))
                return View("ar/services");
            return View("en/services");
        }
        [Route("en/register")]
        [Route("ar/register")]
        public ActionResult register()
        {
            var url = Request.Path.ToUriComponent();
            if (url.Contains("ar"))
                return View("ar/register");
            return View("en/register");
        }
        [HttpPost]
        public ActionResult SubmitContact(ContactModel Model, string lang = "en")
        {

            if (!ModelState.IsValid)
            {

                if (lang.Contains("ar"))
                    return View("ar/Contact", Model);
                return View("en/Contact", Model);
            }
            try
            {
                //MailContact.Mail(Model);
                if (lang.Contains("ar"))
                    RedirectToAction("en/Contact", new { msg_id = 1, lang = lang });
                return RedirectToAction("en/Contact", new { msg_id = 1, lang = lang });
            }
            catch (Exception ex)
            {
                if (lang.Contains("ar"))
                    return RedirectToAction("Contact", new { msg_id = 0, lang = lang });
                return RedirectToAction("Contact", new { msg_id = 0, lang = lang });
            }
            finally
            {
                if (null != Model)
                {
                    Model = null;
                }
            }
        }


    }
}
