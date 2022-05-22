﻿using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace BusinessLogicServer.Networking.Books;

public class BookNetworking : IBookNetworking
{
    private BookService.BookServiceClient client;
    
    
      public BookNetworking(BookService.BookServiceClient client)
    {
        this.client = client;
    }
      
      public async Task AddBookAsync(Book book)
      {
          var buildBookMessage = book.BuildBookMessage();

          var addBook = await client.addBookAsync(buildBookMessage);
    }

      // first create the BookByIsbn in the Proto file, then make the request message 
    public async Task<Book> GetBookByIsbnAsync(string isbn)
    {
        var requestMessage = new BookByIsbn()
        {
            Isbn = isbn
        };
        
        // make the response message and give the request message as param to the rpc call
        var response = client.getBookByIsbn(requestMessage);
        if (String.IsNullOrEmpty(response.Isbn))
        {
            return null;
        }
        
        return new Book(response);
    }
}

