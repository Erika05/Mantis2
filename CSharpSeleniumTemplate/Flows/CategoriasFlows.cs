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
        public CategoriasFlows()
        {
            gerenciarCategoriaPage = new GerenciarCategoriaPage();
        }
        #endregion
        public void ApagarCategoria(string nomeCategoria, string nomeColunaPesq, string nomeColunaAcao)
        {
            gerenciarCategoriaPage.ClicaEditarCategoria(nomeCategoria, nomeColunaPesq, nomeColunaAcao);
            gerenciarCategoriaPage.ClicaApagarCategoria();
            gerenciarCategoriaPage.ClicaConfirmarExclusaoCategoria();
        }
        public void CadastrarCategoria(string nomeCategoria)
        {
            gerenciarCategoriaPage.PreencherCategoria(nomeCategoria);
            gerenciarCategoriaPage.ClicarAdicionar();
        }
        public void EditarCategoria(string nomeCategoria, string nomeCategoriaAlteracao, string nomeColunaPesq, string nomeColunaAcao)
        {
            gerenciarCategoriaPage.ClicaEditarCategoria(nomeCategoria, nomeColunaPesq, nomeColunaAcao);
            gerenciarCategoriaPage.LimparCategoria();
            gerenciarCategoriaPage.PreencherCategoriaEditar(nomeCategoriaAlteracao);
            gerenciarCategoriaPage.ClicarAtualizar();
        }

    }
}
