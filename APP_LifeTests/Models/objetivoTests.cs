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
    /// Classe de Testes dos Objetivos
    /// </summary>
    [TestClass()]
    public class objetivoTests
    {
        /// <summary>
        /// Método de Teste do Cadastro dos Objetivos, instanciando a variável para ser testada e comparada. 
        /// Logo após dos testes exclui a informação nova cadastrada do banco de dados.
        /// </summary>
        [TestMethod()]
        public void CadastrarObjetivoTest()
        {
            app_lifeContext contexto = new app_lifeContext();
            objetivo teste = new objetivo();
            objetivo atual = new objetivo();
            teste.Nome = "moto";
            teste.ValorAtual = 1000;
            teste.ValorTotal = 2000;
            teste.UsuarioID = 1;

            //Execução
            teste.CadastrarObjetivo(teste, 1);

            var query = from u in contexto.objetivos where u.ObjetivoID == teste.ObjetivoID select u;
            foreach (var item in query)
            {
                atual.Nome = item.Nome;
                atual.ValorAtual = item.ValorAtual;
                atual.ValorTotal = item.ValorTotal;
                atual.UsuarioID = item.UsuarioID;
            }

            //teste
            Assert.AreEqual(teste.ObjetivoID, atual.ObjetivoID);
            teste.RemoverObjetivo(teste.ObjetivoID);
        }
        /// <summary>
        /// Método de Teste de Remoção dos Objetivos, instanciando a variável para ser testada e comparada. 
        /// </summary>
        [TestMethod()]
        public void RemoverObjetivoTest()
        {
            app_lifeContext contexto = new app_lifeContext();
            objetivo teste = new objetivo();
            objetivo atual = new objetivo();
            teste.Nome = "moto";
            teste.ValorAtual = 1000;
            teste.ValorTotal = 2000;
            teste.UsuarioID = 1;

            //Execução
            teste.CadastrarObjetivo(teste, 1);
            teste.RemoverObjetivo(teste.O);

            var query = from u in contexto.objetivos select u;
            foreach (var item in query)
            {
                if (item.ObjetivoID == teste.ObjetivoID)
                {
                    atual.Nome = item.Nome;
                    atual.ValorAtual = item.ValorAtual;
                    atual.ValorTotal = item.ValorTotal;
                    atual.UsuarioID = item.UsuarioID;
                }
            }

            //teste
            Assert.AreNotSame(teste, atual);
        }

        /// <summary>
        /// Método de Teste de Alteração dos Objetivos, instanciando a variável para ser testada e comparada. 
        /// Logo após dos testes exclui a informação nova cadastrada do banco de dados.
        /// </summary>

        [TestMethod()]
        public void UpdateObjetivoTest()
        {
            app_lifeContext contexto = new app_lifeContext();
            objetivo teste = new objetivo();
            objetivo atual = new objetivo();
            teste.Nome = "moto";
            teste.ValorAtual = 1000;
            teste.ValorTotal = 2000;
            teste.UsuarioID = 1;

            objetivo atualizado = new objetivo();
            atualizado.Nome = "Mudado";
            atualizado.ValorAtual = 500;
            atualizado.ValorTotal = 3000;
            atualizado.UsuarioID = 1;

            //Execução
            teste.CadastrarObjetivo(teste, 1);


            var query = from u in contexto.objetivos where u.ObjetivoID == teste.ObjetivoID select u;
            foreach (var item in query)
            {
                if (item.ObjetivoID == teste.ObjetivoID)
                {
                    atual.Nome = item.Nome;
                    atual.ValorAtual = item.ValorAtual;
                    atual.ValorTotal = item.ValorTotal;
                    atual.UsuarioID = item.UsuarioID;
                }

            }
            teste.UpdateObjetivo(atualizado);
            //teste
            Assert.AreNotSame(teste, atual);
            teste.RemoverObjetivo(teste.ObjetivoID);
        }


        [TestMethod()]
        public void GetEnumeratorTest()
        {
            Assert.Fail();
        }
    }
}