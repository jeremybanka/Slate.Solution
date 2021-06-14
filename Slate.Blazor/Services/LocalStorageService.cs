using Microsoft.JSInterop;
using System.Text.Json;
using System.Threading.Tasks;

namespace Slate.Blazor.Services
{
  public interface ILocalStorageService
  {
    Task<T> GetItem<T>(string key);
    Task SetItem<T>(string key, T value);
    Task RemoveItem(string key);
  }

  public class LocalStorageService : ILocalStorageService
  {
    private readonly IJSRuntime _jsRuntime;

    public LocalStorageService(IJSRuntime jsRuntime)
    {
      _jsRuntime = jsRuntime;
    }

    public async Task<T> GetItem<T>(string key)
    {
      var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);

      return json == null
        ? default
        : JsonSerializer.Deserialize<T>(json);
    }

    public async Task SetItem<T>(string key, T value)
    {
      await _jsRuntime.InvokeVoidAsync(
        "localStorage.setItem",
        key,
        JsonSerializer.Serialize(value)
        );
    }

    public async Task RemoveItem(string key)
    {
      await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
    }
  }
}