using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
    public class GerenciarMarcadoresPage : PageBase
    {
        #region Mapping
        By menuMarcadores = By.XPath("//a[contains(text(),'Gerenciar Marcadores')]");      
        By nomeTextarea = By.Id("tag-name");
        By criarButton = By.Name("config_set");
        By tableMarcadores = By.XPath("//*[@id='main-container']//table");
        By atualizarMarcadorButton = By.XPath("//input[@value='Atualizar Marcador']");
        By apagarMarcadoButton = By.XPath("//input[@value='Apagar Marcador']");
        By telaDetalheMarcadores = By.XPath("//*[@id='main-container']//h4");
        By voltarMarcadoButton = By.LinkText ("Voltar ao Marcador");
        #endregion

        public void ClicarMenuMarcador()
        {
            Click(menuMarcadores);
        }

        public void PreencherNomeMarcador(string nome)
        {
            SendKeys(nomeTextarea, nome);
        }
        public void ClicarCriarMarcador()
        {
            Click(criarButton);
        }
        public string RetornaMensagemObrigatoriedade()
        {
            return GetAttribute(nomeTextarea, "validationMessage");
        }

        public void AcessarTelaEditarMarcador(string nomeMarcador, string colunaMarcador)
        {
            ClicarSobreLinha(tableMarcadores, colunaMarcador, nomeMarcador);
        }
        public void ClicarAtualizarMarcador()
        {
            Click(atualizarMarcadorButton);
        }
        public void LimparNomeMarcador()
        {
            Clear(nomeTextarea);
        }
        public void ClicarApagarMarcador()
        {
            Click(apagarMarcadoButton);
        }
        public void ClicarVoltarAoMarcador()
        {
            Click(voltarMarcadoButton);
        }
        public string RetornaTituloTelaDetalheMarcador()
        {
            return GetText(telaDetalheMarcadores);
        }
    }
}