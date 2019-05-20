using CSharpSeleniumTemplate.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Flows
{
    public class CategoriasFlows
    {
        #region Page Object and Constructor
        GerenciarCategoriaPage gerenciarCategoriaPage;
        ProjetosFlows projetoFlows;
        public CategoriasFlows()
        {
            gerenciarCategoriaPage = new GerenciarCategoriaPage();
            projetoFlows = new ProjetosFlows();
        }
        #endregion
        public void ApagarCategoria(string nomeCategoria, string nomeColunaPesq, string nomeColunaAcao)
        {
            gerenciarCategoriaPage.ClicarEditarCategoria(nomeCategoria, nomeColunaPesq, nomeColunaAcao);
            gerenciarCategoriaPage.ClicaApagarCategoria();
            gerenciarCategoriaPage.ClicarConfirmarExclusaoCategoria();
        }
        public void CadastrarCategoria(string nomeCategoria)
        {
            projetoFlows.AcessarTelaGestaoProjeto();
            gerenciarCategoriaPage.PreencherCategoria(nomeCategoria);
            gerenciarCategoriaPage.ClicarAdicionarCategoria();
        }
        public void EditarCategoria(string nomeCategoria, string nomeCategoriaAlteracao, string nomeColunaPesq, string nomeColunaAcao)
        {
            gerenciarCategoriaPage.ClicarEditarCategoria(nomeCategoria, nomeColunaPesq, nomeColunaAcao);
            gerenciarCategoriaPage.LimparCampoNomeCategoria();
            gerenciarCategoriaPage.PreencherCategoriaEditar(nomeCategoriaAlteracao);
            gerenciarCategoriaPage.ClicarAtualizarCategoria();
        }

    }
}
