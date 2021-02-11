using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeEntity;

namespace DataLogic
{
   public class DalcPerdidaDocumentos
    {
        public List<BePerdidaDocumentos> FindAll()
        {
            var data = new List<BePerdidaDocumentos>();

            try
            {
                using (var db = new EstG2Contex())
                {
                    data.AddRange(from tn in db.PerdidaDocumentos
                                  where tn.EstatusID != 3
                                  select new BePerdidaDocumentos()

                                  {

                                      PerdidaDocumentosID = tn.PerdidaDocumentosID,
                                      Nombre = tn.Nombre,
                                      EstatusID = tn.EstatusID,
                                      UsuarioCreo = tn.UsuarioCreo,
                                      FechaCreo = tn.FechaCreo,
                                      UsuarioActualizo = tn.UsuarioActualizo,
                                      FechaActualizo = tn.FechaActualizo
                                  });

                };
                return data.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Tipo Novedad Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BePerdidaDocumentos Find(int? id)
        {
            var data = new List<BePerdidaDocumentos>();

            try
            {
                using (var db = new EstG2Contex())
                {
                    data.AddRange(from tn in db.PerdidaDocumentos.Where(t => t.PerdidaDocumentosID == id)
                                  select new BePerdidaDocumentos()

                                  {

                                      PerdidaDocumentosID = tn.PerdidaDocumentosID,
                                      Nombre = tn.Nombre,
                                      EstatusID = tn.EstatusID,
                                      UsuarioCreo = tn.UsuarioCreo,
                                      FechaCreo = tn.FechaCreo,
                                      UsuarioActualizo = tn.UsuarioActualizo,
                                      FechaActualizo = tn.FechaActualizo
                                  });

                };
                return data.FirstOrDefault();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }

        /// <summary>
        /// Create Tipo Novedad
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BePerdidaDocumentos item)
        {

            try
            {
                using (var db = new EstG2Contex())
                {
                    var tn = new PerdidaDocumentos();
                    tn.Nombre = item.Nombre;
                    tn.EstatusID = (int)item.EstatusID;
                    tn.UsuarioCreo = "gbrito";
                    tn.FechaCreo = DateTime.Now;
                    db.PerdidaDocumentos.Add(tn);
                    db.SaveChanges();
                    return true;
                }


            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);

            }

        }


        /// <summary>
        /// Edit Tipo Novedad
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(BePerdidaDocumentos item)
        {

            try
            {
                using (var db = new EstG2Contex())
                {
                    var tn = new PerdidaDocumentos();


                    tn.UsuarioActualizo = "gbrito";
                    tn.FechaActualizo = DateTime.Now;
                    tn.Nombre = item.Nombre;
                    tn.PerdidaDocumentosID = item.PerdidaDocumentosID;
                    tn.EstatusID = (int)item.EstatusID;
                    db.PerdidaDocumentos.Attach(tn);
                    db.Entry(tn).Property(x => x.Nombre).IsModified = true;
                    db.Entry(tn).Property(x => x.EstatusID).IsModified = true;
                    db.Entry(tn).Property(x => x.UsuarioActualizo).IsModified = true;
                    db.Entry(tn).Property(x => x.FechaActualizo).IsModified = true;
                    db.SaveChanges();
                    return true;

                }

            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Elimina Tipo Novedad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int? id)
        {
            try
            {
                using (var db = new EstG2Contex())
                {


                    var tn = db.PerdidaDocumentos.Find(id);
                    if (tn != null)

                        db.PerdidaDocumentos.Remove(tn);
                    db.SaveChanges();
                    return true;

                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }
    }
}
