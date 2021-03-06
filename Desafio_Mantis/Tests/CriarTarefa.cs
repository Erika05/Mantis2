﻿using Desafio_Mantis.Bases;
using Desafio_Mantis.DataBaseSteps;
using Desafio_Mantis.Flows;
using Desafio_Mantis.Helpers;
using Desafio_Mantis.Pages;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Desafio_Mantis.Tests
{
    [TestFixture]
    public class CriarTarefa : TestBase
    {
        #region Pages and Flows Objects
        [AutoInstance] CriarTarefaPage criarTarefaPage;
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] TarefasFlows tarefasFlows;
        #endregion

        #region Data Driven 
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
            string categoria = "General";
            string resumo = "teste automatizado resumo-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string descricao = "teste automatizado descrição-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            tarefasFlows.CriarTarefaApenasCamposObrigatorios(categoria, resumo, descricao);
            Assert.AreEqual(mensagemEsperadaCadastroRealizadoComSucesso, criarTarefaPage.RetornaMensagemDeSucesso());
            Assert.AreEqual(1, TarefasDBSteps.RetornaTarefas(descricao, resumo), "Tarefa não foi gravada no banco.");
            TarefasDBSteps.DeletaTarefa(descricao, resumo);
        }

        [Test, TestCaseSource("CriarTarefaSucesso")]
        public void CadastrarTarefaTodosCampos(ArrayList testData)
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string categoria = testData[0].ToString();
            string resumo = testData[1].ToString() + "-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string descricao = testData[2].ToString() + "-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string frequencia = testData[3].ToString();
            string gravidade = testData[4].ToString();
            string prioridade = testData[5].ToString();
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            tarefasFlows.CriarTarefaTodosCampos(categoria, resumo, descricao, frequencia, gravidade, prioridade);
            Assert.AreEqual(mensagemEsperadaCadastroRealizadoComSucesso, criarTarefaPage.RetornaMensagemDeSucesso());
            Assert.AreEqual(1, TarefasDBSteps.RetornaTarefas(descricao, resumo), "Tarefa não foi gravada no banco.");
            TarefasDBSteps.DeletaTarefa(descricao, resumo);
        }

        [Test]
        public void CadastrarMaisTarefas()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string categoria = "General";
            string resumo = "teste automatizado resumo-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string descricao = "teste automatizado descrição-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string tituloDaTelaEsperado = "Digite os Detalhes do Relatório";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            tarefasFlows.ContinuarCriandoTarefas(categoria, resumo, descricao);
            Assert.AreEqual(tituloDaTelaEsperado, criarTarefaPage.RetornaTituloTelaCadastro());
            Assert.AreEqual(1, TarefasDBSteps.RetornaTarefas(descricao, resumo), "Tarefa não foi gravada no banco.");
            TarefasDBSteps.DeletaTarefa(descricao, resumo);
        }

        [Test]
        public void CampoResumoNaoPreenchido()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string categoria = "General";
            string descricao = "teste automatizado descrição-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
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
            string categoria = "General";
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
