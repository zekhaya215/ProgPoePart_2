namespace ProgPoePart_2.Models
{
    public class UserMemory
    {
        public string UserName { get; set; }
        public string FavouriteTopic { get; set; }

        public UserMemory()
        {
            UserName = "";
            FavouriteTopic = "";
        }
    }
}