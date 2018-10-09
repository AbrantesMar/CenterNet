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

        public int PointsPromotion
        {
            get
            {
                return PointOfCompany + PointOfProgression + PointOfAge;
            }
        }

        private int PointOfAge
        {
            get
            {
                int age = DateTime.Now.Year - BirthYear.Year;
                return age % 5;
            }
        }

        private int PointOfCompany
        {
            get
            {
                return isTimeValideCompany % 2;
            }
        }

        private int PointOfProgression
        {
            get
            {
                int timeOfProgression = DateTime.Now.Year - LastProgressionYear.Year;
                return timeOfProgression % 3;
            }
        }

        //Restrição de Critérios
        //Tempo da empresa Mínimo 1 ano
        //Tempo sem progressão Mínimo de 2 anos, se o nível for 4.
        //Idade sem restrições.
        //Critérios Critérios Peso
        //Tempo da empresa 2 pontos por ano
        //Tempo sem progressão 3 pontos por ano
        //Idade 1 ponto por 5 anos
        //Os funcionários devem ser classificados pela soma dos pontos calculados por esses critérios, 
        //se as restrições forem atendidas.O usuário informará o número de funcionários que ele deseja 
        //promover.Inicialmente, o aplicativo está no ano atual.Depois de qualquer
        //progressão aplicada, o aplicativo adiciona um ano ao ano atual.

        private int isTimeValideCompany
        {
            get
            {
                int quantityYearsInCompany = DateTime.Now.Year - AdmissionYear.Year;
                return quantityYearsInCompany;
            }
        }

        private bool isTimeInCompanyMin() => !(isTimeValideCompany< 2 && PLevel == 4);

        public bool IsValidateToProgress
        {
            get
            {
                if (isTimeValideCompany > 1)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
