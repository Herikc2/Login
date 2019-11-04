using System;
using Npgsql;

namespace Sistema_Login.DAO
{
    public class Conexao
    {
        
        string serverName = "loginsystem.czs1kdyivfpm.us-east-2.rds.amazonaws.com"; //localhost
        string port = "5432";   //porta default
        string userName = "postgres";     //nome do administrador
        string password = "W6l$o7%fL^L!XJ4ZBmdlrxJKgG1x7BZepCBPjBRt#1gIpN0HuNRm!wIL8c9fJ3nBEVthJ6RTp9*Bl^y!13nbROdFmvNinjc^k3W";   //senha do administrador
        string databaseName = "Login";   //nome do banco de dados
        public NpgsqlConnection pgsqlConnection = null;
        public string connString = null;
        
        /*
        string serverName = "127.0.0.1"; //localhost
        string port = "5432";   //porta default
        string userName = "postgres";     //nome do administrador
        string password = "N67rkt*#kB9^tWCFZ2vVBlhUsB6wFzJgZZzMkGU@0W%4DqoL2l";   //senha do administrador
        string databaseName = "Login";   //nome do banco de dados
        public NpgsqlConnection pgsqlConnection = null;
        public string connString = null;
        */
        public Conexao()
        {
            connString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
                                                        serverName, port, userName, password, databaseName);
        }
    }
}
