using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLogic;
using BeEntity;
using BusinessControl;

namespace Sist_G2ERD.Controllers
{
    public class TipoApresamientosController : Controller
    {
        #region variables
        private BcTipoApresamientos _BcTipoApresamientos = new BcTipoApresamientos();
        BcEstatus bcEstatus = new BcEstatus();
        #endregion
        // GET: TipoApresamientos
        public ActionResult Index()
        {
            try
            {
                var tipoApresamientos = _BcTipoApresamientos.FindAll().ToList();
                return View(tipoApresamientos);
            }
            catch (Exception ex)
            {

                throw new Exception (ex.Message);
            }
            //return View(db.TipoApresamientos.ToList());
        }

        // GET: TipoApresamientos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var tipoApresamiento = _BcTipoApresamientos.Find(id);
                if (tipoApresamiento == null)
                {
                    return HttpNotFound();
                } 
                return View(tipoApresamiento);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                AllEstados();
                return View();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeTipoApresamientos item)
        {
            try
            {
                if (item == null)
                {
                    AllEstados();
                    return View(item);
                }
                try
                {
                    _BcTipoApresamientos.Create(item);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void AllEstados ()
        {
            try
            {
                var Estados = bcEstatus.FindAll().ToList();
                ViewBag.EstatusID = new SelectList(Estados, "EstatusID", "Nombre");
            }
            catch (Exception ex)
            {

                throw new Exception (ex.Message);
            }
        }

        public ActionResult Edit (int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var tipoApresamiento = _BcTipoApresamientos.Find(id);
                AllEstados();
                if (tipoApresamiento == null)
                {
                    return HttpNotFound();
                } 
                return View(tipoApresamiento);
            }
            catch (Exception ex)
            {

                throw new Exception (ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (BeTipoApresamientos item)
        {
            if (item == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                _BcTipoApresamientos.Edit(item);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw new Exception (ex.Message);
            }
        }

    }
}
