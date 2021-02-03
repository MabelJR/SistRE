using BeEntity;
using BusinessControl;
using DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Sist_G2ERD.Controllers
{
    public class TipoNovedadController : Controller
    {
        #region variables

      private  BcTipoNovedad BcTipoNoveda = new BcTipoNovedad();
        BcEstatus BcEstatus = new BcEstatus();

        #endregion


        // GET: Tipo_Novedad
        public ActionResult Index()
        {
            try
            {

                var tiponovedad = BcTipoNoveda.FindAll().ToList();
                return View(tiponovedad);
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
        /// Details Tipo Novedad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Tipo_Novedad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
            try
            {
                var tiponovedad = BcTipoNoveda.Find(id);
                if (tiponovedad == null)
                {
                    return HttpNotFound();
                }
                return View(tiponovedad);


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpGet]
        // GET: Tipo_Novedad/Create
        public ActionResult Create(  )
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
        // POST: Tipo_Novedad/Create
        public ActionResult Create(BeTipoNovedad item)
        {
                

            if (item==null)
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
        /// Editar Novedad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Tipo_Novedad/Edit/
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            try
            {
                var tiponovedad = BcTipoNoveda.Find(id);
                AllEstados();
                if (tiponovedad == null)
                {
                    return HttpNotFound();
                }
               
                return View(tiponovedad);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // POST: Tipo_Novedad/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BeTipoNovedad item)
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
