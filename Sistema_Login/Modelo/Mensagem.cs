namespace Sistema_Login.Modelo
{
    class Mensagem
    {

        public string msg;

        public Mensagem()
        {
            this.msg = "";
        }

        public string adicionaMensagem(string input)
        {
            if(!input.Equals(""))
                if (this.msg.Equals(""))
                    this.msg = input;
                else
                    this.msg += "\n" + "- " + input;

            return msg;
        }

        public void clearMensagem()
        {
            this.msg = "";
        }

    }
}
