using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessControl;
using BeEntity;

namespace Sist_G2ERD.Controllers
{
    public class PerdidaDocumentosController : Controller
    {
        #region variables
        private BcPerdidaDocumentos _BcPerdidaDocumentos = new BcPerdidaDocumentos();
        BcEstatus bcEstatus = new BcEstatus();
        #endregion
        // GET: PerdidaDocumentos
        public ActionResult Index()
        {
            try
            {
                var PerdidaDocumentos = _BcPerdidaDocumentos.FindAll().ToList();
                return View(PerdidaDocumentos);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            //return View(db.PerdidaDocumentos.ToList());
        }

        // GET: PerdidaDocumentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var tipoApresamiento = _BcPerdidaDocumentos.Find(id);
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
        public ActionResult Create(BePerdidaDocumentos item)
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
                    _BcPerdidaDocumentos.Create(item);
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
                var tipoApresamiento = _BcPerdidaDocumentos.Find(id);
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
        public ActionResult Edit(BePerdidaDocumentos item)
        {
            if (item == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                _BcPerdidaDocumentos.Edit(item);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}