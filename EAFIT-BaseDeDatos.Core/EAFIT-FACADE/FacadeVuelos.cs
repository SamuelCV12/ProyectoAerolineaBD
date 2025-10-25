using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAFIT_BaseDeDatos.Core.EAFIT_FACADE
{
    public class FacadeVuelos
    {
        public bool InsertarVuelo(Dictionary<string, string> ValuesVuelo)
        {
            EAFIT_MANAGER.ManagerVuelos InsertVuelo = new EAFIT_MANAGER.ManagerVuelos();
            return InsertVuelo.InsertarVuelo(ValuesVuelo);
        }

        public bool ActualizarVuelo(Dictionary<string, string> ValuesVuelo)
        {
            EAFIT_MANAGER.ManagerVuelos UpdateVuelo = new EAFIT_MANAGER.ManagerVuelos();
            return UpdateVuelo.ActualizarVuelo(ValuesVuelo);
        }

        public bool InactivarVuelo(int id_vuelo)
        {
            EAFIT_MANAGER.ManagerVuelos InactivateVuelo = new EAFIT_MANAGER.ManagerVuelos();
            return InactivateVuelo.InactivarVuelo(id_vuelo);
        }

        public Dictionary<string, string> ValidarVuelo(int id_vuelo)
        {
            EAFIT_MANAGER.ManagerVuelos ValidateVuelo = new EAFIT_MANAGER.ManagerVuelos();
            return ValidateVuelo.ValidarVuelo(id_vuelo);
        }
    }
}
