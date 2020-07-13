using Desafio_Mantis.Helpers;
using Desafio_Mantis.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Mantis.DataBaseSteps
{
    public class UsuariosDBSteps
    {
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
        public static void DeletaEmailUsuario(string email)
        {
            string query = UsuariosQueries.DeletaEmailUsuario.Replace("$$email", email);
            DataBaseHelpers.ExecuteQuery(query);
        }
    }
}