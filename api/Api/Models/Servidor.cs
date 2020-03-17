using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Servidor
    {
        public int ServidorID { get; set; }
        public string IP { get; set; }
        public string Hostname { get; set; }
        public string Observacao { get; set; }
        public bool Status { get; set; }
        public string TipoServidor { get; set; }
        public int EspacoDisco { get; set; }
        public int Cpu { get; set; }
        public int Memoria { get; set; }
        public string Conteudo { get; set; }
        public override string ToString()
        {
            return string.Format("ServidorID {0}, IP {1}, Hostname {2}, Observacao {3}, Status {4}, " +
                "TipoServidor {5}, EspacoDisco {6}, Cpu {7}, Memoria {8}, Conteudo {9}",
                ServidorID, IP, Hostname, Observacao, Status, TipoServidor, EspacoDisco, Cpu, Memoria, Conteudo);
        }
    }
}
