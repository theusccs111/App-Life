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
    /// Classe de Teste das Projeções
    /// </summary>
    [TestClass()]
    public class projetadoTests
    {
        /// <summary>
        /// Método de Teste do Cadastro das Projeções, instanciando a variável para ser testada e comparada. 
        /// Logo após dos testes exclui a informação nova cadastrada do banco de dados.
        /// </summary>
        [TestMethod()]
        public void CadastrarProjetadoTest()
        {
            app_lifeContext contexto = new app_lifeContext();
            projetado teste = new projetado();
            projetado atual = new projetado();
            teste.Descricao = "teste";
            teste.Valor = 12345;
            teste.Data = "12/12/1212";
            teste.CategoriaID = 1;
            teste.UsuarioID = 1;
            teste.ProjetadoID = 999;



            //Execução
            teste.CadastrarProjetado(teste, 1);

            var query = from u in contexto.projetadoes where u.ProjetadoID == teste.ProjetadoID select u;
            foreach (var item in query)
            {
                atual.Descricao = item.Descricao;
                atual.Valor = item.Valor;
                atual.Data = item.Data;
                atual.CategoriaID = item.CategoriaID;
                atual.UsuarioID = item.UsuarioID;
                atual.ProjetadoID = item.ProjetadoID;
            }

            //teste
            Assert.AreEqual(teste.ProjetadoID, atual.ProjetadoID);
            teste.RemoverProjetado(teste.ProjetadoID);
        }

        /// <summary>
        /// Método de Teste da Remoção das Projeções, instanciando a variável para ser testada e comparada. 
        /// </summary>
        [TestMethod()]
        public void RemoverProjetadoTest()
        {
            app_lifeContext contexto = new app_lifeContext();
            projetado teste = new projetado();
            projetado atual = new projetado();
            teste.Descricao = "teste";
            teste.Valor = 12345;
            teste.Data = "12/12/1212";
            teste.CategoriaID = 1;
            teste.UsuarioID = 1;



            //Execução
            teste.CadastrarProjetado(teste, 1);
            atual.RemoverProjetado(teste.ProjetadoID);

            var query = from u in contexto.projetadoes where u.ProjetadoID == teste.ProjetadoID select u;
            foreach (var item in query)
            {
                atual.Descricao = item.Descricao;
                atual.Valor = item.Valor;
                atual.Data = item.Data;
                atual.CategoriaID = item.CategoriaID;
                atual.UsuarioID = item.UsuarioID;
                atual.ProjetadoID = item.ProjetadoID;
            }

            //teste
            Assert.AreNotSame(teste.ProjetadoID, atual.ProjetadoID);
        }
        /// <summary>
        /// Método de Teste da Alteração das Projeções, instanciando a variável para ser testada e comparada. 
        /// Logo após dos testes exclui a informação nova cadastrada do banco de dados.
        /// </summary>
        [TestMethod()]
        public void UpdateProjetadoTest()
        {
            app_lifeContext contexto = new app_lifeContext();
            projetado teste = new projetado();
            projetado atual = new projetado();
            teste.Descricao = "teste";
            teste.Valor = 12345;
            teste.Data = "12/12/1212";
            teste.CategoriaID = 1;
            teste.UsuarioID = 1;


            projetado atualizado = new projetado();
            atualizado.Descricao = "Mudado";
            atualizado.Valor = 54321;
            atualizado.CategoriaID = 2;
            atualizado.UsuarioID = 1;
            atualizado.Data = "09/09/1515";


            //Execução
            teste.CadastrarProjetado(teste, 1);


            var query = from u in contexto.projetadoes where u.ProjetadoID == teste.ProjetadoID select u;
            foreach (var item in query)
            {
                atual.Descricao = item.Descricao;
                atual.Valor = item.Valor;
                atual.Data = item.Data;
                atual.CategoriaID = item.CategoriaID;
                atual.UsuarioID = item.UsuarioID;
                atual.ProjetadoID = item.ProjetadoID;
                atualizado.ProjetadoID = item.ProjetadoID;

            }
            teste.UpdateProjetado(atualizado);
            //teste
            Assert.AreNotSame(teste, atual);

            teste.RemoverProjetado(teste.ProjetadoID);
        }
    }
}