// <copyright file="receitaTest.cs">Copyright ©  2016</copyright>
using System;
using APP_Life.Models;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APP_Life.Models.Tests
{
    /// <summary>This class contains parameterized unit tests for receita</summary>
    [PexClass(typeof(receita))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class receitaTest
    {
        /// <summary>Test stub for CadastrarReceita(receita, Int32)</summary>
        [PexMethod]
        public void CadastrarReceitaTest(
            [PexAssumeUnderTest]receita target,
            receita rece,
            int id
        )
        {
            target.CadastrarReceita(rece, id);
            // TODO: add assertions to method receitaTest.CadastrarReceitaTest(receita, receita, Int32)
        }
    }
}
