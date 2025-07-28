using DoAnCuoiKi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnCuoiKi.Controllers
{
    public class FavouriteController : Controller
    {

        // GET: Favourite
        DBSportStore1Entities database = new DBSportStore1Entities();   
        public ActionResult ShowFavourite()
        {
            if (Session["Favourite"] == null)
                return View("EmptyFavourite");
            Favourite _favourite = Session["Favourite"] as Favourite;
            return View(_favourite);
        }
        public Favourite GetFavourite()
        {
            Favourite favourite = Session["Favourite"] as Favourite;
            if(favourite == null || Session["Favourite"]==null)
            {
                favourite = new Favourite();
                Session["Favourite"]=favourite;
            }    
            return favourite;
        }
        public ActionResult AddToFavourite(int id) 
        { 
            var _pro=database.Products.SingleOrDefault(s=>s.ProductID==id);
            if (_pro == null)
            {
                GetFavourite().Add_Product_Favourite(_pro);
            }
            return RedirectToAction("ShowFavourite", "Favourite");
        }
        public ActionResult Update_Favourite_Quantity(FormCollection form)
        {
            Favourite favourite = Session["Favourite"] as Favourite;
            int id_pro = int.Parse(form["idPro"]);
            int _quantity = int.Parse(form["favouriteQuantity"]);
            favourite.Update_quantity(id_pro, _quantity);
            return RedirectToAction("ShowFavourite", "Favourite");
        }
        public ActionResult RemoveFavourite(int id)
        {
            Favourite favourite = Session["Favourite"] as Favourite;
            favourite.Remove_FavouriteItem(id);
            return RedirectToAction("ShowFavourite", "Favourite");
        }
        public PartialViewResult BagFavourite()
        {
            int toltal_quantity_item = 0;
            Favourite favourite = Session["Favourite"] as Favourite;
            if (favourite != null)
                toltal_quantity_item = favourite.Total_quantity();
            ViewBag.QuantityFavourite = toltal_quantity_item;
            return PartialView("BagFavourite");
        }

    }
}