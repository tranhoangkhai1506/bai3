using Chieu4_Buoi3_TranHoangKhai_2011060423.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace DemoLinq.Controllers
{
    public class SachController : Controller
    {
        // GET: Theloai
        NhaSachDataContext data = new NhaSachDataContext();
        //-------------Index-Theloai------------
        public ActionResult Index()
        {
            var all_sach = from tt in data.Saches select tt;
            return View(all_sach);
        }
        //-------------Detail-------------------
        public ActionResult Detail(int id)
        {
            var all_sach = data.Saches.Where(m => m.masach == id).First();
            return View(all_sach);
        }
        //-------------Create-------------------
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, Sach tl)
        {
            var maloai = collection["Mã loại"];
            var tensach = collection["Tên sách"];
            var hinh = collection["link hình"];
            if (string.IsNullOrEmpty(maloai))
            {
                ViewData["Error"] = "Don't empty!";
            }
            if (string.IsNullOrEmpty(tensach))
            {
                ViewData["Error"] = "Don't empty!";
            }
            if (string.IsNullOrEmpty(hinh))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                tl.tensach = maloai;
                tl.hinh = hinh;
                tl.maloai = int.Parse(maloai);
                data.Saches.InsertOnSubmit(tl);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        //-------------Edit-------------------
        public ActionResult Edit(int id)
        {
            var E_category = data.Saches.First(m => m.masach == id);
            return View(E_category);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {        
            var sach = data.Saches.First(m => m.masach == id);
            var E_maloai = collection["maloai"];
            var E_tenloai = collection["tenloai"];
            var E_hinh = collection["hinh"];
            sach.maloai = id;
            if (string.IsNullOrEmpty(E_maloai))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else if (string.IsNullOrEmpty(E_tenloai))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                sach.maloai = int.Parse(E_maloai);
                sach.tensach = E_tenloai;
                sach.hinh = E_hinh;
                UpdateModel(sach);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        //-------------Delete-------------------
        public ActionResult Delete(int id)
        {
            var D_theloai = data.Saches.First(m => m.masach == id);
            return View(D_theloai);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_theloai = data.Saches.Where(m => m.masach == id).First();
            data.Saches.DeleteOnSubmit(D_theloai);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}