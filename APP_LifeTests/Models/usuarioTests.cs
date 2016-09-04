using Microsoft.VisualStudio.TestTools.UnitTesting;
using APP_Life;
using APP_Life.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_Life.Models.Tests
{
    [TestClass()]
    public class usuarioTests
    {
        [TestMethod()]
        public void CadastrarUsuarioTest()
        {
            app_lifeContext contexto = new app_lifeContext();
            usuario teste = new usuario();
            teste.email = "teste@teste.com";
            teste.senha = "12345";
            teste.CadastrarUsuario(teste);
            Assert.AreEqual(teste,);



        }
    }
}