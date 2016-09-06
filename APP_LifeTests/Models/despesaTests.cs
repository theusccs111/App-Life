using Microsoft.VisualStudio.TestTools.UnitTesting;
using APP_Life.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_Life.Models.Tests
{
    [TestClass()]
    public class despesaTests
    {
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
            Assert.AreNotSame(teste, atual);
        }

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
            teste.DespesaID = 999;

            despesa atualizado = new despesa();
            atualizado.Descricao = "Mudado";
            atualizado.Valor = 54321;
            atualizado.CategoriaID = 2;
            atualizado.UsuarioID = 3;
            atualizado.Data = "09/09/1515";


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

            }
            teste.UpdateDespesa(atualizado);
            //teste
            Assert.AreNotSame(teste, atual);
        }





    }
}