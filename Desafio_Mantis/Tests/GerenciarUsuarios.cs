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
            string nomeUsuario = "user-"+ GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string nivel = "relator";
            string mensagemSucessoEsperada = "Usuário " + nomeUsuario + " criado com um nível de acesso de " + nivel;
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            usuariosFlows.CadastrarUsuarioApenasCamposObrigatorios(nomeUsuario, nivel);
            Assert.AreEqual(mensagemSucessoEsperada, gerenciarUsuariosPage.RetornaMensagemDeSucesso());
            Assert.AreEqual(1, UsuariosDBSteps.RetornaUsuarios(nomeUsuario), "Usuário não foi gravado no banco de dados");
            UsuariosDBSteps.DeletaUsuario(nomeUsuario);
        }
        [Test]
        public void CadastrarUsuarioTodosCampos()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeUsuario = "userOp-"+ GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string nomeVerdadeiro = "Luisa-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string email = "teste@" + GeneralHelpers.ReturnStringWithRandomNumbers(8) + ".com.br";
            string nivel = "relator";
            string mensagemSucessoEsperada = "Usuário " + nomeUsuario + " criado com um nível de acesso de " + nivel;
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            usuariosFlows.CadastrarUsuarioTodosCampos(nomeUsuario, nomeVerdadeiro, email, nivel);
            Assert.AreEqual(mensagemSucessoEsperada, gerenciarUsuariosPage.RetornaMensagemDeSucesso());
            Assert.AreEqual(1, UsuariosDBSteps.RetornaUsuarios(nomeUsuario), "Usuário não foi salvo no banco de dados");
            UsuariosDBSteps.DeletaUsuario(nomeUsuario);
            UsuariosDBSteps.DeletaEmailUsuario(email);
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
            string nomeUsuario = "user-"+ GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string nivel = "relator";
            string mensagemErroEsperada = "Este nome de usuário já está sendo usado. Por favor, volte e selecione um outro.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            usuariosFlows.CadastrarUsuarioApenasCamposObrigatorios(nomeUsuario, nivel);
            usuariosFlows.CadastrarUsuarioApenasCamposObrigatorios(nomeUsuario, nivel);
            Assert.AreEqual(mensagemErroEsperada, gerenciarUsuariosPage.RetornaMensagemDeErro());
            UsuariosDBSteps.DeletaUsuario(nomeUsuario);
        }
        [Test]
        public void EmailJaCadastrado()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator"; ;
            string nomeUsuario = "userOpx-"+GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string nomeUsuario_2 = "user-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string nomeVerdadeiro = "Luisa-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string email = "teste@" + GeneralHelpers.ReturnStringWithRandomNumbers(8) + ".com.br";
            string nivel = "relator";
            string mensagemErroEsperada = "Este e-mail já está sendo usado. Por favor, volte e selecione outro.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            usuariosFlows.CadastrarUsuarioTodosCampos(nomeUsuario, nomeVerdadeiro, email, nivel);
            usuariosFlows.CadastrarUsuarioTodosCampos(nomeUsuario_2, nomeVerdadeiro, email, nivel);
            Assert.AreEqual(mensagemErroEsperada, gerenciarUsuariosPage.RetornaMensagemDeErro());
            UsuariosDBSteps.DeletaUsuario(nomeUsuario);
            UsuariosDBSteps.DeletaEmailUsuario(email);
        }

        [Test]
        public void EditarUsuario()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeUsuario = "user-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string nomeUsuarioEdicao = "user editado-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string nivel = "relator";
            string nomeColuna = "Nome de usuário";
            string mensagemSucessoEsperada = "Operação realizada com sucesso.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            usuariosFlows.CadastrarUsuarioApenasCamposObrigatorios(nomeUsuario,nivel);
            usuariosFlows.EditarUsuario(nomeUsuario, nomeUsuarioEdicao, nomeColuna);
            Assert.AreEqual(mensagemSucessoEsperada, gerenciarUsuariosPage.RetornaMensagemDeSucesso());
            Assert.AreEqual(1, UsuariosDBSteps.RetornaUsuarios(nomeUsuarioEdicao), "Usuário não foi atualizado no banco de dados");
            Assert.AreEqual(0, UsuariosDBSteps.RetornaUsuarios(nomeUsuario), "Usuário não foi atualizado  no banco de dados");
            UsuariosDBSteps.DeletaUsuario(nomeUsuarioEdicao);
        }
        [Test]
        public void ApagarUsuario()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeUsuario = "user-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string nomeColuna = "Nome de usuário";
            string nivel = "relator";
            string mensagemSucessoEsperada = "Operação realizada com sucesso.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            usuariosFlows.CadastrarUsuarioApenasCamposObrigatorios(nomeUsuario, nivel);
            usuariosFlows.ApagarUsuario(nomeUsuario, nomeColuna); 
            Assert.AreEqual(mensagemSucessoEsperada, gerenciarUsuariosPage.RetornaMensagemDeSucesso());
            Assert.AreEqual(0, UsuariosDBSteps.RetornaUsuarios(nomeUsuario), "Usuário não foi apagado do banco de dados");
        }
        [Test]
        public void RedefinirSenhaSemPreencherEmail()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeUsuario = "user-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string nivel = "relator";
            string nomeColuna = "Nome de usuário";
            string mensagemErroEsperada = "Você deve fornecer um endereço de e-mail para poder reajustar a senha.";
            #endregion                        
            loginFlows.EfetuarLogin(usuario, senha);
            usuariosFlows.CadastrarUsuarioApenasCamposObrigatorios(nomeUsuario, nivel);
            usuariosFlows.RedefinirSenhaUsuario(nomeUsuario, nomeColuna);
            Assert.AreEqual(mensagemErroEsperada, gerenciarUsuariosPage.RetornaMensagemDeErro());
            UsuariosDBSteps.DeletaUsuario(nomeUsuario);
        }
        [Test]
        public void EmailInvalido()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeUsuario = "user-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string email = "xxx";
            string mensagemErroEsperada = "E-mail inválido.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            usuariosFlows.EmailInvalido(nomeUsuario, email);
            Assert.AreEqual(mensagemErroEsperada, gerenciarUsuariosPage.RetornaMensagemDeErro());
        }

        [Test]
        public void PesquisarUsuarios()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeUsuario = "user-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string colunaUsuario = "Nome de usuário";
            string nomeVerdadeiro = "verdadeiro-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string nivel = "relator";
            #endregion            
            loginFlows.EfetuarLogin(usuario, senha);
            usuariosFlows.CadastrarUsuarioApenasCamposObrigatorios(nomeUsuario, nivel);
            usuariosFlows.RealizarPesquisa(nomeUsuario);
            Assert.IsTrue(gerenciarUsuariosPage.ValidarRetornoPesquisa(nomeUsuario, colunaUsuario), "Dados retornados na pesquisa são diferentes do filtro informado.");
            UsuariosDBSteps.DeletaUsuario(nomeUsuario);        }
    }
}
