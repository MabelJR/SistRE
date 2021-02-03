﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeEntity;
using BusinessControl;

namespace Sist_G2ERD.Controllers
{
    public class CausaHeridaController : Controller
    {

        #region Variable u Objetos
       private BcCausaHerida BcCausaHerida = new BcCausaHerida();
       private  BcEstatus BcEstatus = new BcEstatus();
        #endregion

        // GET: CausaHerida
        public ActionResult Index()
        {

            try
            {
                var CausaH = BcCausaHerida.FindAll();
                return View(CausaH);
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
        /// Details Causa Herida
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: CausaHerida/Details/5
        public ActionResult Details(int? id)
        {

            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            try
            {
                var causaherida = BcCausaHerida.Find(id);
                if(causaherida ==null)
                {
                    return HttpNotFound();

                }
                return View(causaherida);

   
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
     
        }

        /// <summary>
        /// Create  Cause Herida
        /// </summary>
        /// <returns></returns>
        // GET: CausaHerida/Create
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

        /// <summary>
        /// Create Tipo Causa Herida
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        // POST: CausaHerida/Create
        [HttpPost]
        public ActionResult Create(BeCausaHerida item)
        {

            if (item == null)
            {
                AllEstados();
                return View(item);
            }
            try
            {
                BcCausaHerida.Create(item);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        /// <summary>
        /// Edit Causa Herida
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: CausaHerida/Edit/5
        public ActionResult Edit(int? id)
        {

            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            try
            {
                var causaherida = BcCausaHerida.Find(id);
                AllEstados();
                if(causaherida==null)
                {
                    return HttpNotFound();

                }

                return View(causaherida);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
   
        }

        // POST: CausaHerida/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BeCausaHerida item)
        {
            if (item == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                BcCausaHerida.Edit(item);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        // GET: CausaHerida/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CausaHerida/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
