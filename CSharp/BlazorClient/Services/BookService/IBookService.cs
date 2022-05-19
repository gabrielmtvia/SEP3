﻿
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelClasses;

namespace BlazorClient.Services.BookService;

public interface IBookService
{
    public string Message { get; set; }
    event Action BooksChanged;
    public List<Book> Books { get; set; }
    Task GetBooksAsync(string? categoryUrl = null);
    Task SearchBooks(string searchText);
    Task<List<string>> GetBookSearchSuggestionsAsync(string searchText);
    
    Task <ServiceResponse<Book>> GetBookByIsbnAsync(string isbn);

    Task AddBookAsync(Book book);
}