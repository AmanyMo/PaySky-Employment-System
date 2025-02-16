
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
