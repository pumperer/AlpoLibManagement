using System;
using System.Collections.Generic;
using alpoLib.Util.WebApiClient;

namespace alpoLib.Sample.WebApiClient.Services
{
    public class UserService : BaseApiService<ApiManager>
    {
        public class UserProfile
        {
            public int id;
            public string username;
            public string email;
            public string displayName;
        }

        public class UpdateProfileRequest
        {
            public string displayName;
            public string email;
        }

        public class UserListResponse
        {
            public List<UserProfile> users;
            public int totalCount;
        }

        public UserService(ApiManager client) : base(client) { }

        public void GetUserProfile(Action<UserProfile> onSuccess)
        {
            APIClient.QueueRequest<object, UserProfile>(
                "/user/profile",
                "GET",
                null,
                onSuccess,
                HandleProfileError,
                maxRetries: 5,
                retryDelay: 1f
            );
        }

        public void UpdateProfile(UpdateProfileRequest profileData, Action<UserProfile> onSuccess)
        {
            APIClient.QueueRequest<UpdateProfileRequest, UserProfile>(
                "/user/profile",
                "PUT",
                profileData,
                onSuccess,
                HandleUpdateProfileError,
                maxRetries: 3
            );
        }

        public void GetUserList(int page, int limit, Action<UserListResponse> onSuccess)
        {
            APIClient.QueueRequest<object, UserListResponse>(
                $"/user/list?page={page}&limit={limit}",
                "GET",
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
