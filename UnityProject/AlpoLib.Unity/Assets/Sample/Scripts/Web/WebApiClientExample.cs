using UnityEngine;
using alpoLib.Util.WebApiClient;
using alpoLib.Sample.Web.Services;

namespace alpoLib.Sample.Web
{
    /// <summary>
    /// WebApiClient 사용 예시를 보여주는 샘플 클래스
    /// EMethod enum을 사용한 HTTP 요청 방법을 데모
    /// </summary>
    public class WebApiClientExample : MonoBehaviour
    {
        private void Start()
        {
            // ApiManager 초기화 - EMethod enum 지원
            InitializeApiManager();
            
            // 샘플 API 호출들
            StartCoroutine(RunApiExamples());
        }

        private void InitializeApiManager()
        {
            var context = new WebApiClientInitializeContext
            {
                BaseUrl = "https://api.example.com",
                MaxConcurrentRequests = 5,
                DefaultMaxRetries = 3,
                DefaultRetryDelay = 1f
            };

            ApiManager.Initialize(context);
            Debug.Log("ApiManager initialized successfully");
        }

        private System.Collections.IEnumerator RunApiExamples()
        {
            // 1초 대기 후 API 호출 시작
            yield return new WaitForSeconds(1f);

            // 1. 로그인 예시 (POST 메서드)
            Debug.Log("=== Login Example ===");
            LoginExample();
            
            yield return new WaitForSeconds(2f);

            // 2. 사용자 프로필 조회 예시 (GET 메서드)
            Debug.Log("=== Get User Profile Example ===");
            GetUserProfileExample();
            
            yield return new WaitForSeconds(2f);

            // 3. 프로필 업데이트 예시 (PUT 메서드)
            Debug.Log("=== Update Profile Example ===");
            UpdateProfileExample();
            
            yield return new WaitForSeconds(2f);

            // 4. 게임 스코어 제출 예시 (POST 메서드)
            Debug.Log("=== Submit Score Example ===");
            SubmitScoreExample();
            
            yield return new WaitForSeconds(2f);

            // 5. 리더보드 조회 예시 (GET 메서드)
            Debug.Log("=== Get Leaderboard Example ===");
            GetLeaderboardExample();
        }

        /// <summary>
        /// 로그인 요청 예시 - EMethod.POST 사용
        /// </summary>
        private void LoginExample()
        {
            var loginData = new AuthService.LoginRequest
            {
                username = "sampleuser",
                password = "samplepassword123"
            };

            ApiManager.Auth.Login(loginData, OnLoginSuccess);
        }

        /// <summary>
        /// 사용자 프로필 조회 예시 - EMethod.GET 사용
        /// </summary>
        private void GetUserProfileExample()
        {
            ApiManager.User.GetUserProfile(OnProfileLoaded);
        }

        /// <summary>
        /// 프로필 업데이트 예시 - EMethod.PUT 사용
        /// </summary>
        private void UpdateProfileExample()
        {
            var profileData = new UserService.UpdateProfileRequest
            {
                displayName = "Updated Name",
                email = "updated@example.com"
            };

            ApiManager.User.UpdateProfile(profileData, OnProfileUpdated);
        }

        /// <summary>
        /// 게임 스코어 제출 예시 - EMethod.POST 사용
        /// </summary>
        private void SubmitScoreExample()
        {
            var scoreData = new GameDataService.ScoreSubmitRequest
            {
                score = 12500,
                level = 5,
                metadata = new System.Collections.Generic.Dictionary<string, object>
                {
                    { "playTime", Time.time },
                    { "gameMode", "classic" },
                    { "difficulty", "hard" }
                }
            };

            ApiManager.GameData.SubmitScore(scoreData, OnScoreSubmitted);
        }

        /// <summary>
        /// 리더보드 조회 예시 - EMethod.GET 사용
        /// </summary>
        private void GetLeaderboardExample()
        {
            ApiManager.GameData.GetLeaderboard(OnLeaderboardLoaded);
        }

        // 콜백 메서드들
        private void OnLoginSuccess(AuthService.LoginResponse response)
        {
            if (response.success)
            {
                Debug.Log($"Login successful! Token: {response.token}");
                Debug.Log($"Welcome message: {response.message}");
            }
            else
            {
                Debug.LogWarning($"Login failed: {response.message}");
            }
        }

        private void OnProfileLoaded(UserService.UserProfile profile)
        {
            Debug.Log($"Profile loaded - ID: {profile.id}, Name: {profile.displayName}");
            Debug.Log($"Username: {profile.username}, Email: {profile.email}");
        }

        private void OnProfileUpdated(UserService.UserProfile profile)
        {
            Debug.Log($"Profile updated successfully! New name: {profile.displayName}");
        }

        private void OnScoreSubmitted(GameDataService.GameScore result)
        {
            Debug.Log($"Score submitted successfully!");
            Debug.Log($"Score: {result.score}, Level: {result.level}, PlayTime: {result.playTime}");
        }

        private void OnLeaderboardLoaded(GameDataService.LeaderboardResponse leaderboard)
        {
            Debug.Log($"Leaderboard loaded! Your rank: {leaderboard.playerRank}");
            Debug.Log($"Top scores count: {leaderboard.scores?.Count ?? 0}");
            
            if (leaderboard.scores != null && leaderboard.scores.Count > 0)
            {
                Debug.Log($"Top score: {leaderboard.scores[0].score} (Level {leaderboard.scores[0].level})");
            }
        }

        /// <summary>
        /// 수동으로 다양한 HTTP 메서드 테스트
        /// </summary>
        public void TestAllHttpMethods()
        {
            Debug.Log("=== Testing All HTTP Methods ===");

            // GET 요청 예시
            ApiManager.User.GetUserProfile(profile => 
                Debug.Log("GET request completed"));

            // POST 요청 예시  
            var loginData = new AuthService.LoginRequest { username = "test", password = "test" };
            ApiManager.Auth.Login(loginData, response => 
                Debug.Log("POST request completed"));

            // PUT 요청 예시
            var updateData = new UserService.UpdateProfileRequest { displayName = "Test", email = "test@test.com" };
            ApiManager.User.UpdateProfile(updateData, profile => 
                Debug.Log("PUT request completed"));

            // 사용자 목록 조회 (GET with parameters)
            ApiManager.User.GetUserList(1, 10, userList => 
                Debug.Log("GET with parameters completed"));
        }

        private void OnDestroy()
        {
            Debug.Log("WebApiClientExample destroyed");
        }
    }
}
