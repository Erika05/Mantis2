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
        By categoriaTextarea = By.Name("name");
        By adicionarButton = By.XPath("//input[@value='Adicionar Categoria']");
        By tableCategoria = By.XPath("//*[@id='categories']//table");
        By MsgErro = By.XPath("//*[@id='main-container']//p[2]");
        By atualizarButton = By.XPath("//input[@value='Atualizar Categoria']");
        By MsgSucesso = By.XPath("//div[@id='main-container']//p");
        By nomeCategoriaEditar = By.Id("proj-category-name");
        By apagarButton = By.XPath("//*[@id='main-container']//input[4]");
        By confirmaExclusaoButton = By.XPath("//input[@value='Apagar Categoria']");
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