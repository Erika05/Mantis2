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
    class GerenciarMarcadores : TestBase
    {
        #region
        [AutoInstance] MainPage mainPage;
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] MarcadoresFlows marcadoresFlows;
        [AutoInstance] GerenciarMarcadoresPage gerenciarMarcadoresPage;
        #endregion

        string mensagemObrigatoriedadeChormeFirefoxLocal = "Preencha este campo.";
        string mensagemObrigatoriedadeChromeRemota = "Please fill out this field.";
        string mensagemObrigatoriedadeIE = "Este é um campo obrigatório";

        [Test]
        public void CadastrarMarcador()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeMarcador = "marcador";
            string nomeColuna = "Nome";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);            
            marcadoresFlows.CadastrarMarcador(nomeMarcador);
            Assert.IsTrue(gerenciarMarcadoresPage.ValidarCadastroMarcado(nomeMarcador, nomeColuna), "Marcador não cadastrada");
        }

        [Test]
        public void CampoObrigatorioNaoPreenchido()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string mensagemSucessoEsperada = "Preencha este campo.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            marcadoresFlows.AcessarTelaGerenciarMarcadores();
            gerenciarMarcadoresPage.ClicarCriarMarcador();
            CollectionAssert.Contains(new[] { mensagemObrigatoriedadeIE, mensagemObrigatoriedadeChormeFirefoxLocal, mensagemObrigatoriedadeChromeRemota }, gerenciarMarcadoresPage.RetornaMensagemObrigatoriedade());
        }

        [Test]
        public void EditarMarcador()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeMarcador = "marcador";
            string nomeColuna = "Nome";
            string nomeMarcadorAtualizar = "marcador atualizado";
            #endregion
            MarcadoresDBSteps.InseriMarcador(nomeMarcador);
            loginFlows.EfetuarLogin(usuario, senha);
            marcadoresFlows.EditarMarcador(nomeMarcador, nomeColuna, nomeMarcadorAtualizar);
            Assert.AreEqual(nomeMarcadorAtualizar, gerenciarMarcadoresPage.ValidarAlteracaoMarcador());
        }
        [Test]
        public void ApagarMarcador()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeMarcador = "marcador";
            string nomeColuna = "Nome";
            #endregion
            MarcadoresDBSteps.InseriMarcador(nomeMarcador);
            loginFlows.EfetuarLogin(usuario, senha);
            marcadoresFlows.ApagarMarcador(nomeMarcador, nomeColuna);
            Assert.IsFalse(gerenciarMarcadoresPage.ValidarExclusaoMarcado(nomeMarcador, nomeColuna));
        }
        [Test]
        public void VoltarAoDetalheMarcador()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeMarcador = "marcador";
            string nomeColuna = "Nome";
            string tituloEsperado = "Detalhes do marcador: " + nomeMarcador;
            #endregion
            MarcadoresDBSteps.InseriMarcador(nomeMarcador);
            loginFlows.EfetuarLogin(usuario, senha);
            marcadoresFlows.VoltarDetalheMarcador(nomeMarcador, nomeColuna);
            Assert.AreEqual(tituloEsperado, gerenciarMarcadoresPage.RetornaTituloTelaDetalheMarcador());
        }
    }
}
