using Desafio_Mantis.Bases;
using Desafio_Mantis.DataBaseSteps;
using Desafio_Mantis.Flows;
using Desafio_Mantis.Helpers;
using Desafio_Mantis.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Mantis.Tests
{
    [TestFixture]
    class GerenciarCategorias : TestBase
    {
        [AutoInstance] LoginFlows loginFlows;        
        [AutoInstance] GerenciarCategoriaPage gerenciarCategoriasPage;
        [AutoInstance] CategoriasFlows categoriaFlows;
        [AutoInstance] ProjetosFlows projetoFlows;

        [Test]
        public void CadastrarCategoria()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeCategoria = "categoria-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            categoriaFlows.CadastrarCategoria(nomeCategoria);
            Assert.AreEqual(1, CategoriasDBSteps.RetornaCategoria(nomeCategoria), "Categoria não foi gravada no banco.");
            CategoriasDBSteps.DeletaCategoria(nomeCategoria);
        }
        [Test]
        public void CategoriaJaCadastrada()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeCategoria = "categoria-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string mensagemErroEsperada = "Uma categoria com este nome já existe.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            categoriaFlows.CadastrarCategoria(nomeCategoria);
            categoriaFlows.CadastrarCategoria(nomeCategoria);
            Assert.AreEqual(mensagemErroEsperada, gerenciarCategoriasPage.RetornaMensagemDeErro());
            CategoriasDBSteps.DeletaCategoria(nomeCategoria);
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
            string nomeCategoria = "categoria-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string nomeColunaPesq = "Categoria";
            string nomeColunaAcao = "Ações";
            string nomeCategoriaEdicao = "categoria auteracao-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string mensagemSucessoEsperada = "Operação realizada com sucesso.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            categoriaFlows.CadastrarCategoria(nomeCategoria);
            categoriaFlows.EditarCategoria(nomeCategoria, nomeCategoriaEdicao, nomeColunaPesq, nomeColunaAcao);
            Assert.AreEqual(mensagemSucessoEsperada, gerenciarCategoriasPage.RetornaMensagemDeSucesso());
            Assert.AreEqual(1, CategoriasDBSteps.RetornaCategoria(nomeCategoriaEdicao), "Categoria não foi alterada no banco.");
            Assert.AreEqual(0, CategoriasDBSteps.RetornaCategoria(nomeCategoria), "Categoria não foi alterada no banco.");
            CategoriasDBSteps.DeletaCategoria(nomeCategoriaEdicao);
        }

        [Test]
        public void ApagarCategoria()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeCategoria = "categoria-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string nomeColunaPesq = "Categoria";
            string nomeColunaAcao = "Ações";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            categoriaFlows.CadastrarCategoria(nomeCategoria);
            categoriaFlows.ApagarCategoria(nomeCategoria, nomeColunaPesq, nomeColunaAcao);
            Assert.AreEqual(0, CategoriasDBSteps.RetornaCategoria(nomeCategoria), "Categoria não foi alterada no banco.");
        }
    }
}
