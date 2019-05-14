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
    public class GerenciarTarefas : TestBase
    {
        #region Pages and Flows Objects
        [AutoInstance] MainPage mainPage;
        [AutoInstance] GerenciarTarefasPage gerenciarTarefasPage;
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] TarefasFlows tarefasFlows;
        #endregion

        [Test]
        public void PesquisarTarefa()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string filtro = "teste automatizado resumo";
            string colunaFiltra = "Resumo";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarTarefasPage.AcessarVerTarefas();
            tarefasFlows.RealizarPesquisa(filtro);
            Assert.IsTrue(gerenciarTarefasPage.RetornoPesquisa(filtro, colunaFiltra), "Resultado retornado é diferente do filtro informado.");
        }

        [Test]
        public void SelecionarTodasTarefas()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarTarefasPage.AcessarVerTarefas();
            tarefasFlows.LimparPesquisa();
            gerenciarTarefasPage.ClicarSelecionarTudo();
            Assert.IsTrue(gerenciarTarefasPage.ValidarSelecaoTodosRegistros(), "Um ou mais itens não foram selecionados.");
        }
        [Test]
        public void AcessarEditarTarefa()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string tituloEsperado = "Atualizar Informações da Tarefa";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            tarefasFlows.AcessarEditarTarefa();
            Assert.AreEqual(tituloEsperado, gerenciarTarefasPage.RetornaTituloTelaEditarTarefa());
        }
        [Test]
        public void VoltarDetalheTarefa()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string tituloEsperado = "Ver Detalhes da Tarefa";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            tarefasFlows.VoltarDetalheTarefa();
            Assert.AreEqual(tituloEsperado, gerenciarTarefasPage.RetornaTituloTelaDetalheTarefa());
        }
        [Test]
        public void AdicionarAnotacaoSemCampoObrigatorio()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string MensagemErroEsperado = "Um campo necessário 'Anotação' estava vazio. Por favor, verifique novamente suas entradas.";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            tarefasFlows.AcessarEditarTarefa();
            gerenciarTarefasPage.ClicarAtualizarInformacao();
            gerenciarTarefasPage.ClicarAdicionarAnotacao();
            Assert.AreEqual(MensagemErroEsperado, gerenciarTarefasPage.RetornaMensagemDeErro());
        }
    }
}
