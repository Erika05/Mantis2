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
        public static void InserirPerfilGlobal(string nomeplataforma, string nomeso, string nomeversaoso)
        {
            string query = PerfisGlobalQueries.InserePerfilGlobal.Replace("$nomeplataforma", nomeplataforma).Replace("$nomeso", nomeso).Replace("$nomeversaoso", nomeversaoso);
            DataBaseHelpers.ExecuteQuery(query);
        }
        public static void DeletaPerfilGlobal(string nomeplataforma, string nomeso, string nomeversaoso)
        {
            string query = PerfisGlobalQueries.DeletaPerfilGlobal.Replace("$nomeplataforma", nomeplataforma).Replace("$nomeso", nomeso).Replace("$nomeversaoso", nomeversaoso);
            DataBaseHelpers.ExecuteQuery(query);
        }
        public static void DeletaTosdosPerfisGlobal()
        {
            string query = PerfisGlobalQueries.ApagaTodosPerfisGlobal;
            DataBaseHelpers.ExecuteQuery(query);
        }
        public static int  RetornaPerfilGlobal(string nomeplataforma, string nomeso, string nomeversaoso)
        {
            string query = PerfisGlobalQueries.RetornaPerfilGlobal.Replace("$nomeplataforma", nomeplataforma).Replace("$nomeso", nomeso).Replace("$nomeversaoso", nomeversaoso);
            return Int32.Parse(DataBaseHelpers.RetornaDadosQuery(query)[0]);
        }
    }
}
