using Desafio_Mantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Mantis.Pages
{
    public class GerenciarCamposPersonalizadosPage : PageBase
    {
        #region Mapping
        By menuGerenciarCampos = By.LinkText("Gerenciar Campos Personalizados");
        By campoTextarea = By.Name("name");
        By criarCampoButton = By.XPath("//input[@value='Novo Campo Personalizado']");
        By MsgSucesso = By.XPath("//div[@id='main-container']//p");
        By MsgErro = By.XPath("//*[@id='main-container']//p[2]");
        By campoSalvoTextarea = By.Id("custom-field-name");
        By tableCampos = By.XPath("//*[@id='main-container']//table");
        By atualizarCampoButton = By.XPath("//input[@value='Atualizar Campo Personalizado']");
        By apagarCampoButton = By.XPath("//input[@value='Apagar Campo Personalizado']");
        By confirmarExclusaCampoButton = By.XPath("//input[@value='Apagar Campo']");
        #endregion
        public void ClicarGerenciarCampo()
        {
            Click(menuGerenciarCampos);
        }
        public void PreencherCampo(string nome)
        {
            SendKeys(campoTextarea, nome);
        }
        public void ClicarCriarCampo()
        {
            Click(criarCampoButton);
        }
        public string RetornaMensagemDeSucesso()
        {
            return GetText(MsgSucesso);
        }
        public string RetornaMensagemDeErro()
        {
            return GetText(MsgErro);
        }
        public void AcessarTelaEdicaoCampo(string nome, string colunaNome)
        {
            ClicarSobreLinha(tableCampos, colunaNome, nome);
        }
        public void LimparCampo()
        {
            Clear(campoSalvoTextarea);
        }
        public void PreencherCampoEdicao(string nomeEdicao)
        {
            SendKeys(campoSalvoTextarea, nomeEdicao);
        }
        public void ClicarAtualizarCampo()
        {
            Click(atualizarCampoButton);
        }
        public void ClicarApagarCampo()
        {
            Click(apagarCampoButton);
        }
        public void CorfirmarApagarCampo()
        {
            Click(confirmarExclusaCampoButton);
        }
    }
}
