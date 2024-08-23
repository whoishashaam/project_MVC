using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace project1.Models
{
    public class Category
    {
       // [Key] used to show that it is the primary key of the table
       // model is basically the structure of the Database
         public int Id { get; set; }


        [Required]
        [DisplayName("Category Name")]

        [MaxLength(25)]
        public String Name { get; set; }

        [Range(1,1000)]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
