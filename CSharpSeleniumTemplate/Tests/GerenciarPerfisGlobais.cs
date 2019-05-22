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
        string mensagemEsperadaPerfilObrigatorioIERemota = "Um parâmetro necessário para esta página (action) não foi encontrado.";
        string mensagemEsperadaPerfilObrigatorio = "Um campo necessário 'Selecionar Perfil' estava vazio. Por favor, verifique novamente suas entradas.";
        #endregion

        [Test]
        public void CadastrarPerfilSucesso()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string plataforma = "nome perfil-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string so = "mac-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string versaoSo = "1.3-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPerfisGlobaisFlows.CadastrarPerfilGlobal(plataforma, so, versaoSo);
            Assert.AreEqual(1, PerfisGlobalDBSteps.RetornaPerfilGlobal(plataforma, so, versaoSo), "Perfil não foi gravado no banco de dados.");
            PerfisGlobalDBSteps.DeletaPerfilGlobal(plataforma, so, versaoSo);
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
            string plataforma = "plataforma";
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
            string plataforma = "nome perfil-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string so = "mac-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string versaoSo = "1.3-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string mensagemEsperada = "Um parâmetro necessário para esta página (action) não foi encontrado.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPerfisGlobaisFlows.CadastrarPerfilGlobal(plataforma, so, versaoSo);
            gerenciarPerfisGlobaisPage.ClicarEnviar();
            Assert.AreEqual(mensagemEsperada, gerenciarPerfisGlobaisPage.RetornaMensagemDeErro());
            PerfisGlobalDBSteps.DeletaPerfilGlobal(plataforma, so, versaoSo);
        }
        [Test]
        public void EditarSemSelecionarUmPerfil()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator"; ;
            string plataforma = "nome perfil-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string so = "mac-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string versaoSo = "1.3-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPerfisGlobaisFlows.CadastrarPerfilGlobal(plataforma, so, versaoSo);
            gerenciarPerfisGlobaisPage.ClicarEditarPerfil();
            gerenciarPerfisGlobaisPage.ClicarEnviar();
            CollectionAssert.Contains(new[] { mensagemEsperadaPerfilObrigatorio, mensagemEsperadaPerfilObrigatorioIERemota }, gerenciarPerfisGlobaisPage.RetornaMensagemDeErro());
            PerfisGlobalDBSteps.DeletaPerfilGlobal(plataforma, so, versaoSo);
        }
        [Test]
        public void EditarPerfilSucesso()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string plataforma = "nome perfil-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string so = "mac-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string versaoSo = "1.3-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string plataformaEdicao = "mac edicao-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPerfisGlobaisFlows.CadastrarPerfilGlobal(plataforma, so, versaoSo);
            gerenciarPerfisGlobaisFlows.EditarPerfilGlobal(plataforma + " " + so + " " + versaoSo, plataformaEdicao);
            Assert.AreEqual(1, PerfisGlobalDBSteps.RetornaPerfilGlobal(plataformaEdicao, so, versaoSo), "Perfil não foi alterado no banco de dados.");
            Assert.AreEqual(0, PerfisGlobalDBSteps.RetornaPerfilGlobal(plataforma, so, versaoSo), "Perfil não foi alterado do banco de dados.");
            PerfisGlobalDBSteps.DeletaPerfilGlobal(plataformaEdicao, so, versaoSo);
        }
        [Test]
        public void ApagarSemSelecionarUmPerfil()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string plataforma = "nome perfil-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string so = "mac-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string versaoSo = "1.3-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);            
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPerfisGlobaisFlows.CadastrarPerfilGlobal(plataforma, so, versaoSo);
            gerenciarPerfisGlobaisPage.ClicarApagarPerfil();
            gerenciarPerfisGlobaisPage.ClicarEnviar();
            CollectionAssert.Contains(new[] { mensagemEsperadaPerfilObrigatorio, mensagemEsperadaPerfilObrigatorioIERemota }, gerenciarPerfisGlobaisPage.RetornaMensagemDeErro());
            PerfisGlobalDBSteps.DeletaPerfilGlobal(plataforma, so, versaoSo);
        }
        [Test]
        public void ApagarPerfilScucesso()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string plataforma = "nome perfil-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string so = "mac-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string versaoSo = "1.3-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPerfisGlobaisFlows.CadastrarPerfilGlobal(plataforma, so, versaoSo);
            gerenciarPerfisGlobaisFlows.ApagarPerfilGlobal(plataforma + " " + so + " " + versaoSo);
            Assert.AreEqual(0, PerfisGlobalDBSteps.RetornaPerfilGlobal(plataforma, so, versaoSo), "Perfil não foi apagado do banco de dados.");
        }
    }
}