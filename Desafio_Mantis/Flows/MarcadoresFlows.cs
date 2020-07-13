using Desafio_Mantis.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Mantis.Flows
{
    public class MarcadoresFlows
    {
        #region Page Object and Constructor
        GerenciarMarcadoresPage gerenciarMarcadoresPage;
        GerenciarPage gerenciarPage;
        #endregion
        public MarcadoresFlows()
        {
            gerenciarPage = new GerenciarPage();
            gerenciarMarcadoresPage = new GerenciarMarcadoresPage();
        }

        public void AcessarTelaGerenciarMarcadores()
        {
            gerenciarPage.ClicarGerenciar();
            gerenciarMarcadoresPage.ClicarMenuMarcador();
        }

        public void CadastrarMarcador(string nome)
        {
            this.AcessarTelaGerenciarMarcadores();
            gerenciarMarcadoresPage.PreencherNomeMarcador(nome);
            gerenciarMarcadoresPage.ClicarCriarMarcador();
        }

        public void EditarMarcador(string nomeAtual, string coluna, string nomeNovo)
        {
            this.AcessarTelaGerenciarMarcadores();
            gerenciarMarcadoresPage.AcessarTelaEditarMarcador(nomeAtual, coluna);
            gerenciarMarcadoresPage.ClicarAtualizarMarcador();
            gerenciarMarcadoresPage.LimparNomeMarcador();
            gerenciarMarcadoresPage.PreencherNomeMarcador(nomeNovo);
            gerenciarMarcadoresPage.ClicarAtualizarMarcador();
        }

        public void ApagarMarcador(string nome, string coluna)
        {
            this.AcessarTelaGerenciarMarcadores();
            gerenciarMarcadoresPage.AcessarTelaEditarMarcador(nome, coluna);
            gerenciarMarcadoresPage.ClicarApagarMarcador();
            gerenciarMarcadoresPage.ClicarApagarMarcador();
        }
        public void VoltarDetalheMarcador(string nome, string coluna)
        {
            this.AcessarTelaGerenciarMarcadores();
            gerenciarMarcadoresPage.AcessarTelaEditarMarcador(nome, coluna);
            gerenciarMarcadoresPage.ClicarAtualizarMarcador();
            gerenciarMarcadoresPage.ClicarVoltarAoMarcador();
        }
    }
}
