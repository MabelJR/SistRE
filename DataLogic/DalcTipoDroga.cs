using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeEntity;

namespace DataLogic
{
   public class DalcTipoDroga
    {
        public List<BeTipoDroga> FindAll()
        {
            var data = new List<BeTipoDroga>();

            try
            {
                using (var db = new EstG2Contex())
                {
                    data.AddRange(from tn in db.TipoDroga
                                  where tn.EstatusID != 3
                                  select new BeTipoDroga()

                                  {

                                      ID = tn.TipoDrogaID,
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
        /// Tipo Droga Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BeTipoDroga Find(int? id)
        {
            var data = new List<BeTipoDroga>();

            try
            {
                using (var db = new EstG2Contex())
                {
                    data.AddRange(from tn in db.TipoDroga.Where(t => t.TipoDrogaID == id)
                                  select new BeTipoDroga()

                                  {

                                      ID = tn.TipoDrogaID,
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
        /// Create Tipo Droga
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BeTipoDroga item)
        {

            try
            {
                using (var db = new EstG2Contex())
                {
                    var tn = new TipoDroga();
                    tn.Nombre = item.Nombre;
                    tn.EstatusID = (int)item.EstatusID;
                    tn.UsuarioCreo = "gbrito";
                    tn.FechaCreo = DateTime.Now;
                    db.TipoDroga.Add(tn);
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
        /// Edit Tipo Droga
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(BeTipoDroga item)
        {

            try
            {
                using (var db = new EstG2Contex())
                {
                    var tn = new TipoDroga();


                    tn.UsuarioActualizo = "gbrito";
                    tn.FechaActualizo = DateTime.Now;
                    tn.Nombre = item.Nombre;
                    tn.TipoDrogaID = item.ID;
                    tn.EstatusID = (int)item.EstatusID;
                    db.TipoDroga.Attach(tn);
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
        /// Elimina Tipo Droga
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int? id)
        {
            try
            {
                using (var db = new EstG2Contex())
                {


                    var tn = db.TipoDroga.Find(id);
                    if (tn != null)

                        db.TipoDroga.Remove(tn);
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
