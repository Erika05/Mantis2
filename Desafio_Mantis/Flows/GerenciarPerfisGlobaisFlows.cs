using Desafio_Mantis.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Mantis.Flows
{
    public class GerenciarPerfisGlobaisFlows
    {
        #region Page Object and Constructor
        GerenciarPerfisGlobaisPage gerenciarPerfisGlobaisPage;
        GerenciarPage gerenciarPage;
        public GerenciarPerfisGlobaisFlows()
        {
            gerenciarPerfisGlobaisPage = new GerenciarPerfisGlobaisPage();
            gerenciarPage = new GerenciarPage();
        }

        #endregion
        public void AcessarGerenciarPerfis()
        {
            gerenciarPage.ClicarGerenciar();
            gerenciarPerfisGlobaisPage.ClicarMenuGerenciarPerfis();
        }
        public void CadastrarPerfilGlobal(string plataforma, string so, string versaoSo)
        {
            this.AcessarGerenciarPerfis();
            gerenciarPerfisGlobaisPage.PreencherPlataforma(plataforma);
            gerenciarPerfisGlobaisPage.PreencherSO(so);
            gerenciarPerfisGlobaisPage.PreencherVersaoSo(versaoSo);
            gerenciarPerfisGlobaisPage.ClicarAdicionarPerfil();
        }
        public void EditarPerfilGlobal(string plataforma, string novaPlataforma)
        {
            this.AcessarGerenciarPerfis();
            gerenciarPerfisGlobaisPage.SelecionarPerfil(plataforma);
            gerenciarPerfisGlobaisPage.ClicarEditarPerfil();
            gerenciarPerfisGlobaisPage.ClicarEnviar();
            gerenciarPerfisGlobaisPage.LimparCampoPlataforma();
            gerenciarPerfisGlobaisPage.PreencherPlataformaEdicao(novaPlataforma);
            gerenciarPerfisGlobaisPage.AtualizarPerfil();
        }
        public void ApagarPerfilGlobal(string plataforma)
        {
            this.AcessarGerenciarPerfis();
            gerenciarPerfisGlobaisPage.SelecionarPerfil(plataforma);
            gerenciarPerfisGlobaisPage.ClicarApagarPerfil();
            gerenciarPerfisGlobaisPage.ClicarEnviar();
       }
    }
}
