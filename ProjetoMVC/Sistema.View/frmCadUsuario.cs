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

                    try
                    {
                        objTabela.Id = Convert.ToInt32(txtCodico.Text);
                        int x = UsuarioModel.Excluir(objTabela);
                        
                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Usuário {0}  foi Excluido!", txtNome.Text));
                        }
                        else
                        {
                            MessageBox.Show("Não Excluido!");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Occoreu um erro ao Excluir!" + ex.Message);
                        throw;
                    }

                    break;
                
                case "Editar":
                    try
                    {
                        objTabela.Id = Convert.ToInt32(txtCodico.Text);
                        objTabela.Nome = txtNome.Text;
                        objTabela.Usuario = txtUsuario.Text;
                        objTabela.Senha = txtSenha.Text;

                        int x = UsuarioModel.Editar(objTabela);
                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Usuário {0}  foi Editado!", txtNome.Text));
                        }
                        else
                        {
                            MessageBox.Show("Não Editado!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Occoreu um erro ao Excluir!" + ex.Message);
                        throw;
                    }
             
                    break;
                
                case "Buscar":
                    try
                    {
                        objTabela.Nome = txtBuscar.Text;
                        List<UsuarioEnt> lista = new List<UsuarioEnt>();
                        lista = new UsuarioModel().Buscar(objTabela);
                        grid.AutoGenerateColumns = false;
                        grid.DataSource = lista;



                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Erro ao listar os Dados" + ex.Message);
                    }

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
            txtCodico.Text = "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            opc = "Salvar";
            IniciarOpc();
            ListarGrid();
            DesabilitarCampos();
            LimparCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtCodico.Text == "")
            {
                MessageBox.Show("Selecione um registo na tabela para poder excluir !!!");
                return;
            }
            opc = "Excluir";
            IniciarOpc();
            ListarGrid();
            DesabilitarCampos();
            LimparCampos();
        }

        private void btbEditar_Click(object sender, EventArgs e)
        {
            if (txtCodico.Text == "")
            {
                MessageBox.Show("Selecione um registo na tabela para poder editar !!!");
                return;
            }
            opc = "Editar";
            IniciarOpc();
            ListarGrid();
            DesabilitarCampos();
            LimparCampos();
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

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodico.Text = grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtUsuario.Text = grid.CurrentRow.Cells[2].Value.ToString();
            txtSenha.Text = grid.CurrentRow.Cells[3].Value.ToString();
            HabilitarCampos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if(txtBuscar.Text =="")
            {
                ListarGrid();
                return;
            }
            opc = "Buscar";
            IniciarOpc();
        }

        //private void btnProduto_Click(object sender, EventArgs e)
        //  {
        //opc""
        ///}
    }
}
