using CenterEntities;
using System.Collections.Generic;

namespace CenterRepository
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository()
        {

        }
        public List<Employee> GetEmployeeInCompany(int company)
        {


            return new List<Employee>();
        }

        public List<Employee> GetEmployeesByFile()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"C:\carga\employees.txt");

                var employees = new List<Employee>();
                string[] lineArray;


                for (int i = 0, count = lines.Length; i < count; i++)
                {
                    //Nome do Empregado, Nível, Ano de Nascimento, Ano de Admissão, Último Ano de Progressão 
                    lineArray = lines[i].Split(',');
                    var employee = new Employee();
                    employee.Id = i;
                    employee.Description = lineArray[0];
                    int aux;
                    int.TryParse(lineArray[3].Trim().ToString(), out aux);
                    employee.AdmissionYear = aux;
                    int.TryParse(lineArray[2].Trim().ToString(), out aux);
                    employee.BirthYear = aux;
                    int.TryParse(lineArray[4].Trim().ToString(), out aux);
                    employee.LastProgressionYear = aux;
                    int.TryParse(lineArray[1].Trim().ToString(), out aux);
                    employee.PLevel = aux;

                    employees.Add(employee);

                }

                return employees;
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }
    }
}
