using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Web.Data
{
    public class Employee : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        public string PhoneNumber { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Выберите компанию")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}