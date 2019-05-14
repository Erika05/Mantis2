using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
    public class GerenciarProjetoPage : PageBase
    {
        #region Mapping
        By menuGerenciarProjeto = By.LinkText("Gerenciar Projetos");
        By criarProjetoButton = By.XPath("//button[@type='submit']");
        By nomeTextarea = By.Id("project-name");
        By estadoSelect = By.Id("project-status");
        By descricaoTextarea = By.Id("project-description");
        By MsgSucesso = By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div/div[2]/p");
        By adicionarTarefaButton = By.ClassName("btn-white");
        By MsgErro = By.XPath("//*[@id='main-container']/div[2]/div[2]/div/div/div[2]/p[2]");
        By tableProjetos = By.XPath("//*[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]");
        By apagarProjetoButton = By.XPath("//input[@value='Apagar Projeto']");
        #endregion

        public void ClicarGerenciarProjeto()
        {
            Click(menuGerenciarProjeto);
        }
        public void PreencherNomeProjeto(string nome)
        {
            SendKeys(nomeTextarea, nome);
        }

        public void PreencherEstadoProjeto(string estado)
        {
            ComboBoxSelectByVisibleText(estadoSelect, estado);
        }

        public void PreencherDescricaoProjeto(string descricao)
        {
            SendKeys(descricaoTextarea, descricao);
        }

        public string RetornaMensagemDeSucesso()
        {
            return GetText(MsgSucesso);
        }

        public bool ValidarCadastroProjeto(string nomeProjeto, string colunaProjeto)
        {
            return ValidarCadastro(tableProjetos, nomeProjeto, colunaProjeto);
        }

        public bool ValidarExclusaoProjeto(string nomeProjeto, string colunaProjeto)
        {
            return ValidarExclusao(tableProjetos, nomeProjeto, colunaProjeto);
        }
        public string RetornaMensagemDeErro()
        {
            return GetText(MsgErro);
        }

        public void ClicarCadastrarProjeto()
        {
            Click(adicionarTarefaButton);
        }             

        public void ClicarCriarPojeto()
        {
            Click(criarProjetoButton);
        }
        public string RetornaMensagemObrigatoriedade()
        {
            return GetAttribute(nomeTextarea, "validationMessage");
        }

        public void AcessarTelaEditarProjeto(string nomeProjeto, string colunaNome)
        {
            ClicarSobreLinha(tableProjetos, colunaNome, nomeProjeto);
        }

        public void LimparNomeProjeto()
        {
            Clear(nomeTextarea);
        }
        public void ClicarEmApagarProjeto()
        {
            Click(apagarProjetoButton);
        }
    }
}