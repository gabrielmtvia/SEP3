using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorClient.wwwroot.javaScript;

public class Msg
{
    [Inject] private IJSRuntime JsRuntime { get; set; }
    private async Task Alert(string msg)
    {
        await JsRuntime.InvokeAsync<object>("Alert", msg);
    }
    public void alertMsg()
    {
        Alert("You are going to login Successfully");
    }
}