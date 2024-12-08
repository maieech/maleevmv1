using System;
using System.Collections;
using System.Collections.Generic;


public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }


    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }


    public override string ToString()
    {
        return $"Title: {Title}, Author: {Author}, Year: {Year}";
    }
}


public class Library : IEnumerable<Book>
{
    private List<Book> books = new List<Book>();


    public void AddBook(Book book)
    {
        books.Add(book);
    }


    public IEnumerator<Book> GetEnumerator()
    {
        foreach (var book in books)
        {
            yield return book;
        }
    }


    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Program
{
    public static void Main()
    {
        var book1 = new Book("Война и мир", "Лев Толстой", 1869);
        var book2 = new Book("Преступление и наказание", "Фёдор Достоевский", 1866);
        var book3 = new Book("Евгений Онегин", "Александр Пушкин", 1833);

        var library = new Library();
        library.AddBook(book1);
        library.AddBook(book2);
        library.AddBook(book3);

        foreach (var book in library)
        {
            Console.WriteLine(book);
        }
    }
}
