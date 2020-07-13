using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.DataBaseSteps
{
    public class MarcadoresDBSteps
    {
        public static void DeletaMarcador(string nomemarcador)
        {
            string query = MarcadoresQueries.DeletaMarcador.Replace("$nomemarcador", nomemarcador);
            DataBaseHelpers.ExecuteQuery(query);
        }
        public static int RetornaMarcado(string nomemarcador)
        {
            string query = MarcadoresQueries.RetornaMarcador.Replace("$nomemarcador", nomemarcador);
            return Int32.Parse(DataBaseHelpers.RetornaDadosQuery(query)[0]);
        }
    }
}
