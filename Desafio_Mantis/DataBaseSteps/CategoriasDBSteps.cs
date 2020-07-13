using Desafio_Mantis.Helpers;
using Desafio_Mantis.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Mantis.DataBaseSteps
{
    public class CategoriasDBSteps
    {
        public static void InseriCategoria(string nomecategoria)
        {
            string query = CategoriasQueries.InsereCategoria.Replace("$nomecategoria", nomecategoria);
            DataBaseHelpers.ExecuteQuery(query);
        }
        public static void DeletaCategoria(string nomecategoria)
        {
            string query = CategoriasQueries.DeletaCategoria.Replace("$nomecategoria", nomecategoria);
            DataBaseHelpers.ExecuteQuery(query);
        }
        public static int RetornaCategoria(string nomecategoria)
        {
            string query = CategoriasQueries.RetornaCategoria.Replace("$nomecategoria", nomecategoria);
            return Int32.Parse(DataBaseHelpers.RetornaDadosQuery(query)[0]);
        }
    }
}
