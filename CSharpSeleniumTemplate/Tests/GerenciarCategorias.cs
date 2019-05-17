using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.DataBaseSteps;
using CSharpSeleniumTemplate.Flows;
using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Tests
{
    [TestFixture]
    class GerenciarCategorias : TestBase
    {
        [AutoInstance] MainPage mainPage;
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] ProjetosFlows projetoFlows;
        [AutoInstance] GerenciarCategoriaPage gerenciarCategoriasPage;
        [AutoInstance] CategoriasFlows categoriaFlows;

        [Test]
        public void CadastrarCategoria()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeCategoria = "categoria";
            string nomeColuna = "Categoria";
            #endregion
            CategoriasDBSteps.DeletaCategoria(nomeCategoria);
            loginFlows.EfetuarLogin(usuario, senha);
            projetoFlows.AcessarTelaGestaoProjeto();
            categoriaFlows.CadastrarCategoria(nomeCategoria);
            Assert.IsTrue(gerenciarCategoriasPage.ValidarCadastroCategoria(nomeCategoria, nomeColuna), "Categoria não cadastrada");
        }
        [Test]
        public void CategoriaJaCadastrada()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeCategoria = "categoria";
            string mensagemErroEsperada = "Uma categoria com este nome já existe.";
            #endregion
            CategoriasDBSteps.InseriCategoria(nomeCategoria);
            loginFlows.EfetuarLogin(usuario, senha);
            projetoFlows.AcessarTelaGestaoProjeto();
            categoriaFlows.CadastrarCategoria(nomeCategoria);
            Assert.AreEqual(mensagemErroEsperada, gerenciarCategoriasPage.RetornaMensagemDeErro());
        }

        [Test]
        public void CampoObrigatorioNaoPreenchido()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string mensagemErroEsperada = "Um campo necessário 'Categoria' estava vazio. Por favor, verifique novamente suas entradas.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            projetoFlows.AcessarTelaGestaoProjeto();
            gerenciarCategoriasPage.ClicarAdicionarCategoria();
            Assert.AreEqual(mensagemErroEsperada, gerenciarCategoriasPage.RetornaMensagemDeErro());
        }
        [Test]
        public void EditarCategoria()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeCategoria = "categoria";
            string nomeColunaPesq = "Categoria";
            string nomeColunaAcao = "Ações";
            string nomeCategoriaAlteracao = "categoria auteracao";
            string mensagemSucessoEsperada = "Operação realizada com sucesso.";
            #endregion
            CategoriasDBSteps.InseriCategoria(nomeCategoria);
            loginFlows.EfetuarLogin(usuario, senha);
            projetoFlows.AcessarTelaGestaoProjeto();
            categoriaFlows.EditarCategoria(nomeCategoria, nomeCategoriaAlteracao, nomeColunaPesq, nomeColunaAcao);
            Assert.AreEqual(mensagemSucessoEsperada, gerenciarCategoriasPage.RetornaMensagemDeSucesso());
            Assert.IsTrue(gerenciarCategoriasPage.ValidarCadastroCategoria(nomeCategoriaAlteracao, nomeColunaPesq), "Categoria não atualziada.");
        }

        [Test]
        public void ApagarCategoria()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeCategoria = "categoria";
            string nomeColunaPesq = "Categoria";
            string nomeColunaAcao = "Ações";
            #endregion
            CategoriasDBSteps.InseriCategoria(nomeCategoria);
            loginFlows.EfetuarLogin(usuario, senha);
            projetoFlows.AcessarTelaGestaoProjeto();            
            categoriaFlows.ApagarCategoria(nomeCategoria, nomeColunaPesq, nomeColunaAcao);
            Assert.IsTrue(gerenciarCategoriasPage.ValidaExclusaoCategoria(nomeCategoria, nomeColunaPesq), "Categoria não excluído.");
        }
    }
}
