﻿using Desafio_Mantis.Bases;
using Desafio_Mantis.DataBaseSteps;
using Desafio_Mantis.Helpers;
using Desafio_Mantis.Pages;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Desafio_Mantis.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        #region Pages and Flows Objects
        [AutoInstance] LoginPage loginPage;
        [AutoInstance] MainPage mainPage;
        #endregion

        #region Data Driven Providers
        public static IEnumerable EfetuarLoginInformandoUsuarioInvalidoIProvider()
        {
            return GeneralHelpers.ReturnCSVData(GeneralHelpers.ReturnProjectPath() + "Resources/TestData/Login/EfetuarLoginInformandoUsuarioInvalidoData.csv");
        }
        #endregion

        [Test]
        public void EfetuarLoginComSucesso()
        {
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            #endregion
            loginPage.PreenhcerUsuario(usuario);
            loginPage.PreencherSenha(senha);
            loginPage.ClicarEmEntrar();

            Assert.AreEqual(usuario, mainPage.RetornaUsernameDasInformacoesDeLogin());
        }

        [Test, TestCaseSource("EfetuarLoginInformandoUsuarioInvalidoIProvider")]
        public void EfetuarLoginInformandoUsuarioInvalido(ArrayList testData)
        {
            #region Parameters
            string usuario = testData[0].ToString();
            string senha = testData[1].ToString();
            string mensagemErroEsperada = "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.";
            #endregion

            loginPage.PreenhcerUsuario(usuario);
            loginPage.PreencherSenha(senha);
            loginPage.ClicarEmEntrar();

            Assert.AreEqual(mensagemErroEsperada, loginPage.RetornaMensagemDeErro());
        }
    }
}
