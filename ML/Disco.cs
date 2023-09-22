using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ML
{
    public class Disco
    {

        public int IdDisco { get; set; }  

        public string Titulo { get; set; }    

        public string Artista { get; set; } 

        public string GeneroMusical { get; set; }   

        public string Duracion { get; set; }    

        public string Año { get; set; }    

        public string Distribuidora { get; set; } 

        public string Ventas { get; set;}

        public bool Disponibilidad { get; set; }    

        public List<Object> Discos { get; set; }
        

    }
}