using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        private Models.RestaurantDatabaseEntities2 db = new Models.RestaurantDatabaseEntities2();

        public ActionResult Index(string vegetarian, int? price)
        {
            IQueryable<Menu> menus = db.Menus;
            //if (price != null && price != 0)
            //{
            //    menus = menus.Where(p => p.Price == price);
            //}
            if (price != null )
            {
                menus = menus.Where(p => p.Price >= price);
            }
            if (!String.IsNullOrEmpty(vegetarian) && !vegetarian.Equals("Все"))
            {
                menus = menus.Where(p => p.Vegetarian == vegetarian);
            }

            List<Menu> teams = db.Menus.ToList();
            // устанавливаем начальный элемент, который позволит выбрать всех
            //teams.Insert(0, new Menu { Name = "Все"});

            MenuListViewModel plvm = new MenuListViewModel
            {
                Menus = menus.ToList(),
                Vegetarian = new SelectList(new List<string>()
            {
                "Все",
                "Вегетарианское",
                "Не вегетарианское",
            }),
                Price = new SelectList(new List<int>()
            {
                0,
                100, 
                300,
                500,
                800

            })
        
            };
            return View(plvm);
            //var Items = db.Menus;
            //return View(Items);
        }



        [HttpPost]
        public ActionResult MenuSearch(string name)
        {
            if (name != "")
            {
                var alldish = db.Menus.Where(a => a.Type.Contains(name)).ToList();
                if (alldish.Count <= 0)
                {
                    return HttpNotFound();
                }

                return PartialView(alldish);
            }
            else
            {
                return PartialView(0);
            }
        }

        public ActionResult GetDescription(int id)
        {
            Models.Menu ddb = db.Menus.Find(id);
            return PartialView(ddb);
        }

        [HttpGet]
        public ActionResult Form()
        {
            ViewBag.Message = "Your application description page.";
            return PartialView();
        }

  
        [HttpPost]
        public ActionResult Form(string Name, int Price, string Type, string Vegetarian, string Structure, string Photo)
        {
            Menu menu = new Menu
            {
                Name = Name,
                Price = Price,
                Structure = Structure,
                Vegetarian = Vegetarian,
                Type = Type,
                Photo = Photo
            };

            db.Menus.Add(menu);
            db.SaveChanges();
            return PartialView();
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

        
    }
}