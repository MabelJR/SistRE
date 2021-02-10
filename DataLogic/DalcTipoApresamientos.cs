using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeEntity;

namespace DataLogic
{
   public class DalcTipoApresamientos
    {
        public List<BeTipoApresamientos> FindAll()
        {
            var data = new List<BeTipoApresamientos>();
            try
            {
                using (var db = new EstG2Contex())
                {
                    data.AddRange(from tn in db.TipoApresamientos
                                  where tn.EstatusID != 3
                                  select new BeTipoApresamientos()
                                  {
                                     ApresamientoID = tn.ApresamientoID,
                                     Nombre = tn.Nombre,
                                     UsuarioCreo = tn.UsuarioCreo,
                                     FechaCreo = tn.FechaCreo,
                                     UsuarioActualizo = tn.UsuarioActualizo,
                                     FechaActualizo = tn.FechaActualizo,
                                     TipoNovedadID = tn.TipoNovedadID
                                  }); return data.ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception (ex.Message);
            }
        }

        public BeTipoApresamientos Find (int? id)
        {
            var data = new List<BeTipoApresamientos>();

            try
            {
                using (var db = new EstG2Contex())
                {
                    data.AddRange(from tn in db.TipoApresamientos
                                  .Where(t => t.ApresamientoID == id)
                                  select new BeTipoApresamientos()
                                  {
                                      ApresamientoID = tn.ApresamientoID,
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
                throw new Exception (ex.Message);
            }
        }

        public bool Create (BeTipoApresamientos item)
        {
            try
            {
                using (var db = new EstG2Contex())
                {
                    var tn = new TipoApresamientos();
                    tn.Nombre = item.Nombre;
                    tn.EstatusID = (int)item.EstatusID;
                    tn.UsuarioCreo = "MJimenez";
                    tn.TipoNovedadID = 9;
                    tn.FechaCreo = DateTime.Now;
                    db.TipoApresamientos.Add(tn);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }

        public bool Edit (BeTipoApresamientos item)
        {
            try
            {
                using (var db = new EstG2Contex() )
                {
                    var tn = new TipoApresamientos();
                    tn.UsuarioActualizo = "MJimenez";
                    tn.FechaActualizo = DateTime.Now;
                    tn.Nombre = item.Nombre;
                    tn.ApresamientoID = item.ApresamientoID;
                    tn.EstatusID = item.EstatusID;
                    db.TipoApresamientos.Attach(tn);
                    db.Entry(tn).Property(x => x.Nombre).IsModified = true;
                    db.Entry(tn).Property(x => x.EstatusID).IsModified = true;
                    db.Entry(tn).Property(x => x.UsuarioActualizo).IsModified=true;
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

        public bool Delete (int? id)
        {
            try
            {
                using (var db = new EstG2Contex())
                {
                    var tn = db.TipoApresamientos.Find(id);
                    if (tn!=null)
                        db.TipoApresamientos.Remove(tn);
                        db.SaveChanges();
                        return true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception (ex.Message);
            }
        }

    }
}
