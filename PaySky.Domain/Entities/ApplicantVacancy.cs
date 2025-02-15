using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySky.Domain.Entities
{
    public class ApplicantVacancy
    {
        public int UserId { get; set; } 
        public int VacancyId { get; set; } 
        public DateTime AppliedDate { get; set; }

        public User User { get; set; } 
        public Vacancy Vacancy { get; set; }
    }
}
