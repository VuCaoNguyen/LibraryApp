using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace LibraryApp.Models
{
   public class User
    {
        public User() { }

        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public bool Admin { get; set; }

    }
}
