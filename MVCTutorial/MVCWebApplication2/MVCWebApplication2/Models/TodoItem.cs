namespace MVCWebApplication2.Models
{
    public class TodoItem
    {


        public int Id { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public bool Checked { get; set; }

        public DateTime DueDate { get; set; }
    }
}
