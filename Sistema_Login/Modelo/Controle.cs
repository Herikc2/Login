using Sistema_Login.DAL;
using System;

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
    }
}
