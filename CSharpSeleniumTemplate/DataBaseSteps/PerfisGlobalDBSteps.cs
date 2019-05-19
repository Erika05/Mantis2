using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.DataBaseSteps
{
    public class PerfisGlobalDBSteps
    {
        public static void InserirPerfilGlobal(string nomeplatafornma, string nomeso, string nomeversaoso)
        {
            string query = PerfisGlobalQueries.InserePerfilGlobal.Replace("$nomeplatafornma", nomeplatafornma).Replace("$nomeso", nomeso).Replace("$nomeversaoso", nomeversaoso);
            DataBaseHelpers.ExecuteQuery(query);
        }
        public static void DeletaPerfilGlobal(string nomeplatafornma, string nomeso, string nomeversaoso)
        {
            string query = PerfisGlobalQueries.DeletaPerfilGlobal.Replace("$nomeplatafornma", nomeplatafornma).Replace("$nomeso", nomeso).Replace("$nomeversaoso", nomeversaoso);
            DataBaseHelpers.ExecuteQuery(query);
        }
        public static void DeletaTosdosPerfisGlobal()
        {
            string query = PerfisGlobalQueries.ApagaTodosPerfisGlobal;
            DataBaseHelpers.ExecuteQuery(query);
        }
    }
}
