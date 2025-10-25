using EAFIT_BaseDeDatos.Core.EAFIT_BROKER;
using EAFIT_BaseDeDatos.Core.EAFIT_FACADE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAFIT_BaseDeDatos.Core.EAFIT_MANAGER
{
    public class ManagerAviones
    {
        internal bool InsertarAvion(Dictionary<string, string> ValuesAvion)
        {
            BrokerAviones InsertAvion = new BrokerAviones();
            FormatDateForDB(ValuesAvion);
            ChangeValuesState(ValuesAvion);

            return InsertAvion.InsertarAvion(ValuesAvion);
        }

        internal bool ActualizarAvion(Dictionary<string, string> ValuesAvion)
        {

            BrokerAviones UpdateAvion = new BrokerAviones();

            FormatDateForDB(ValuesAvion);
            ChangeValuesState(ValuesAvion);
            return UpdateAvion.ActualizarAvion(ValuesAvion);
        }

        internal bool InactivarAvion(string matricula)
        {
            BrokerAviones InactivateAvion = new BrokerAviones();
            return InactivateAvion.InactivarAvion(matricula);
        }

        internal Dictionary<string, string> ValidarAvion(string matricula)
        {
            BrokerAviones ValidateAvion = new BrokerAviones();
            Dictionary<string, string> ResultGetAvion = new Dictionary<string, string>();
            ResultGetAvion = ValidateAvion.ValidarAvion(matricula);
            if (ResultGetAvion.Count()>0 &&  string.IsNullOrEmpty(ResultGetAvion["fecha_ensamblaje_avion"]))
                ResultGetAvion["fecha_ensamblaje_avion"] = DateTime.MinValue.ToString();



            return ResultGetAvion;
        }

        /// <summary>
        /// Convierte el texto del estado ("Activo"/"Inactivo") al ID numérico ("1"/"2") 
        /// que requiere la base de datos para la Foreign Key.
        /// </summary>
        private static void ChangeValuesState(Dictionary<string, string> ValuesAvion)
        {
            string Estado = ValuesAvion.GetValueOrDefault("Estado_avion");

            if (string.IsNullOrEmpty(Estado)) return;

            if (Estado.Contains("Activo"))
                ValuesAvion["Estado_avion"] = "1";
            else
                ValuesAvion["Estado_avion"] = "2";

            //ValuesAvion["Estado_avion"] = Estado.Contains("Activo") ? "1" : "2";
        }

        /// <summary>
        /// Asegura que la fecha esté en formato 'YYYY-MM-DD' para MySQL, previniendo errores de inserción.
        /// </summary>
        private static void FormatDateForDB(Dictionary<string, string> ValuesAvion)
        {
            if (ValuesAvion.ContainsKey("fecha_ensamblaje_avion") && !string.IsNullOrEmpty(ValuesAvion["fecha_ensamblaje_avion"]))
            {
                if (DateTime.TryParse(ValuesAvion["fecha_ensamblaje_avion"], out DateTime fecha))
                    ValuesAvion["fecha_ensamblaje_avion"] = fecha.ToString("yyyy-MM-dd");

            }
        }
    }
}
