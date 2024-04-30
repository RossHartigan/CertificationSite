using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Mining.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }
    }

    public class Mining_Sites
    {
        [Key]
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public string SiteOwner { get; set; }
        public string Location { get; set; }
    }

    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a surname.")]
        public string Surname { get; set; }

        public int SiteId { get; set; }
    }

    public class Certifications
    {
        [Key]
        public int CertId { get; set; }
        public string CertName { get; set; }
        public string CertOwner { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int EmployeeId { get; set; }
    }

}
