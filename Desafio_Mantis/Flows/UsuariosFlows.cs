using CSharpSeleniumTemplate.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Flows
{
    public class UsuariosFlows
    {
        #region Page Object and Constructor
        GerenciarUsuariosPage gerenciarUsuariosPage;
        GerenciarPage gerenciarPage;
        public UsuariosFlows()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            gerenciarPage = new GerenciarPage();
        }
        #endregion

        public void AcessarTelaGestaoUsuarios()
        {
            gerenciarPage.ClicarGerenciar();
            gerenciarUsuariosPage.AcessarTelaGerenciarUsuarios();
        }
        public void AcessarTelaCadastroUsuarios()
        {
            this.AcessarTelaGestaoUsuarios();
            gerenciarUsuariosPage.ClicarNovoContato();
        }
        public void PreencherCamposObrigatorios(string nomeUsuario, string nomeNivel)
        {
            gerenciarUsuariosPage.PreencherNomeUsuario(nomeUsuario);
            gerenciarUsuariosPage.PreencherNivel(nomeNivel);
        }
        public void PreencherCamposOpcionais(string nomeVerdadeiro, string email)
        {
            gerenciarUsuariosPage.PreencherNomeVerdadeiro(nomeVerdadeiro);
            gerenciarUsuariosPage.PreencherEmail(email);
        }
        public void CadastrarUsuarioApenasCamposObrigatorios(string nomeUsuario, string nomeNivel)
        {
            this.AcessarTelaCadastroUsuarios();
            this.PreencherCamposObrigatorios(nomeUsuario, nomeNivel);
            gerenciarUsuariosPage.ClicarCadastraUsuario();
        }
        public void CadastrarUsuarioTodosCampos(string nomeUsuario, string nomeVerdadeito, string email,string nomeNivel)
        {
            this.AcessarTelaCadastroUsuarios();
            this.PreencherCamposObrigatorios(nomeUsuario, nomeNivel);
            this.PreencherCamposOpcionais(nomeVerdadeito, email);
            gerenciarUsuariosPage.ClicarCadastraUsuario();
        }
        public void EditarUsuario(string nomeUsuario, string nomeUsuarioEdicao, string nomeColuna)
        {
            this.AcessarTelaGestaoUsuarios();
            gerenciarUsuariosPage.AcessarTelaEditarUsuario(nomeUsuario, nomeColuna);
            gerenciarUsuariosPage.LimparNomeUsuario();
            gerenciarUsuariosPage.PreencherCampoEdicao(nomeUsuarioEdicao);
            gerenciarUsuariosPage.ClicarAtualizarUsuario();
        }
        public void RealizarPesquisa(string valorFiltro)
        {
            this.AcessarTelaGestaoUsuarios();
            gerenciarUsuariosPage.PreencherFitroPesquisa(valorFiltro);
            gerenciarUsuariosPage.ClicarPesquisa();
        }
        public void ApagarUsuario(string nomeUsuario, string nomeColuna)
        {
            this.AcessarTelaGestaoUsuarios();
            gerenciarUsuariosPage.AcessarTelaEditarUsuario(nomeUsuario, nomeColuna);
            gerenciarUsuariosPage.ClicarApagarUsuario();
            gerenciarUsuariosPage.ClicarConfirmarExclusaorUsuario();
        }
        public void RedefinirSenhaUsuario(string nomeUsuario, string nomeColuna)
        {
            this.AcessarTelaGestaoUsuarios();
            gerenciarUsuariosPage.AcessarTelaEditarUsuario(nomeUsuario, nomeColuna);
            gerenciarUsuariosPage.ClicarRedefinirSenha();
        }
        public void EmailInvalido(string nomeUsuario, string email)
        {
            this.AcessarTelaCadastroUsuarios();
            gerenciarUsuariosPage.PreencherNomeUsuario(nomeUsuario);
            gerenciarUsuariosPage.PreencherEmail(email);
            gerenciarUsuariosPage.ClicarCadastraUsuario();
        }
    }
}
