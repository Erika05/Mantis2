using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.DataBaseSteps;
using CSharpSeleniumTemplate.Flows;
using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Pages;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Tests
{
    [TestFixture]
    class GerenciarUsuarios : TestBase
    {
        #region Pages and Flows Objects
        [AutoInstance] MainPage mainPage;
        [AutoInstance] GerenciarUsuariosPage gerenciarUsuariosPage;
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] UsuariosFlows usuariosFlows;
        #endregion

        #region Data Driven Providers
        public static IEnumerable PesquisarUsuariosSucesso()
        {
            return GeneralHelpers.ReturnCSVData(GeneralHelpers.ReturnProjectPath() + "Resources/TestData/Usuarios/PesquisarUsuariosData.csv");
        }
        #endregion

        [Test]
        public void CadastrarUsuarioApenasCamposObrigatorios()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeUsuario = "user";
            string nivel = "relator";
            string mensagemSucessoEsperada = "Usuário " + nomeUsuario + " criado com um nível de acesso de " + nivel;
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            usuariosFlows.CadastrarUsuarioApenasCamposObrigatorios(nomeUsuario, nivel);
            Assert.AreEqual(mensagemSucessoEsperada, gerenciarUsuariosPage.RetornaMensagemDeSucesso());
            Assert.AreEqual(nomeUsuario, gerenciarUsuariosPage.ValidarCadastroUsuario(nomeUsuario));
        }
        [Test]
        public void CadastrarUsuarioTodosCampos()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeUsuario = "userOp";
            string nomeVerdadeiro = "Luisa";
            string email = "teste@teste.com.br";
            string nivel = "relator";
            string mensagemSucessoEsperada = "Usuário " + nomeUsuario + " criado com um nível de acesso de " + nivel;
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            usuariosFlows.CadastrarUsuarioTodosCampos(nomeUsuario, nomeVerdadeiro, email, nivel);
            Assert.AreEqual(mensagemSucessoEsperada, gerenciarUsuariosPage.RetornaMensagemDeSucesso());
            Assert.AreEqual(nomeUsuario, gerenciarUsuariosPage.ValidarCadastroUsuario(nomeUsuario));
        }

        [Test]
        public void CampoNomeNaoPreenchido()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nivel = "relator";
            string mensagemErroEsperada = "O nome de usuário não é inválido. Nomes de usuário podem conter apenas letras, números, espaços, hífens, pontos, sinais de mais e sublinhados.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            usuariosFlows.AcessarTelaCadastroUsuarios();
            gerenciarUsuariosPage.PreencherNivel(nivel);
            gerenciarUsuariosPage.ClicarCadastraUsuario();
            Assert.AreEqual(mensagemErroEsperada, gerenciarUsuariosPage.RetornaMensagemDeErro());
        }
        [Test]
        public void UsuarioJaCadastrado()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeUsuario = "user";
            string nivel = "relator";
            string mensagemErroEsperada = "Este nome de usuário já está sendo usado. Por favor, volte e selecione um outro.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            usuariosFlows.CadastrarUsuarioApenasCamposObrigatorios(nomeUsuario, nivel);            
            Assert.AreEqual(mensagemErroEsperada, gerenciarUsuariosPage.RetornaMensagemDeErro());
        }
        [Test]
        public void EmailJaCadastrado()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator"; ;
            string nomeUsuario = "userOpx";
            string nomeVerdadeiro = "Luisa";
            string email = "teste@teste.com.br";
            string nivel = "relator";
            string mensagemErroEsperada = "Este e-mail já está sendo usado. Por favor, volte e selecione outro.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);            
            usuariosFlows.CadastrarUsuarioTodosCampos(nomeUsuario, nomeVerdadeiro, email, nivel);
            Assert.AreEqual(mensagemErroEsperada, gerenciarUsuariosPage.RetornaMensagemDeErro());
        }

        [Test]
        public void EditarUsuario()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeUsuario = "user";
            string nomeUsuarioEdicao = "user editado";
            string nomeColuna = "Nome de usuário";
            string mensagemSucessoEsperada = "Operação realizada com sucesso.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            usuariosFlows.EdiatarUsuario(nomeUsuario, nomeUsuarioEdicao, nomeColuna);
            Assert.AreEqual(mensagemSucessoEsperada, gerenciarUsuariosPage.RetornaMensagemDeSucesso());
            Assert.AreEqual(nomeUsuarioEdicao, gerenciarUsuariosPage.ValidarCadastroUsuario(nomeUsuario));
        }
        [Test]
        public void ApagarUsuario()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeUsuario = "user";
            string nomeColuna = "Nome de usuário";
            string mensagemSucessoEsperada = "Operação realizada com sucesso.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            usuariosFlows.ApagarUsuario(nomeUsuario, nomeColuna);
            Assert.AreEqual(mensagemSucessoEsperada, gerenciarUsuariosPage.RetornaMensagemDeSucesso());
            Assert.IsTrue(gerenciarUsuariosPage.ValidarExclusaoUsuario(nomeUsuario, nomeColuna), "Usuário não foi excluído.");
        }
        [Test]
        public void RedefinirSenhaSemPreencherEmail()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeUsuario = "user";
            string nomeColuna = "Nome de usuário";
            string mensagemErroEsperada = "Você deve fornecer um endereço de e-mail para poder reajustar a senha.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            usuariosFlows.RedefinirSenhaUsuario(nomeUsuario, nomeColuna);
            Assert.AreEqual(mensagemErroEsperada, gerenciarUsuariosPage.RetornaMensagemDeErro());
        }
        [Test]
        public void EmailInvalido()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeUsuario = "user";
            string email = "xxx";
            string mensagemErroEsperada = "E-mail inválido.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            usuariosFlows.EmailInvalido(nomeUsuario, email);
            Assert.AreEqual(mensagemErroEsperada, gerenciarUsuariosPage.RetornaMensagemDeErro());
        }

        [Test, TestCaseSource("PesquisarUsuariosSucesso")]
        public void PesquisarUsuarios(ArrayList testData)
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string valorFiltro = testData[1].ToString();
            string nomeColuna = testData[0].ToString();
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            usuariosFlows.RealizarPesquisa(valorFiltro);
            Assert.IsTrue(gerenciarUsuariosPage.ValidarRetornoPesquisa(valorFiltro, nomeColuna), "Dados retornados na pesquisa são diferentes do filtro informado.");
        }
    }
}
