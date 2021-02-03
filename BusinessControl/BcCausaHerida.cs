using DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeEntity;

namespace BusinessControl
{
  public  class BcCausaHerida
    {

        #region objetos y variables
        private static DalcCausaHerida _dalc = new DalcCausaHerida();
        #endregion


        /// <summary>
        /// Find All Tipo Novedades
        /// </summary>
        /// <returns></returns>
        public List<BeCausaHerida> FindAll()
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
        /// Find Tipo Novedad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BeCausaHerida Find(int? id)
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
        /// Create Tipo Novedad
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BeCausaHerida item)
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
        /// Edit Tipo Novedad
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(BeCausaHerida item)

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
