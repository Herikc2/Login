using System;
using System.Data;

using Npgsql;
using Sistema_Login.Apresentacao;
using Sistema_Login.Modelo;
using Sistema_Login.Modelo.Validacoes;

namespace Sistema_Login.DAO
{
    class LoginDAOComandos
    {
        public bool tem;
        public Mensagem mensagem = new Mensagem();
        public String cmd;

        public Conexao con = new Conexao();

        public bool verificarLogin(String login, String pass)
        {
            //comandos SQL para verificar no BD
            DataTable dt = new DataTable();
            Validacoes valida = new Validacoes();

            mensagem.msg = valida.generalValidationLogin(pass, login);         

            if (mensagem.msg == "")
            {
                try
                {
                    using (con.pgsqlConnection = new NpgsqlConnection(con.connString))
                    {
                        // abre a conexão com o PgSQL e define a instrução SQL
                        con.pgsqlConnection.Open();
                        cmd = String.Format("select * from login where email = '{0}'", login);

                        using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmd, con.pgsqlConnection))
                        {
                            Adpt.Fill(dt);
                        }

                        if (dt.Rows.Count > 0)
                        {
                            string hash = dt.Rows[0]["senha"].ToString();         
                            
                            if (BCrypt.Net.BCrypt.Verify(pass, hash.TrimEnd()))
                            {
                                tem = true;
                            }
                        }
                        else
                        {
                            tem = false;
                        }
                    }
                }
                catch (NpgsqlException ex)
                {
                    mensagem.adicionaMensagem("Erro com Banco de Dados!");
                    throw ex;
                }
                catch (Exception ex)
                {
                    mensagem.adicionaMensagem("Erro com Banco de Dados!");
                    throw ex;
                }
                finally
                {
                    con.pgsqlConnection.Close();
                }
            }

