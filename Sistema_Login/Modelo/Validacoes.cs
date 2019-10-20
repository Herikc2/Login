using Sistema_Login.Modelo.E_mail;
using Sistema_Login.Modelo.Senha;
using System;
using System.Collections.Generic;

namespace Sistema_Login.Modelo
{
    class Validacoes
    {

        private Mensagem mensagem;
        private bool validator = false;
        private string tempMensagem = "";

        public Validacoes()
        {
            mensagem = new Mensagem();
        }

        public string validaDigitacao(string input, string campo)
        {
            if (input.Trim().Equals(""))
                return "O campo " + campo + " está vazio!";
            else
                return "";
        }

        public string generalValidationCadastro(string senha, string confSenha, string email)
        {
            validator = false;
            tempMensagem = "";

            mensagem.adicionaMensagem("O formulário possui as seguintes invalidações:");

            tempMensagem = validaSenha(senha, confSenha);
            mensagem.adicionaMensagem(tempMensagem);
            clearString();

            tempMensagem = validaEmail(email);
            mensagem.adicionaMensagem(tempMensagem);
            clearString();

            if (!validator)
                mensagem.clearMensagem();
            return mensagem.msg;
        }

        public string generalValidationLogin(string senha, string email)
        {
            validator = false;
            tempMensagem = "";

            mensagem.adicionaMensagem("O formulário possui as seguintes invalidações:");

            tempMensagem = checkInputMessage(senha, "senha");
            mensagem.adicionaMensagem(tempMensagem);
            clearString();

            tempMensagem = checkInputMessage(email, "email");
            mensagem.adicionaMensagem(tempMensagem);
            clearString();

            tempMensagem = validaDigitacao(senha, "senha");
            mensagem.adicionaMensagem(tempMensagem);
            clearString();

            tempMensagem = validaDigitacao(email, "email");
            mensagem.adicionaMensagem(tempMensagem);
            clearString();

            if (!validator)
                mensagem.clearMensagem();
            return mensagem.msg;
        }

        private void clearString()
        {
            if (tempMensagem != "")
            {
                tempMensagem = "";
                validator = true;
            }
        }

        public string validaSenha(string senha, string confSenha)
        {
            checkSenha ckSenha = new checkSenha();
            string localTemp = "";

            localTemp = validaDigitacao(senha, "senha");
            if (!localTemp.Equals(""))
                return localTemp;

            localTemp = validaDigitacao(confSenha, "confirmar senha");
            if (!localTemp.Equals(""))
                return localTemp;

            if (!ckSenha.equalSenha(senha, confSenha))
                return "As senhas não correspondem!";
            if (!ckSenha.validaPontuacao(senha))
                return "A senha é muito fraca!";
            if (!checkInput(senha))
                return "A senha possui caracteres invalidos!";
            return "";
        }

        public string validaEmail(string email)
        {
            checkEmail ckEmail = new checkEmail();
            string localTemp = "";

            localTemp = validaDigitacao(email, "email");
            if (!localTemp.Equals(""))
                return localTemp;

            if (!ckEmail.validaEmailEstrutura(email))
                return "E-mail invalido!";
            if (!checkInput(email))
                return "O E-mail possui caracteres invalidos!";
            return "";
        }

        public bool checkInput(String input)
        {
            List<String> lixo = new List<String>();
            string textoOK = input;

            lixo.Add("select");
            lixo.Add("drop");
            lixo.Add(";");
            lixo.Add("--");
            lixo.Add("insert");
            lixo.Add("delete");
            lixo.Add("xp_");
            lixo.Add("alter");
            lixo.Add("table");

            for (int i = 0; i < lixo.Count; i++)
                textoOK = textoOK.Replace(lixo[i], "");

            if (input.Equals(textoOK)) return true;
            else return false;
        }

        public string checkInputMessage(String input, String campo)
        {
            if (!checkInput(input))
                return "O campo " + campo + " está invalido!";
            else
                return "";
        }

    }
}
