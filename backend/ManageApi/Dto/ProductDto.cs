// DTOs/ProductDto.cs
using System;

namespace ManageApi.DTOs
{
    public class ProductDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool Archived { get; set; }
        public long ManageId { get; set; }
        public ManageDto Manage { get; set; } // Assuming ManageDto is defined similarly
    }

    public class ManageDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
