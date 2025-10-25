using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAFIT_BaseDeDatos.Core.EAFIT_FACADE
{
    public class FacadeLogin
    {
        public Dictionary<bool, string> ValidarLogin(string usuario, string password)
        {

            EAFIT_MANAGER.ManagerLogin Logeo = new EAFIT_MANAGER.ManagerLogin();
            Dictionary<bool, string> Results = new Dictionary<bool, string>();
            return Logeo.ValidarLogin(usuario, password);
        }
       


    }
}
