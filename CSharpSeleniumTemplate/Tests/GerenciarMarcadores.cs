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
            string nomeMarcador = "marcador-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);            
            marcadoresFlows.CadastrarMarcador(nomeMarcador);
            Assert.AreEqual(1,MarcadoresDBSteps.RetornaMarcado(nomeMarcador), "Marcador não foi gravado no banco.");
            MarcadoresDBSteps.DeletaMarcador(nomeMarcador);
        }

        [Test]
        public void CampoObrigatorioNaoPreenchido()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
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
            string nomeMarcador = "marcador-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string nomeColuna = "Nome";
            string nomeMarcadorEdicao = "marcador atualizado-" + GeneralHelpers.ReturnStringWithRandomNumbers(8); 
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            marcadoresFlows.CadastrarMarcador(nomeMarcador);
            marcadoresFlows.EditarMarcador(nomeMarcador, nomeColuna, nomeMarcadorEdicao);
            Assert.AreEqual(1, MarcadoresDBSteps.RetornaMarcado(nomeMarcadorEdicao), "Marcador não foi atualziado no banco.");
            Assert.AreEqual(0, MarcadoresDBSteps.RetornaMarcado(nomeMarcador), "Marcador não foi atualizado no banco.");
            MarcadoresDBSteps.DeletaMarcador(nomeMarcadorEdicao);

        }
        [Test]
        public void ApagarMarcador()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeMarcador = "marcador-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string nomeColuna = "Nome";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            marcadoresFlows.CadastrarMarcador(nomeMarcador);
            marcadoresFlows.ApagarMarcador(nomeMarcador, nomeColuna);
            Assert.AreEqual(0, MarcadoresDBSteps.RetornaMarcado(nomeMarcador), "Marcador não foi gravado no banco.");
        }
        [Test]
        public void VoltarAoDetalheMarcador()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string nomeMarcador = "marcador-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string nomeColuna = "Nome";
            string tituloEsperado = "Detalhes do marcador: " + nomeMarcador;
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            marcadoresFlows.CadastrarMarcador(nomeMarcador);
            marcadoresFlows.VoltarDetalheMarcador(nomeMarcador, nomeColuna);
            Assert.AreEqual(tituloEsperado, gerenciarMarcadoresPage.RetornaTituloTelaDetalheMarcador());
            MarcadoresDBSteps.DeletaMarcador(nomeMarcador);
        }
    }
}
