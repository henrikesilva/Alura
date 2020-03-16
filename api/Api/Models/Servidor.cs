using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Servidor
    {
        public int ServidorId { get; set; }
        public string Ip { get; set; }
        public string Hostname { get; set; }
        public string Observacao { get; set; }
        public string Status { get; set; }
        private string TipoServidor { get; set; }
        private string EspacoDisco { get; set; }
        private string Cpu { get; set; }
        private string Memoria { get; set; }
        private string Conteudo { get; set; }
    }
}
