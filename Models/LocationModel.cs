namespace MVCLibraryApp.Models
{
    public class LocationModel
    {
        public int ID { get; set; }
        public string LocationName { get; set; }

        public ICollection<ItemModel> Items { get; set; }
    }
}
