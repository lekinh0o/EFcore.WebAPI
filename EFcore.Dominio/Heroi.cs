using System;
using System.Collections.Generic;
namespace EFcore.Dominio
{
    public class Heroi
    {
        public int Id { get; set; }

        public string  Nome { get; set; }
        public IdentidadeSecreta Indentidade { get; set; }
        public string Summary { get; set; }

        public List<Arma> Armas { get; set; }

        public List<HeroiBatalha> HeroisBatalhas { get; set; }



    }
}
