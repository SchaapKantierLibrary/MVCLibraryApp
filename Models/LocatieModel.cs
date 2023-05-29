namespace MVCLibraryApp.Models
{
    public class LocatieModel
    {
        public int ID { get; set; }
        public string Beschrijving { get; set; }

        public ICollection<ItemModel> Items { get; set; }
    }
}
