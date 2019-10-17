using Sistema_Login.Apresentacao;
using Sistema_Login.DAL;
using Sistema_Login.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Login
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            CadastreSe cad = new CadastreSe();
            cad.Show();
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
                    bv.Show();
                }
                else
                {
                    MessageBox.Show("LOGIN NÃO ENCONTRADO", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(controle.mensagem, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
    }
}
