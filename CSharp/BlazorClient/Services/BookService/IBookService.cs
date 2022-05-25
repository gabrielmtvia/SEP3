
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelClasses;

namespace BlazorClient.Services.BookService;

public interface IBookService
{
    //  public List<Book> Books { get; set; }
    //  public string Message { get; set; }
    // event Action BooksChanged;
    // Task SearchBooks(string searchText);
  // Task<List<string>> GetBookSearchSuggestionsAsync(string searchText);
  
 
    Task<List<Book>> GetBooksByNameAsync(string searchName);
    Task<List<Book>> GetAllBooksAsync();
    
    Task<Book> GetBookByIsbnAsync(string isbn);

    Task AddBookAsync(Book book);
    Task DeleteBookAsync(string isbn);
    Task EditBook(Book bookToAdd);
}