using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAFIT_BaseDeDatos.Core.EAFIT_MANAGER
{
    class ManagerLogin
    {
        internal Dictionary<bool, string> ValidarLogin(string Usuario, string Password)
        {
            EAFIT_BROKER.BrokerLogin LoginValidate = new EAFIT_BROKER.BrokerLogin();
            Dictionary<bool, string> values = new Dictionary<bool, string>();
            List<string> Result = new List<string>();
            Result = LoginValidate.ValidarLogin(Usuario);

            if (Result.Count > 0)
            {
                if (Result[0].ToString() == Password)
                    values.Add(true, "LogeoCorrecto");
                else
                    values.Add(false, "Contraseña incorrecta, favor validar la contraseña ingresada");
            }
            else
                values.Add(false, "El usuario no existe, por favor validar el usuario ingresado");

            return values;

        }

    }
}
