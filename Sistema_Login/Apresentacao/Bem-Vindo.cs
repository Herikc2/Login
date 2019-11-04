using Sistema_Login.Modelo;
using System;
using System.Windows.Forms;

namespace Sistema_Login.Apresentacao
{
    public partial class Bem_Vindo : Form
    {

        public Bem_Vindo()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();

            dvgPessoa.DataSource = controle.filtrarPessoa(rdnM, rdnM, rdnO, txtNomeFiltro.Text, txtEmailFiltro.Text, txtCPF.Text);

            if (!controle.mensagem.Equals(""))
                MessageBox.Show(controle.mensagem, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();

            controle.mensagem = controle.inserirPessoa(rdnM, rdnF, rdnO, txtNomeFiltro.Text, txtEmailFiltro.Text, txtCPF.Text);
            cicloConclusivo(controle);
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();   

            if (txtCPF.Text == string.Empty)
            {
                MessageBox.Show("O campo CPF não foi preenchido", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            controle.mensagem = controle.deletarPessoa(txtCPF.Text);
            cicloConclusivo(controle);        
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            dvgPessoa.DataSource = controle.atualizarExibicao();

            if (!controle.mensagem.Equals(""))
                MessageBox.Show(controle.mensagem, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }      

        private void dvgPessoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNomeFiltro.Text = Convert.ToString(dvgPessoa.Rows[e.RowIndex].Cells[1].Value);
            txtCPF.Text = Convert.ToString(dvgPessoa.Rows[e.RowIndex].Cells[3].Value);
            txtEmailFiltro.Text = Convert.ToString(dvgPessoa.Rows[e.RowIndex].Cells[2].Value);
        }

        public void limpaTextBox(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                if (c.HasChildren)
                {
                    limpaTextBox(c);
                }
            }
        }

        private void cicloConclusivo(Controle controle)
        {
            if (controle.mensagem.Equals(""))
            {
                dvgPessoa.DataSource = controle.atualizarExibicao();
                Mensagem();
                limpaTextBox(this);
            }
            else
                MessageBox.Show(controle.mensagem, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Mensagem()
        {
            MessageBox.Show("Operação realizada com sucesso!", "OPERAÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            controle.mensagem = controle.about(txtCPF.Text);

            if (!controle.mensagem.Equals(""))
                MessageBox.Show(controle.mensagem, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
