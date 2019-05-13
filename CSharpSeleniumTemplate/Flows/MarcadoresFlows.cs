using CSharpSeleniumTemplate.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Flows
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

        public void AcessarTelaMarcadores()
        {
            gerenciarPage.ClicarEmGerenciar();
            gerenciarMarcadoresPage.ClicarMenuMarcadores();
        }

        public void CadastroMarcador(string nome)
        {
            this.AcessarTelaMarcadores();
            gerenciarMarcadoresPage.PreencherNomeMarcador(nome);
            gerenciarMarcadoresPage.ClicarEmCriar();
        }

        public void EditaMarcador(string nomeAtual, string coluna, string nomeNovo)
        {
            this.AcessarTelaMarcadores();
            gerenciarMarcadoresPage.TelaEditarMarcador(nomeAtual, coluna);
            gerenciarMarcadoresPage.ClicarEmAtualizarMarcador();
            gerenciarMarcadoresPage.LimparNomeMarcador();
            gerenciarMarcadoresPage.PreencherNomeMarcador(nomeNovo);
            gerenciarMarcadoresPage.ClicarEmAtualizarMarcador();
        }

        public void ApagarMarcador(string nome, string coluna)
        {
            this.AcessarTelaMarcadores();
            gerenciarMarcadoresPage.TelaEditarMarcador(nome, coluna);
            gerenciarMarcadoresPage.ClicarApagarMarcador();
            gerenciarMarcadoresPage.ClicarApagarMarcador();
        }
        public void VoltarDetalheMarcador(string nome, string coluna)
        {
            this.AcessarTelaMarcadores();
            gerenciarMarcadoresPage.TelaEditarMarcador(nome, coluna);
            gerenciarMarcadoresPage.ClicarEmAtualizarMarcador();
            gerenciarMarcadoresPage.ClicarVoltarMarcador();
        }
    }
}
