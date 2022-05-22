
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlazorClient.Services.BookService;

public interface IBookService
{
    public string Message { get; set; }
    event Action BooksChanged;
    public List<Book> Books { get; set; }
    Task SearchBooks(string searchText);
    Task<List<string>> GetBookSearchSuggestionsAsync(string searchText);
    Task<List<Book>> GetAllBooksAsync();
    
    Task<Book> GetBookByIsbnAsync(string isbn);

    Task AddBookAsync(Book book);
}