using System;

namespace StudentManagementSystem.Core.Entities
{
    public class Student   // ✅ must be public
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public string Course { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}