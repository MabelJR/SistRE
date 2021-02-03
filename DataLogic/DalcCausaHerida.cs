using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeEntity;

namespace DataLogic
{
   public class DalcCausaHerida
    {

        /// <summary>
        /// Find All  Causa Herida
        /// </summary>
        /// <returns></returns>
        public List<BeCausaHerida> FindAll()
        {
            var data = new List<BeCausaHerida>();

            try
            {
                using (var db = new EstG2Contex())
                {
                    data.AddRange(from tn in db.CausaHerida
                                  where tn.EstatusID != 3
                                  select new BeCausaHerida()

                                  {

                                      ID = tn.CausaHeridaID,
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
        /// Tipo Cauda Herida Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BeCausaHerida Find(int? id)
        {
            var data = new List<BeCausaHerida>();

            try
            {
                using (var db = new EstG2Contex())
                {
                    data.AddRange(from tn in db.CausaHerida.Where(t => t.CausaHeridaID == id)
                                  select new BeCausaHerida()

                                  {

                                      ID = tn.CausaHeridaID,
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
        /// Create Tipo Causa Herida
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BeCausaHerida item)
        {

            try
            {
                using (var db = new EstG2Contex())
                {
                    var tn = new CausaHerida();
                    tn.Nombre = item.Nombre;
                    tn.EstatusID = (int)item.EstatusID;
                    tn.UsuarioCreo = "gbrito";
                    tn.FechaCreo = DateTime.Now;
                    db.CausaHerida.Add(tn);
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
        public bool Edit(BeCausaHerida item)
        {

            try
            {
                using (var db = new EstG2Contex())
                {
                    var ch = new CausaHerida();


                    ch.UsuarioActualizo = "gbrito";
                    ch.FechaActualizo = DateTime.Now;
                    ch.Nombre = item.Nombre;
                    ch.CausaHeridaID = item.ID;
                    ch.EstatusID = (int)item.EstatusID;
                    db.CausaHerida.Attach(ch);
                    db.Entry(ch).Property(x => x.Nombre).IsModified = true;
                    db.Entry(ch).Property(x => x.EstatusID).IsModified = true;
                    db.Entry(ch).Property(x => x.UsuarioActualizo).IsModified = true;
                    db.Entry(ch).Property(x => x.FechaActualizo).IsModified = true;
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
        /// Elimina Causa Herida
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int? id)
        {
            try
            {
                using (var db = new EstG2Contex())
                {


                    var tn = db.CausaHerida.Find(id);
                    if (tn != null)

                    db.CausaHerida.Remove(tn);
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
