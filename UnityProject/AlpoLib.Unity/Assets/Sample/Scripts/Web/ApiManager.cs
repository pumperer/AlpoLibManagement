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
        private static ApiManager _instance;
        
        /// <summary>
        /// 인증 서비스에 대한 정적 접근자
        /// </summary>
        public static AuthService Auth => _instance != null ? new AuthService(_instance) : null;
        
        /// <summary>
        /// 사용자 서비스에 대한 정적 접근자
        /// </summary>
        public static UserService User => _instance != null ? new UserService(_instance) : null;
        
        /// <summary>
        /// 게임 데이터 서비스에 대한 정적 접근자
        /// </summary>
        public static GameDataService GameData => _instance != null ? new GameDataService(_instance) : null;

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
        /// <returns>초기화된 ApiManager 인스턴스</returns>
        public static ApiManager Initialize(WebApiClientInitializeContext context)
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
            return _instance;
        }

        /// <summary>
        /// ApiManager가 초기화되었는지 확인
        /// </summary>
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
