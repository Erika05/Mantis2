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
    class GerenciarPerfisGlobais : TestBase
    {
        #region Pages and Flows Objects
        [AutoInstance] MainPage mainPage;
        [AutoInstance] GerenciarPerfisGlobaisPage gerenciarPerfisGlobaisPage;
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] GerenciarPerfisGlobaisFlows gerenciarPerfisGlobaisFlows;
        #endregion

        #region mensagens
        string mensagemEsperadaCampoObrigatorioChromeFirefoxLocal = "Preencha este campo.";
        string mensagemEsperadaCampoObrigatorioIELocal = "Este é um campo obrigatório";
        string mensagemEsperadaCampoObrigatorioChromeRemota = "Please fill out this field.";
        string mensagemEsperadaCadastroRealizadoComSucesso = "Operação realizada com sucesso.";
        #endregion

        [Test]
        public void CadastrarPerfilSucesso()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string plataforma = "ffff";
            string so = "mac";
            string versaoSo = "1.3";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPerfisGlobaisFlows.CadastrarPerfilGlobal(plataforma, so, versaoSo);
           ///Assert.IsTrue(gerenciarPerfisGlobaisPage.ValidarCadastroPerfil(plataforma), "Perfil não cadastrado.");
           //// Assert.That(mensagemEsperada.Contains(gerenciarPerfisGlobaisPage.RetornaMensagemDeErro()));
        }
        [Test]
        public void PlataformaNaoPreenchida()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string so = "mac";
            string versaoSo = "1.3";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPerfisGlobaisFlows.AcessarGerenciarPerfis();
            gerenciarPerfisGlobaisPage.PreencherSO(so);
            gerenciarPerfisGlobaisPage.PreencherVersaoSo(versaoSo);
            gerenciarPerfisGlobaisPage.ClicarAdicionarPerfil();
            CollectionAssert.Contains(new[] { mensagemEsperadaCampoObrigatorioChromeFirefoxLocal, mensagemEsperadaCampoObrigatorioIELocal, mensagemEsperadaCampoObrigatorioChromeRemota }, gerenciarPerfisGlobaisPage.RetornaMensagemObrigatoriedadePlataforma());
        }
        [Test]
        public void VersaoSONaoPreenchida()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string plataforma = "plat";
            string Versaso = "1.3.4";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPerfisGlobaisFlows.AcessarGerenciarPerfis();
            gerenciarPerfisGlobaisPage.PreencherPlataforma(plataforma);
            gerenciarPerfisGlobaisPage.PreencherVersaoSo(Versaso);
            gerenciarPerfisGlobaisPage.ClicarAdicionarPerfil();
            CollectionAssert.Contains(new[] { mensagemEsperadaCampoObrigatorioChromeFirefoxLocal, mensagemEsperadaCampoObrigatorioIELocal, mensagemEsperadaCampoObrigatorioChromeRemota }, gerenciarPerfisGlobaisPage.RetornaMensagemObrigatoriedadeSO());
        }
        [Test]
        public void EnviarSemSelecionarUmdosParametros()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string mensagemEsperada = "Um parâmetro necessário para esta página (action) não foi encontrado.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPerfisGlobaisFlows.AcessarGerenciarPerfis();
            gerenciarPerfisGlobaisPage.ClicarEnviar();
            Assert.AreEqual(mensagemEsperada, gerenciarPerfisGlobaisPage.RetornaMensagemDeErro());            
        }
        [Test]
        public void EditarSemSelecionarUmPerfil()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string mensagemEsperada = "Um campo necessário 'Selecionar Perfil' estava vazio. Por favor, verifique novamente suas entradas.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPerfisGlobaisFlows.AcessarGerenciarPerfis();
            gerenciarPerfisGlobaisPage.ClicarEditarPerfil();
            gerenciarPerfisGlobaisPage.ClicarEnviar();
            Assert.AreEqual(mensagemEsperada, gerenciarPerfisGlobaisPage.RetornaMensagemDeErro());
        }
        [Test]
        public void EditarPerfilSucesso()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string perfil = "erika mac 1.3";
            string plataformaEdicao = "mac";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPerfisGlobaisFlows.EditarPerfilGlobal(perfil, plataformaEdicao);
            Assert.IsTrue(gerenciarPerfisGlobaisPage.ValidarCadastroPerfil(plataformaEdicao), "Perfil não foi editado.");
        }
        [Test]
        public void ApagarSemSelecionarUmPerfil()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string mensagemEsperada = "Um campo necessário 'Selecionar Perfil' estava vazio. Por favor, verifique novamente suas entradas.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPerfisGlobaisFlows.AcessarGerenciarPerfis();
            gerenciarPerfisGlobaisPage.ClicarApagarPerfil();
            gerenciarPerfisGlobaisPage.ClicarEnviar();
            Assert.AreEqual(mensagemEsperada, gerenciarPerfisGlobaisPage.RetornaMensagemDeErro());
        }
        [Test]
        public void ApagarPerfilScucesso()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string perfil = "erika mac 1.3";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPerfisGlobaisFlows.ApagarPerfilGlobal(perfil);
            Assert.IsFalse(gerenciarPerfisGlobaisPage.ValidarCadastroPerfil(perfil), "Perfil não foi apagado.");
        }
    }
}