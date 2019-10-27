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

        private void Bem_Vindo_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
