using BeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogic;

namespace BusinessControl
{

    /// <summary>
    /// Clase BC Estatus
    /// </summary>
    public class BcEstatus
    {
        #region objetos y variables
        private static DalcEstatus _dalc = new DalcEstatus();
        #endregion

        /// <summary>
        /// Find All Estatus
        /// </summary>
        /// <returns></returns>
        public List<BeEstatus> FindAll()
        {
            try
            {
                return _dalc.FindAll();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }
    }
}
