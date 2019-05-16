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
    public class CriarTarefa : TestBase
    {
        #region Pages and Flows Objects
        [AutoInstance] MainPage mainPage;
        [AutoInstance] CriarTarefaPage criarTarefaPage;
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] TarefasFlows tarefasFlows;
        #endregion

        #region Data Driven Providers
        public static IEnumerable CriarTarefaSucesso()
        {
            return GeneralHelpers.ReturnCSVData(GeneralHelpers.ReturnProjectPath() + "Resources/TestData/Tarefas/CriarTarefasData.csv");
        }
        #endregion
        #region mensagens
        string mensagemEsperadaCampoObrigatorioChromeFirefoxLocal = "Preencha este campo.";
        string mensagemEsperadaCampoObrigatorioIELocal = "Este é um campo obrigatório";
        string mensagemEsperadaCampoObrigatorioChromeRemota = "Please fill out this field.";
        string mensagemEsperadaCadastroRealizadoComSucesso = "Operação realizada com sucesso.";
        #endregion

        [Test]
        public void CadastrarTarefaApenasCamposObrigatorios()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string categoria = "categoria";
            string resumo = "teste automatizado resumo";
            string descricao = "teste automatizado descrição";
            string colunaResumo = "Resumo";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            criarTarefaPage.AcessarCadastroTarefa();
            tarefasFlows.PreencherCamposObrigatorios(categoria, resumo, descricao);
            criarTarefaPage.ClicarCadastrarTarefa();
            Assert.AreEqual(mensagemEsperadaCadastroRealizadoComSucesso, criarTarefaPage.RetornaMensagemDeSucesso());
            tarefasFlows.RealizarPesquisa(resumo);
            Assert.IsTrue(criarTarefaPage.RetornoPesquisa(resumo, colunaResumo), "Tarefa não foi cadastrada.");
        }

        [Test, TestCaseSource("CriarTarefaSucesso")]
        public void CadastrarTarefaTodosCampos(ArrayList testData)
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string categoria = testData[0].ToString();
            string resumo = testData[1].ToString();
            string descricao = testData[2].ToString();
            string frequencia = testData[3].ToString();
            string gravidade = testData[4].ToString();
            string prioridade = testData[5].ToString();
            string colunaResumo = "Resumo";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            criarTarefaPage.AcessarCadastroTarefa();
            tarefasFlows.PreencherCamposObrigatorios(categoria, resumo, descricao);
            tarefasFlows.PreencherCamposOpicionais(frequencia, gravidade, prioridade);
            criarTarefaPage.ClicarCadastrarTarefa();
            Assert.AreEqual(mensagemEsperadaCadastroRealizadoComSucesso, criarTarefaPage.RetornaMensagemDeSucesso());
            tarefasFlows.RealizarPesquisa(resumo);
            Assert.IsTrue(criarTarefaPage.RetornoPesquisa(resumo, colunaResumo), "Tarefa não foi cadastrada.");
        }

        [Test]
        public void CadastrarMaisTarefas()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string resumo = "teste automatizado resumo";
            string descricao = "teste automatizado descrição";
            string mensagemEsperada = "Digite os Detalhes do Relatório";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            criarTarefaPage.AcessarCadastroTarefa();
            criarTarefaPage.ContinuaCadastrandoTarefas(resumo, descricao);
            criarTarefaPage.ClicarCadastrarTarefa();
            Assert.AreEqual(mensagemEsperada, criarTarefaPage.RetornaTituloTelaCadastro());
        }

        [Test]
        public void CampoResumoNaoPreenchido()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string categoria = "categoria";
            string descricao = "teste automatizado descrição";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            criarTarefaPage.AcessarCadastroTarefa();
            criarTarefaPage.PreencherCategoriaTarefa("[Todos os Projetos] " + categoria);
            criarTarefaPage.PreencherDescricaoTarefa(descricao);
            criarTarefaPage.ClicarCadastrarTarefa();
            CollectionAssert.Contains(new[] { mensagemEsperadaCampoObrigatorioChromeFirefoxLocal, mensagemEsperadaCampoObrigatorioIELocal, mensagemEsperadaCampoObrigatorioChromeRemota }, criarTarefaPage.RetornaMensagemObrigatoriedadeResumo());
        }
        [Test]
        public void CampoDescricaoNaoPreenchido()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string categoria = "categoria";
            string resumo = "teste automatizado resumo";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            criarTarefaPage.AcessarCadastroTarefa();
            criarTarefaPage.PreencherCategoriaTarefa("[Todos os Projetos] " + categoria);
            criarTarefaPage.PreencherResumoTarefa(resumo);
            criarTarefaPage.ClicarCadastrarTarefa();
            CollectionAssert.Contains(new[] { mensagemEsperadaCampoObrigatorioChromeFirefoxLocal, mensagemEsperadaCampoObrigatorioIELocal, mensagemEsperadaCampoObrigatorioChromeRemota }, criarTarefaPage.RetornaMensagemObrigatoriedadeDescricao());
        }
    }
}
