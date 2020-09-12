using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rodenstock.Models;

namespace Rodenstock.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View((List<Glasses>)Session["cart"]);
        }
        public ActionResult Add(Glasses g)
        {
            if (Session["cart"] == null)
            {
                List<Glasses> li = new List<Glasses>();

                li.Add(g);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = 1;
            }
            else
            {
                List<Glasses> li = (List<Glasses>)Session["cart"];
                li.Add(g);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
            }
            return RedirectToAction("Index", "Glasses");
        }

        public ActionResult DeleteConfirmed(Glasses g)
        {
            List<Glasses> li = (List<Glasses>)Session["cart"];
            foreach(var item in li)
            {
                if (item.Id == g.Id)
                {
                    li.Remove(item);
                    break;
                }
            }
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return RedirectToAction("Index", "Cart");
        }
    }
}
