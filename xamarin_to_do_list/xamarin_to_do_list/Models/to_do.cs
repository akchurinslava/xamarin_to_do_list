using System;
using SQLite;

namespace xamarin_to_do_list.Models
{
    [Table("todo")]
    public class to_do
    {
	    [PrimaryKey, AutoIncrement, Column("_id")]
	    public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DueDate { get; set; }
            
        public TimeSpan Time { get; set; }
        public string Description { get; set; }
        public to_do()
	    {
	        DueDate = DateTime.Now;
        }


    }
}
