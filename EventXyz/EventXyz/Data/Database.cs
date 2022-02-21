using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Data {
    public static class Database {

        public static string ConnectionString() {
            return string.Format(
                "Data Source = {0}; Initial Catalog = {1}; User ID = {2}; Password = {3}",
                host,
                database,
                username,
                password
            );
        }

        private const string host = "DESKTOP-USRB5QF";
        private const string database = "EventXyz";
        private const string username = "it";
        private const string password = "admin";
    }
}
