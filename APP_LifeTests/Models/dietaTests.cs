using Microsoft.VisualStudio.TestTools.UnitTesting;
using APP_Life.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_Life.Models.Tests
{

    /// <summary>
    /// Classe de Teste das Dietas
    /// </summary
    [TestClass()]
    public class dietaTests
    {
        /// <summary>
        /// Método de Teste do Cadastro das Dietas, instanciando a variável para ser testada e comparada. 
        /// Logo após dos testes exclui a informação nova cadastrada do banco de dados.
        /// </summary>
        [TestMethod()]
        public void CadastrarDietaTest()
        {
            app_lifeContext contexto = new app_lifeContext();
            dieta teste = new dieta();
            dieta atual = new dieta();
            teste.Nome = "teste";
            teste.UsuarioID = 1;
            
            //Execução
            teste.CadastrarDieta(teste, 1);

            var query = from u in contexto.dietas where u.DietaID == teste.DietaID select u;
            foreach (var item in query)
            {
                atual.Nome = item.Nome;
                atual.UsuarioID = item.UsuarioID;
            }

            //teste
            Assert.AreEqual(teste.DietaID, atual.DietaID);
            teste.RemoverDieta(teste.DietaID);
        }
        /// <summary>
        /// Método de Teste de Remoção das Dieas, instanciando a variável para ser testada e comparada. 
        /// </summary>
        [TestMethod()]
        public void RemoverDietaTest()
        {
            app_lifeContext contexto = new app_lifeContext();
            dieta teste = new dieta();
            dieta atual = new dieta();
            teste.Nome = "teste";
            teste.UsuarioID = 1;
            
            //Execução
            teste.CadastrarDieta(teste, 1);
            teste.RemoverDieta(teste.DietaID);

            var query = from u in contexto.dietas select u;
            foreach (var item in query)
            {
                if (item.DietaID == teste.DietaID)
                {
                    atual.Nome = item.Nome;
                    atual.UsuarioID = item.UsuarioID;
                }
            }

            //teste
            Assert.AreNotSame(teste, atual);
        }

        /// <summary>
        /// Método de Teste de Alteração das Dietas, instanciando a variável para ser testada e comparada. 
        /// Logo após dos testes exclui a informação nova cadastrada do banco de dados.
        /// </summary>
        [TestMethod()]
        public void UpdateDietaTest()
        {
            app_lifeContext contexto = new app_lifeContext();
            dieta teste = new dieta();
            dieta atual = new dieta();
            teste.Nome = "teste";
            teste.UsuarioID = 1;

            dieta atualizado = new dieta();
            atualizado.Nome = "Mudado";
            atualizado.UsuarioID = 1;

            //Execução
            teste.CadastrarDieta(teste, 1);


            var query = from u in contexto.dietas where u.DietaID == teste.DietaID select u;
            foreach (var item in query)
            {
                if (item.DietaID == teste.DietaID)
                {
                    atual.Nome = item.Nome;
                    atual.UsuarioID = item.UsuarioID;
                }

            }
            teste.UpdateDieta(atualizado);
            //teste
            Assert.AreNotSame(teste, atual);

            teste.RemoverDieta(teste.DietaID);
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            Assert.Fail();
        }
    }
}