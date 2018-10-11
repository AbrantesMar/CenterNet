using System;

namespace CenterEntities
{
    public class Employee : Base
    {
        //TODO: vai de 1 a 5  
        public int PLevel { get; set; }
        
        public int BirthYear { get; set; }

        public int AdmissionYear { get; set; }

        //TODO: Colocar validação que se o empregado nunca recebeu uma promoção, colocar data de adimissão  
        public int LastProgressionYear { get; set; }

        public Client Client { get; set; }

 
    }
}
