using System.ComponentModel.DataAnnotations;

namespace TodoListWebApi.Models
{
    public class Todo
    {
        private static int _id = 1;
        public int Id { get; private set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool Completed { get; set; }
        public DateTime CreateDate { get; private set; }

        public Todo(string title, string description, bool completed)
        {
            Title = title;
            Description = description;
            Completed = completed;
            CreateDate = DateTime.Now;
            Id = _id;
            _id++;
        }
    }
}
