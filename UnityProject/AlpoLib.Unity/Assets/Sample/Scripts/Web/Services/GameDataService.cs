using System;
using System.Collections.Generic;
using alpoLib.Util.WebApiClient;

namespace alpoLib.Sample.Web.Services
{
    /// <summary>
    /// 게임 데이터 관련 API 서비스 샘플 클래스
    /// 점수 제출, 리더보드 조회 등의 게임 데이터 기능을 제공
    /// </summary>
    public class GameDataService : BaseApiService<ApiManager>
    {
        /// <summary>
        /// 게임 점수 데이터 클래스
        /// </summary>
        [Serializable]
        public class GameScore
        {
            public int score;
            public int level;
            public float playTime;
        }

        /// <summary>
        /// 점수 제출 요청 데이터 클래스
        /// </summary>
        [Serializable]
        public class ScoreSubmitRequest
        {
            public int score;
            public int level;
            public Dictionary<string, object> metadata;
        }

        /// <summary>
        /// 리더보드 응답 데이터 클래스
        /// </summary>
        [Serializable]
        public class LeaderboardResponse
        {
            public List<GameScore> scores;
            public int playerRank;
        }

        public GameDataService(ApiManager client) : base(client) { }

        /// <summary>
        /// 게임 점수를 서버에 제출합니다
        /// </summary>
        /// <param name="scoreData">제출할 점수 데이터</param>
        /// <param name="onSuccess">성공 콜백</param>
        public void SubmitScore(ScoreSubmitRequest scoreData, Action<GameScore> onSuccess)
        {
            APIClient.QueueRequest<ScoreSubmitRequest, GameScore>(
                "/game/score",
                EMethod.POST,
                scoreData,
                onSuccess,
                HandleScoreSubmitError,
                maxRetries: 5,
                retryDelay: 2f
            );
        }

        /// <summary>
        /// 리더보드 정보를 조회합니다
        /// </summary>
        /// <param name="onSuccess">성공 콜백</param>
        public void GetLeaderboard(Action<LeaderboardResponse> onSuccess)
        {
            APIClient.QueueRequest<object, LeaderboardResponse>(
                "/game/leaderboard",
                EMethod.GET,
                null,
                onSuccess,
                HandleLeaderboardError
            );
        }

        /// <summary>
        /// 특정 레벨의 리더보드를 조회합니다
        /// </summary>
        /// <param name="level">조회할 레벨</param>
        /// <param name="onSuccess">성공 콜백</param>
        public void GetLeaderboardByLevel(int level, Action<LeaderboardResponse> onSuccess)
        {
            APIClient.QueueRequest<object, LeaderboardResponse>(
                $"/game/leaderboard/{level}",
                EMethod.GET,
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
