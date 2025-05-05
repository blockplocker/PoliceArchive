using System.ComponentModel.DataAnnotations;

namespace PolisArkiv.Models
{
    public class Policeman
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
