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
    public class TipoDrogaController : Controller
    {
        #region variables
        //Testing connection to GitHub
        private BcTipoDroga BcTipoNoveda = new BcTipoDroga();
        BcEstatus BcEstatus = new BcEstatus();

        #endregion


        // GET: Tipo_Droga
        public ActionResult Index()
        {
            try
            {

                var tipoDroga = BcTipoNoveda.FindAll().ToList();
                return View(tipoDroga);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// All Estatus
        /// </summary>
        public void AllEstados()
        {

            try
            {
                var Estados = BcEstatus.FindAll().ToList();
                ViewBag.EstatusID = new SelectList(Estados, "EstatusID", "Nombre");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        /// <summary>
        /// Details Tipo Droga
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Tipo_Droga/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var tipoDroga = BcTipoNoveda.Find(id);
                if (tipoDroga == null)
                {
                    return HttpNotFound();
                }
                return View(tipoDroga);


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpGet]
        // GET: Tipo_Droga/Create
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
        // POST: Tipo_Droga/Create
        public ActionResult Create(BeTipoDroga item)
        {


            if (item == null)
            {
                AllEstados();
                return View(item);
            }

            try
            {
                BcTipoNoveda.Create(item);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }


        /// <summary>
        /// Editar Droga
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Tipo_Droga/Edit/
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            try
            {
                var tipoDroga = BcTipoNoveda.Find(id);
                AllEstados();
                if (tipoDroga == null)
                {
                    return HttpNotFound();
                }

                return View(tipoDroga);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // POST: Tipo_Droga/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BeTipoDroga item)
        {

            if (item == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                BcTipoNoveda.Edit(item);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }
    }
}
