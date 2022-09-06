using System.ComponentModel.DataAnnotations.Schema;

namespace GadgetFixers.Models
{
    public class Fixer
    {
       
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }

    }
}
