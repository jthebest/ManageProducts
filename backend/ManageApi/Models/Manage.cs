// Models/Manage.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageApi.Models
{
    [Table("MANAGE")] // Ensure this matches your actual table name in MySQL
    public class Manage
    {
        [Key]
        [Column("id")] // Ensure this matches your actual column name in MySQL
        public long Id { get; set; }

        [Required]
        [Column("name")] // Ensure this matches your actual column name in MySQL
        public string Name { get; set; }

        // Navigation property removed: public ICollection<Product> Products { get; set; }
    }
}
