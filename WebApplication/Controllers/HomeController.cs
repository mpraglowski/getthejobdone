using System;
using System.Diagnostics;
using System.Threading;
using System.Web.Hosting;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Run()
        {
            HostingEnvironment.QueueBackgroundWorkItem(cancellationToken =>
            {
                // ... get the job done here ...
                Thread.Sleep(TimeSpan.FromSeconds(20));

                Trace.WriteLine("Done.");
            });

            return RedirectToAction("Index");
        }

    }
}