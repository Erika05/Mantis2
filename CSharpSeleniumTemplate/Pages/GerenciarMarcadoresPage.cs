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
        By menuMarcadores = By.LinkText("Gerenciar Marcadores");
        By nomeTextarea = By.Id("tag-name");
        By criarButton = By.XPath("//*[@id='manage-tags-create-form']/div/div[2]/div[2]/input");
        By tableMarcadores = By.XPath("//*[@id='main-container']/div[2]/div[2]/div/div/div[4]/div[2]/div[2]/div/table");
        By atualizarMarcadorButton = By.XPath("//input[@value='Atualizar Marcador']");
        By textValidarAlteracao = By.XPath("//*[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr[2]/td[2]");
        By apagarMarcadoButton = By.XPath("//input[@value='Apagar Marcador']");
        By telaDetalheMarcadores = By.XPath("//*[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[1]/h4");
        By voltarMarcadoButton = By.XPath("//*[@id='main-container']/div[2]/div[2]/div/div/form/div/div[2]/div/div[1]/a");
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
        public bool ValidarCadastroMarcado(string nomeMarcador, string colunaMarcador)
        {
            return ValidarCadastro(tableMarcadores, nomeMarcador, colunaMarcador);
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

        public string ValidarAlteracaoMarcador()
        {
            return GetText(textValidarAlteracao);
        }
        public void ClicarApagarMarcador()
        {
            Click(apagarMarcadoButton);
        }
        public bool ValidarExclusaoMarcado(string nomeMarcador, string colunaMarcador)
        {
            return ValidarExclusao(tableMarcadores, nomeMarcador, colunaMarcador);
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