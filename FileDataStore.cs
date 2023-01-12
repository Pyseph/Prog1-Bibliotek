using Newtonsoft.Json;
using System.Diagnostics;

namespace Library
{
	public class FileDataStore
	{
		// The FileDataStore class uses JSON file encoding to read and write data

		public static string FileName = "Contents.txt";
		public List<BookDataStruct> FileData = new();

		public FileDataStore()
		{
			// Create file if it doesn't exist
			if (!File.Exists(FileName))
			{
				Debug.WriteLine("Creating file");
				File.Create(@"c:\" + FileName);
				File.WriteAllText(FileName, "[]");
			}

			// Read data from file
			string bookData = File.ReadAllText(FileName);

			List<BookDataStruct>? books = JsonConvert.DeserializeObject<List<BookDataStruct>>(bookData);
			if (books == null) books = new();

			this.FileData = books;
		}

		private void updateFile()
		{
			string bookData = JsonConvert.SerializeObject(FileData);
			File.WriteAllText(FileName, bookData);
		}

		public void WriteBook(BookDataStruct data)
		{
			FileData.Add(data);
			updateFile();
		}
		public void WriteBooks(List<BookDataStruct> data)
		{
			FileData.AddRange(data);
			updateFile();
		}
		public void RemoveBook(BookDataStruct data)
		{
			FileData.Remove(data);
			updateFile();
		}
	}
}