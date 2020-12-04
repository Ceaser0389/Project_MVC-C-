using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Entidades;
using Sistema.DAO;
namespace Sistema.Model
{
    public class UsuarioModel
    {
        public static int Inserir(UsuarioEnt objTabela)
        {
            return new UsuarioDAO().Inserir(objTabela);
        }

        public List<UsuarioEnt> lista()
        {
            return new UsuarioDAO().lista();
        }

        public UsuarioEnt Login(UsuarioEnt obj)
        {
            return new UsuarioDAO().Login(obj);
        }
    }
}
