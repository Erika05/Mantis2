using Desafio_Mantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Mantis.Pages
{
    public class GerenciarUsuariosPage : PageBase
    {
        #region Mapping
        By gerenciarUsuariosTabindex = By.XPath("//a[contains(text(),'Gerenciar Usuários')]");
        By cadastrarUsuarioButton = By.XPath("//button[@type='submit']");
        By nomeTextarea = By.Id("user-username");
        By nomeVerdadeiroTextarea = By.Id("user-realname");
        By nivelCombobox = By.Id("user-access-level");
        By emailTextArea = By.Id("email-field");
        By confirmaCadastroButton = By.XPath("//input[@value='Criar Usuário']");
        By MsgSucesso = By.XPath("//div[@id='main-container']//p");
        By nomeSalvo = By.Id("edit-username");
        By tableUsuarios = By.XPath("//*[@id='main-container']//table");
        By atualizarUsuarioButton = By.XPath("//input[@value='Atualizar Usuário']");
        By MsgErro = By.XPath("//*[@id='main-container']//p[2]");
        By filtroTextarea = By.Id("search");
        By aplicarFiltroButton = By.XPath("//input[@value='Aplicar Filtro']");
        By apagarUsuarioButtor = By.XPath("//input[@value='Apagar Usuário']");
        By confirmarExclusaoUsuarioButton = By.XPath("//input[@value='Apagar Conta']");
        By redefinirSenhaButton = By.XPath("//input[@value='Redefinir Senha']");   
        #endregion

        public void AcessarTelaGerenciarUsuarios()
        {
            Click(gerenciarUsuariosTabindex);
        }
        public void ClicarNovoContato()
        {
            Click(cadastrarUsuarioButton);
        }
        public void PreencherNomeUsuario(string nome)
        {
            SendKeys(nomeTextarea, nome);
        }
        public void PreencherEmail(string email)
        {
            SendKeys(emailTextArea, email);
        }
        public void PreencherNivel(string nivel)
        {
            ComboBoxSelectByVisibleText(nivelCombobox, nivel);
        }
        public void PreencherNomeVerdadeiro(string nomeVerdadeiro)
        {
            SendKeys(nomeVerdadeiroTextarea, nomeVerdadeiro);
        }
        public void ClicarCadastraUsuario()
        {
            Click(confirmaCadastroButton);
        }
        public string RetornaMensagemDeSucesso()
        {
            return GetText(MsgSucesso);
        }
        public void AcessarTelaEditarUsuario(string nomeUsuario, string colunaUsuario)
        {
            ClicarSobreLinha(tableUsuarios, colunaUsuario, nomeUsuario);
        }
        public void LimparNomeUsuario()
        {
            Clear(nomeSalvo);
        }
        public void PreencherCampoEdicao(string nome)
        {
            SendKeys(nomeSalvo, nome);
        }
        public void ClicarAtualizarUsuario()
        {
            Click(atualizarUsuarioButton);
        }
        public string RetornaMensagemDeErro()
        {
            return GetText(MsgErro);
        }
        public void PreencherFitroPesquisa(string valorFiltro)
        {
            SendKeys(filtroTextarea, valorFiltro);
        }
        public void ClicarPesquisa()
        {
            Click(aplicarFiltroButton);
        }
        public bool ValidarRetornoPesquisa(string valorFiltro, string nomeColuna)
        {
            return VerificarRetornoPesquisa(tableUsuarios, valorFiltro, nomeColuna);
        }
        public void ClicarApagarUsuario()
        {
            Click(apagarUsuarioButtor);
        }
        public void ClicarConfirmarExclusaorUsuario()
        {
            Click(confirmarExclusaoUsuarioButton);
        }
        public void ClicarRedefinirSenha()
        {
            Click(redefinirSenhaButton);
        }
    }
}
