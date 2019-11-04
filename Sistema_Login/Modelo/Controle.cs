using Sistema_Login.Apresentacao;
using Sistema_Login.DAO;
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
            LoginDAOComandos loginDAO = new LoginDAOComandos();
            tem = loginDAO.verificarLogin(login, senha);

            if (!loginDAO.mensagem.msg.Equals(""))
                this.mensagem = loginDAO.mensagem.msg;

            return tem;
        }

        public String cadastrar(String email, String senha, String confSenha)
        {
            LoginDAOComandos loginDAO = new LoginDAOComandos();
            mensagem = loginDAO.cadastrar(email, senha, confSenha);

            if (loginDAO.tem)
                this.tem = true;

            return mensagem;
        }

        public DataTable atualizarExibicao()
        {
            LoginDAOComandos loginDAO = new LoginDAOComandos();

            return loginDAO.GetTodosRegistros();
        }

        public String inserirPessoa(RadioButton masc, RadioButton fem, RadioButton oth, String txtNomeFiltro, String txtEmailFiltro, String txtCpf)
        {
            LoginDAOComandos loginDAO = new LoginDAOComandos();

            String sexo = "";
            if (masc.Checked)
                sexo = "F";

            if (fem.Checked)
                sexo = "M";

            if (oth.Checked)
                sexo = "O";

            return loginDAO.InserirRegistros(txtNomeFiltro, txtEmailFiltro, txtCpf, sexo);
        }

        public String deletarPessoa(String CPF)
        {
            LoginDAOComandos loginDAO = new LoginDAOComandos();

            return loginDAO.DeletarRegistro(CPF);
        }

        public DataTable filtrarPessoa(RadioButton masc, RadioButton fem, RadioButton oth, String txtNomeFiltro, String txtEmailFiltro, String txtCpf)
        {
            LoginDAOComandos loginDAO = new LoginDAOComandos();

            String sexo = "";
            if (masc.Checked)
                sexo = "F";

            if (fem.Checked)
                sexo = "M";

            if (oth.Checked)
                sexo = "O";

            return loginDAO.GetTodosRegistrosFiltrados(txtNomeFiltro, txtEmailFiltro, txtCpf, sexo);
        }

        public String about(String cpf)
        {
           
            LoginDAOComandos loginDAO = new LoginDAOComandos();
            
            return loginDAO.requisicaoHTTP(cpf);  
        }
    }
}