            return tem;
        }

        public string verificaExistenciaLogin(String login)
        {
            DataTable dt = new DataTable();

            try
            {
                using (con.pgsqlConnection = new NpgsqlConnection(con.connString))
                {
                    // abre a conexão com o PgSQL e define a instrução SQL
                    con.pgsqlConnection.Open();
                    cmd = String.Format("select * from login where email = '{0}'", login);

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmd, con.pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                    }

                    if (dt.Rows.Count > 0)
                        return "Já possui um Usuário com Esse E-mail";
                }
            }
            catch (NpgsqlException ex)
            {
                mensagem.adicionaMensagem("Erro com Banco de Dados!");
                throw ex;
            }
            catch (Exception ex)
            {
                mensagem.adicionaMensagem("Erro com Banco de Dados!");
                throw ex;
            }
            finally
            {
                con.pgsqlConnection.Close();
            }
            return "";
        }

        public string verificaExistenciaCPF(String cpf)
        {
            DataTable dt = new DataTable();

            try
            {
                using (con.pgsqlConnection = new NpgsqlConnection(con.connString))
                {
                    // abre a conexão com o PgSQL e define a instrução SQL
                    con.pgsqlConnection.Open();
                    cmd = String.Format("select * from Pessoa where cpf = '{0}'", cpf);

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmd, con.pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                    }

                    if (dt.Rows.Count > 0)
                        return "Já possui um Usuário com Esse CPF";
                }
            }
            catch (NpgsqlException ex)
            {
                mensagem.adicionaMensagem("Erro com Banco de Dados!");
                throw ex;
            }
            catch (Exception ex)
            {
                mensagem.adicionaMensagem("Erro com Banco de Dados!");
                throw ex;
            }
            finally
            {
                con.pgsqlConnection.Close();
            }
            return "";
        }

        public String cadastrar(String email, String senha, String confSenha)
        {
            Validacoes valida = new Validacoes();
            tem = false;
            //comandos SQL para inserir no BD
            mensagem.msg = valida.generalValidationCadastro(senha, confSenha, email); // Validações

            if (mensagem.msg == "") 
            {
                try
                {                 
                    using (con.pgsqlConnection = new NpgsqlConnection(con.connString))
                    {
                        //Abra a conexão com o PgSQL                  
                        con.pgsqlConnection.Open();

                        int workfactor = 12; // 2 ^ (14) = 16.384 iterations.
                        string salt = BCrypt.Net.BCrypt.GenerateSalt(workfactor);
                        string hash = BCrypt.Net.BCrypt.HashPassword(senha, salt);

                        string cmdInserir = String.Format("Insert Into login(email,senha) values('{0}','{1}')", email, hash.TrimEnd());

                        using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(cmdInserir, con.pgsqlConnection))
                        {
                            pgsqlcommand.ExecuteNonQuery();
                        }
                        mensagem.adicionaMensagem("Cadastrado com Sucesso!");
                        tem = true;
                    }
                }
                catch (NpgsqlException ex)
                {
                    mensagem.adicionaMensagem("Erro com Banco de Dados!");
                    throw ex;
                }
                catch (Exception ex)
                {
                    mensagem.adicionaMensagem("Erro com Banco de Dados!");
                    throw ex;
                }
                finally
                {
                    con.pgsqlConnection.Close();
                }
            }
            return mensagem.msg;
        }

        public DataTable GetTodosRegistros()
        {
            DataTable dt = new DataTable();

            try
            {
                using (con.pgsqlConnection = new NpgsqlConnection(con.connString))
                {
                    // abre a conexão com o PgSQL e define a instrução SQL
                    con.pgsqlConnection.Open();
                    string cmdSeleciona = "select nome, email, cpf, sexo from pessoa order by nome";

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSeleciona, con.pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                        dt.Columns[0].ColumnName = "NOME";
                        dt.Columns[1].ColumnName = "EMAIL";
                        dt.Columns[2].ColumnName = "CPF";
                        dt.Columns[3].ColumnName = "SEXO";
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                mensagem.adicionaMensagem("Erro com Banco de Dados!");
                throw ex;
            }
            catch (Exception ex)
            {
                mensagem.adicionaMensagem("Erro com Banco de Dados!");
                throw ex;
            }
            finally
            {
                con.pgsqlConnection.Close();
            }

            return dt;
        }

        public DataTable GetTodosRegistrosFiltrados(String nome, String email, String cpf, String sexo)
        {
            DataTable dt = new DataTable();

            Validacoes valida = new Validacoes();

            mensagem.msg = valida.generalValidatioFiltro(nome, email, cpf, sexo);

            if (mensagem.msg.Equals(""))
            {

                nome = valida.validaCampoFiltro(nome);
                email = valida.validaCampoFiltro(email);
                cpf = valida.validaCampoFiltro(cpf);
                sexo = valida.validaCampoFiltro(sexo);

                try
                {
                    using (con.pgsqlConnection = new NpgsqlConnection(con.connString))
                    {
                        // abre a conexão com o PgSQL e define a instrução SQL
                        con.pgsqlConnection.Open();

                        string cmdSeleciona = String.Format("select nome, email, cpf, sexo from pessoa where nome ilike '{0}' and email ilike '{1}' and cpf ilike '{2}' and sexo ilike '{3}'", nome, email, cpf, sexo);

                        using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSeleciona, con.pgsqlConnection))
                        {
                            Adpt.Fill(dt);
                            dt.Columns[0].ColumnName = "NOME";
                            dt.Columns[1].ColumnName = "EMAIL";
                            dt.Columns[2].ColumnName = "CPF";
                            dt.Columns[3].ColumnName = "SEXO";
                        }
                    }
                }
                catch (NpgsqlException ex)
                {
                    mensagem.adicionaMensagem("Erro com Banco de Dados!");
                    throw ex;
                }
                catch (Exception ex)
                {
                    mensagem.adicionaMensagem("Erro com Banco de Dados!");
                    throw ex;
                }
                finally
                {
                    con.pgsqlConnection.Close();
                }
            }

            return dt;
        }

        //Inserir registros
        public String InserirRegistros(string nome, string email, string cpf, string sexo)
        {
            GetTodosRegistros();

            Validacoes valida = new Validacoes();

            //comandos SQL para inserir no BD
            mensagem.msg = valida.generalValidationFormPessoa(nome, cpf, email, sexo, true); // Validações
            mensagem.adicionaMensagem(verificaExistenciaCPF(cpf));

            if (mensagem.msg.Equals(""))
            {
                try
                {
                    using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(con.connString))
                    {
                        //Abra a conexão com o PgSQL                  
                        pgsqlConnection.Open();

                        string cmdInserir = String.Format("Insert into Pessoa (nome, email, cpf, sexo) values ('{0}','{1}','{2}','{3}')", nome, email, cpf, sexo);

                        using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(cmdInserir, pgsqlConnection))
                        {
                            pgsqlcommand.ExecuteNonQuery();
                        }
                    }
                }
                catch (NpgsqlException ex)
                {
                    mensagem.adicionaMensagem("Erro com Banco de Dados!");
                    throw ex;
                }
                catch (Exception ex)
                {
                    mensagem.adicionaMensagem("Erro com Banco de Dados!");
                    throw ex;
                }
                finally
                {
                    con.pgsqlConnection.Close();
                }
            }

            return mensagem.msg;
        }

        //Atualiza registros
        public void AtualizarRegistro(string nome, string email, string cpf, string sexo)
        {
            try
            {
                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(con.connString))
                {
                    //Abra a conexão com o PgSQL                  
                    pgsqlConnection.Open();

                    string cmdAtualiza = String.Format("Update Pessoa Set email = '" + email + "' , nome = '" + nome + "' , sexo = '" + sexo + "' Where cpf = '" + cpf + "'");

                    using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(cmdAtualiza, pgsqlConnection))
                    {
                        pgsqlcommand.ExecuteNonQuery();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                mensagem.adicionaMensagem("Erro com Banco de Dados!");
                throw ex;
            }
            catch (Exception ex)
            {
                mensagem.adicionaMensagem("Erro com Banco de Dados!");
                throw ex;
            }
            finally
            {
                con.pgsqlConnection.Close();
            }
        }

        public String DeletarRegistro(string cpf)
        {
            GetTodosRegistros();

            Validacoes valida = new Validacoes();

            //comandos SQL para inserir no BD           
            mensagem.msg = valida.generalValidationFormPessoa("default", cpf, "default", "default", true); // Validações

            if (mensagem.msg.Equals(""))
            {
                mensagem.msg = "";
                if (verificaExistenciaCPF(cpf).Equals("Já possui um Usuário com Esse CPF"))
                    mensagem.msg = "";
                else
                {
                    mensagem.adicionaMensagem("Não existe nenhum usuário com esse CPF!");
                    return mensagem.msg;
                }

                try
                {
                    using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(con.connString))
                    {
                        //abre a conexao                
                        pgsqlConnection.Open();

                        string cmdDeletar = String.Format("Delete From Pessoa Where cpf = '{0}'", cpf);

                        using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(cmdDeletar, pgsqlConnection))
                        {
                            pgsqlcommand.ExecuteNonQuery();
                        }
                    }
                }
                catch (NpgsqlException ex)
                {
                    mensagem.adicionaMensagem("Erro com Banco de Dados!");
                    throw ex;
                }
                catch (Exception ex)
                {
                    mensagem.adicionaMensagem("Erro com Banco de Dados!");
                    throw ex;
                }
                finally
                {
                    con.pgsqlConnection.Close();
                }
            }

            return mensagem.msg;
        }
   
        public String requisicaoHTTP(string cpf)
        {
            Validacoes valida = new Validacoes();
            requisicaoHTTP web = new requisicaoHTTP();

            mensagem.msg = "";
            if (verificaExistenciaCPF(cpf).Equals("Já possui um Usuário com Esse CPF")) { 
                mensagem.msg = "";
                web.requisicaoGET(cpf);
            }
            else
                mensagem.adicionaMensagem("Não existe nenhum usuário com esse CPF!");

            return mensagem.msg;
        }
    }
}
