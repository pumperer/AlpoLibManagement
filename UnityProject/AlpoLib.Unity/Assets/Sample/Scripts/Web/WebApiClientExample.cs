using alpoLib.Sample.WebApiClient.Services;
using alpoLib.Util.WebApiClient;
using UnityEngine;

namespace alpoLib.Sample.WebApiClient
{
    public class WebApiClientExample : MonoBehaviour
    {
        private void Start()
        {
            var context = new WebApiClientInitializeContext
            {
                BaseUrl = "https://api.example.com",
                MaxConcurrentRequests = 5,
                DefaultMaxRetries = 3,
                DefaultRetryDelay = 1f,
            };
            ApiManager.Initialize(context);

            // 초기화 완료 후 로그인 요청
            var loginData = new AuthService.LoginRequest
            {
                username = "player1",
                password = "password123"
            };

            ApiManager.Auth.Login(loginData, OnLoginSuccess);
        }

        private void OnLoginSuccess(AuthService.LoginResponse response)
        {
            if (response.success)
            {
                Debug.Log($"Login successful: {response.token}");
                
                // 로그인 성공 후 프로필 조회
                ApiManager.User.GetUserProfile(OnProfileLoaded);
            }
        }

        private void OnProfileLoaded(UserService.UserProfile profile)
        {
            Debug.Log($"Welcome {profile.displayName}!");
            
            // 리더보드 조회
            ApiManager.GameData.GetLeaderboard(OnLeaderboardLoaded);
        }

        private void OnLeaderboardLoaded(GameDataService.LeaderboardResponse leaderboard)
        {
            Debug.Log($"Your rank: {leaderboard.playerRank}");
        }

        // 점수 제출 예시
        public void SubmitGameScore(int score, int level)
        {
            var scoreData = new GameDataService.ScoreSubmitRequest
            {
                score = score,
                level = level,
                metadata = new System.Collections.Generic.Dictionary<string, object>
                {
                    { "playTime", Time.time },
                    { "gameMode", "classic" }
                }
            };

            ApiManager.GameData.SubmitScore(scoreData, OnScoreSubmitted);
        }

        private void OnScoreSubmitted(GameDataService.GameScore result)
        {
            Debug.Log($"Score submitted successfully: {result.score}");
        }
    }
}
