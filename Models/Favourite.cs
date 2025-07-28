using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnCuoiKi.Models
{
    public class FavouriteItem
    {
        public Product _product { get; set; }
        public int _quantity { get; set; }
    }

    public class Favourite
    {
        List<FavouriteItem> items = new List<FavouriteItem>();
        public IEnumerable<FavouriteItem> Items
        {
            get { return items; }
        }

        public void Add_Product_Favourite(Product _pro, int _quan = 1)
        {

            var item = Items.FirstOrDefault(s => s._product.ProductID == _pro.ProductID);
            if (item == null)
                items.Add(new FavouriteItem
                {
                    _product = _pro,
                    _quantity = _quan
                });
            else
                item._quantity += _quan;
        }
        public int Total_quantity()
        {
            return items.Sum(s => s._quantity);
        }
        public void Update_quantity(int id, int _new_quan)
        {
            var item = items.Find(s => s._product.ProductID == id);
            if (item != null)
                item._quantity = _new_quan;
        }

        public void Remove_FavouriteItem(int id)
        {
            items.RemoveAll(s => s._product.ProductID == id);
        }

        public void ClearFavourite()
        {
            items.Clear();
        }

    }
}