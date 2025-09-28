using alpoLib.Util.WebApiClient;
using alpoLib.Sample.Web.Services;

namespace alpoLib.Sample.Web
{
    /// <summary>
    /// Web API 관리자 샘플 클래스
    /// WebApiClient를 상속받아 구체적인 API 클라이언트 구현 제공
    /// </summary>
    public class ApiManager : WebApiClient
    {
        /// <summary>
        /// 싱글톤 인스턴스
        /// </summary>
        private static ApiManager _instance;
        
        /// <summary>
        /// ApiManager가 초기화되었는지 확인
        /// </summary>
        public static bool IsInitialized => _instance != null;
        
        /// <summary>
        /// 인증 서비스
        /// </summary>
        private AuthService _authService;
        
        /// <summary>
        /// 인증 서비스
        /// </summary>
        public static AuthService Auth => _instance?._authService;
        
        /// <summary>
        /// 사용자 서비스
        /// </summary>
        private UserService _userService;
        
        /// <summary>
        /// 사용자 서비스
        /// </summary>
        public static UserService User => _instance?._userService;
        
        /// <summary>
        /// 게임 데이터 서비스
        /// </summary>
        private GameDataService _gameDataService;
        
        /// <summary>
        /// 게임 데이터 서비스
        /// </summary>
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

        /// <summary>
        /// ApiManager를 초기화합니다
        /// </summary>
        /// <param name="context">초기화 컨텍스트</param>
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
            _instance.InitServices();
        }

        /// <summary>
        /// 서비스 인스턴스 초기화
        /// </summary>
        private void InitServices()
        {
            _authService = new AuthService(this);
            _userService = new UserService(this);
            _gameDataService = new GameDataService(this);
        }

        private new void OnDestroy()
        {
            base.OnDestroy();
            if (_instance == this)
            {
                _instance = null;
            }
        }
    }
}
