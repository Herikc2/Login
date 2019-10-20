using Sistema_Login.Apresentacao;
using VerificaForcaSenha.Modelo.Senha;

namespace Sistema_Login.Modelo.Senha
{
    class checkSenha
    {

        public bool equalSenha(string senha, string confSenha)
        {
            if (senha.Equals(confSenha)) return true;
            else return false;
        }

        public bool validaPontuacao(string senha)
        {
            CheckPower verifica = new CheckPower();
            int placar = verifica.geraPontosSenha(senha);
            ForcaDaSenha forca = verifica.GetForcaDaSenha(senha);

            CadastreSe.valueLblPontosSenha = placar.ToString() + " Pontos";
            CadastreSe.valueLblForcaSenha = forca.ToString();

            if (forca < ForcaDaSenha.Aceitavel)
                return false;
            else
                return true;
        }

    }
}
