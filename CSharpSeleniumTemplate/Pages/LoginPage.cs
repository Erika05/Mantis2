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
        By usernameField = By.Id ("username");
        By passwordField = By.Id("password");
        By loginButton = By.XPath("//input[@value='Entrar']");
        By mensagemErroTextArea = By.ClassName ("alert-danger");
        #endregion

        #region Actions
        public void PreenhcerUsuario(string usuario)
        {
            SendKeysJavaScript(usernameField, usuario);
            ClickJavaScript(loginButton);
        }

        public void PreencherSenha(string senha)
        {
            SendKeysJavaScript(passwordField, senha);
        }

        public void ClicarEmEntrar()
        {
            ClickJavaScript(loginButton);
        }

        public string RetornaMensagemDeErro()
        {
            return GetText(mensagemErroTextArea);
        }
        #endregion
    }
}
