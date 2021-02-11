using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeEntity;
using DataLogic;

namespace BusinessControl
{
   public class BcTipoContrabando
    {
        #region 
        private static DalcTipoContrabando _dalc = new DalcTipoContrabando();
        #endregion

        public List<BeTipoContrabando> FindAll()
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

        public BeTipoContrabando Find(int? id)
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

        public bool Create(BeTipoContrabando item)
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

        public bool Edit(BeTipoContrabando item)
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
