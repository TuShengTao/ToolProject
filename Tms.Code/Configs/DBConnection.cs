﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tms.Code
{
    public class DBConnection
    {
        public static bool Encrypt { get; set; }
        public DBConnection(bool encrypt)
        {
            Encrypt = encrypt;
        }
        public static string connectionString
        {
            get
            {
                string connection = System.Configuration.ConfigurationManager.ConnectionStrings["TmsDbContext"].ConnectionString;
                if (Encrypt == true)
                {
                    return DESEncrypt.Decrypt(connection);
                }
                else
                {
                    return connection;
                }
            }
        }
    }
}
