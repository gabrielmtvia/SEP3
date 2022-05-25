using System.Diagnostics.SymbolStore;
using Grpc.Core;
using Microsoft.VisualBasic;
using ModelClasses;

namespace BusinessLogicServer.Networking.Cart;

public class CartNetworking : ICartNetworking
{
    private CartService.CartServiceClient CartServiceClient;

    public CartNetworking(CartService.CartServiceClient cartServiceClient)
    {
        CartServiceClient = cartServiceClient;
    }


    public async Task AddCartAsync(CartLineDTO cartLineDto)
    {
        
      //  cartLineDto.username = username;
       // cartLineDto.CartOrderLineDtos = orderlines;
        
        //////////////////////////////////////////////////////
        //var c = new CartOrderLine();
      //  CartOrderLine c1 = new CartOrderLine();
        //  c.Isbn=o
        var cs = new List<CartOrderLine>();


        foreach (OrderLineDTO col in cartLineDto.CartOrderLineDtos)
        {
            var c = new CartOrderLine();
            c.Isbn = col.Isbn;
            c.Qte = col.Quantity;
            cs.Add(c);

        }
        

        await CartServiceClient.confirmedCartAsync(new CartMessage
        {
            Username = cartLineDto.username,
            CartOrderLine =
               
            { 
                cs.ToArray()
            }

        });

        
        
        
    /*
       CartOrderLine c = new CartOrderLine();
       List<CartOrderLine> cs = new List<CartOrderLine>();
     

        foreach (OrderLineDTO col in cartLineDto.CartOrderLineDtos)
        {
            c.Isbn= col.Isbn;
             c.Qte= col.Quantity;
             cs.Add(c);

        }

        await CartServiceClient.confirmedCartAsync(new CartMessage
        {

            Username = cartLineDto.username,
            
            CartOrderLine =
            { 
               cs.ToArray()
            }

     });

*/
   }




}