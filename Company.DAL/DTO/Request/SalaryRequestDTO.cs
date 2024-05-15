using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.DTO.Request
{
    public class SalaryRequestDTO
    {
        public int SalaryId { get; set; }

        public string? userid { get; set; }

        public double ConstractSalary { get; set; }

        public int DaysOff { get; set; }

        public DateOnly PayDate { get; set; }

        public double TotalSalary { get; set; }
    }
}
