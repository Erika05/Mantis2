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
            string colunaFiltra = "Resumo";
            string categoria = "categoria-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string resumo_1 = "teste automatizado resumo-"+GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string descricao_1 = "teste automatizado descrição-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string resumo_2 = "teste automatizado resumo-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string descricao_2 = "teste automatizado descrição-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            #endregion
            CategoriasDBSteps.InseriCategoria(categoria);
            loginFlows.EfetuarLogin(usuario, senha);
            tarefasFlows.CriarTarefaApenasCamposObrigatorios(categoria,resumo_1,descricao_1);
            tarefasFlows.CriarTarefaApenasCamposObrigatorios(categoria, resumo_2, descricao_2);
            gerenciarTarefasPage.AcessarVerTarefas();
            tarefasFlows.RealizarPesquisa(resumo_1);
            Assert.IsTrue(gerenciarTarefasPage.RetornoPesquisa(resumo_1, colunaFiltra), "Resultado retornado é diferente do filtro informado.");
            TarefasDBSteps.DeletaTarefa(descricao_1, resumo_1);
            TarefasDBSteps.DeletaTarefa(descricao_2, resumo_2);
            CategoriasDBSteps.DeletaCategoria(categoria);
        }

        [Test]
        public void SelecionarTodasTarefas()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string categoria = "categoria-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string resumo = "teste automatizado resumo-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string descricao = "teste automatizado descrição-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string resumo_2 = "teste automatizado resumo-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string descricao_2 = "teste automatizado descrição-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            #endregion
            CategoriasDBSteps.InseriCategoria(categoria);
            loginFlows.EfetuarLogin(usuario, senha);
            tarefasFlows.CriarTarefaApenasCamposObrigatorios(categoria, resumo, descricao);
            tarefasFlows.CriarTarefaApenasCamposObrigatorios(categoria, resumo_2, descricao_2);
            gerenciarTarefasPage.AcessarVerTarefas();
            tarefasFlows.LimparPesquisa();
            gerenciarTarefasPage.ClicarSelecionarTudo();
            Assert.IsTrue(gerenciarTarefasPage.ValidarSelecaoTodosRegistros(), "Um ou mais itens não foram selecionados.");
            TarefasDBSteps.DeletaTarefa(descricao, resumo);
            TarefasDBSteps.DeletaTarefa(descricao_2, resumo_2);
            CategoriasDBSteps.DeletaCategoria(categoria);
        }
        [Test]
        public void AcessarEditarTarefa()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string categoria = "categoria-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string resumo = "teste automatizado resumo-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string descricao = "teste automatizado descrição-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string tituloEsperado = "Atualizar Informações da Tarefa";
            #endregion
            CategoriasDBSteps.InseriCategoria(categoria);
            loginFlows.EfetuarLogin(usuario, senha);            
            tarefasFlows.CriarTarefaApenasCamposObrigatorios(categoria, resumo, descricao);            
            tarefasFlows.AcessarEditarTarefa();
            Assert.AreEqual(tituloEsperado, gerenciarTarefasPage.RetornaTituloTelaEditarTarefa());
            TarefasDBSteps.DeletaTarefa(descricao, resumo);
            CategoriasDBSteps.DeletaCategoria(categoria);
        }
        [Test]
        public void VoltarDetalheTarefa()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string categoria = "categoria-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string resumo = "teste automatizado resumo-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string descricao = "teste automatizado descrição-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string tituloEsperado = "Ver Detalhes da Tarefa";
            #endregion
            CategoriasDBSteps.InseriCategoria(categoria);
            loginFlows.EfetuarLogin(usuario, senha);
            tarefasFlows.CriarTarefaApenasCamposObrigatorios(categoria, resumo, descricao);
            tarefasFlows.VoltarDetalheTarefa();
            Assert.AreEqual(tituloEsperado, gerenciarTarefasPage.RetornaTituloTelaDetalheTarefa());
            TarefasDBSteps.DeletaTarefa(descricao, resumo);
            CategoriasDBSteps.DeletaCategoria(categoria);
        }
        [Test]
        public void AdicionarAnotacaoSemCampoObrigatorio()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string categoria = "categoria-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string resumo = "teste automatizado resumo-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string descricao = "teste automatizado descrição-" + GeneralHelpers.ReturnStringWithRandomNumbers(8);
            string MensagemErroEsperado = "Um campo necessário 'Anotação' estava vazio. Por favor, verifique novamente suas entradas.";
            #endregion
            CategoriasDBSteps.InseriCategoria(categoria);
            loginFlows.EfetuarLogin(usuario, senha);
            tarefasFlows.CriarTarefaApenasCamposObrigatorios(categoria, resumo, descricao);
            tarefasFlows.AcessarEditarTarefa();
            gerenciarTarefasPage.ClicarAtualizarInformacao();
            gerenciarTarefasPage.ClicarAdicionarAnotacao();
            Assert.AreEqual(MensagemErroEsperado, gerenciarTarefasPage.RetornaMensagemDeErro());
            TarefasDBSteps.DeletaTarefa(descricao, resumo);
            CategoriasDBSteps.DeletaCategoria(categoria);
        }
    }
}
