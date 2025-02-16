

namespace PaySky.Domain.Entities
{
    public class Vacancy
    {
        public int Id { get; set; } 
        public string Title { get; set; } 
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiryDate { get; set; } 
        public int MaxApplicant { get; set; }
        public int? EmployerId { get; set; } 

        
        public User Employer { get; set; } 
        public ICollection<ApplicantVacancy> ApplicantVacancies { get; set; }=new List<ApplicantVacancy>();
    }
}
