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
    class GerenciarCamposPersonalizados : TestBase
    {
        #region Pages and Flows Objects
        [AutoInstance] MainPage mainPage;
        [AutoInstance] GerenciarCamposPersonalizadosPage gerenciarCamposPersonalizadosPage;
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] CamposPersonalizadosFlows camposPersonalizadosFlows;
        #endregion

        [Test]
        public void CadastrarCampoPersonalizado()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string campo = "campo";
            string mensagemSucessoEsperada = "Operação realizada com sucesso.";
            #endregion
            CamposPersonalizadosDBSteps.DeletaCampo(campo);
            loginFlows.EfetuarLogin(usuario, senha);
            camposPersonalizadosFlows.CadastrarCampo(campo);
            Assert.AreEqual(mensagemSucessoEsperada, gerenciarCamposPersonalizadosPage.RetornaMensagemDeSucesso());
            Assert.AreEqual(campo, gerenciarCamposPersonalizadosPage.VerificarValorSalvo());
        }
        [Test]
        public void CampoObrigatorioNaoInformado()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string mensagemErroEsperada = "Um campo necessário 'name' estava vazio. Por favor, verifique novamente suas entradas.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            camposPersonalizadosFlows.AcessarMenuCamposPersonalizados();
            gerenciarCamposPersonalizadosPage.ClicarCriarCampo();
            Assert.AreEqual(mensagemErroEsperada, gerenciarCamposPersonalizadosPage.RetornaMensagemDeErro());
        }
        [Test]
        public void CampoPersonalizadoJaCadastrado()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string campo = "campo";
            string mensagemErroEsperada = "Este é um nome duplicado.";
            #endregion
            CamposPersonalizadosDBSteps.InseriCampo(campo);
            loginFlows.EfetuarLogin(usuario, senha);
            camposPersonalizadosFlows.CadastrarCampo(campo);
            Assert.AreEqual(mensagemErroEsperada, gerenciarCamposPersonalizadosPage.RetornaMensagemDeErro());
        }
        [Test]
        public void EditarCampoPersonalizado()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string campo = "campo";
            string campoEdicao = "campo edicao";
            string nomeColuna = "Nome";
            string mensagemSucessoEsperada = "Operação realizada com sucesso.";
            #endregion
            CamposPersonalizadosDBSteps.InseriCampo(campo);
            loginFlows.EfetuarLogin(usuario, senha);
            camposPersonalizadosFlows.EditarCampo(campo, campoEdicao, nomeColuna);
            Assert.AreEqual(mensagemSucessoEsperada, gerenciarCamposPersonalizadosPage.RetornaMensagemDeSucesso());
            Assert.IsTrue(gerenciarCamposPersonalizadosPage.ValidarEdicaoCampo(campoEdicao, nomeColuna), "Edição não foi realziada.");
        }
        [Test]
        public void ApagarCampoPersonalizado()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string campo = "campoy";
            string nomeColuna = "Nome";
            string mensagemSucessoEsperada = "Operação realizada com sucesso.";
            #endregion
            CamposPersonalizadosDBSteps.InseriCampo(campo);
            loginFlows.EfetuarLogin(usuario, senha);
            camposPersonalizadosFlows.ApagarCampo(campo, nomeColuna);
            Assert.AreEqual(mensagemSucessoEsperada, gerenciarCamposPersonalizadosPage.RetornaMensagemDeSucesso());
            Assert.IsTrue(gerenciarCamposPersonalizadosPage.ValidarExclusaoCampo(campo, nomeColuna), "Edição não foi realziada.");
        }

    }
}
