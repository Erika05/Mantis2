using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
    public class CriarTarefaPage : PageBase
    {
        #region Mapping
        By categoriaTabindex = By.XPath("//select[@id='category_id']");
        By acessoCadastroTarefaButton = By.XPath("//*[@id='sidebar']/ul/li[3]/a/span");
        By resumoTextarea = By.Id("summary");
        By descricaoTextarea = By.Id("description");
        By criarTarefaButton = By.ClassName("btn-white");
        By MsgSucesso = By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div/div[2]/p");
        By frequenciaTabindex = By.Id("reproducibility");
        By gravidadeTabindex = By.Id("severity");
        By prioridadeTabindex = By.Id("priority");
        By criarMaisTarefa = By.XPath("//tr[14]/td/label/span");
        By tituloTelaCadastro = By.XPath("//form[@id='report_bug_form']/div/div/h4");
        By tableTarefas = By.Id("buglist");        
        #endregion

        public void PreencherCategoriaTarefa(string categoria)
        {
            ComboBoxSelectByVisibleText(categoriaTabindex, categoria);
        }
        public void PreencherResumoTarefa(string resumo)
        {
            SendKeys(resumoTextarea, resumo);
        }

        public void PreencherDescricaoTarefa(string descricao)
        {
            SendKeys(descricaoTextarea, descricao);
        }

        public void PreencherFrequenciaTarefa(string frequencia)
        {
            ComboBoxSelectByVisibleText(frequenciaTabindex, frequencia);
        }

        public void PreencherPrioridadeTarefa(string prioridade)
        {
            ComboBoxSelectByVisibleText(prioridadeTabindex, prioridade);
        }

        public void PreencherGravidadeTarefa(string gravidade)
        {
            ComboBoxSelectByVisibleText(gravidadeTabindex, gravidade);
        }

        public void ContinuaCadastrandoTarefas(string resumo, string descricao)
        {
            if (!ReturnIfElementIsSelected(criarMaisTarefa))
            {
                Click(criarMaisTarefa);
            }
        }

        public string RetornaMensagemDeSucesso()
        {
            return GetText(MsgSucesso);
        }

        public string RetornaTituloTelaCadastro()
        {
            return GetText(tituloTelaCadastro);
        }
        public void AcessarCadastroTarefa()
        {
            Click(acessoCadastroTarefaButton);
        }
        public void ClicarCadastrarTarefa()
        {
            Click(criarTarefaButton);
        }
        public string RetornaMensagemObrigatoriedadeResumo()
        {
            return GetAttribute(resumoTextarea, "validationMessage");
        }
        public string RetornaMensagemObrigatoriedadeDescricao()
        {
            return GetAttribute(descricaoTextarea, "validationMessage");
        }
        public bool RetornoPesquisa(string valorFiltro, string nomeColuna)
        {
            return VerificarRetornoPesquisa(tableTarefas, valorFiltro, nomeColuna);
        }       
    }
}