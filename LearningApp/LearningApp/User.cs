namespace LearningApp
{
    public class User
    {
        public User(string n, int a)
        {
            Name = n;
            Age = a;
        }
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
