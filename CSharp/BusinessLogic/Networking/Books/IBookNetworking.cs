﻿using ModelClasses;

namespace BusinessLogicServer.Networking.Books;

public interface IBookNetworking
{
     Task AddBookAsync(Book book);
     Task <Book>GetBookByIsbnAsync(string isbn);

   public  Task<List<Book>> GetAllBooks();
}