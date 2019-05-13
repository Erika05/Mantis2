using CSharpSeleniumTemplate.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Flows
{
    public class CamposPersonalizadosFlows
    {
        #region Page Object and Constructor
        GerenciarCamposPersonalizadosPage gerenciarCamposPersonalizadosPage;
        GerenciarPage gerenciarPage;
        public CamposPersonalizadosFlows()
        {
            gerenciarCamposPersonalizadosPage = new GerenciarCamposPersonalizadosPage();
            gerenciarPage = new GerenciarPage();
        }
        #endregion
        public void AcessarMEnuCamposPersonalizados()
        {
            gerenciarPage.ClicarEmGerenciar();
            gerenciarCamposPersonalizadosPage.ClicarGerenciarCampo();
        }
        public void CadastrarCampo(string nome)
        {
            this.AcessarMEnuCamposPersonalizados();
            gerenciarCamposPersonalizadosPage.PreencherCampo(nome);
            gerenciarCamposPersonalizadosPage.ClicarCriarCampo();
        }
        public void EditarCampo(string nome, string nomeEdicao, string nomeColuna)
        {
            this.AcessarMEnuCamposPersonalizados();
            gerenciarCamposPersonalizadosPage.AcessarTelaEdicao(nome, nomeColuna);
            gerenciarCamposPersonalizadosPage.LimparCampo();
            gerenciarCamposPersonalizadosPage.PreencherCampoEdicao(nomeEdicao);
            gerenciarCamposPersonalizadosPage.ClicarAtualizarCampo();
        }
        public void ApagarCampo(string nome, string nomeColuna)
        {
            this.AcessarMEnuCamposPersonalizados();
            gerenciarCamposPersonalizadosPage.AcessarTelaEdicao(nome, nomeColuna);
            gerenciarCamposPersonalizadosPage.ClicarApagarCampo();
            gerenciarCamposPersonalizadosPage.CorfirmarApagarCampo();
        }
    }
}
