using System;
using System.Data;
using Npgsql;
using Sistema_Login.Modelo;

namespace Sistema_Login.DAL
{
    class LoginDalComandos
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

        public String cadastrar(String email, String senha, String confSenha)
        {
            Validacoes valida = new Validacoes();
            tem = false;
            //comandos SQL para inserir no BD
            mensagem.msg = valida.generalValidationCadastro(senha, confSenha, email); // Validações

            if (mensagem.msg == "") // VERIFICA SE O EMAIL JÁ ESTA CADASTRADO
            {
                try
                {
                    using (con.pgsqlConnection = new NpgsqlConnection(con.connString))
                    {
                        //Abra a conexão com o PgSQL                  
                        con.pgsqlConnection.Open();

                        int workfactor = 10; // 2 ^ (14) = 16.384 iterations.
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
    }
}
