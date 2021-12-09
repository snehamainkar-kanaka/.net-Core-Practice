using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace EmployeesData.Models
{
    public partial class Person
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [MaxLength(2)]
        [Range(1, 100)]
        public int? Age { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        public long? Contact { get; set; }
    }
}
