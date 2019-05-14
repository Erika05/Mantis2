using CSharpSeleniumTemplate.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Flows
{
    public class TarefasFlows
    {
        #region Page Object and Constructor
        CriarTarefaPage criarTarefaPage;
        GerenciarTarefasPage gerenciarTarefasPage;
        public TarefasFlows()
        {
            criarTarefaPage = new CriarTarefaPage();
            gerenciarTarefasPage = new GerenciarTarefasPage();
        }
        #endregion

        public void PreencherCamposObrigatorios(string categoria, string resumo, string descricao)
        {
            criarTarefaPage.PreencherCategoriaTarefa("[Todos os Projetos] " + categoria);
            criarTarefaPage.PreencherResumoTarefa(resumo);
            criarTarefaPage.PreencherDescricaoTarefa(descricao);
        }
        public void PreencherCamposOpicionais(string frequencia, string gravidade, string prioridade)
        {
            criarTarefaPage.PreencherFrequenciaTarefa(frequencia);
            criarTarefaPage.PreencherGravidadeTarefa(gravidade);
            criarTarefaPage.PreencherPrioridadeTarefa(prioridade);
        }
        public void RealizarPesquisa(string valorFiltro)
        {
            gerenciarTarefasPage.LimparFiltroProjeto();
            gerenciarTarefasPage.PreencherFiltro(valorFiltro);
            gerenciarTarefasPage.ClicarPesquisar();
        }

        public void LimparPesquisa()
        {
            gerenciarTarefasPage.LimparFiltroProjeto();
            gerenciarTarefasPage.ClicarPesquisar();
        }
        public void AcessarEditarTarefa()
        {
            gerenciarTarefasPage.AcessarVerTarefas();
            gerenciarTarefasPage.AcessarTelaEditarTarefa();
        }
        public void VoltarDetalheTarefa()
        {
            gerenciarTarefasPage.AcessarVerTarefas();
            gerenciarTarefasPage.AcessarTelaEditarTarefa();
            gerenciarTarefasPage.ClicarVoltarATarefa();
        }
    }
}
