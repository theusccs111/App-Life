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
    /// Classe de Testes da Lista de Alimentos da Dieta
    /// </summary>
    [TestClass()]
    public class lista_alimentosTests
    {
        /// <summary>
        /// Método de Teste do Cadastro dos Itens, instanciando a variável para ser testada e comparada. 
        /// Logo após dos testes exclui a informação nova cadastrada do banco de dados.
        /// </summary>
        [TestMethod()]
        public void CadastrarItensTest()
        {
            app_lifeContext contexto = new app_lifeContext();
            lista_alimentos teste = new lista_alimentos();
            lista_alimentos atual = new lista_alimentos();
            teste.IDAlimento = 1;
            teste.IDDieta = 1;
            teste.Medida = "Colher";
            teste.Quantidade = 1;
            
            //Execução
            teste.CadastrarItens(teste);

            var query = from u in contexto.lista_alimentos where u.IDDieta == teste.IDDieta select u;
            foreach (var item in query)
            {
                atual.IDAlimento = item.IDAlimento;
                atual.IDDieta = item.IDDieta;
                atual.Medida = item.Medida;
                atual.Quantidade = item.Quantidade;
            }

            //teste
            Assert.AreEqual(teste.IDDieta, atual.IDDieta);
        }
      
        [TestMethod()]
        public void GetEnumeratorTest()
        {
            Assert.Fail();
        }
    }
}