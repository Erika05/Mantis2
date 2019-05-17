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
        public static void InseriUsuarioCamposObrigatorios(string username)
        {
            string query = UsuariosQueries.InseriUsuarioCamposObrigatorios.Replace("$username", username);
            DataBaseHelpers.ExecuteQuery(query);
        }
        public static void InseriUsuarioTodosCampos(string username, string realname, string email)
        {
            string query = UsuariosQueries.InseriUsuarioTodosCampos.Replace("$username", username).Replace("$realname", realname).Replace("$email", email);
            DataBaseHelpers.ExecuteQuery(query);
        }
        public static void DeletaUsuario(string username, string useremail)
        {
            string query = UsuariosQueries.DelataUsuario.Replace("$username", username).Replace("$useremail", useremail);
            DataBaseHelpers.ExecuteQuery(query);
        }
        public static void DeletaTososUsuarios()
        {
            string query = UsuariosQueries.DetalaTodosUsuariosExcetoAdministrator;
            DataBaseHelpers.ExecuteQuery(query);
        }
    }
}