using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pgsql
{
    public static class Config
    {
        public static string login { get; set; }
        public static string password { get; set; }
        public static string database { get; set; }
        public static string server { get; set; }
        public static string port { get; set; }
        public static string mode { get; set; }
        public static string path { get; set; }
    }
}
