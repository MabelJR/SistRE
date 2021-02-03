using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeEntity;

namespace DataLogic
{
   public class DalcEstatus
    {


        /// <summary>
        /// Find All
        /// </summary>
        /// <returns></returns>
        public List<BeEstatus> FindAll()
        {
            List<BeEstatus> data = new List<BeEstatus>();

            try
            {
                using (var db = new EstG2Contex())
                {
                    data.AddRange(from e in db.Estatus
                                  select new BeEstatus()
                                  {
                                      EstatusID = e.EstatusID,
                                      Nombre = e.Nombre

                                  });
                    
                }
                return data;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }
    }
}
