using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Npgsql;

namespace Sistema_Login.DAL
{
    public class Conexao
    {
        string serverName = "127.0.0.1"; //localhost
        string port = "5432";   //porta default
        string userName = "postgres";     //nome do administrador
        string password = "N67rkt*#kB9^tWCFZ2vVBlhUsB6wFzJgZZzMkGU@0W%4DqoL2l";   //senha do administrador
        string databaseName = "Login";   //nome do banco de dados
        public NpgsqlConnection pgsqlConnection = null;
        public string connString = null;

        public Conexao()
        {
            connString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
                                                        serverName, port, userName, password, databaseName);
        }
    }
}
