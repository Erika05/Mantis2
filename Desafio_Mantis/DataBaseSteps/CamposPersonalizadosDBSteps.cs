using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.DataBaseSteps
{
    public class CamposPersonalizadosDBSteps
    {
        public static void InseriCampo(string nomeCampo)
        {
            string query = CamposPersonalizadosQueries.InsereCampoPersonalizado.Replace("$nomecampo", nomeCampo);
            DataBaseHelpers.ExecuteQuery(query);
        }
        public static void DeletaCampo(string nomeCampo)
        {
            string query = CamposPersonalizadosQueries.DeletaCampoPersonalizado.Replace("$nomecampo", nomeCampo);
            DataBaseHelpers.ExecuteQuery(query);
        }
        public static int RetornaCampo(string nomeCampo)
        {
            string query = CamposPersonalizadosQueries.RetornaCampoPersonalizado.Replace("$nomecampo", nomeCampo);
            return Int32.Parse(DataBaseHelpers.RetornaDadosQuery(query)[0]);
        }
        public static void DeletaTodosCampos()
        {
            string query = CamposPersonalizadosQueries.ApagaTodosCamposPersonalizados;
            DataBaseHelpers.ExecuteQuery(query);
        }
    }
}
