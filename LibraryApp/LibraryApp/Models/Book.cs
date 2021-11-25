using SQLite;
namespace LibraryApp.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int bID { get; set; }
        public string title { get; set; }
        public int price { get; set; }
        public string img { get; set; }
    }
}
