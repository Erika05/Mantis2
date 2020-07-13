using Desafio_Mantis.Helpers;
using Desafio_Mantis.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Mantis.DataBaseSteps
{
    public class TarefasDBSteps
    {
        public static int RetornaTarefas(string descricaoTarefa, string resumoTarefa)
        {
            string query = TarefasQueries.RetornaTarefa.Replace("$descricaoTarefa", descricaoTarefa).Replace("$resumoTarefa", resumoTarefa);
            return Int32.Parse(DataBaseHelpers.RetornaDadosQuery(query)[0]);
        }
        public static void DeletaTarefa(string descricaoTarefa, string resumoTarefa)
        {
            string query = TarefasQueries.DeletaTarefa.Replace("$descricaoTarefa", descricaoTarefa).Replace("$resumoTarefa", resumoTarefa);
            DataBaseHelpers.ExecuteQuery(query);
        }
    }
}
