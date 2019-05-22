using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.DataBaseSteps
{
    public class UsuariosDBSteps
    {
        public static string RetornaSenhaDoUsuario(string username)
        {
            string query = UsuariosQueries.RetornaSenhaUsuario.Replace("$username", username);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }
        public static void DeletaUsuario(string username)
        {
            string query = UsuariosQueries.DelataUsuario.Replace("$username", username);
            DataBaseHelpers.ExecuteQuery(query);
        }
        public static int RetornaUsuarios(string username)
        {
            string query = UsuariosQueries.RetornaUsuario.Replace("$username", username);
            return Int32.Parse(DataBaseHelpers.RetornaDadosQuery(query)[0]);
        }
    }
}