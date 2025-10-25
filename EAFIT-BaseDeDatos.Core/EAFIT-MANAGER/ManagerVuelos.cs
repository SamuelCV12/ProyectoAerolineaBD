using EAFIT_BaseDeDatos.Core.EAFIT_BROKER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAFIT_BaseDeDatos.Core.EAFIT_MANAGER
{
    public class ManagerVuelos
    {
        internal bool InsertarVuelo(Dictionary<string, string> ValuesVuelo)
        {
            BrokerVuelos InsertVuelo = new BrokerVuelos();
            FormatDateForDB(ValuesVuelo);
            return InsertVuelo.InsertarVuelo(ValuesVuelo);
        }

        internal bool ActualizarVuelo(Dictionary<string, string> ValuesVuelo)
        {
            BrokerVuelos UpdateVuelo = new BrokerVuelos();
            FormatDateForDB(ValuesVuelo);
            return UpdateVuelo.ActualizarVuelo(ValuesVuelo);
        }

        internal bool InactivarVuelo(int id_vuelo)
        {
            BrokerVuelos InactivateVuelo = new BrokerVuelos();
            return InactivateVuelo.InactivarVuelo(id_vuelo);
        }

        internal Dictionary<string, string> ValidarVuelo(int id_vuelo)
        {
            BrokerVuelos ValidateVuelo = new BrokerVuelos();
            Dictionary<string, string> ResultGetVuelo = ValidateVuelo.ConsultarVuelo(id_vuelo);

            if (ResultGetVuelo.Count > 0)
            {
                // Conversión de fechas
                if (string.IsNullOrEmpty(ResultGetVuelo.GetValueOrDefault("fecha_hora_salida")))
                    ResultGetVuelo["fecha_hora_salida"] = DateTime.MinValue.ToString();

                if (string.IsNullOrEmpty(ResultGetVuelo.GetValueOrDefault("fecha_hora_llegada")))
                    ResultGetVuelo["fecha_hora_llegada"] = DateTime.MinValue.ToString();

                // ✅ Conversión del estado
                string estado = ResultGetVuelo.GetValueOrDefault("estado_vuelo", "");
                if (estado == "1")
                    ResultGetVuelo["estado_vuelo"] = "Activo";
                else if (estado == "2")
                    ResultGetVuelo["estado_vuelo"] = "Inactivo";
                else
                    ResultGetVuelo["estado_vuelo"] = "Desconocido";
            }

            return ResultGetVuelo;
        }

        private static void FormatDateForDB(Dictionary<string, string> ValuesVuelo)
        {
            if (ValuesVuelo.ContainsKey("fecha_hora_salida") && !string.IsNullOrEmpty(ValuesVuelo["fecha_hora_salida"]))
            {
                if (DateTime.TryParse(ValuesVuelo["fecha_hora_salida"], out DateTime fechaSalida))
                    ValuesVuelo["fecha_hora_salida"] = fechaSalida.ToString("yyyy-MM-dd HH:mm:ss");
            }

            if (ValuesVuelo.ContainsKey("fecha_hora_llegada") && !string.IsNullOrEmpty(ValuesVuelo["fecha_hora_llegada"]))
            {
                if (DateTime.TryParse(ValuesVuelo["fecha_hora_llegada"], out DateTime fechaLlegada))
                    ValuesVuelo["fecha_hora_llegada"] = fechaLlegada.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
    }
}
