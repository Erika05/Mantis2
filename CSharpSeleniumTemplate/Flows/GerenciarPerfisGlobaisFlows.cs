using CSharpSeleniumTemplate.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Flows
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
            gerenciarPage.ClicarEmGerenciar();
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
        public void EdiatarPerfilGlobal(string plataforma, string novaPlataforma)
        {
            this.AcessarGerenciarPerfis();
            gerenciarPerfisGlobaisPage.SelecionarPerfil(plataforma);
            gerenciarPerfisGlobaisPage.ClicarEmEditar();
            gerenciarPerfisGlobaisPage.ClicarEmEviar();
            gerenciarPerfisGlobaisPage.LimparPerfil();
            gerenciarPerfisGlobaisPage.PreencherPlataformaEdicao(novaPlataforma);
            gerenciarPerfisGlobaisPage.AtualizarPerfil();
        }
        public void ApagarPerfilGlobal(string plataforma)
        {
            this.AcessarGerenciarPerfis();
            gerenciarPerfisGlobaisPage.SelecionarPerfil(plataforma);
            gerenciarPerfisGlobaisPage.ClicarEmApagar();
            gerenciarPerfisGlobaisPage.ClicarEmEviar();
        }
    }
}
