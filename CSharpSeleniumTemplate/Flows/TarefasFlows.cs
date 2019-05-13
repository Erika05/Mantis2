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
        public void RealizaPesquisa(string valorFiltro)
        {
            gerenciarTarefasPage.LimparFiltro();
            gerenciarTarefasPage.PreencherFiltro(valorFiltro);
            gerenciarTarefasPage.ClicarEmPesquisar();
        }

        public void LimpaFiltroPesquisa()
        {
            gerenciarTarefasPage.LimparFiltro();
            gerenciarTarefasPage.ClicarEmPesquisar();
        }
        public void AcessarEditarTarefa()
        {
            gerenciarTarefasPage.TelaVerTarefas();
            gerenciarTarefasPage.AcessarEditarTarefa();
        }
        public void VoltarDetalheTarefa()
        {
            gerenciarTarefasPage.TelaVerTarefas();
            gerenciarTarefasPage.AcessarEditarTarefa();
            gerenciarTarefasPage.ClicarOpcaoVoltar();
        }
    }
}
