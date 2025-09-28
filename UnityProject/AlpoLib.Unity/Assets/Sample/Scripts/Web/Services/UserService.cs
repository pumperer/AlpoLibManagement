using System;
using System.Collections.Generic;
using alpoLib.Util.WebApiClient;

namespace alpoLib.Sample.Web.Services
{
    /// <summary>
    /// 사용자 관련 API 서비스 샘플 클래스
    /// 프로필 조회, 수정, 사용자 목록 조회 등의 기능을 제공
    /// </summary>
    public class UserService : BaseApiService<ApiManager>
    {
        /// <summary>
        /// 사용자 프로필 데이터 클래스
        /// </summary>
        [Serializable]
        public class UserProfile
        {
            public int id;
            public string username;
            public string email;
            public string displayName;
        }

        /// <summary>
        /// 프로필 수정 요청 데이터 클래스
        /// </summary>
        [Serializable]
        public class UpdateProfileRequest
        {
            public string displayName;
            public string email;
        }

        /// <summary>
        /// 사용자 목록 응답 데이터 클래스
        /// </summary>
        [Serializable]
        public class UserListResponse
        {
            public List<UserProfile> users;
            public int totalCount;
        }

        public UserService(ApiManager client) : base(client) { }

        /// <summary>
        /// 현재 사용자의 프로필을 조회합니다
        /// </summary>
        /// <param name="onSuccess">성공 콜백</param>
        public void GetUserProfile(Action<UserProfile> onSuccess)
        {
            APIClient.QueueRequest<object, UserProfile>(
                "/user/profile",
                EMethod.GET,
                null,
                onSuccess,
                HandleProfileError,
                maxRetries: 5,
                retryDelay: 1f
            );
        }

        /// <summary>
        /// 사용자 프로필을 수정합니다
        /// </summary>
        /// <param name="profileData">수정할 프로필 정보</param>
        /// <param name="onSuccess">성공 콜백</param>
        public void UpdateProfile(UpdateProfileRequest profileData, Action<UserProfile> onSuccess)
        {
            APIClient.QueueRequest<UpdateProfileRequest, UserProfile>(
                "/user/profile",
                EMethod.PUT,
                profileData,
                onSuccess,
                HandleUpdateProfileError,
                maxRetries: 3
            );
        }

        /// <summary>
        /// 사용자 목록을 조회합니다 (페이지네이션 지원)
        /// </summary>
        /// <param name="page">페이지 번호</param>
        /// <param name="limit">페이지당 항목 수</param>
        /// <param name="onSuccess">성공 콜백</param>
        public void GetUserList(int page, int limit, Action<UserListResponse> onSuccess)
        {
            APIClient.QueueRequest<object, UserListResponse>(
                $"/user/list?page={page}&limit={limit}",
                EMethod.GET,
                null,
                onSuccess,
                HandleUserListError
            );
        }

        private void HandleProfileError(string error)
        {
            Debug.LogError($"Profile Error: {error}");
            // 프로필 관련 에러 처리
        }

        private void HandleUpdateProfileError(string error)
        {
            Debug.LogError($"Profile Update Error: {error}");
        }

        private void HandleUserListError(string error)
        {
            Debug.LogError($"User List Error: {error}");
        }
    }
}
