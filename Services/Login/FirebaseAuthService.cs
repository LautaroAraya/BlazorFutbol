using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorFutbol.Services.Login
{
    public class FirebaseAuthService
    {
        private readonly IJSRuntime _jsRuntime;
        private const string UserIdKey = "firebaseUserId";
        public event Action OnChangeLogin;

        public FirebaseAuthService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<string> SignInWithEmailPassword(string email, string password)
        {
            var userId = await _jsRuntime.InvokeAsync<string>("firebaseAuth.signInWithEmailPassword", email, password);
            if (userId != null)
            {
                await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", UserIdKey, userId);
                OnChangeLogin?.Invoke();
            }
            return userId;
        }

        public async Task SignOut()
        {
            await _jsRuntime.InvokeVoidAsync("firebaseAuth.signOut");
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.removeItem", UserIdKey);
            OnChangeLogin?.Invoke();
        }

        public async Task<string> GetUserId()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", UserIdKey);
        }

        public async Task<bool> IsUserAuthenticated()
        {
            var userId = await GetUserId();
            return !string.IsNullOrEmpty(userId);
        }
    }
}
