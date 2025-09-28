using System;
using alpoLib.Util.WebApiClient;

namespace alpoLib.Sample.WebApiClient.Services
{
    public class AuthService : BaseApiService<ApiManager>
    {
        public class LoginRequest
        {
            public string username;
            public string password;
        }

        public class LoginResponse
        {
            public bool success;
            public string token;
            public string message;
        }

        public class RefreshTokenRequest
        {
            public string refreshToken;
        }

        public AuthService(ApiManager client) : base(client) { }

        public void Login(LoginRequest loginData, Action<LoginResponse> onSuccess)
        {
            APIClient.QueueRequest<LoginRequest, LoginResponse>(
                "/auth/login",
                "POST",
                loginData,
                onSuccess,
                HandleLoginError,
                maxRetries: 2,
                retryDelay: 0.5f
            );
        }

        public void RefreshToken(RefreshTokenRequest tokenData, Action<LoginResponse> onSuccess)
        {
            APIClient.QueueRequest<RefreshTokenRequest, LoginResponse>(
                "/auth/refresh",
                "POST",
                tokenData,
                onSuccess,
                HandleRefreshTokenError,
                maxRetries: 1,
                retryDelay: 0.2f
            );
        }

        public void Logout(Action<object> onSuccess)
        {
            APIClient.QueueRequest<object, object>(
                "/auth/logout",
                "POST",
                null,
                onSuccess,
                HandleLogoutError
            );
        }

        private void HandleLoginError(string error)
        {
            Debug.LogError($"Login Error: {error}");
            // 로그인별 특별한 에러 처리
        }

        private void HandleRefreshTokenError(string error)
        {
            Debug.LogError($"Token Refresh Error: {error}");
            // 토큰 갱신 실패시 로그아웃 처리
        }

        private void HandleLogoutError(string error)
        {
            Debug.LogError($"Logout Error: {error}");
        }
    }
}
