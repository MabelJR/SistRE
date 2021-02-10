using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeEntity;
using DataLogic;

namespace BusinessControl
{
    public class BcTipoApresamientos
    {
        #region 
        private static DalcTipoApresamientos _dalc = new DalcTipoApresamientos();
        #endregion

        public List<BeTipoApresamientos> FindAll()
        {
            try
            {
                return _dalc.FindAll();
            }
            catch (Exception ex)
            {

                throw new Exception (ex.Message);
            }
        }

        public BeTipoApresamientos Find (int? id)
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

        public bool Create (BeTipoApresamientos item)
        {
            try
            {
                return _dalc.Create(item);
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
                return _dalc.Edit(item);
            }
            catch (Exception ex)
            {

                throw new Exception (ex.Message);
            }
        }
    }
}
