namespace MVCLibraryApp.Models
{
    public class AuteurModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
   

        public ICollection<ItemModel> Items { get; set; }
    }
}
