namespace PolisArkiv.Models
{
    public class ArchiveBox
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Evidence> Evidence { get; set; } = new List<Evidence>();

    }
}
