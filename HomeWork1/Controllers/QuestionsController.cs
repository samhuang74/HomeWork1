using HomeWork1.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utils;

namespace HomeWork1.Controllers
{
    public class QuestionsController : Controller
    {
        // GET: Questions
        public ActionResult Index()
        {
            return View();
        }

        // GET: Questions/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Questions/Create
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

        // GET: Questions/Edit/5
        public ActionResult Edit(int id)
        {
            List<Question> qs = new List<Question>();

            for (int qsIndex = 0; qsIndex < 10; qsIndex++)
            {
                Question q = new Question();

                String idx = qsIndex.ToString();

                q.Kind = "1";
                q.QId = idx;
                q.Topic = "test" + idx;

                List<Option> options = new List<Option>();

                for (int index = 0; index < 4; index++)
                {
                    Option op = new Option();

                    //op.OTitle = "選擇" + index;
                    op.OValue = StringUtils.getToString(index);

                    //if (index % 2 == 0)
                    //{
                    //    op.IsChecked = true;
                    //}

                    options.Add(op);
                }

                q.Options = options;

                qs.Add(q);
            }
            return View(qs);
        }

        // POST: Questions/Edit/5
        [HttpPost]
        public ActionResult Edit(Question[] qs)
        {
            try
            {
                List<Question> re = new List<Question>();
                for(int index = 0; index < qs.Count(); index++)
                {
                    re.Add(qs[index]);
                }
                return View(re);
            }
            catch
            {
                return View();
            }
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Questions/Delete/5
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
