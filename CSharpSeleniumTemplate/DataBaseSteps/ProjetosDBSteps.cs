using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.DataBaseSteps
{
    public class ProjetosDBSteps
    {
        public static void InseriProjeto(string nomeProjeto)
        {
            string query = ProjetosQueries.InsereProjeto.Replace("$nomeProjeto", nomeProjeto);
            DataBaseHelpers.ExecuteQuery(query);
        }
        public static void DeletaProjeto(string nomeProjeto)
        {
            string query = ProjetosQueries.DeletaProjeto.Replace("$nomeProjeto", nomeProjeto);
            DataBaseHelpers.ExecuteQuery(query);
        }
        public static string RetornaProjeto(string nomeProjeto)
        {
            string query = ProjetosQueries.RetornaProjeto.Replace("$nomeProjeto", nomeProjeto);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }
        public static void DeletaTodosProjetos()
        {
            string query = ProjetosQueries.ApagarDadosTableProjetos;
            DataBaseHelpers.ExecuteQuery(query);
        }
    }
}