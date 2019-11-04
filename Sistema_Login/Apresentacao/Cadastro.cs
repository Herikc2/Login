using Sistema_Login.Modelo;
using System;
using System.Windows.Forms;

namespace Sistema_Login.Apresentacao
{
    public partial class CadastreSe : Form
    {

        public static string valueLblForcaSenha;
        public static string valueLblPontosSenha;

        public CadastreSe()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            String mensagem = controle.cadastrar(txtLogin.Text, txtSenha.Text, txtConfSenha.Text);

            if (controle.tem)
            {   
                this.Close();
                MessageBox.Show(mensagem, "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblForcaSenha.Text = valueLblForcaSenha;
                lblPontosSenha.Text = valueLblPontosSenha;
                txtSenha.Text = "";
                txtConfSenha.Text = "";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
