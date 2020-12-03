using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Entidades;
using Sistema.Model;
namespace Sistema.View
{
    public partial class frmCadUsuario : Form
    {
        UsuarioEnt objTabela = new UsuarioEnt();


        public frmCadUsuario()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            opc="Novo";
            IniciarOpc();
           
        }
    
    

        private string opc = "";
        public void IniciarOpc()
        {
            switch (opc)
            {
                case "Novo":
                    HabilitarCampos();
                    LimparCampos();
                    break;
               
                case "Salvar":
                    try
                    {
                        objTabela.Nome = txtNome.Text;
                        objTabela.Usuario = txtUsuario.Text;
                        objTabela.Senha = txtSenha.Text;

                        int x = UsuarioModel.Inserir(objTabela);
                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Usuário {0}  foi inserio!", txtNome.Text));
                        }
                        else
                        {
                            MessageBox.Show("Não inserido");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao Salvar"+ ex.Message);
                        throw;
                    }
                    
                    
                    break;
                
                case "Excluir":
                    break;
                
                case "Editar":
                    break;
                
                case "Buscar":
                    break;
                
                default:
                    break;
            }




        }

        public void HabilitarCampos()
        {
            txtNome.Enabled = true;
            txtUsuario.Enabled = true;
            txtSenha.Enabled = true;
        }


        public void DesabilitarCampos()
        {
            txtNome.Enabled = false;
            txtUsuario.Enabled = false;
            txtSenha.Enabled = false;
        }

        public void LimparCampos()
        {
            txtNome.Text = "";
            txtUsuario.Text = "";
            txtSenha.Text = "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            opc = "Salvar";
            IniciarOpc();
            ListarGrid();
            DesabilitarCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            opc = "Excluir";
            IniciarOpc();
        }

        private void btbEditar_Click(object sender, EventArgs e)
        {
            opc = "Editar";
            IniciarOpc();
        }

        private void ListarGrid()
        {
            try
            {
                List<UsuarioEnt> lista = new List<UsuarioEnt>();
                lista = new UsuarioModel().lista();
                grid.AutoGenerateColumns = false;
                grid.DataSource = lista;



            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao listar os Dados" + ex.Message);
            }
        }

        private void frmCadUsuario_Load(object sender, EventArgs e)
        {
            ListarGrid();
        }
    }
}
