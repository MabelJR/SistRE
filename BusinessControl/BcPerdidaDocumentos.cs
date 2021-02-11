using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeEntity;
using DataLogic;

namespace BusinessControl
{
    public class BcPerdidaDocumentos
    {

        #region objetos y variables
        private static DalcPerdidaDocumentos _dalc = new DalcPerdidaDocumentos();
        #endregion


        /// <summary>
        /// Find All Tipo Novedades
        /// </summary>
        /// <returns></returns>
        public List<BePerdidaDocumentos> FindAll()
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
        public BePerdidaDocumentos Find(int? id)
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
        public bool Create(BePerdidaDocumentos item)
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
        public bool Edit(BePerdidaDocumentos item)

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
