using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPushLineNotify.Models;

namespace WebPushLineNotify.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LineNotify()
        {
            var model = new NotifyViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LineNotify(NotifyViewModel model)
        {
            var client = new RestClient("https://notify-api.line.me/api/notify");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer qPaVKVtT65tfDrbG8rennr8E7v2JRjnlm0z55iKbMvF");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("undefined", "message=" + model.Message, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return View(model);
        }
    }
}