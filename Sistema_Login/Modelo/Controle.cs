using Sistema_Login.Apresentacao;
using Sistema_Login.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace Sistema_Login.Modelo
{
    public class Controle
    {
        public bool tem;
        public String mensagem = "";

        public bool acessar(String login, String senha)
        {
            LoginDalComandos loginDal = new LoginDalComandos();
            tem = loginDal.verificarLogin(login, senha);

            if (!loginDal.mensagem.msg.Equals(""))
                this.mensagem = loginDal.mensagem.msg;

            return tem;
        }

        public String cadastrar(String email, String senha, String confSenha)
        {
            LoginDalComandos loginDal = new LoginDalComandos();
            mensagem = loginDal.cadastrar(email, senha, confSenha);

            if (loginDal.tem)
                this.tem = true;

            return mensagem;
        }

        public DataTable atualizarExibicao()
        {
            LoginDalComandos loginDal = new LoginDalComandos();

            return loginDal.GetTodosRegistros();
        }

        public String inserirPessoa(RadioButton masc, RadioButton fem, RadioButton oth, String txtNomeFiltro, String txtEmailFiltro, String txtCpf)
        {
            LoginDalComandos loginDal = new LoginDalComandos();

            String sexo = "";
            if (masc.Checked)
                sexo = "F";

            if (fem.Checked)
                sexo = "M";

            if (oth.Checked)
                sexo = "O";

            return loginDal.InserirRegistros(txtNomeFiltro, txtEmailFiltro, txtCpf, sexo);
        }

        public String deletarPessoa(String CPF)
        {
            LoginDalComandos loginDal = new LoginDalComandos();

            return loginDal.DeletarRegistro(CPF);
        }

        public DataTable filtrarPessoa(RadioButton masc, RadioButton fem, RadioButton oth, String txtNomeFiltro, String txtEmailFiltro, String txtCpf)
        {
            LoginDalComandos loginDal = new LoginDalComandos();

            String sexo = "";
            if (masc.Checked)
                sexo = "F";

            if (fem.Checked)
                sexo = "M";

            if (oth.Checked)
                sexo = "O";

            return loginDal.GetTodosRegistrosFiltrados(txtNomeFiltro, txtEmailFiltro, txtCpf, sexo);
        }

        public String about(String cpf)
        {
           
            LoginDalComandos loginDal = new LoginDalComandos();
            
            return loginDal.requisicaoHTTP(cpf);  
        }
    }
}
