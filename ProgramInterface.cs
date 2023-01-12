namespace Library
{
	public class ProgramInterface
	{
		public static Dictionary<char, string> Commands = new()
		{
			{ 'T', "Search for title" },
			{ 'A', "Search for author" },
			{ 'B', "Borrow book" },
			{ 'R', "Return book" },
			{ 'A', "Add new book" },
			{ 'D', "Delete book" },
			{ 'L', "List all books" },
			{ 'Q', "Quit" }
		};

		public ProgramInterface()
		{
			
		}

		private string Input(string prompt)
		{
			Console.Write(prompt);
			string? Output = Console.ReadLine();
			Output = HelperUtils.AssertIsNotNull(Output);

			return Output;
		}

		public void SearchForTitle()
		{
			string title = Input("Enter title: ");
			BookDataStruct? book = FileDataStore.FileData.FindAll(x => x.Title == title);

			if (book == null)
			{
				Console.WriteLine("No books found");
			}
			else
			{
				Console.WriteLine(book);
			}
		}
	}
}