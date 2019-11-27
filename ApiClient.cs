﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BlazorApp2
{

    // https://github.com/torhovland/blazor-realworld-example-app/blob/master/src/BlazorRealworld/ApiClient.cs


    public class ApiClient
    {
        const string BaseUrl = "https://conduit.productionready.io/api";
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void SetToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", token);
        }

        public void ClearToken()
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        //public async Task<UserResponse> SignUpAsync(UserModel userForm)
        //{
        //   return await PostUserFormAsync("/users", userForm);
        //}

        //public async Task<UserResponse> SignInAsync(UserModel userForm)
        //{
        //    return await PostUserFormAsync("/users/login", userForm);
        //}

        //public async Task<UserResponse> UpdateUserAsync(UserModel userForm)
        //{
        //    return await PutUserFormAsync("/user", userForm);
        //}
        /*
        public async Task<UserModel> GetUserAsync()
        {
            
            var response = await _httpClient.GetJsonAsync<UserResponse>($"{BaseUrl}/user");
            return response.user;
        }

        async Task<UserResponse> PostUserFormAsync(string urlFragment, UserModel userForm)
        {
            return await _httpClient.PostJsonAsync<UserResponse>($"{BaseUrl}{urlFragment}",
                new
                {
                    user = userForm
                });
        }

        async Task<UserResponse> PutUserFormAsync(string urlFragment, UserModel userForm)
        {
            return await _httpClient.PutJsonAsync<UserResponse>($"{BaseUrl}{urlFragment}",
                new
                {
                    user = userForm
                });
        }

        public async Task<ProfileModel> GetProfileAsync(string username)
        {
            var response = await _httpClient.GetJsonAsync<ProfileResponse>($"{BaseUrl}/profiles/{username}");
            return response.profile;
        }

        public async Task<IEnumerable<ArticleModel>> GetArticlesAsync()
        {
            return await GetArticlesAsync("/articles", null, null);
        }

        public async Task<IEnumerable<ArticleModel>> GetArticlesByTagAsync(string tag)
        {
            return await GetArticlesAsync("/articles", tag, null);
        }

        public async Task<IEnumerable<ArticleModel>> GetArticlesByAuthorAsync(string author)
        {
            return await GetArticlesAsync("/articles", null, author);
        }

        public async Task<IEnumerable<ArticleModel>> GetArticleFeedAsync()
        {
            return await GetArticlesAsync("/articles/feed", null, null);
        }

        async Task<IEnumerable<ArticleModel>> GetArticlesAsync(string urlFragment, string tag, string author)
        {
            var tagFilter = tag == null ? "" : $"tag={tag}&";
            var authorFilter = author == null ? "" : $"author={author}&";
            var query = $"?{tagFilter}{authorFilter}limit=10&offset=0";
            var response = await _httpClient.GetJsonAsync<ArticlesResponse>($"{BaseUrl}{urlFragment}{query}");
            return response.articles;
        }

        public async Task<ArticleModel> GetArticleAsync(string slug)
        {
            var response = await _httpClient.GetJsonAsync<ArticleResponse>($"{BaseUrl}/articles/{slug}");
            return response.article;
        }

        public async Task<IEnumerable<string>> GetTagsAsync()
        {
            var response = await _httpClient.GetJsonAsync<TagResponse>($"{BaseUrl}/tags");
            return response.tags;
        }

        public async Task<ArticleResponse> SaveArticleAsync(ArticleModel article)
        {
            string url = $"{BaseUrl}/articles";
            object content = new
            {
                article = article
            };

            if (String.IsNullOrEmpty(article.slug))
                return await _httpClient.PostJsonAsync<ArticleResponse>(url, content);
            else
                return await _httpClient.PutJsonAsync<ArticleResponse>($"{url}/{article.slug}", content);
        }

        public async Task<bool> DeleteArticleAsync(string slug)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/articles/{slug}");
            return response.IsSuccessStatusCode;
        }
        */
    }


    public class UserResponse
    {
        //public ErrorsModel errors { get; set; }
        public UserModel user { get; set; }
    }

    //public class ProfileResponse
    //{
    //    public ProfileModel profile { get; set; }
    //}

    //public class ArticleResponse
    //{
    //    public ErrorsModel errors { get; set; }
    //    public ArticleModel article { get; set; }
    //}

    //class ArticlesResponse
    //{
    //    public ArticleModel[] articles { get; set; }
    //}

    class TagResponse
    {
        public string[] tags { get; set; }
    }


}
