using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.Flows;
using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Tests
{
    [TestFixture]
    class GerenciarPerfisGlobais : TestBase
    {
        #region Pages and Flows Objects
        [AutoInstance] MainPage mainPage;
        [AutoInstance] GerenciarPerfisGlobaisPage gerenciarPerfisGlobaisPage;
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] GerenciarPerfisGlobaisFlows gerenciarPerfisGlobaisFlows;
        #endregion

        [Test]
        public void CadastrarPerfilSucesso()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string plataforma = "ffff";
            string so = "mac";
            string versaoSo = "1.3";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPerfisGlobaisFlows.CadastrarPerfilGlobal(plataforma, so, versaoSo);
            Assert.IsTrue(gerenciarPerfisGlobaisPage.ValidarCadastroPerfilGolbal(plataforma), "Perfil não cadastrado.");
        }
        [Test]
        public void PlataformaObrigatorio()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string mensagemEsperada = "Preencha este campo.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPerfisGlobaisFlows.AcessarGerenciarPerfis();
            gerenciarPerfisGlobaisPage.ClicarAdicionarPerfil();
            Assert.AreEqual(mensagemEsperada, gerenciarPerfisGlobaisPage.RetornaMensagemObrigatoriedadePlataforma());
        }
        [Test]
        public void VersaoSOObrigatorio()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string plataforma = "plat";
            string mensagemEsperada = "Preencha este campo.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPerfisGlobaisFlows.AcessarGerenciarPerfis();
            gerenciarPerfisGlobaisPage.PreencherPlataforma(plataforma);
            gerenciarPerfisGlobaisPage.ClicarAdicionarPerfil();
            Assert.AreEqual(mensagemEsperada, gerenciarPerfisGlobaisPage.RetornaMensagemObrigatoriedadeSO());
        }
        [Test]
        public void EnviarSemSelecionarUmdosParametros()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string mensagemEsperada = "Um parâmetro necessário para esta página (action) não foi encontrado.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPerfisGlobaisFlows.AcessarGerenciarPerfis();
            gerenciarPerfisGlobaisPage.ClicarEmEviar();
            Assert.AreEqual(mensagemEsperada, gerenciarPerfisGlobaisPage.RetornaMensagemDeErro());
        }
        [Test]
        public void EditarSemSelecionarUmPerfil()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string mensagemEsperada = "Um campo necessário 'Selecionar Perfil' estava vazio. Por favor, verifique novamente suas entradas.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPerfisGlobaisFlows.AcessarGerenciarPerfis();
            gerenciarPerfisGlobaisPage.ClicarEmEditar();
            gerenciarPerfisGlobaisPage.ClicarEmEviar();
            Assert.AreEqual(mensagemEsperada, gerenciarPerfisGlobaisPage.RetornaMensagemDeErro());
        }
        [Test]
        public void EditarPerfilSucesso()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string perfil = "erika mac 1.3";
            string plataformaEdicao = "mac";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPerfisGlobaisFlows.EdiatarPerfilGlobal(perfil, plataformaEdicao);
            Assert.IsTrue(gerenciarPerfisGlobaisPage.ValidarCadastroPerfilGolbal(plataformaEdicao), "Perfil não foi editado.");
        }
        [Test]
        public void ApagarSemSelecionarUmPerfil()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string mensagemEsperada = "Um campo necessário 'Selecionar Perfil' estava vazio. Por favor, verifique novamente suas entradas.";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPerfisGlobaisFlows.AcessarGerenciarPerfis();
            gerenciarPerfisGlobaisPage.ClicarEmApagar();
            gerenciarPerfisGlobaisPage.ClicarEmEviar();
            Assert.AreEqual(mensagemEsperada, gerenciarPerfisGlobaisPage.RetornaMensagemDeErro());
        }
        [Test]
        public void ApagarPerfilScuesso()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string perfil = "erika mac 1.3";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPerfisGlobaisFlows.ApagarPerfilGlobal(perfil);
            Assert.IsFalse(gerenciarPerfisGlobaisPage.ValidarCadastroPerfilGolbal(perfil), "Perfil não foi apagado.");
        }
    }
}