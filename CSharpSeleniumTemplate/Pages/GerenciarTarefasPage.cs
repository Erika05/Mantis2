using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
    public class GerenciarTarefasPage : PageBase
    {
        #region Mapping
        By acessoVerTarefasButton = By.XPath("//*[@id='sidebar']/ul/li[2]/a/span");
        By filtroTextarea = By.Id("filter-search-txt");
        By pesquisaButton = By.XPath("//*[@id='filter']/div[3]/div[1]/div/input[2]");
        By tableRetornoPesquisa = By.Id("buglist");
        By opcaoSeleciona = By.XPath("//form[@id='bug_action']/div/div[2]/div[2]/div[2]/div/label/span");
        By editarTarefaButton = By.XPath("//*[@id='buglist']/tbody/tr[1]/td[2]/a/i");
        By tituloEditarTarefa = By.XPath("//*[@id='update_bug_form']/div/div[1]/h4");
        By tituloDetalheTarefa = By.XPath("//*[@id='main-container']/div[2]/div[2]/div/div[1]/div/div[1]/h4");
        By opcaoVoltarButton = By.XPath("//*[@id='update_bug_form']/div/div[1]/div/div/a");
        By atualizarInformacaoButton = By.XPath("//input[@value='Atualizar Informação']");
        By adicionarAnotacaoButton = By.XPath("//input[@value='Adicionar Anotação']");
        By MsgErro = By.XPath("//*[@id='main-container']/div[2]/div[2]/div/div/div[2]/p[2]");
        #endregion
        public void TelaVerTarefas()
        {
            Click(acessoVerTarefasButton);
        }

        public void PreencherFiltro(string valorFiltro)
        {
            SendKeys(filtroTextarea, valorFiltro);
        }

        public void ClicarEmPesquisar()
        {
            Click(pesquisaButton);
        }

        public void LimparFiltro()
        {
            Clear(filtroTextarea);
        }

        public bool RetornoPesquisa(string valorFiltro, string nomeColuna)
        {
            return VerificarRetornoPesquisa(tableRetornoPesquisa, valorFiltro, nomeColuna);
        }
        public void ClicarOpcaoSeleciona()
        {
            Click(opcaoSeleciona);
        }
        public bool ValidaSelecao()
        {
            return ValidarSelecaoTodos(tableRetornoPesquisa);
        }
        public void AcessarEditarTarefa()
        {
            Click(editarTarefaButton);
        }
        public string RetornaTituloEditarTarefa()
        {
            return GetText(tituloEditarTarefa);
        }
        public void ClicarOpcaoVoltar()
        {
            Click(opcaoVoltarButton);
        }
        public string RetornaTituloDetalheTarefa()
        {
            return GetText(tituloDetalheTarefa);
        }
        public void ClicarEmAtualizarInformacao()
        {
            Click(atualizarInformacaoButton);
        }
        public void ClicarEmAdicionarAnotacao()
        {
            Click(adicionarAnotacaoButton);
        }
        public string RetornaMensagemDeErro()
        {
            return GetText(MsgErro);
        }
    }
}