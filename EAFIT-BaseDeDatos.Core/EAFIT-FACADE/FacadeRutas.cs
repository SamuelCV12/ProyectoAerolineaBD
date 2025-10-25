using EAFIT_BaseDeDatos.Core.EAFIT_MANAGER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAFIT_BaseDeDatos.Core.EAFIT_FACADE
{
    public class FacadeRutas
    {

        public bool InsertarRuta(Dictionary<string, string> ValuesRuta)
        {
            EAFIT_MANAGER.ManagerRutas InsertRuta = new EAFIT_MANAGER.ManagerRutas();
            return InsertRuta.InsertarRuta(ValuesRuta);
        }

        public bool ActualizarRuta(Dictionary<string, string> ValuesRuta)
        {
            EAFIT_MANAGER.ManagerRutas UpdateRuta = new EAFIT_MANAGER.ManagerRutas();
            return UpdateRuta.ActualizarRuta(ValuesRuta);
        }

        public bool InactivarRuta(int idRuta)
        {
            EAFIT_MANAGER.ManagerRutas InactivateRuta = new EAFIT_MANAGER.ManagerRutas();
            return InactivateRuta.InactivarRuta(idRuta);
        }

        public Dictionary<string, string> ConsultarRuta(int idRuta)
        {
            ManagerRutas ValidateRuta = new ManagerRutas();
            return ValidateRuta.ConsultarRuta(idRuta);
        }
    }
}
