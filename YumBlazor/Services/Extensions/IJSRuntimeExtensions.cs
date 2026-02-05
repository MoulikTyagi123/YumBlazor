using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace YumBlazor.Services.Extensions
{
    public static class JSRuntimeExtensions
    {
        public static async Task ToastrSuccess(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("showToastr", "success", message);
        }

        public static async Task ToastrError(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("showToastr", "error", message);
        }

        public static async Task ToastrInfo(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("showToastr", "info", message);
        }
    }
}
