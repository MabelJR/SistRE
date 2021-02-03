using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogic;
using BeEntity;

namespace BusinessControl
{
   public class BcTipoDroga
    {


        #region objetos y variables
        private static DalcTipoDroga _dalc = new DalcTipoDroga();
        #endregion


        /// <summary>
        /// Find All Tipo Drogas
        /// </summary>
        /// <returns></returns>
        public List<BeTipoDroga> FindAll()
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


        /// <summary>
        /// Find Tipo Droga
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BeTipoDroga Find(int? id)
        {
            try
            {
                return _dalc.Find(id);

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
                return _dalc.Create(item);

            }
            catch (Exception ex)
            {

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

                return _dalc.Edit(item);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }
    }
}
