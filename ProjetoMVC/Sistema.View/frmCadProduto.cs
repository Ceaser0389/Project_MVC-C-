using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Model;
using Sistema.Entidades;
namespace Sistema.View
{
    public partial class frmCadProduto : Form
    {
        ProdutoEnt objTabela = new ProdutoEnt();
        public frmCadProduto()
        {
            InitializeComponent();
        }

        private void ListarGrid()
        {
            try
            {
                List<ProdutoEnt> lista = new List<ProdutoEnt>();
                lista = new ProdutoModel().Lista();
                grid1.AutoGenerateColumns = false;
                grid1.DataSource = lista;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao Listar Dados" + ex.Message);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            opc = "Novo";
            iniciarOpc();
        }


        private string opc = "";

        private void iniciarOpc()
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
                        objTabela.Descricao = txtDescricao.Text;
                        objTabela.Valor = (decimal)Convert.ToDecimal(txtValor.Text);

                        int x = ProdutoModel.Inserir(objTabela);

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Produto {0} foi inserido!", txtNome.Text));
                        }
                        else
                        {
                            MessageBox.Show("Não inserido!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao Salvar" + ex.Message);

                    }
                    break;

                case "Excluir":
                    try
                    {


                        objTabela.Id = Convert.ToInt32(txtCodigo.Text);

                        int x = ProdutoModel.Excluir(objTabela);

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Produto {0} foi Excluido!", txtNome.Text));
                        }
                        else
                        {
                            MessageBox.Show("Não Excluido!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao Excluir" + ex.Message);

                    }
                    break;

                case "Editar":
                    try
                    {
                        objTabela.Id = Convert.ToInt32(txtCodigo.Text);
                        objTabela.Nome = txtNome.Text;
                        objTabela.Descricao = txtDescricao.Text;
                        objTabela.Valor = (decimal)Convert.ToDecimal(txtValor.Text);

                        int x = ProdutoModel.Editar(objTabela);

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Produto {0} foi Editado!", txtNome.Text));
                        }
                        else
                        {
                            MessageBox.Show("Não Alterado!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao Salvar" + ex.Message);

                    }
                    break;

                case "Buscar":
                    try
                    {

                        objTabela.Nome = txtBuscar.Text;
                        List<ProdutoEnt> lista = new List<ProdutoEnt>();
                        lista = new ProdutoModel().Buscar(objTabela);

                        grid1.AutoGenerateColumns = false;
                        grid1.DataSource = lista;

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Erro ao Listar Dados" + ex.Message);
                    }
                    break;

                default:
                    break;
            }


        }


        private void HabilitarCampos()
        {
            txtNome.Enabled = true;
            txtDescricao.Enabled = true;
            txtValor.Enabled = true;
        }

        private void DesabilitarCampos()
        {
            txtNome.Enabled = false;
            txtDescricao.Enabled = false;
            txtValor.Enabled = false;
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtValor.Text = "";
            txtCodigo.Text = "";
        }

        private void btnNovo_Click_1(object sender, EventArgs e)
        {
            opc = "Novo";
            iniciarOpc();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            opc = "Salvar";
            iniciarOpc();
            ListarGrid();
            DesabilitarCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Selecione um registro na Tabela para poder excluir!!");
                return;
            }
            opc = "Excluir";
            iniciarOpc();
            ListarGrid();
            DesabilitarCampos();
            LimparCampos();


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Selecione um registro na Tabela para poder Editar!!");
                return;
            }

            opc = "Editar";
            iniciarOpc();
            ListarGrid();
            DesabilitarCampos();
            LimparCampos();
        }

        private void grid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = grid1.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = grid1.CurrentRow.Cells[1].Value.ToString();
            txtDescricao.Text = grid1.CurrentRow.Cells[2].Value.ToString();
            txtValor.Text = grid1.CurrentRow.Cells[3].Value.ToString();
            HabilitarCampos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                ListarGrid();
                return;
            }

            opc = "Buscar";
            iniciarOpc();
        }

        private void frmCadProduto_Load(object sender, EventArgs e)
        {
            ListarGrid();
        }
    }
}
