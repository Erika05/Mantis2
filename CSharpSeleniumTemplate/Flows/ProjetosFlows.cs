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
            gerenciarPage.ClicarEmGerenciar();
            criarProjetoPage.ClicarEmGerenciarProjeto();
        }
        public void AcessarTelaCadastroProjeto()
        {
            gerenciarPage.ClicarEmGerenciar();
            criarProjetoPage.ClicarEmGerenciarProjeto();
            criarProjetoPage.ClicarEmCriarPojeto();
        }

        public void CadastroProjeto(string nome, string estado, string descricao)
        {
            this.AcessarTelaCadastroProjeto();
            criarProjetoPage.PreencherNomeProjeto(nome);
            criarProjetoPage.PreencherEstadoProjeto(estado);
            criarProjetoPage.PreencherDescricaoProjeto(descricao);
            criarProjetoPage.ClicarEmCadastrarProjeto();
        }

        public void EditaProjeto(string nome, string nomeProjeto, string colunaProjeto)
        {
            this.AcessarTelaGestaoProjeto();
            criarProjetoPage.TelaEditarProjeto(nomeProjeto, colunaProjeto);
            criarProjetoPage.LimparNomeProjeto();
            criarProjetoPage.PreencherNomeProjeto(nome);
            criarProjetoPage.ClicarEmCadastrarProjeto();
        }
        public void ApagarProjeto(string nomeProjeto, string nomeColuna)
        {
            this.AcessarTelaGestaoProjeto();
            criarProjetoPage.TelaEditarProjeto(nomeProjeto, nomeColuna);
            criarProjetoPage.ClicarEmApagarProjeto();
            criarProjetoPage.ClicarEmApagarProjeto();
        }
    }
}