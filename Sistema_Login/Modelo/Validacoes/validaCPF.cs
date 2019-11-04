using System;

namespace Sistema_Login.Modelo.Validacoes
{
    class validaCPF
    {


       public String generalValidationCPF(String CPF)
        {
            Validacoes valida = new Validacoes();
            String tempMensagem = "";

            tempMensagem = valida.checkInputMessage(CPF, "CPF");
            tempMensagem += isCPF(CPF);

            if (!tempMensagem.Equals(""))
                return "CPF Invalido!";
            return "";
        }

        public String isCPF(String CPF)
        {
            char dig10, dig11;
            int sm, i, r, num, peso;

            if (CPF.Equals("00000000000") ||
                CPF.Equals("11111111111") ||
                CPF.Equals("22222222222") || CPF.Equals("33333333333") ||
                CPF.Equals("44444444444") || CPF.Equals("55555555555") ||
                CPF.Equals("66666666666") || CPF.Equals("77777777777") ||
                CPF.Equals("88888888888") || CPF.Equals("99999999999") ||
                (CPF.Length != 11))
                return "CPF Invalido!";

            char[] cpfChar = new char[11];
            cpfChar = CPF.ToCharArray();

            // VALIDAÇÃO DIGITO VERIFICADOR 1
            sm = 0;
            peso = 10;

            for (i = 0; i < 9; i++)
            {
                num = (int)(cpfChar[i] - 48);
                sm = sm + (num * peso);
                peso = peso - 1;
            }

            r = 11 - (sm % 11);
            if ((r == 10) || (r == 11))
                dig10 = '0';
            else
                dig10 = (char)(r + 48);

            // VALIDAÇÃO DIGITO VERIFICADOR 2

            sm = 0;
            peso = 11;
            for (i = 0; i < 10; i++)
            {
                num = (int)(cpfChar[i] - 48);
                sm = sm + (num * peso);
                peso = peso - 1;
            }

            r = 11 - (sm % 11);
            if ((r == 10) || (r == 11))
                dig11 = '0';
            else
                dig11 = (char)(r + 48);

            if ((dig10 == cpfChar[9]) && (dig11 == cpfChar[10]))
                return "";
            else
                return "CPF Invalido!";
        }

    }
}
