using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Configuration;

namespace FTPKlijent
{
    [Serializable]
    public class ConnectionsContainer
    {
        public ConnectionsContainer()
        {

        }

        public Dictionary<string, Connection> myConnections = new Dictionary<string, Connection>();        
    }
}
