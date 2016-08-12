using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace APP_Life.Models
{
    public class CrudUsuario
    {
        app_lifeContext context = new app_lifeContext();
        public void InsertOrUpdate(usuario user)
        {
            try
            {
                context.Entry(user).State = user.usuarioID == 0 ? EntityState.Added : EntityState.Modified;
                context.SaveChanges();
            }
            catch(Exception)
            {
                throw;
            }

        }

        public void delete(int id)
        {
            try
            {

                var user = context.usuarios.Find(id);
                context.usuarios.Remove(user);
                context.SaveChanges();
            }
            catch(Exception)
            {
                throw;
            }

        }
    }
}