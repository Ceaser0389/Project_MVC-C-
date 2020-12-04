using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.DAO;
using Sistema.Entidades;

namespace Sistema.DAO
{
    public class UsuarioDAO
    {
        public int Inserir(UsuarioEnt objTabela)
        {
            // metodo inserir 
           
                //cria uma nova conexão (nome coloquei con) depois eu instanciei a conexão 
                using (SqlConnection con = new SqlConnection())
                {

                    //aki associa obj (con com connnectionString)
                    con.ConnectionString = Properties.Settings.Default.banco;//aki assoaciação, conecçao feita por padrão pede default +nome
                    /* SqlCommand p vc usar comandos para comunicar com banco 
                    variavel aki usada foi cn, houve uma instanciação SqlCommand  */
                    SqlCommand cn = new SqlCommand();
                    /* CommandType é text pois as info geralmente passados em form de string  */
                    cn.CommandType = CommandType.Text; // tipo texto

                    //inicializar a conexao (abrir)
                    con.Open();

                    // aki eu passo o comando usado(geralemnte são os usados no bd) INSERT INTO + nome da tab (os valores[aki fica o valor]) VALUES(@parametro+valores ) obs id não é passado
                    cn.CommandText = "INSERT INTO usuarios([nome],[usuario],[senha]) VALUES(@nome,@usuario,@senha)";

                    // aki são definidos os parametros +valor +tipo SqlDbType + .VarChar(campo) .valor que recebe objTabela.Nome
                    cn.Parameters.Add("nome", SqlDbType.VarChar).Value = objTabela.Nome;
                    cn.Parameters.Add("usuario", SqlDbType.VarChar).Value = objTabela.Usuario;
                    cn.Parameters.Add("senha", SqlDbType.VarChar).Value = objTabela.Senha;

                    //associando  conexaoString meu obj SQLCommand
                    cn.Connection = con;

                    // varivel int que retorna um valor(registro) em inteiro 1 inseriu no banco 0 false
                    int qtd = cn.ExecuteNonQuery();
                    //cn(obj) + função ExecuteNonQuery fez a consulta
                    Console.Write(qtd);
                    return qtd;
                    // retorna a quantidade 
                }


        }

        public UsuarioEnt Login(UsuarioEnt obj)
        {
            using (SqlConnection con = new SqlConnection())
            {

                //aki associa obj (con com connnectionString)
                con.ConnectionString = Properties.Settings.Default.banco;//aki assoaciação, conecçao feita por padrão pede default +nome
                /* SqlCommand p vc usar comandos para comunicar com banco 
                variavel aki usada foi cn, houve uma instanciação SqlCommand  */
                SqlCommand cn = new SqlCommand();
                /* CommandType é text pois as info geralmente passados em form de string  */
                cn.CommandType = CommandType.Text; // tipo texto

                //inicializar a conexao (abrir)
                con.Open();

                // para consultar dados na tabela 
                cn.CommandText = "SELECT * from usuarios where usuario = @usuario AND senha = @senha";
                // os parametros seriam usados se utiliza-se where 

                //associando  conexaoString meu obj SQLCommand
                cn.Connection = con;

                cn.Parameters.Add("usuario", SqlDbType.VarChar).Value = obj.Usuario;
                cn.Parameters.Add("senha", SqlDbType.VarChar).Value = obj.Senha;

                SqlDataReader dr;  // usado para consultas 
                                   // execute reader para consulta os dados (armazenado remem obj dataReader)
                dr = cn.ExecuteReader();

                if (dr.HasRows)  // verificação se tem linhas no banco 
                {
                    // prenchimento da tabale retornada eplo data reader 
                    while (dr.Read()) // while que faz leitura dos dados  no dataReader
                    {
                        UsuarioEnt dado = new UsuarioEnt();  /// instanciaçao obj dado

                        dado.Usuario = Convert.ToString(dr["usuario"]);
                        dado.Senha = Convert.ToString(dr["senha"]);
                    }
                }
                else
                {
                    obj.Usuario = null; // não encontrar  obj é null
                    obj.Senha = null;
                }
                return obj;

            }
        }

        public List<UsuarioEnt> lista()
        {
            using (SqlConnection con = new SqlConnection())
            {

                //aki associa obj (con com connnectionString)
                con.ConnectionString = Properties.Settings.Default.banco;//aki assoaciação, conecçao feita por padrão pede default +nome
                /* SqlCommand p vc usar comandos para comunicar com banco 
                variavel aki usada foi cn, houve uma instanciação SqlCommand  */
                SqlCommand cn = new SqlCommand();
                /* CommandType é text pois as info geralmente passados em form de string  */
                cn.CommandType = CommandType.Text; // tipo texto

                //inicializar a conexao (abrir)
                con.Open();

                // para consultar dados na tabela 
                cn.CommandText = "SELECT * from usuarios ORDER BY id DESC";
                // os parametros seriam usados se utiliza-se where 

                //associando  conexaoString meu obj SQLCommand
                cn.Connection = con;

                SqlDataReader dr;  // usado para consultos 
                                   //  instanciei para usar o obj de lista 
                List<UsuarioEnt> lista = new List<UsuarioEnt>();

                // execute reader para consulta os dados (armazenado remem obj dataReader)
                dr = cn.ExecuteReader();

                if (dr.HasRows)  // verifica se tem linhas no banco 
                {
                    // prenchimento da tabale retornada eplo data reader 
                    while (dr.Read()) // while que faz leitura dos dados  no dataReader
                    {
                        UsuarioEnt dado = new UsuarioEnt();  /// instanciaçao obj dado genenrico 
                        dado.Id = Convert.ToInt32(dr["id"]);   // id recebe o dado (dai vc tem converter tipo de dado p campo) dai dr recebe dados do "id"
                        dado.Nome = Convert.ToString(dr["nome"]);
                        dado.Usuario = Convert.ToString(dr["usuario"]);
                        dado.Senha = Convert.ToString(dr["senha"]);


                        lista.Add(dado);
                    }
                }
                return lista;
            }

        }
    }
}
