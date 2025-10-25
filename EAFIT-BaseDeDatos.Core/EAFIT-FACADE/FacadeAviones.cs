using EAFIT_BaseDeDatos.Core.EAFIT_BROKER;
using EAFIT_BaseDeDatos.Core.EAFIT_MANAGER;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAFIT_BaseDeDatos.Core.EAFIT_FACADE
{
    public class FacadeAviones
    {
        public bool InsertarAvion(Dictionary<string, string> ValuesAvion)
        {
            EAFIT_MANAGER.ManagerAviones InsertAvion = new EAFIT_MANAGER.ManagerAviones();
            return InsertAvion.InsertarAvion(ValuesAvion);
        }
        public bool ActualizarAvion(Dictionary<string, string> ValuesAvion)
        {
            EAFIT_MANAGER.ManagerAviones UpdateAvion = new EAFIT_MANAGER.ManagerAviones();
            return UpdateAvion.ActualizarAvion(ValuesAvion);
        }
        public bool InactivarAvion(string matricula)
        {
            EAFIT_MANAGER.ManagerAviones InactivateAvion = new EAFIT_MANAGER.ManagerAviones();
            return InactivateAvion.InactivarAvion(matricula);
        }
        public Dictionary<string, string> ValidarAvion(string matricula)
        {
            EAFIT_MANAGER.ManagerAviones ValidateAvion = new EAFIT_MANAGER.ManagerAviones();
            return ValidateAvion.ValidarAvion(matricula);
        }
    }
}
