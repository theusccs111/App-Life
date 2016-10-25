using Microsoft.VisualStudio.TestTools.UnitTesting;
using APP_Life;
using APP_Life.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace APP_Life.Models.Tests
{
    /// <summary>
    /// Classe de Teste de Usuários
    /// </summary>
    [TestClass()]
    public class usuarioTests
    {

        /// <summary>
        /// Método de Teste do Cadastro de Usuários, instanciando a variável para ser testada e comparada. 
        /// Logo após dos testes exclui a informação nova cadastrada do banco de dados.
        /// </summary>
        [TestMethod()]
        public void CadastrarUsuarioTest()
        {
            //ambiente   
            app_lifeContext contexto = new app_lifeContext();
            usuario teste = new usuario();
            usuario atual = new usuario();
            teste.email = "teste@teste.com";
            teste.senha = "12345";
            teste.nome = "teste";
            teste.sobrenome = "sobreTeste";
            teste.datanasc = new DateTime(2008, 5, 1, 8, 30, 52);
            teste.sexo = "M";
            teste.telefone = 78787878;
            teste.rua = "teste";
            teste.numero = 12;
            teste.bairro = "teste";
            teste.cidade = "teste";
            teste.estado = "teste";
            teste.Calorias = 12;
            teste.idfacebook = 0; 

            //Execução
            teste.CadastrarUsuario(teste);
            var query = from u in contexto.usuarios where u.usuarioID == teste.usuarioID  select u;
            foreach (var item in query)
            {
                atual.usuarioID = item.usuarioID;
                atual.email = item.email;
                atual.senha = item.senha;
                atual.nome = item.nome;
                atual.sobrenome = item.sobrenome;
                atual.datanasc = item.datanasc;
                atual.sexo = item.sexo;
                atual.telefone = item.telefone;
                atual.rua = item.rua;
                atual.numero = item.numero;
                atual.bairro = item.bairro;
                atual.cidade = item.cidade;
                atual.estado = item.estado;
                atual.Calorias = item.Calorias;
                atual.idfacebook = item.idfacebook;
            }

                //teste
                Assert.AreEqual(teste.usuarioID,atual.usuarioID);

            teste.RemoverUsuario(teste.usuarioID);


        }
        /// <summary>
        /// Método de Teste da Remoção de Usuário, instanciando a variável para ser testada e comparada. 
        /// </summary>
        [TestMethod()]
        public void RemoverUsuarioTest()
        {
            //ambiente   
            app_lifeContext contexto = new app_lifeContext();
            usuario teste = new usuario();
            usuario atual = new usuario();
            teste.email = "teste2@teste.com";
            teste.senha = "12345";
            teste.nome = "teste";
            teste.sobrenome = "sobreTeste";
            teste.datanasc = new DateTime(2008, 5, 1, 8, 30, 52);
            teste.sexo = "M";
            teste.telefone = 787872878;
            teste.rua = "teste";
            teste.numero = 12;
            teste.bairro = "teste";
            teste.cidade = "teste";
            teste.estado = "teste";
            teste.Calorias = 12;
            teste.usuarioID = 9999;
            teste.idfacebook = 0;
            //Execução
            teste.CadastrarUsuario(teste);
            teste.RemoverUsuario(teste.usuarioID);
            var query = from u in contexto.usuarios where u.usuarioID == teste.usuarioID select u;
            foreach (var item in query)
            {
                atual.usuarioID = item.usuarioID;
                atual.email = item.email;
                atual.senha = item.senha;
                atual.nome = item.nome;
                atual.sobrenome = item.sobrenome;
                atual.datanasc = item.datanasc;
                atual.sexo = item.sexo;
                atual.telefone = item.telefone;
                atual.rua = item.rua;
                atual.numero = item.numero;
                atual.bairro = item.bairro;
                atual.cidade = item.cidade;
                atual.estado = item.estado;
                atual.Calorias = item.Calorias;
                atual.idfacebook = item.idfacebook;
            }

            //teste
            Assert.AreNotSame(teste, atual);

        }

          

    }
}