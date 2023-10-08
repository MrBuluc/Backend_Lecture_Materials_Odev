namespace Week_4_1.Entities
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Text { get; set; }

        public Note(string text)
        {
            Id = Guid.NewGuid();
            Text = text;
        }
    }
}
