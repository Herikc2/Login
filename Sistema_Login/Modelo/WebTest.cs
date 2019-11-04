using System.Net;
using System.IO;
using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using Sistema_Login.Modelo;
using System.Text;
using System.Collections.Generic;

namespace Sistema_Login.Apresentacao
{
    partial class WebTest 
    {

        public void requisicaoGET(string cpf)
        {
            string argumento = String.Format("http://cadastrapessoa.us-east-2.elasticbeanstalk.com/Servlet?acao=onlyCadastro&cpf={0}", cpf);
            //string argumento = String.Format("http://localhost:8080/Contatos/Servlet?acao=onlyCadastro&cpf={0}", cpf);
            var requisicaoWeb = WebRequest.CreateHttp(argumento);
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";

            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();              
                Requisicao requisicao = new Requisicao();
                requisicao = tratamentoRequisicao(objResponse.ToString(), requisicao);

                MessageBox.Show("Nome: " + requisicao.nome.ToUpper() + "\n\nCPF: " + requisicao.cpf + "\n\nEmail: " + requisicao.email + "\n\nSexo: " + requisicao.sexo.ToUpper());
                streamDados.Close();
                resposta.Close();        
            }
     
        }

        public Requisicao tratamentoRequisicao(String conteudo, Requisicao requisicao) {
            char[] vetorChar = new char[300000];          

            conteudo = conteudo.TrimStart();
            conteudo = conteudo.TrimEnd();

            List<String> lixo = new List<String>();

            lixo.Add("<html>");
            lixo.Add("<head>");
            lixo.Add("<body>");
            lixo.Add("<tr>");
            lixo.Add("<td>");
            lixo.Add("<table>");
            lixo.Add("</html>");
            lixo.Add("</head>");
            lixo.Add("</body>");
            lixo.Add("</tr>");
            lixo.Add("</td>");
            lixo.Add("</table>");
            lixo.Add("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">");
            lixo.Add("\n");
            lixo.Add("\"");          
            lixo.Add("{");
            lixo.Add("}");

            for (int i = 0; i < lixo.Count; i++)
                conteudo = conteudo.Replace(lixo[i], "");

            vetorChar = conteudo.ToCharArray();
            List<String> elementos = new List<String>();
            String temp = "";
            bool findtwoPoints = false; // :
            bool findPoint = false; // ?

            for (int i = 0; i < vetorChar.Length; i++)
            {
                if (vetorChar[i] == '?')
                {
                    elementos.Add(temp);
                    findPoint = true;
                    findtwoPoints = false;
                }

                if (findtwoPoints && !findPoint)
                {
                    temp += vetorChar[i];
                }

                if (vetorChar[i] == ':')
                {
                    temp = "";
                    findtwoPoints = true;
                    findPoint = false;
                }                
               
            }         

            requisicao.cpf = elementos[0];
            requisicao.nome = elementos[1];
            requisicao.sexo = elementos[2];
            requisicao.email = elementos[3];

            return requisicao;
        }

    }
}