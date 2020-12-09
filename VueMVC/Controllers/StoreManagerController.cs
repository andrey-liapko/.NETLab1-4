using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VueMVC.Models;

namespace VueMVC.Controllers
{
    
    [Authorize(Users = "123@mail.ru")]
    public class StoreManagerController : Controller
    {
        private ShoppingStoreEntities db = new ShoppingStoreEntities();

        // GET: StoreManager
        public ActionResult Index(string sortOrder, string categoryFurniture, string producerFurniture, string searchString, int? fromPrice, int? toPrice)
        {
            var categories = from m in db.Items
                         select m;

            var CategorySortParm = String.IsNullOrEmpty(sortOrder) ? "category_desc" : "";
            var PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            var TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "title_ascen";

            switch (sortOrder)
            {
                case "category_desc":
                    categories = categories.OrderByDescending(s => s.Category.Name);
                    break;
                case "Price":
                    categories = categories.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    categories = categories.OrderByDescending(s => s.Price);
                    break;
                case "title_ascen":
                    categories = categories.OrderBy(s => s.Title);
                    break;
                case "title_desc":
                    categories = categories.OrderByDescending(s => s.Title);
                    break;
                default:
                    categories = categories.OrderBy(s => s.Category.Name);
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                categories = categories.Where(s => s.Title.Contains(searchString));
            }

            if (fromPrice != null)
            {
                categories = categories.Where(x => x.Price >= fromPrice);
            }
            if (toPrice != null)
            {
                categories = categories.Where(x => x.Price <= toPrice);
            }
         
            var CategoriList = from m in db.Categories
                                            orderby m.Name
                                            select m.Name;
            var ProducerList = from m in db.Producers
                          orderby m.Name
                          select m.Name;


            if (!string.IsNullOrEmpty(categoryFurniture))
            {
                categories = categories.Where(x => x.Category.Name == categoryFurniture);
            }
            if (!string.IsNullOrEmpty(producerFurniture))
            {
                categories = categories.Where(x => x.Producer.Name == producerFurniture);
            }
       
            var categoryFI = new CategoryTitleSearch
            {
                CategorySortParm = CategorySortParm,
                PriceSortParm = PriceSortParm,
                TitleSortParm = TitleSortParm,
                Categori = new SelectList(CategoriList.ToList()),
                Producer = new SelectList(ProducerList.ToList()),
                Names = categories.ToList()
            };

            return View(categoryFI);
        }

        // GET: StoreManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: StoreManager/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            ViewBag.ProducerId = new SelectList(db.Producers, "ProducerId", "Name");
            return View();
        }

        // POST: StoreManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,CategoryId,ProducerId,Title,Price,ItemArtUrl")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", item.CategoryId);
            ViewBag.ProducerId = new SelectList(db.Producers, "ProducerId", "Name", item.ProducerId);
            return View(item);
        }

        // GET: StoreManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", item.CategoryId);
            ViewBag.ProducerId = new SelectList(db.Producers, "ProducerId", "Name", item.ProducerId);
            return View(item);
        }

        // POST: StoreManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,CategoryId,ProducerId,Title,Price,ItemArtUrl")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", item.CategoryId);
            ViewBag.ProducerId = new SelectList(db.Producers, "ProducerId", "Name", item.ProducerId);
            return View(item);
        }

        // GET: StoreManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
