﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

using CarProject.App_extension;


namespace CarProject.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/


        public ActionResult Index()
        {
            return View();
        }
        
        #region Cart
        public void AddToCart(int id, Models.Store.CartOfProducts.CartType type)
        {
            if (Session["guestUser"] != null && Session["guestUser"] is DBSEF.User)
            {
                var user = Session["guestUser"] as DBSEF.User;
                var dbs = new DBSEF.CarAutomationEntities();
                var tobasket = new DBSEF.ToBasket();
                tobasket.UserId = user.UserId;

                bool istrue = true;
                switch (type)
                {
                    case Models.Store.CartOfProducts.CartType.Product:
                        if (dbs.ToBaskets.Count(c => c.UserId == user.UserId && c.ProductId == id && c.BasketId == null) <= 0)
                            tobasket.ProductId = id;
                        else
                            istrue = false;
                        break;
                    case Models.Store.CartOfProducts.CartType.AutoService:
                        if (dbs.ToBaskets.Count(c => c.UserId == user.UserId && c.AutoServiceId == id && c.BasketId == null) <= 0)
                            tobasket.AutoServiceId = id;
                        else
                            istrue = false;
                        break;
                    case Models.Store.CartOfProducts.CartType.AutoServicePack:
                        if (dbs.ToBaskets.Count(c => c.UserId == user.UserId && c.AutoServicePackId == id && c.BasketId == null) <= 0)
                            tobasket.AutoServicePackId = id;
                        else
                            istrue = false;
                        break;
                    default:
                        istrue = false;
                        break;
                }

                if (istrue)
                {
                    tobasket.ProductEntity = 1;
                    dbs.ToBaskets.Add(tobasket);
                    dbs.SaveChanges();
                }
                
            }
            else
            {
                var list = new List<Models.Store.CartOfProducts>();
                var cartobje = new Models.Store.CartOfProducts { Id = id, TypeOfProduct = type };

                if (Request.Cookies["UserCart"] != null && Request.Cookies["UserCart"].Value != "")
                {
                    list = JsonConvert.DeserializeObject<List<Models.Store.CartOfProducts>>(Request.Cookies["UserCart"].Value);
                    if (list == null)
                        list = new List<Models.Store.CartOfProducts>();
                }

                if (!list.Contains(cartobje))
                    list.Add(cartobje);


                Response.Cookies["UserCart"].Value = JsonConvert.SerializeObject(list);
                Response.Cookies["UserCart"].Expires = DateTime.Today.AddMonths(1);
            }
        }
        public ActionResult Cart()
        {
            var list = Models.Store.CartOfProducts.GenerateList(Session, Request);
            return View(list);
        }

        [HttpPost]
        public ActionResult Cart(List<Models.Store.CartOfProducts> model)
        {
            if (Session["guestUser"] != null && Session["guestUser"] is DBSEF.User)
            {
                var dbs = new DBSEF.CarAutomationEntities();
                var user = Session["guestUser"] as DBSEF.User;

                foreach (var item in model)
                {
                    switch (item.TypeOfProduct)
                    {
                        case Models.Store.CartOfProducts.CartType.Product:
                            {
                                var itm = dbs.ToBaskets.FirstOrDefault(c => c.UserId == user.UserId && c.ProductId == item.Id && c.BasketId == null);
                                if (itm != null)
                                    itm.ProductEntity = item.Count;
                            }
                            break;
                        case Models.Store.CartOfProducts.CartType.AutoService:
                            {
                                var itm = dbs.ToBaskets.FirstOrDefault(c => c.UserId == user.UserId && c.AutoServiceId == item.Id && c.BasketId == null);
                                if (itm != null)
                                    itm.ProductEntity = item.Count;
                            }
                            break;
                        case Models.Store.CartOfProducts.CartType.AutoServicePack:
                            {
                                var itm = dbs.ToBaskets.FirstOrDefault(c => c.UserId == user.UserId && c.AutoServicePackId == item.Id && c.BasketId == null);
                                if (itm != null)
                                    itm.ProductEntity = item.Count;
                            }
                            break;
                        default:
                            break;
                    }
                }
                dbs.SaveChanges();
            }
            else
            {
                Response.Cookies["UserCart"].Value = JsonConvert.SerializeObject(model);
                Response.Cookies["UserCart"].Expires = DateTime.Today.AddMonths(1);
            }

            return RedirectToAction("Cart_CartConfirmAddress");
            
        }
        [HttpPost]
        public ActionResult Cart_remoSelection(string RemoveList)
        {
            var list = Models.Store.CartOfProducts.GenerateList(Session, Request);

            if (!RemoveList.IsNullOrWhiteSpace())
            {
                var removelistarray = JsonConvert.DeserializeObject<string[]>(RemoveList);
                var dbs = new DBSEF.CarAutomationEntities();
                var user = Session["guestUser"] as DBSEF.User;

                foreach (var item in removelistarray)
                {
                    var xitem = JsonConvert.DeserializeObject<Models.Store.CartOfProducts>(Server.HtmlDecode(item));

                    if (Session["guestUser"] != null && Session["guestUser"] is DBSEF.User)
                    {
                        switch (xitem.TypeOfProduct)
                        {
                            case Models.Store.CartOfProducts.CartType.Product:
                                {
                                    var itm = dbs.ToBaskets.FirstOrDefault(c => c.ProductId == xitem.Id && c.UserId == user.UserId && c.BasketId == null);
                                    if (itm != null)
                                        dbs.ToBaskets.Remove(itm);
                                }
                                break;
                            case Models.Store.CartOfProducts.CartType.AutoService:
                                {
                                    var itm = dbs.ToBaskets.FirstOrDefault(c => c.AutoServiceId == xitem.Id && c.UserId == user.UserId && c.BasketId == null);
                                    if (itm != null)
                                        dbs.ToBaskets.Remove(itm);
                                }
                                break;
                            case Models.Store.CartOfProducts.CartType.AutoServicePack:
                                {
                                    var itm = dbs.ToBaskets.FirstOrDefault(c => c.AutoServicePackId == xitem.Id && c.UserId == user.UserId && c.BasketId == null);
                                    if (itm != null)
                                        dbs.ToBaskets.Remove(itm);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        if(list.Contains(xitem))
                        list.Remove(xitem);
                    }
                }

                if (Session["guestUser"] != null && Session["guestUser"] is DBSEF.User)
                    dbs.SaveChanges();
                else
                {
                    Response.Cookies["UserCart"].Value = JsonConvert.SerializeObject(list);
                    Response.Cookies["UserCart"].Expires = DateTime.Today.AddMonths(1);
                }
            }

           
            return RedirectToAction("Cart");
        }
        [HttpPost]
        public ActionResult Cart_RemoveCopletly()
        {
            if (Session["guestUser"] != null && Session["guestUser"] is DBSEF.User)
            {
                var dbs = new DBSEF.CarAutomationEntities();
                var user = Session["guestUser"] as DBSEF.User;
                dbs.ToBaskets.RemoveRange(dbs.ToBaskets.Where(c => c.UserId == user.UserId && c.BasketId == null));
                dbs.SaveChanges();
            }
            else
            {
                Response.Cookies["UserCart"].Value = JsonConvert.SerializeObject(new List<Models.Store.CartOfProducts>());
                Response.Cookies["UserCart"].Expires = DateTime.Today.AddMonths(1);
            }
            return RedirectToAction("Cart");
        }

        [Areas.Users.UsersCLS.UsersAuthFilter]
        public ActionResult Cart_CartConfirmAddress()
        {
            var user = Session["guestUser"] as DBSEF.User;
            var model = new Models.Store.CartConfirmBillAndAddressModel(user);
            Session["Cart_CartConfirmAddress_model"] = model;

            return View(model);
        }
        [HttpPost]
        [Areas.Users.UsersCLS.UsersAuthFilter]
        public ActionResult Cart_CartConfirmAddress(Models.Store.CartConfirmBillAndAddressModel model)
        {
            if (ModelState.IsValid)
            {
                var m = Session["Cart_CartConfirmAddress_model"] as Models.Store.CartConfirmBillAndAddressModel;
                TryUpdateModel(m);
                m.saveChaneges();
                return RedirectToAction("SelectePaymentType");
            }
            else
                return View(model);
        }

        [Areas.Users.UsersCLS.UsersAuthFilter]
        public ActionResult SelectePaymentType()
        {
            return View();
        }

        [Areas.Users.UsersCLS.UsersAuthFilter]
        public ActionResult PaymentCart(int? id)
        {
            if (id == null)
            {
                var x = new Models.Store.CartConfirmBillAndAddressModel();
                if (x.BillingList.Count > 0)
                {
                    var bs = x.PaymentCartSuccessed(DateTime.Now.Ticks.ToString(), true);
                    return View(bs);
                }
                else
                    return RedirectToAction("Cart");
            }
            else
            {
                var dbs = new DBSEF.CarAutomationEntities();
                var user = Session["guestUser"] as DBSEF.User;
                var bs2 = dbs.Baskets.FirstOrDefault(bs => bs.BasketId == id && bs.UserId == user.UserId);

                if (bs2 != null)
                    return View(bs2);
                else
                    return RedirectToAction("Cart");
            }
        }
        #endregion

        #region Products
        public ActionResult Products(int id)
        {
            return View(id);
        }
        [HttpPost]
        public ActionResult Products(int id, FormCollection form)
        {
            ViewBag.error = new Dictionary<string, string>();
            if (form.AllKeys.Contains("SendACommentRequest"))
            {
                if (form["fullname"] == "")
                    ViewBag.error["fullname"] = "نام و نام خانوادگی تعیین نشده است";
                if (form["email"] == "")
                    ViewBag.error["email"] = "ایمیل وارد نشده است";
                else if(!form["email"].String_IsEmail())
                    ViewBag.error["email"] = "ایمیل وارد شده صحیح نیست";

                if(form["comment"] == "")
                    ViewBag.error["comment"] = "پیام وارد نشده است";

                if (((Dictionary<string, string>)ViewBag.error).Count == 0)
                {
                    var dbs = new DBSEF.CarAutomationEntities();
                    dbs.ProductComments.Add(new DBSEF.ProductComment { Comment = form["comment"], Email = form["email"], Fullname = form["fullname"], ProductId = id, datetime = DateTime.Now });
                    dbs.SaveChanges();
                    ViewBag.error["success"] = "پیام شما با موفقیت ثبت شد و پس از تایید به نمایش در خواهد آمد";
                }
            }
            return View(id);
        }
        
        [HttpPost]
        public int Products_makePopular(int id)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            int res = 0;
            if (dbs.ProductToViews.Count(p => p.ProductId == id) > 0)
            {
                var x = dbs.ProductToViews.FirstOrDefault(p => p.ProductId == id);
                if (x != null)
                {
                    if (x.Favorite == null || x.Favorite <= 0)
                    { x.Favorite = 1; res = 1; }
                    else
                    { x.Favorite += 1; res = x.Favorite.Value; }
                }
            }

            dbs.SaveChanges();
            return res;
        }
        

        public ActionResult ProductsList(int? id)
        {
            return View(id);
        }
        #endregion

        #region Services
        public ActionResult ServiceView(int id)
        {
            return View(id);
        }
        [HttpPost]
        public int ServiceView_makePopular(int id)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            int res = 0;

            var x = dbs.ServiceToViews.FirstOrDefault(p => p.ServiceId == id);
            if (x != null)
            {
                if (x.Favorite == null || x.Favorite <= 0)
                { x.Favorite = 1; res = 1; }
                else
                { x.Favorite += 1; res = x.Favorite.Value; }
            }


            dbs.SaveChanges();
            return res;
        }



        public ActionResult ServicePackView(int id)
        {
            return View(id);
        }
        [HttpPost]
        public int ServicePackView_makePopular(int id)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            int res = 0;

            var x = dbs.ServicesPackToViews.FirstOrDefault(p => p.ServicesPackId == id);
            if (x != null)
            {
                if (x.Favorite == null || x.Favorite <= 0)
                { x.Favorite = 1; res = 1; }
                else
                { x.Favorite += 1; res = x.Favorite.Value; }
            }


            dbs.SaveChanges();
            return res;
        }
        #endregion

        #region forum
        public ActionResult ProductForum(int? id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProductForum(int? id, FormCollection form)
        {
            if (form.AllKeys.Contains("newQuestion") && !string.IsNullOrWhiteSpace(form["newQuestion"]))
            {
                var dbs = new DBSEF.CarAutomationEntities();
                dbs.ProductQnAs.Add(new DBSEF.ProductQnA { ProductId = id, Question = form["newQuestion"], QuestionType = "Q" });
                dbs.SaveChanges();
                ModelState.AddModelError("success", "پرسش شما با موفقیت ثبت شد");
            }
            else
                ModelState.AddModelError("newQuestion", "پرسش وارد نشده است");
            return View();
        }
        public ActionResult ProductForum_Question(int? id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProductForum_Question(int? id, DBSEF.ProductQnA model)
        {
            if (model.Question.IsNullOrWhiteSpace())
                ViewData.ModelState.AddModelError("Question", "متن پرسش وارد نشده است");
            if (ModelState.IsValid)
            {
                var dbs = new DBSEF.CarAutomationEntities();
                model.QuestionType = "Q";
                dbs.ProductQnAs.Add(model);
                dbs.SaveChanges();

                return RedirectToAction("ProductForum_Question", new { id = id });
            }
            return View(model);
        }
        #endregion
    }

   
}
