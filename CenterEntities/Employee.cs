using System;

namespace CenterEntities
{
    public class Employee : Base
    {
        //TODO: vai de 1 a 5  
        public int PLevel { get; set; }
        
        public DateTime BirthYear { get; set; }

        public DateTime AdmissionYear { get; set; }

        //TODO: Colocar validação que se o empregado nunca recebeu uma promoção, colocar data de adimissão  
        public DateTime LastProgressionYear { get; set; }

 
    }
}
