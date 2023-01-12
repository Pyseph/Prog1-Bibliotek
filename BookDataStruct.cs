namespace Library
{
    public class BookDataStruct
    {
        // Contains the data that will be written to the file
        // Data:
        // * Book title
        // * Book author

        public string Title { get; }
        public string Author { get; }
        public bool Borrowed { get; set; }

        public BookDataStruct(string title, string author)
        {
            Title = title;
            Author = author;
            Borrowed = false;
        }
    }
}