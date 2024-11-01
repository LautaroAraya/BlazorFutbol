using Microsoft.JSInterop;

namespace BlazorFutbol.Interfaces
{
    public class SweeAlert2
    {
        private readonly IJSRuntime _jsRuntime;

        public SweeAlert2(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        // instanciamos ShowAlert
        public async Task ShowAlert(string tipo, string titulo, string mensaje)
        {
            await _jsRuntime.InvokeVoidAsync("showSwal", tipo, titulo, mensaje);
        }

        // instanciamos Confirmation
        public async Task<bool> Confirmation(string titulo, string mensaje, TipoIconSweetAlert tipoIconSweetAlert)
        {
            return await _jsRuntime.InvokeAsync<bool>("SweetAlertHelper.showDeleteConfirmation", titulo, mensaje, tipoIconSweetAlert.ToString());
        }
    }
    // eneumeramos los tipos de alerta según el icon
    public enum TipoIconSweetAlert
    {
        question, warning, success, info
    }
}

