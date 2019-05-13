using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
    public class LoginPage : PageBase
    {
        #region Mapping
        By usernameField = By.Name("username");
        By passwordField = By.Name("password");
        By loginButton = By.XPath("//input[@value='Entrar']");
        By mensagemErroTextArea = By.ClassName ("alert-danger");
        #endregion

        #region Actions
        public void PreenhcerUsuario(string usuario)
        {
            SendKeys(usernameField, usuario);
            Click(loginButton);
        }

        public void PreencherSenha(string senha)
        {
            SendKeys(passwordField, senha);
        }

        public void ClicarEmEntrar()
        {
            Click(loginButton);
        }

        public string RetornaMensagemDeErro()
        {
            return GetText(mensagemErroTextArea);
        }
        #endregion
    }
}
