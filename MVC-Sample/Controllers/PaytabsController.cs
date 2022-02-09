using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Sample.Controllers
{
    public class PaytabsController : Controller
    {
        // GET: PaytabsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PaytabsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PaytabsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaytabsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PaytabsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PaytabsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PaytabsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaytabsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
