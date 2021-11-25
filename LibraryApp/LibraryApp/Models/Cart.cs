using SQLite;
namespace LibraryApp.Models
{
    public class Cart
    {
        [PrimaryKey, AutoIncrement]
        public int cId { get; set; }
        public int bId { get; set; }
        public int totalAmount { get; set; }
    }
}
