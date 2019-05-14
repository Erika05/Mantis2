using CSharpSeleniumTemplate.Bases;
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
    class GerenciarProjetos : TestBase
    {
        [AutoInstance] MainPage mainPage;
        [AutoInstance] GerenciarProjetoPage criarProjetoPage;
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] ProjetosFlows projetoFlows;

        [Test]
        public void CadastrarProjeto()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeProjeto = "nome do projeto";
            string estado = "desenvolvimento";
            string descricao = "descrição";
            string mensagemSucessoEsperada = "Operação realizada com sucesso.";
            string nomeColuna = "Nome";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            projetoFlows.CadastrarProjeto(nomeProjeto, estado, descricao);
            Assert.AreEqual(mensagemSucessoEsperada, criarProjetoPage.RetornaMensagemDeSucesso());
            Assert.IsTrue(criarProjetoPage.ValidarCadastroProjeto(nomeProjeto, nomeColuna), "Projeto não foi cadastrado.");
        }


        [Test]
        public void CadastradoJaRealizado()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeProjeto = "nome do projeto";
            string estado = "desenvolvimento";
            string descricao = "descrição";
            string mensagemErroEsperada = "Um projeto com este nome já existe. Por favor, volte e entre um nome diferente.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            projetoFlows.CadastrarProjeto(nomeProjeto, estado, descricao);
            Assert.AreEqual(mensagemErroEsperada, criarProjetoPage.RetornaMensagemDeErro());
        }

        [Test]
        public void CampoNomeProjetoNaoPreenchidos()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string mensagemObrigatoriedadeEsperada = "Preencha este campo.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            projetoFlows.AcessarTelaCadastroProjeto();
            criarProjetoPage.ClicarCadastrarProjeto();
            Assert.AreEqual(mensagemObrigatoriedadeEsperada, criarProjetoPage.RetornaMensagemObrigatoriedade());
        }

        [Test]
        public void EditarProjeto()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeProjeto = "nome do projeto";
            string colunaProjeto = "Nome";
            string nomeEdicao = "nome do projeto editado";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            projetoFlows.EditarProjeto(nomeProjeto, colunaProjeto, nomeEdicao);
            Assert.IsTrue(criarProjetoPage.ValidarCadastroProjeto(nomeEdicao, colunaProjeto), "Projeto não foi atualizado.");
        }

        [Test]
        public void ApagarProjeto()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeProjeto = "nome do projeto";
            string nomeColuna = "Nome";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            projetoFlows.ApagarProjeto(nomeProjeto, nomeColuna);
            Assert.IsTrue(criarProjetoPage.ValidarExclusaoProjeto(nomeProjeto, nomeColuna), "Projeto não foi excluído.");
        }
    }
}
