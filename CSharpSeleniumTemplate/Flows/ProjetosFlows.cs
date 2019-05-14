using CSharpSeleniumTemplate.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Flows
{
    public class ProjetosFlows
    {
        #region Page Object and Constructor
        GerenciarProjetoPage criarProjetoPage;
        GerenciarPage gerenciarPage;
        public ProjetosFlows()
        {
            gerenciarPage = new GerenciarPage();
            criarProjetoPage = new GerenciarProjetoPage();
        }
        #endregion

        public void AcessarTelaGestaoProjeto()
        {
            gerenciarPage.ClicarGerenciar();
            criarProjetoPage.ClicarGerenciarProjeto();
        }
        public void AcessarTelaCadastroProjeto()
        {
            gerenciarPage.ClicarGerenciar();
            criarProjetoPage.ClicarGerenciarProjeto();
            criarProjetoPage.ClicarCriarPojeto();
        }

        public void CadastrarProjeto(string nome, string estado, string descricao)
        {
            this.AcessarTelaCadastroProjeto();
            criarProjetoPage.PreencherNomeProjeto(nome);
            criarProjetoPage.PreencherEstadoProjeto(estado);
            criarProjetoPage.PreencherDescricaoProjeto(descricao);
            criarProjetoPage.ClicarCadastrarProjeto();
        }

        public void EditarProjeto(string nome, string nomeProjeto, string colunaProjeto)
        {
            this.AcessarTelaGestaoProjeto();
            criarProjetoPage.AcessarTelaEditarProjeto(nomeProjeto, colunaProjeto);
            criarProjetoPage.LimparNomeProjeto();
            criarProjetoPage.PreencherNomeProjeto(nome);
            criarProjetoPage.ClicarCadastrarProjeto();
        }
        public void ApagarProjeto(string nomeProjeto, string nomeColuna)
        {
            this.AcessarTelaGestaoProjeto();
            criarProjetoPage.AcessarTelaEditarProjeto(nomeProjeto, nomeColuna);
            criarProjetoPage.ClicarEmApagarProjeto();
            criarProjetoPage.ClicarEmApagarProjeto();
        }
    }
}