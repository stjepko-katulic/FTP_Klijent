using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPKlijent
{
    [Serializable]
    public class Connection
    {
        public string ConnectionName { get; set; }
        public int Protocol { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Napomena { get; set; }
        public string Modificirano { get; set; }


        public Connection(string connectionName, int protocol, string host, string port, string username, string password, string napomena, string modificirano)
        {
            try
            {
                this.ConnectionName = connectionName;
                this.Protocol = protocol;
                this.Port = Convert.ToInt16(port);
                this.Host = host;
                this.Username = username;
                this.Password = password;
                this.Napomena = napomena;
                this.Modificirano = modificirano;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }
    }
}
