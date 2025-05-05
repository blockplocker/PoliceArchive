using System.ComponentModel.DataAnnotations;

namespace PolisArkiv.Models
{
    public class Evidence
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateCollected { get; set; }

        public int PolicemanID { get; set; }
        public virtual Policeman? Policeman { get; set; }
        public int ArchiveBoxID { get; set; }
        public virtual ArchiveBox? ArchiveBox { get; set; }
    }
}
