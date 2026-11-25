public class Library {
    public string Name { get; private set; }
    public List<Book> Books { get; private set; } = new List<Book>();

    public Library(string name) {
        if (string.IsNullOrWhiteSpace(name)) {
            Name = "Библиотека";
        } else {
            Name = name.Trim();
        }
    }
}
