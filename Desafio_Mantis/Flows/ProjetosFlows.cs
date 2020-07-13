using Desafio_Mantis.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Mantis.Flows
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

        public void EditarProjeto(string nomeAtual, string nomeProjetoEdicao, string colunaProjeto)
        {
            this.AcessarTelaGestaoProjeto();
            criarProjetoPage.AcessarTelaEditarProjeto(nomeAtual, colunaProjeto);
            criarProjetoPage.LimparNomeProjeto();
            criarProjetoPage.PreencherNomeProjeto(nomeProjetoEdicao);
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