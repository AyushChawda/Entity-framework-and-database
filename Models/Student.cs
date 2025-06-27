using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_framework.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Column ("StudentName", TypeName ="varchar(100)")]
        public string Name { get; set; }

        [Column("StudentAge")]
        public int Age { get; set; }


        [Column("StudentGender", TypeName = "varchar(30)")]

        public string Gender { get; set; }

        public int Standard { get; set; }
    }
}
