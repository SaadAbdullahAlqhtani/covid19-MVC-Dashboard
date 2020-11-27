using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace covid19.Models
{
    public class CaseContext : DbContext
    {
        public CaseContext(DbContextOptions<CaseContext> options) : base(options) { }
        public DbSet<Case> Cases { get; set; }
    }

    public class Case
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First Name must be between 3 and 50 characters")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name must be between 3 and 50 characters")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Type must be between 3 and 50 characters")]
        public string Type { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 50 characters")]
        public string Description { get; set; }
    }
}
