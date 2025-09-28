using System;
using alpoLib.Util.WebApiClient;

namespace alpoLib.Sample.Web.Services
{
    /// <summary>
    /// 인증 관련 API 서비스 샘플 클래스
    /// 로그인, 토큰 갱신, 로그아웃 등의 인증 기능을 제공
    /// </summary>
    public class AuthService : BaseApiService<ApiManager>
    {
        /// <summary>
        /// 로그인 요청 데이터 클래스
        /// </summary>
        [Serializable]
        public class LoginRequest
        {
            public string username;
            public string password;
        }

        /// <summary>
        /// 로그인 응답 데이터 클래스
        /// </summary>
        [Serializable]
        public class LoginResponse
        {
            public bool success;
            public string token;
            public string refreshToken;
            public string message;
        }

        /// <summary>
        /// 토큰 갱신 요청 데이터 클래스
        /// </summary>
        [Serializable]
        public class RefreshTokenRequest
        {
            public string refreshToken;
        }

        public AuthService(ApiManager client) : base(client) { }

        /// <summary>
        /// 사용자 로그인을 수행합니다
        /// </summary>
        /// <param name="loginData">로그인 정보</param>
        /// <param name="onSuccess">성공 콜백</param>
        public void Login(LoginRequest loginData, Action<LoginResponse> onSuccess)
        {
            APIClient.QueueRequest<LoginRequest, LoginResponse>(
                "/auth/login",
                EMethod.POST,
                loginData,
                onSuccess,
                HandleLoginError,
                maxRetries: 2,
                retryDelay: 0.5f
            );
        }

        /// <summary>
        /// 액세스 토큰을 갱신합니다
        /// </summary>
        /// <param name="tokenData">갱신 토큰 정보</param>
        /// <param name="onSuccess">성공 콜백</param>
        public void RefreshToken(RefreshTokenRequest tokenData, Action<LoginResponse> onSuccess)
        {
            APIClient.QueueRequest<RefreshTokenRequest, LoginResponse>(
                "/auth/refresh",
                EMethod.POST,
                tokenData,
                onSuccess,
                HandleRefreshTokenError,
                maxRetries: 1,
                retryDelay: 0.2f
            );
        }

        /// <summary>
        /// 사용자 로그아웃을 수행합니다
        /// </summary>
        /// <param name="onSuccess">성공 콜백</param>
        public void Logout(Action<object> onSuccess)
        {
            APIClient.QueueRequest<object, object>(
                "/auth/logout",
                EMethod.POST,
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
