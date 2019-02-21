namespace DbLib.DbPostgreSQL.Configuration
{
    public static class Configuration
    {
        private static string _host => "localhost";
        private static string _port => "5432";
        private static string _dataBase => "TASK1";
        private static string _userName => "postgres";
        private static string _password => "postgres";


        public static string ConnectionString => "Host=" + _host + ";Port=" + _port + ";Database=" + _dataBase + ";Username=" + _userName + ";Password=" + _password;
    }
}
