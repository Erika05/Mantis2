using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
    public class GerenciarCategoriaPage : PageBase
    {
        #region Mapping
        By categoriaTextarea = By.XPath("//*[@id='categories']/div/div[2]/form/div/input[3]");
        By adicionarButton = By.XPath("//*[@id='categories']/div/div[2]/form/div/input[4]");
        By tableCategoria = By.XPath("//*[@id='categories']/div/div[2]/div/div");
        By MsgErro = By.XPath("//*[@id='main-container']/div[2]/div[2]/div/div/div[2]/p[2]");
        By atualizarButton = By.XPath("//*[@id='manage-proj-category-update-form']/div/div[3]/input");
        By MsgSucesso = By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div/div[2]/p");
        By nomeCategoriaEditar = By.Id("proj-category-name");
        By apagarButton = By.XPath("//*[@id='main-container']/div[2]/div[2]/div/div[2]/form/fieldset/input[4]");
        By confirmaExclusaoButton = By.XPath("//*[@id='main-container']/div[2]/div[2]/div/div/div[2]/form/input[5]");
        #endregion

        public void PreencherCategoria(string categoria)
        {
            SendKeys(categoriaTextarea, categoria);
        }

        public void ClicarAdicionarCategoria()
        {
            Click(adicionarButton);
        }
        public string RetornaMensagemDeErro()
        {
            return GetText(MsgErro);
        }
        public void ClicarEditarCategoria(string nomeCategoria, string nomeColunaPesq, string nomeColunaClick)
        {
            ClicarBotaoLinha(tableCategoria, nomeColunaPesq, nomeCategoria, nomeColunaClick);
        }
        public void LimparCampoNomeCategoria()
        {
            Clear(nomeCategoriaEditar);
        }
        public void PreencherCategoriaEditar(string categoria)
        {
            SendKeys(nomeCategoriaEditar, categoria);
        }
        public void ClicarAtualizarCategoria()
        {
            Click(atualizarButton);
        }
        public string RetornaMensagemDeSucesso()
        {
            return GetText(MsgSucesso);
        }

        public void ClicaApagarCategoria()
        {
            Click(apagarButton);
        }
        public void ClicarConfirmarExclusaoCategoria()
        {
            Click(confirmaExclusaoButton);
        }
    }
}