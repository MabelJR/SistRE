using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLogic;
using BusinessControl;
using BeEntity;

namespace Sist_G2ERD.Controllers
{
    public class TipoContrabandoController : Controller
    {
        #region variables
        private BcTipoContrabando _BcTipoContrabando = new BcTipoContrabando();
        BcEstatus bcEstatus = new BcEstatus();
        #endregion
        // GET: TipoContrabando
        public ActionResult Index()
        {
            try
            {
                var tipoContrabando = _BcTipoContrabando.FindAll().ToList();
                return View(tipoContrabando);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            //return View(db.TipoContrabando.ToList());
        }

        // GET: TipoContrabando/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var tipoApresamiento = _BcTipoContrabando.Find(id);
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
        public ActionResult Create(BeTipoContrabando item)
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
                    _BcTipoContrabando.Create(item);
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
        public void AllEstados()
        {
            try
            {
                var Estados = bcEstatus.FindAll().ToList();
                ViewBag.EstatusID = new SelectList(Estados, "EstatusID", "Nombre");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var tipoApresamiento = _BcTipoContrabando.Find(id);
                AllEstados();
                if (tipoApresamiento == null)
                {
                    return HttpNotFound();
                }
                return View(tipoApresamiento);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BeTipoContrabando item)
        {
            if (item == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                _BcTipoContrabando.Edit(item);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
