using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BDNbaikiemtragiuaki.Models;

namespace BDNbaikiemtragiuaki.Controllers
{
    public class bdnSinhViensController : Controller
    {
        private BDNK22CNT3Entities db = new BDNK22CNT3Entities();

        // GET: bdnSinhViens
        public ActionResult BDNIndex()
        {
            var bdnSinhViens = db.bdnSinhViens.Include(b => b.bdnKhoa);
            return View(bdnSinhViens.ToList());
        }

        // GET: bdnSinhViens/BDNDetails/5
        public ActionResult BDNDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bdnSinhVien bdnSinhVien = db.bdnSinhViens.Find(id);
            if (bdnSinhVien == null)
            {
                return HttpNotFound();
            }
            return View(bdnSinhVien);
        }

        // GET: bdnSinhViens/BDNCreate
        public ActionResult BDNCreate()
        {
            ViewBag.BdnMaKH = new SelectList(db.bdnKhoas, "BdnMaKH", "BdnTenKH");
            return View();
        }

        // POST: bdnSinhViens/BDNCreate
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BDNCreate([Bind(Include = "BdnMaSV,BdnHoSV,BdnTenSV,BdnNgaySinh,BdnPhai,BdnPhone,BdnEmail,BdnMaKH")] bdnSinhVien bdnSinhVien)
        {
            if (ModelState.IsValid)
            {
                db.bdnSinhViens.Add(bdnSinhVien);
                db.SaveChanges();
                return RedirectToAction("BDNIndex");
            }

            ViewBag.BdnMaKH = new SelectList(db.bdnKhoas, "BdnMaKH", "BdnTenKH", bdnSinhVien.BdnMaKH);
            return View(bdnSinhVien);
        }

        // GET: bdnSinhViens/BDNEdit/5
        public ActionResult BDNEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bdnSinhVien bdnSinhVien = db.bdnSinhViens.Find(id);
            if (bdnSinhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.BdnMaKH = new SelectList(db.bdnKhoas, "BdnMaKH", "BdnTenKH", bdnSinhVien.BdnMaKH);
            return View(bdnSinhVien);
        }

        // POST: bdnSinhViens/BDNEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BDNEdit([Bind(Include = "BdnMaSV,BdnHoSV,BdnTenSV,BdnNgaySinh,BdnPhai,BdnPhone,BdnEmail,BdnMaKH")] bdnSinhVien bdnSinhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bdnSinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BDNIndex");
            }
            ViewBag.BdnMaKH = new SelectList(db.bdnKhoas, "BdnMaKH", "BdnTenKH", bdnSinhVien.BdnMaKH);
            return View(bdnSinhVien);
        }

        // GET: bdnSinhViens/Delete/5
        public ActionResult BDNDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bdnSinhVien bdnSinhVien = db.bdnSinhViens.Find(id);
            if (bdnSinhVien == null)
            {
                return HttpNotFound();
            }
            return View(bdnSinhVien);
        }

        // POST: bdnSinhViens/BDNDelete/5
        [HttpPost, ActionName("BDNDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            bdnSinhVien bdnSinhVien = db.bdnSinhViens.Find(id);
            db.bdnSinhViens.Remove(bdnSinhVien);
            db.SaveChanges();
            return RedirectToAction("BDNIndex");
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
