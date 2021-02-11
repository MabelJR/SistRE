using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeEntity;

namespace DataLogic
{
   public class DalcTipoContrabando
    {

        public List<BeTipoContrabando> FindAll()
        {
            var data = new List<BeTipoContrabando>();
            try
            {
                using (var db = new EstG2Contex())
                {
                    data.AddRange(from tn in db.TipoContrabando
                                  where tn.EstatusID != 3
                                  select new BeTipoContrabando()
                                  {
                                      ContrabandoID = tn.ContrabandoID,
                                      Nombre = tn.Nombre,
                                      UsuarioCreo = tn.UsuarioCreo,
                                      FechaCreo = tn.FechaCreo,
                                      UsuarioActualizo = tn.UsuarioActualizo,
                                      FechaActualizo = tn.FechaActualizo,
                                      TipoNovedadID = tn.TipoNovedadID,
                                      EstatusID = tn.EstatusID
                                  }); return data.ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public BeTipoContrabando Find(int? id)
        {
            var data = new List<BeTipoContrabando>();

            try
            {
                using (var db = new EstG2Contex())
                {
                    data.AddRange(from tn in db.TipoContrabando
                                  .Where(t => t.ContrabandoID == id)
                                  select new BeTipoContrabando()
                                  {
                                      ContrabandoID = tn.ContrabandoID,
                                      Nombre = tn.Nombre,
                                      UsuarioCreo = tn.UsuarioCreo,
                                      FechaCreo = tn.FechaCreo,
                                      UsuarioActualizo = tn.UsuarioActualizo,
                                      FechaActualizo = tn.FechaActualizo,
                                      TipoNovedadID = tn.TipoNovedadID

                                  }); return data.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Create(BeTipoContrabando item)
        {
            try
            {
                using (var db = new EstG2Contex())
                {
                    var tn = new TipoContrabando();
                    tn.Nombre = item.Nombre;
                    tn.EstatusID = (int)item.EstatusID;
                    tn.UsuarioCreo = "MJimenez";
                    tn.TipoNovedadID = 9;
                    tn.FechaCreo = DateTime.Now;
                    db.TipoContrabando.Add(tn);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Edit(BeTipoContrabando item)
        {
            try
            {
                using (var db = new EstG2Contex())
                {
                    var tn = new TipoContrabando();
                    tn.UsuarioActualizo = "MJimenez";
                    tn.FechaActualizo = DateTime.Now;
                    tn.Nombre = item.Nombre;
                    tn.ContrabandoID = item.ContrabandoID;
                    tn.EstatusID = item.EstatusID;
                    db.TipoContrabando.Attach(tn);
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
                throw new Exception(ex.Message);
            }
        }

        public bool Delete(int? id)
        {
            try
            {
                using (var db = new EstG2Contex())
                {
                    var tn = db.TipoContrabando.Find(id);
                    if (tn != null)
                        db.TipoContrabando.Remove(tn);
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
