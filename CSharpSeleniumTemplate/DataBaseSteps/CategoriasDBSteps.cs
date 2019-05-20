using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.DataBaseSteps
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
    }
}
