﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EF_Assignment_4_CRUD.Models.Entity
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
        [JsonIgnore]
        public bool IsDeleted { get; set; } = false;   

    }
}
