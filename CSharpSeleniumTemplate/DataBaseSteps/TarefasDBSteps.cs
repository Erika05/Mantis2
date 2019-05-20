using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.DataBaseSteps
{
    public class TarefasDBSteps
    {
        public static string RetornaTarefas(string categoriaTarefa, string descricaoTarefa, string resumoTarefa)
        {
            string query = TarefasQueries.RetornaTarefa.Replace("$categoriaTarefa", categoriaTarefa.Replace("$descricaoTarefa", descricaoTarefa).Replace("$resumoTarefa", resumoTarefa));

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }
        public static void DeletaTarefa(string descricaoTarefa, string resumoTarefa)
        {
            string query = TarefasQueries.DeletaTarefa.Replace("$descricaoTarefa", descricaoTarefa).Replace("$resumoTarefa", resumoTarefa);
            DataBaseHelpers.ExecuteQuery(query);
        }
    }
}
