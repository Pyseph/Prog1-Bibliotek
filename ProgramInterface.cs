namespace Library
{
	public class ProgramInterface
	{
		public static FileDataStore FileDataStore = new();
		public static Dictionary<char, string> Commands = new()
		{
			{ 'T', "Search for title" },
			{ 'A', "Search for author" },
			{ 'B', "Borrow book" },
			{ 'R', "Return book" },
			{ 'N', "Add new book" },
			{ 'D', "Delete book" },
			{ 'L', "List all books" },
			{ 'Q', "Quit" }
		};

		public ProgramInterface()
		{
			Console.WriteLine("Welcome to the library!");
			Console.WriteLine("List of available commands:");

			foreach (KeyValuePair<char, string> command in Commands)
			{
				Console.WriteLine($"{command.Key}: {command.Value}");
			}

			Console.WriteLine("Enter a command to continue");
			AwaitInput();
		}

		public void AwaitInput()
		{
			string input = Input("Enter command: ");
			char command = input[0];

			switch (command)
			{
				case 'T':
					SearchForTitle();
					break;
				case 'A':
					SearchForAuthor();
					break;
				case 'B':
					BorrowBook();
					break;
				case 'R':
					ReturnBook();
					break;
				case 'D':
					DeleteBook();
					break;
				case 'N':
					AddBook();
					break;
				case 'L':
					ListBooks();
					break;
				case 'Q':
					Environment.Exit(0);
					break;
				default:
					Console.WriteLine("Invalid command");
					break;
			}

			AwaitInput();
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
			BookDataStruct? book = FileDataStore.FileData.Find(x => x.Title == title);

			if (book == null)
			{
				Console.WriteLine("No such book found!");
				return;
			}

			Console.WriteLine($"Found {book.Title} by {book.Author}");
		}

		public void SearchForAuthor()
		{
			string author = Input("Enter author: ");
			List<BookDataStruct> books = FileDataStore.FileData.FindAll(x => x.Author == author);

			if (books.Count == 0)
			{
				Console.WriteLine("No books found");
				return;
			}

			Console.WriteLine($"Found {books.Count} books by {author}:");
			foreach (BookDataStruct book in books)
			{
				Console.WriteLine($"{book.Title}");
			}
		}

		public void AddBook()
		{
			string title = Input("Enter title: ");
			if (FileDataStore.FileData.Find(x => x.Title == title) != null)
			{
				Console.WriteLine("Book already exists!");
				return;
			}
			string author = Input("Enter author: ");

			BookDataStruct book = new(title, author);
			FileDataStore.WriteBook(book);

			Console.WriteLine("Book added!");
		}

		public void DeleteBook()
		{
			string title = Input("Enter title: ");
			BookDataStruct? book = FileDataStore.FileData.Find(x => x.Title == title);

			if (book == null)
			{
				Console.WriteLine("No such book found!");
				return;
			}

			if (book.Borrowed)
			{
				Console.WriteLine("Book is borrowed, cannot delete!");
				return;
			}

			FileDataStore.RemoveBook(book);
			Console.WriteLine("Book deleted!");
		}

		public void ListBooks()
		{
			if (FileDataStore.FileData.Count == 0)
			{
				Console.WriteLine("No books found");
				return;
			}

			foreach (BookDataStruct book in FileDataStore.FileData)
			{
				string BorrowedInfo = book.Borrowed ? "Borrowed" : "Available";
				Console.WriteLine($"{book.Title} by {book.Author} - {BorrowedInfo}");
			}
		}

		public void BorrowBook()
		{
			string title = Input("Enter title: ");
			BookDataStruct? book = FileDataStore.FileData.Find(x => x.Title == title);

			if (book == null)
			{
				Console.WriteLine("No such book found!");
				return;
			}

			if (book.Borrowed)
			{
				Console.WriteLine("Book already borrowed!");
				return;
			}

			book.Borrowed = true;
			Console.WriteLine("Book borrowed!");
		}

		public void ReturnBook()
		{
			string title = Input("Enter title: ");
			BookDataStruct? book = FileDataStore.FileData.Find(x => x.Title == title);

			if (book == null)
			{
				Console.WriteLine("No such book found!");
				return;
			}

			if (!book.Borrowed)
			{
				Console.WriteLine("Book already returned!");
				return;
			}

			book.Borrowed = false;
			Console.WriteLine("Book returned!");
		}
	}
}