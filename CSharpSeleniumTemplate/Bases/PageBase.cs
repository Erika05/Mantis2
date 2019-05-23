using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpSeleniumTemplate.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace CSharpSeleniumTemplate.Bases
{
    public class PageBase
    {
        #region Objects and constructor
        protected OpenQA.Selenium.Support.UI.WebDriverWait wait { get; private set; }
        protected IWebDriver driver { get; private set; }
        protected IJavaScriptExecutor javaScript { get; private set; }

        public PageBase()
        {
            wait = new OpenQA.Selenium.Support.UI.WebDriverWait(DriverFactory.INSTANCE, TimeSpan.FromSeconds(Convert.ToDouble(Properties.Settings.Default.DEFAULT_TIMEOUT_IN_SECONDS)));
            driver = DriverFactory.INSTANCE;
            javaScript = (IJavaScriptExecutor)driver;
        }
        #endregion

        #region Custom Actions
        protected IWebElement WaitForElement(By locator)
        {
            wait.Until(ExpectedConditions.ElementExists(locator));
            IWebElement element = driver.FindElement(locator);
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
            return element;
        }
        protected void Click(By locator)
        {
            Stopwatch timeOut = new Stopwatch();
            timeOut.Start();

            while (timeOut.Elapsed.Seconds <= Convert.ToInt32(Properties.Settings.Default.DEFAULT_TIMEOUT_IN_SECONDS))
            {
                try
                {
                    WaitForElement(locator).Click();
                    timeOut.Stop();
                    ExtentReportHelpers.AddTestInfo(3, "");
                    return;
                }
                catch (System.Reflection.TargetInvocationException)
                {

                }
                catch (StaleElementReferenceException)
                {

                }
                catch (System.InvalidOperationException)
                {

                }
                catch (WebDriverException e)
                {
                    if (e.Message.Contains("Other element would receive the click"))
                    {
                        continue;
                    }

                    if (e.Message.Contains("Element is not clickable at point"))
                    {
                        continue;
                    }

                    throw e;
                }
            }

            throw new Exception("Given element isn't visible");
        }

        protected void SendKeys(By locator, string text)
        {
            WaitForElement(locator).SendKeys(text);
            ExtentReportHelpers.AddTestInfo(3, "PARAMETER: " + text);
        }

        protected void Clear(By locator)
        {
            WaitForElement(locator).Clear();
            ExtentReportHelpers.AddTestInfo(3, "");
        }

        protected void SendKeysWithoutWaitVisible(By locator, string text)
        {
            wait.Until(ExpectedConditions.ElementExists(locator));
            IWebElement element = driver.FindElement(locator);
            element.SendKeys(text);
            ExtentReportHelpers.AddTestInfo(3, "PARAMETER: " + text);
        }

        protected void ComboBoxSelectByVisibleText(By locator, string text)
        {
            OpenQA.Selenium.Support.UI.SelectElement comboBox = new OpenQA.Selenium.Support.UI.SelectElement(WaitForElement(locator));
            comboBox.SelectByText(text);
            ExtentReportHelpers.AddTestInfo(3, "PARAMETER: " + text);
        }

        protected void MouseOver(By locator)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(WaitForElement(locator)).Build().Perform();
            ExtentReportHelpers.AddTestInfo(3, "");
        }

        protected string GetText(By locator)
        {
            string text = WaitForElement(locator).Text;
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + text);
            return text;
        }

        protected string GetValue(By locator)
        {
            string text = WaitForElement(locator).GetAttribute("value");
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + text);
            return text;
        }

        protected string GetAttribute(By locator, string mensagem)
        {
            string text = WaitForElement(locator).GetAttribute(mensagem);
            ExtentReportHelpers.AddTestInfo(3, "");
            return text;
        }

        protected bool ReturnIfElementIsDisplayed(By locator)
        {
            wait.Until(ExpectedConditions.ElementExists(locator));
            bool result = driver.FindElement(locator).Displayed;
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + result);
            return result;
        }

        protected bool ReturnIfElementIsEnabled(By locator)
        {
            wait.Until(ExpectedConditions.ElementExists(locator));
            bool result = driver.FindElement(locator).Enabled;
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + result);
            return result;
        }

        protected bool ReturnIfElementIsSelected(By locator)
        {
            wait.Until(ExpectedConditions.ElementExists(locator));
            bool result = driver.FindElement(locator).Selected;
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + result);
            return result;
        }
        #endregion

        #region JavaScript Actions
        protected void SendKeysJavaScript(By locator, string value)
        {
            wait.Until(ExpectedConditions.ElementExists(locator));
            IWebElement element = driver.FindElement(locator);
            javaScript.ExecuteScript("arguments[0].value='" + value + "';",element);
            ExtentReportHelpers.AddTestInfo(3, "PARAMETER: " + value);
        }

        protected void ClickJavaScript(By locator)
        {
            wait.Until(ExpectedConditions.ElementExists(locator));
            IWebElement element = driver.FindElement(locator);
            javaScript.ExecuteScript("arguments[0].click();", element);
            ExtentReportHelpers.AddTestInfo(3, "");
        }

        protected void ScrollToElementJavaScript(By locator)
        {
            wait.Until(ExpectedConditions.ElementExists(locator));
            IWebElement element = driver.FindElement(locator);
            javaScript.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            ExtentReportHelpers.AddTestInfo(3, "");
        }

        protected void ScrollToTop()
        {
            javaScript.ExecuteScript("window.scrollTo(0, 0);");
            ExtentReportHelpers.AddTestInfo(3, "");
        }
        #endregion

        #region Default Actions
        public void Refresh()
        {
            DriverFactory.INSTANCE.Navigate().Refresh();
            ExtentReportHelpers.AddTestInfo(2, "");
        }

        public void NavigateTo(string url)
        {
            DriverFactory.INSTANCE.Navigate().GoToUrl(url);
            ExtentReportHelpers.AddTestInfo(2, "PARAMETER: " + url);
        }

        public void OpenNewTab()
        {
            javaScript.ExecuteScript("window.open();");
            ExtentReportHelpers.AddTestInfo(2, "");
        }

        public void SetFocusToLastTab()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            ExtentReportHelpers.AddTestInfo(2, "");
        }

        public void SetFocusToFirstTab()
        {
            driver.SwitchTo().Window(driver.WindowHandles.First());
            ExtentReportHelpers.AddTestInfo(2, "");
        }

        public string GetTitle()
        {
            string title = driver.Title;
            ExtentReportHelpers.AddTestInfo(2, "RETURN: " + title);

            return title;
        }

        public string GetURL()
        {
            string url = driver.Url;
            ExtentReportHelpers.AddTestInfo(2, "RETURN: " + url);

            return url;
        }
        public int ValidarExistenciaLinhas(By locator)
        {
            IWebElement table = WaitForElement(locator);
            IList<IWebElement> tbody = table.FindElements(By.XPath(".//tbody/tr"));

            if (tbody.Count < 1)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public bool VerificarRetornoPesquisa(By locator, string filtro, string nomeColuna)
        {
            IWebElement table = WaitForElement(locator);
            if (ValidarExistenciaLinhas(locator).Equals(-1))
            {
                return false;
            }
            else
            {
                int colunaID = ObterColuna(locator, nomeColuna);
                IList<IWebElement> tarefas = table.FindElements(By.XPath($"./tbody/tr/td[{colunaID}]"));
                for (int i = 0; i < tarefas.Count; i++)
                {
                    if (!tarefas[i].Text.Contains(filtro))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public int ObterColuna(By locator, string nome)
        {
            IWebElement table = WaitForElement(locator);
            IList<IWebElement> colunas = table.FindElements(By.XPath(".//th"));
            if (colunas.Count.Equals(0))
            {
                 colunas = table.FindElements(By.XPath(".//td"));
            }
            int colunaId = -1;
            for (int i = 0; i < colunas.Count; i++)
            {
                if (colunas[i].Text.ToLower().Contains(nome.ToLower()))
                {
                    colunaId = i + 1;
                    break;
                }
            }
            return colunaId;
        }

        public int ObterIndiceLinhas(By locator, int colunaId, string nomeElemento)
        {
            IWebElement table = WaitForElement(locator);
            IList<IWebElement> linhas = table.FindElements(By.XPath(".//tbody/tr/td[" + colunaId + "]"));

            int limhaId = -1;
            for (int i = 0; i < linhas.Count; i++)
            {
                if (linhas[i].Text.Equals(nomeElemento))
                {
                    limhaId = i + 1;
                    break;
                }
            }

            return limhaId;
        }

        public void ClicarSobreLinha(By locator, string nomecoluna, string nomeElemento)
        {
            IWebElement table = WaitForElement(locator);
            int idColuna = ObterColuna(locator, nomecoluna);
            int idLinha = ObterIndiceLinhas(locator, idColuna, nomeElemento);
            table.FindElement(By.XPath($".//tr[{idLinha}]/td[{idColuna}]/a")).Click();
        }
        public void ClicarBotaoLinha(By locator, string nomecolunaPesq, string nomeElemento, string nomeColunaAcao)
        {
            IWebElement table = WaitForElement(locator);
            int idColunaPesquisa = ObterColuna(locator, nomecolunaPesq);
            int idLinha = ObterIndiceLinhas(locator, idColunaPesquisa, nomeElemento);
            int idColunaClick = ObterColuna(locator, nomeColunaAcao);
            table.FindElement(By.XPath($".//tr[{idLinha}]/td[{idColunaClick}]/div/div[1]")).Click();
        }
        public bool ValidarSelecaoTodos(By locator)
        {
            IWebElement table = WaitForElement(locator);
            IList<IWebElement> tarefas = table.FindElements(By.XPath($".//tbody/tr/td[1]/div/label/span"));
            for (int i = 0; i < tarefas.Count; i++)
            {
                if (tarefas[i].Selected)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
