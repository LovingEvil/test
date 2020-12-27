using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Web.Data
{
    public class Company : BaseEntity
    {
        [Required]
        public string CompanyName { get; set; }
    }
}