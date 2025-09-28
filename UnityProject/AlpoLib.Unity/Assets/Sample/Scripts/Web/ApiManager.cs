using alpoLib.Sample.WebApiClient.Services;
using alpoLib.Util.WebApiClient;

namespace alpoLib.Sample.WebApiClient
{
    public class ApiManager : Util.WebApiClient.WebApiClient
    {
        private static ApiManager _instance;
        
        private AuthService _authService;
        private UserService _userService;
        private GameDataService _gameDataService;
        
        public static AuthService Auth => _instance?._authService;
        public static UserService User => _instance?._userService;
        public static GameDataService GameData => _instance?._gameDataService;

        protected override void OnHttpError(long responseCode, string error)
        {
            Debug.LogError($"HTTP Error {responseCode}: {error}");
            
            // 공통 HTTP 에러 처리
            switch (responseCode)
            {
                case 401:
                    Debug.LogError("Unauthorized - Token may be expired");
                    // 토큰 재발급 로직 또는 로그인 화면으로 이동
                    break;
                case 403:
                    Debug.LogError("Forbidden - Access denied");
                    break;
                case 404:
                    Debug.LogError("Not Found - Invalid endpoint");
                    break;
                case 500:
                    Debug.LogError("Internal Server Error");
                    break;
                default:
                    Debug.LogError($"Unhandled HTTP error: {responseCode}");
                    break;
            }
        }

        public static void Initialize(WebApiClientInitializeContext context)
        {
            if (_instance != null)
            {
                Debug.LogWarning("ApiManager is already initialized. Destroying previous instance.");
                if (_instance.gameObject != null)
                {
                    DestroyImmediate(_instance.gameObject);
                }
            }

            _instance = Initialize<ApiManager>(context);
            _instance.InitService();
        }

        private void InitService()
        {
            _authService = new AuthService(this);
            _userService = new UserService(this);
            _gameDataService = new GameDataService(this);
        }

        public static bool IsInitialized => _instance != null;

        private void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }
    }
}
