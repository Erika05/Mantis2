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
        public static void InseriMarcador(string nomemarcador)
        {
            string query = MarcadoresQueries.InsereMarcador.Replace("$nomemarcador", nomemarcador);
            DataBaseHelpers.ExecuteQuery(query);
        }
        public static void DeletaMarcador(string nomemarcador)
        {
            string query = MarcadoresQueries.DeletaMarcador.Replace("$nomemarcador", nomemarcador);
            DataBaseHelpers.ExecuteQuery(query);
        }
        public static void DeletaTosdosMarcores()
        {
            string query = MarcadoresQueries.ApagaTodosMacadores;
            DataBaseHelpers.ExecuteQuery(query);
        }
    }
}
