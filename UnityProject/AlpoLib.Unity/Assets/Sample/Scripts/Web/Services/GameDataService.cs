using System;
using System.Collections.Generic;
using alpoLib.Util.WebApiClient;

namespace alpoLib.Sample.WebApiClient.Services
{
    public class GameDataService : BaseApiService<ApiManager>
    {
        public class GameScore
        {
            public int score;
            public int level;
            public float playTime;
        }

        public class ScoreSubmitRequest
        {
            public int score;
            public int level;
            public Dictionary<string, object> metadata;
        }

        public class LeaderboardResponse
        {
            public List<GameScore> scores;
            public int playerRank;
        }

        public GameDataService(ApiManager client) : base(client) { }

        public void SubmitScore(ScoreSubmitRequest scoreData, Action<GameScore> onSuccess)
        {
            APIClient.QueueRequest<ScoreSubmitRequest, GameScore>(
                "/game/score",
                "POST",
                scoreData,
                onSuccess,
                HandleScoreSubmitError,
                maxRetries: 5,
                retryDelay: 2f
            );
        }

        public void GetLeaderboard(Action<LeaderboardResponse> onSuccess)
        {
            APIClient.QueueRequest<object, LeaderboardResponse>(
                "/game/leaderboard",
                "GET",
                null,
                onSuccess,
                HandleLeaderboardError
            );
        }

        private void HandleScoreSubmitError(string error)
        {
            Debug.LogError($"Score Submit Error: {error}");
            // 점수 제출 실패시 로컬에 임시 저장
        }

        private void HandleLeaderboardError(string error)
        {
            Debug.LogError($"Leaderboard Error: {error}");
        }
    }
}
