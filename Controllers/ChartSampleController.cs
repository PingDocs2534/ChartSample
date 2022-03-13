using Chart.Utilities;
using Chart.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chart.Controllers
{
    public class ChartSampleController : Controller
    {
        // GET: ChartSample
        public ActionResult Index()
        {
            var chartBuilder = new C3ChartGenerate();
            chartBuilder.AddData("test1", 0, 5);
            chartBuilder.AddData("test1", 0, 6);
            chartBuilder.AddData("test1", 2, 2);
            chartBuilder.AddData("test1", 3, 10);

            var timeSpan = new TimeSpan(1, 0, 0);
            DateTime nextTime = DateTime.Now;
            chartBuilder.AddCategory(0, nextTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture));
            for (int i = 1; i < 10; i++)
            {
                nextTime = nextTime + timeSpan;
                chartBuilder.AddCategory(i, nextTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture));
            }

            ViewBag.DataColumnsJs = chartBuilder.BuildDataColumnsJsObj();
            ViewBag.AxisCategoriesJs = chartBuilder.BuildAxisCategoriesJsObj();
            return View();
        }

        // GET: ChartSample/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ChartSample/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChartSample/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ChartSample/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChartSample/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ChartSample/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChartSample/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
