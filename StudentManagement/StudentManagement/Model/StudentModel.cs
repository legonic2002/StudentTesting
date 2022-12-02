namespace ShoppingWebAPI.Model
{
    public class StudentModel
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public int age { get; set; }
        public decimal high { get; set; }
    }
}
