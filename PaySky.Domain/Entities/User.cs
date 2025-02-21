﻿

using PaySky.Domain.Abstract;

namespace PaySky.Domain.Entities
{
    public class User :AbstractUser
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Email { get; set; }
        //public string HashPassword { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public int RoleId { get; set; }


        public Role Role { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }=new List<Vacancy>();    
        public ICollection<ApplicantVacancy> ApplicantVacancies { get; set; } = new List<ApplicantVacancy>();



    }
}
