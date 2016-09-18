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
    /// Classe de Testes das Despesas
    /// </summary>
    [TestClass()]
    public class despesaTests
    {
        /// <summary>
        /// Método de Teste do Cadastro das Despesas, instanciando a variável para ser testada e comparada. 
        /// Logo após dos testes exclui a informação nova cadastrada do banco de dados.
        /// </summary>
        [TestMethod()]
                public void CadastrarDespesaTest()
        {
            
            app_lifeContext contexto = new app_lifeContext();
            despesa teste = new despesa();
            despesa atual = new despesa();
            teste.Descricao = "teste";
            teste.Valor = 12345;
            teste.Data = "12/12/1212";
            teste.CategoriaID = 1;
            teste.UsuarioID = 1;

            //Execução
            teste.CadastrarDespesa(teste, 1);

            var query = from u in contexto.despesas where u.DespesaID == teste.DespesaID select u;
            foreach (var item in query)
            {
                atual.Descricao = item.Descricao;
                atual.Valor = item.Valor;
                atual.Data = item.Data;
                atual.CategoriaID = item.CategoriaID;
                atual.UsuarioID = item.UsuarioID;
                atual.DespesaID = item.DespesaID;
            }

            //teste
            Assert.AreEqual(teste.DespesaID, atual.DespesaID);
            teste.RemoverDespesa(teste.DespesaID);
        }
        /// <summary>
        /// Método de Teste de Remoção das Despesas, instanciando a variável para ser testada e comparada. 
        /// </summary>
        [TestMethod()]
        public void RemoverDespesaTest()
        {
            app_lifeContext contexto = new app_lifeContext();
            despesa teste = new despesa();
            despesa atual = new despesa();
            teste.Descricao = "teste";
            teste.Valor = 12345;
            teste.Data = "12/12/1212";
            teste.CategoriaID = 1;
            teste.UsuarioID = 1;
          


            //Execução
            teste.CadastrarDespesa(teste, 1);
            teste.RemoverDespesa(teste.DespesaID);

            var query = from u in contexto.despesas  select u;
            foreach (var item in query)
            {
                if (item.DespesaID == teste.DespesaID)
                {
                    atual.Descricao = item.Descricao;
                    atual.Valor = item.Valor;
                    atual.Data = item.Data;
                    atual.CategoriaID = item.CategoriaID;
                    atual.UsuarioID = item.UsuarioID;
                    atual.DespesaID = item.DespesaID;
                }
            }

            //teste
            Assert.AreNotSame(teste, atual);
        }

        /// <summary>
        /// Método de Teste de Alteração das Despesas, instanciando a variável para ser testada e comparada. 
        /// Logo após dos testes exclui a informação nova cadastrada do banco de dados.
        /// </summary>
        [TestMethod()]
        public void UpdateDespesaTest()
        {
            app_lifeContext contexto = new app_lifeContext();
            despesa teste = new despesa();
            despesa atual = new despesa();
            teste.Descricao = "teste";
            teste.Valor = 12345;
            teste.Data = "12/12/1212";
            teste.CategoriaID = 1;
            teste.UsuarioID = 1;

            despesa atualizado = new despesa();
            atualizado.Descricao = "Mudado";
            atualizado.Valor = 54321;
            atualizado.CategoriaID = 2;
            atualizado.UsuarioID = 1;
            atualizado.Data = "09/09/1515";
            atualizado.DespesaID = teste.DespesaID;

            //Execução
            teste.CadastrarDespesa(teste, 1);
          

            var query = from u in contexto.despesas where u.DespesaID == teste.DespesaID select u;
            foreach (var item in query)
            {
                if (item.DespesaID == teste.DespesaID)
                {
                    atual.Descricao = item.Descricao;
                    atual.Valor = item.Valor;
                    atual.Data = item.Data;
                    atual.CategoriaID = item.CategoriaID;
                    atual.UsuarioID = item.UsuarioID;
                    atualizado.DespesaID = item.DespesaID;
                }

            }
            teste.UpdateDespesa(atualizado);
            //teste
            Assert.AreNotSame(teste, atual);

        teste.RemoverDespesa(teste.DespesaID);
        }





    }
}