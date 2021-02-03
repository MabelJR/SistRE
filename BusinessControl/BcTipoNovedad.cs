
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogic;
using BeEntity;

namespace BusinessControl
{

    /// <summary>
    /// Class BC Tipo Novedad
    /// </summary>
    public class BcTipoNovedad
    {

        #region objetos y variables
        private static DalcTipoNovedad _dalc = new DalcTipoNovedad();
        #endregion


        /// <summary>
        /// Find All Tipo Novedades
        /// </summary>
        /// <returns></returns>
        public List<BeTipoNovedad> FindAll()
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
        public BeTipoNovedad Find(int? id)
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
        public bool Create(BeTipoNovedad item)
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
        public bool Edit(BeTipoNovedad item)

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
