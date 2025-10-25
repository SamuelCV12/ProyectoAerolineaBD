using EAFIT_BaseDeDatos.Core.EAFIT_BROKER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAFIT_BaseDeDatos.Core.EAFIT_MANAGER
{
    class ManagerRutas
    {
        internal bool InsertarRuta(Dictionary<string, string> ValuesRuta)
        {
            BrokerRutas InsertRuta = new BrokerRutas();
            ChangeEstadoRuta(ValuesRuta);
            return InsertRuta.InsertarRuta(ValuesRuta);
        }

        internal bool ActualizarRuta(Dictionary<string, string> ValuesRuta)
        {
            BrokerRutas UpdateRuta = new BrokerRutas();
            ChangeEstadoRuta(ValuesRuta);
            return UpdateRuta.ActualizarRuta(ValuesRuta);
        }

        internal bool InactivarRuta(int idRuta)
        {
            BrokerRutas InactivateRuta = new BrokerRutas();
            return InactivateRuta.InactivarRuta(idRuta);
        }

        internal Dictionary<string, string> ConsultarRuta(int idRuta)
        {
            BrokerRutas ValidateRuta = new BrokerRutas();
            return ValidateRuta.ConsultarRuta(idRuta);
        }

        // 🔹 Este método convierte el estado de texto a número (1=Activo, 2=Inactivo)
        private static void ChangeEstadoRuta(Dictionary<string, string> ValuesRuta)
        {
            if (!ValuesRuta.ContainsKey("estado_ruta") || string.IsNullOrWhiteSpace(ValuesRuta["estado_ruta"]))
            {
                ValuesRuta["estado_ruta"] = "1"; // Activo por defecto
                return;
            }

            string estado = ValuesRuta["estado_ruta"].Trim().ToLower();

            if (estado == "activo" || estado == "1" || estado == "true")
                ValuesRuta["estado_ruta"] = "1";
            else if (estado == "inactivo" || estado == "2" || estado == "false")
                ValuesRuta["estado_ruta"] = "2";
            else
                ValuesRuta["estado_ruta"] = "1"; // Por defecto, activo
        }
    }


}
