using Week_4_1.Entities;
using Week_4_1.Persistence;

Console.WriteLine("Entity Framework Core - InMemory");

NoteMasterDbContext context = new();
Note note = new("Note 1");
context.Notes.Add(note);
context.Notes.Add(new("Note 2"));
context.Notes.Add(new("Note 33"));

context.SaveChanges();

foreach (Note note1 in context.Notes.ToList())
{
    Console.WriteLine(note1.Text);
}

context.Notes.Remove(context.Notes.Find(note.Id));
context.SaveChanges();

Console.WriteLine("After Remove");
foreach (Note note1 in context.Notes.ToList())
{
    Console.WriteLine(note1.Text);
}

context.Notes.AddRange(new List<Note>() { new("Note 4"), new("Note 5"), new("Note 6") });
context.SaveChanges();

Console.WriteLine("After AddRange");
foreach (Note note1 in context.Notes.ToList())
{
    Console.WriteLine(note1.Text);
}

Note note4 = context.Notes.Single(note => note.Text == "Note 2");
note4.Text = "Note 2 Updated";
context.SaveChanges();

Console.WriteLine("After Update");
foreach (Note note1 in context.Notes.ToList())
{
    Console.WriteLine(note1.Text);
}