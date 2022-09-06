using System.ComponentModel.DataAnnotations;

namespace GadgetFixers.Models
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string GadgetType { get; set; }
        public string GadgetId { get; set;  }
    }
}
