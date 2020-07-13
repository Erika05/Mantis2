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
        By acessoCadastroTarefaButton = By.XPath("//*[@id='sidebar']/ul/li[3]");
        By resumoTextarea = By.Id("summary");
        By descricaoTextarea = By.Id("description");
        By criarTarefaButton = By.XPath("//input[@value='Criar Nova Tarefa']");
        By MsgSucesso = By.XPath("//*[@id='main-container']//p");
        By frequenciaTabindex = By.Id("reproducibility");
        By gravidadeTabindex = By.Id("severity");
        By prioridadeTabindex = By.Id("priority");
        By criarMaisTarefaVerificarSelecao = By.XPath("//input[@id='report_stay']");
        By criarMaisTarefaButton = By.XPath("//input[@id='report_stay']/..");
        By tituloTelaCadastro = By.XPath("//*[@id='report_bug_form']//h4"); 
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
            if (!ReturnIfElementIsSelected(criarMaisTarefaVerificarSelecao))
            {
                Click(criarMaisTarefaButton);
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