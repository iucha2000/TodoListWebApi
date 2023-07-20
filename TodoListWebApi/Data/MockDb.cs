using TodoListWebApi.Enums;
using TodoListWebApi.Models;

namespace TodoListWebApi.Data
{
    public static class MockDb
    {
        public static Dictionary<int, Todo> Todos { get; set; }
        public static Dictionary<int, User> Users { get; set; }

        static MockDb()
        {
            Todos = new Dictionary<int, Todo>();
            Users = new Dictionary<int, User>();
            SeedData();
        }

        private static void SeedData()
        {
            Users.Add(1, new User() {Id = 1, Username = "TestUser", Password = "12345678", Role = Roles.User});
            Users.Add(2, new User() {Id = 2, Username = "TestAdmin", Password = "Admin123", Role = Roles.Admin });
        }
    }
}
