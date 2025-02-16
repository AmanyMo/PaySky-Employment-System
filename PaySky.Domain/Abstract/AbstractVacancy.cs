using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySky.Domain.Abstract
{
    public class AbstractVacancy
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int MaxApplicant { get; set; }
        public int? EmployerId { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
