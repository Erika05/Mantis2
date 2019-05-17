using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
    public class GerenciarCamposPersonalizadosPage : PageBase
    {
        #region Mapping
        By menuGerenciarCampos = By.LinkText("Gerenciar Campos Personalizados");
        By campoTextarea = By.XPath("//*[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div[2]/form/fieldset/input[2]");
        By criarCampoButton = By.XPath("//input[@value='Novo Campo Personalizado']");
        By MsgSucesso = By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div/div[2]/p");
        By MsgErro = By.XPath("//*[@id='main-container']/div[2]/div[2]/div/div/div[2]/p[2]");
        By campoSalvoTextarea = By.Id("custom-field-name");
        By tableCampos = By.XPath("//*[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div[1]/div/table");
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
        public string VerificarValorSalvo()
        {
            return GetValue(campoSalvoTextarea);
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
        public bool ValidarEdicaoCampo(string nome, string nomeColuna)
        {
            return ValidarCadastro(tableCampos, nome, nomeColuna);
        }
        public void ClicarApagarCampo()
        {
            Click(apagarCampoButton);
        }
        public void CorfirmarApagarCampo()
        {
            Click(confirmarExclusaCampoButton);
        }
        public bool ValidarExclusaoCampo(string nome, string nomeColuna)
        {
            return ValidarExclusao(tableCampos, nome, nomeColuna);
        }
        /*colcoar mensagem de sucesso e erro em apenas um lugar já que todas as telas usam a mesma mensagem. ****
--acabar os scripts do gerenciarcampospersonalziados
1-Script de banco com validações.
2-Verificar se remota funciona npo firefox.
3-Verificar necessidade de apagar os dados da tabela mantis_email_table.
4-Rever questões de deletes em cadas teste de cadastro, uma vez que antes de todo teste é realziado um delete nas tabelas.
5-Verificar massa de testes para: 
    -Criar/Geremciar tarefas.
    -Gerenciar marcadores 
     -Gerenciar perfis globais
6-Para todos os testes, verificar validação cadastro/edição/delete pela consulta no banco*/
    }
}
