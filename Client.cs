using TasksIngrijitori.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksIngrijitori
{
    public class Client
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string NumeClient { get; set; }
        public string Adress { get; set; }
        public string DetaliiClient { get { return NumeClient + " " + Adress; } }
        [OneToMany]
        public List<ListaJobs> ListaJobs { get; set; }
    }
}
