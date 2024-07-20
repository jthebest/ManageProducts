// Models/Product.cs

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageApi.Models
{
    [Table("PRODUCT")] // Ensure this matches your actual table name in MySQL
    public class Product
    {
        [Key]
        [Column("id")] // Ensure this matches your actual column name in MySQL
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        [Column("title")] // Ensure this matches your actual column name in MySQL
        public string Title { get; set; }

        [Column("content")] // Ensure this matches your actual column name in MySQL
        public string Content { get; set; }

        [Column("update_time")] // Ensure this matches your actual column name in MySQL
        public DateTime? UpdateTime { get; set; }

        [Column("archived")] // Ensure this matches your actual column name in MySQL
        public bool Archived { get; set; }

        [Column("manage_id")] // Ensure this matches your actual column name in MySQL
        public long? ManageId { get; set; } // Use nullable long for ManageId

        // Navigation property for Manage (not mapped directly to the database)
        [ForeignKey("ManageId")]
        public Manage Manage { get; set; } // Navigation property

        // Optional: Add any other properties or methods as needed
    }
}
