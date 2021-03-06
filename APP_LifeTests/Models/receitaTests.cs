﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using APP_Life.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_Life.Models.Tests
{
   
    /// <summary>
    /// Classe de Teste das Receitas
    /// </summary>
    [TestClass()]
    public class receitaTests
    {
        /// <summary>
        /// Método de Teste do Cadastro das Receitas, instanciando a variável para ser testada e comparada. 
        /// Logo após dos testes exclui a informação nova cadastrada do banco de dados.
        /// </summary>
        [TestMethod()]
        public void CadastrarReceitaTest()
        {
            app_lifeContext contexto = new app_lifeContext();
            receita teste = new receita();
            receita atual = new receita();
            teste.Descricao = "teste";
            teste.Valor = 12345;
            teste.Data = "12/12/1212";
            teste.CategoriaID = 1;
            teste.UsuarioID = 1;
            teste.ReceitaID = 999;
          

            //Execução
            teste.CadastrarReceita(teste,1);
     
            var query = from u in contexto.receitas where u.ReceitaID == teste.ReceitaID select u;
            foreach (var item in query)
            {
                atual.Descricao = item.Descricao;
                atual.Valor = item.Valor;
                atual.Data = item.Data;
                atual.CategoriaID = item.CategoriaID;
                atual.UsuarioID = item.UsuarioID;
                atual.ReceitaID = item.ReceitaID;

            }

            //teste
            Assert.AreEqual(teste.ReceitaID, atual.ReceitaID);
            teste.RemoverReceita(teste.ReceitaID);
        }
        /// <summary>
        /// Método de Teste da Remoção das Receitas, instanciando a variável para ser testada e comparada. 
        /// </summary>
        [TestMethod()]
        public void RemoverReceitaTest()
        {
            app_lifeContext contexto = new app_lifeContext();
            receita teste = new receita();
            receita atual = new receita();
            teste.Descricao = "teste";
            teste.Valor = 12345;
            teste.Data = "12/12/1212";
            teste.CategoriaID = 1;
            teste.UsuarioID = 1;
          


            //Execução
            teste.CadastrarReceita(teste, 1);
            atual.RemoverReceita(teste.ReceitaID);

            var query = from u in contexto.receitas where u.ReceitaID == teste.ReceitaID select u;
            foreach (var item in query)
            {
                atual.Descricao = item.Descricao;
                atual.Valor = item.Valor;
                atual.Data = item.Data;
                atual.CategoriaID = item.CategoriaID;
                atual.UsuarioID = item.UsuarioID;
                atual.ReceitaID = item.ReceitaID;
            }

            //teste
            Assert.AreNotSame(teste.ReceitaID, atual.ReceitaID);
        }
        /// <summary>
        /// Método de Teste da Alteração das Receitas, instanciando a variável para ser testada e comparada. 
        /// Logo após dos testes exclui a informação nova cadastrada do banco de dados.
        /// </summary>
        [TestMethod()]
        public void UpdateReceitaTest()
        {
            app_lifeContext contexto = new app_lifeContext();
            receita teste = new receita();
            receita atual = new receita();
            teste.Descricao = "teste";
            teste.Valor = 12345;
            teste.Data = "12/12/1212";
            teste.CategoriaID = 1;
            teste.UsuarioID = 1;
           

            receita atualizado = new receita();
            atualizado.Descricao = "Mudado";
            atualizado.Valor = 54321;
            atualizado.CategoriaID = 2;
            atualizado.UsuarioID = 1;
            atualizado.Data = "09/09/1515";


            //Execução
            teste.CadastrarReceita(teste, 1);
           

            var query = from u in contexto.receitas where u.ReceitaID == teste.ReceitaID select u;
            foreach (var item in query)
            {
                atual.Descricao = item.Descricao;
                atual.Valor = item.Valor;
                atual.Data = item.Data;
                atual.CategoriaID = item.CategoriaID;
                atual.UsuarioID = item.UsuarioID;
                atual.ReceitaID = item.ReceitaID;
                atualizado.ReceitaID = item.ReceitaID;

            }
            teste.UpdateReceita(atualizado);
            //teste
            Assert.AreNotSame(teste, atual);

            teste.RemoverReceita(teste.ReceitaID);
        }


    }
}