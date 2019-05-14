using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
    class GerenciarPage : PageBase
    {
        #region Mapping
        By menuGerenciarButton = By.XPath("//*[@id='sidebar']/ul/li[7]/a/span");
        #endregion
        public void ClicarGerenciar()
        {
            Click(menuGerenciarButton);
        }
    }
}
