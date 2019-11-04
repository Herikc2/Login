using Sistema_Login.Apresentacao;   
using Sistema_Login.Modelo;
using System;
using System.Windows.Forms;

namespace Sistema_Login
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            CadastreSe cad = new CadastreSe();
            cad.ShowDialog();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {          
            Controle controle = new Controle();

            controle.acessar(txtLogin.Text, txtSenha.Text);

            if (controle.mensagem.Equals(""))
            {
                if (controle.tem)
                {
                    MessageBox.Show("LOGADO COM SUCESSO", "ENTRANDO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Bem_Vindo bv = new Bem_Vindo();
                    bv.ShowDialog();
                }
                else
                {
                    MessageBox.Show("LOGIN NÃO ENCONTRADO", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSenha.Text = "";
                }
            }
            else
            {
                MessageBox.Show(controle.mensagem, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenha.Text = "";
            }            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            //MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea; MAXIMIZAR SEM COBRIR BARRA DE TAREFAS
            //WindowState = FormWindowState.Maximized;
        }
    }
}
