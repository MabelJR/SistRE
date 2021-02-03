
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeEntity;

namespace DataLogic
{
  public  class DalcTipoNovedad
    {
        
        /// <summary>
        /// Listado de Novedades
        /// </summary>
        /// <returns></returns>
        public List<BeTipoNovedad> FindAll()
        {
            var data = new List<BeTipoNovedad>();

            try
            {
                using (var db = new EstG2Contex())
                {
                    data.AddRange(from tn in db.TipoNovedad where tn.EstatusID != 3
                                  select new BeTipoNovedad()

                                  {

                                      ID = tn.TipoNovedadID,
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
        public BeTipoNovedad Find(int? id)
        {
            var data = new List<BeTipoNovedad>();

            try
            {
                using (var db = new EstG2Contex())
                {
                    data.AddRange(from tn in db.TipoNovedad.Where(t => t.TipoNovedadID == id)
                                  select new BeTipoNovedad()

                                  {

                                      ID = tn.TipoNovedadID,
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
        public bool Create(BeTipoNovedad item)
        {

            try
            {
                using (var db = new EstG2Contex())
                {
                    var tn = new TipoNovedad();
                    tn.Nombre = item.Nombre;
                    tn.EstatusID = (int)item.EstatusID;
                    tn.UsuarioCreo = "gbrito";
                    tn.FechaCreo = DateTime.Now;      
                    db.TipoNovedad.Add(tn);
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
        public bool Edit(BeTipoNovedad item)
        {

            try
            {
                using (var db = new EstG2Contex())
                {
                    var tn = new TipoNovedad();


                    tn.UsuarioActualizo = "gbrito";
                    tn.FechaActualizo = DateTime.Now;
                    tn.Nombre = item.Nombre;
                    tn.TipoNovedadID = item.ID;
                    tn.EstatusID = (int)item.EstatusID;
                    db.TipoNovedad.Attach(tn);
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


                    var tn = db.TipoNovedad.Find(id);
                    if (tn != null)

                        db.TipoNovedad.Remove(tn);
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
