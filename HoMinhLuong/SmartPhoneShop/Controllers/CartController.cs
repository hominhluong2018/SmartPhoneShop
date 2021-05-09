using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartPhoneShop;
using MyLibrary.Model;
using MyLibrary.DAO;

namespace SmartPhoneShop.Controllers
{
    public class CartController : Controller
    {
        SmartPhoneDBContext db = new SmartPhoneDBContext();
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<Cart>();
            if (cart != null)
            {
                list = (List<Cart>)cart;
            }
            return View(list);
        }
        public ActionResult AddItem(int productId, int quantity = 1)
        {
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<Cart>)cart;
                if (list.Exists(m => m.ProductId == productId))
                {

                    foreach (var item in list)
                    {
                        if (item.ProductId == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //tao doi tuong cart item
                    var item = new Cart();
                    item.ProductId = productId;
                    item.Quantity = quantity;
                    item.Product = db.Products.Find(productId);
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                //tao doi tuong cart item
                var item = new Cart();
                item.ProductId = productId;
                item.Quantity = quantity;
                item.Product = db.Products.Find(productId);
                var list = new List<Cart>();
                list.Add(item);
                //gan vao session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        public ActionResult DeleteItem(int productId)
        {
            var cart = Session[CartSession];
            var list = (List<Cart>)cart;
            foreach (var item in list)
            {
                if (item.ProductId == productId)
                {
                    list.Remove(item);
                    Session[CartSession] = list;
                    break;
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateCart(int productId, int quatity)
        {
            var cartSession = Session[CartSession];
            var carts = (List<Cart>)cartSession;

            foreach (var item in carts)
            {
                if (item.ProductId == productId)
                {
                    item.Quantity = quatity;
                }
            }

            Session[CartSession] = carts;

            return Json(new { Success = true });
        }
    }
}