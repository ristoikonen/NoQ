﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2
{
    public class AppState
    {
        private readonly ApiClient api;
        public AppState(ApiClient api)
        {
            this.api = api;
            User = new UserModel();
        }

        public event Action OnUserChange;

        private void NotifyUserChanged() => OnUserChange?.Invoke();

        //public ErrorsModel Errors { get; private set; }
        public UserModel User { get; private set; }

        public bool IsSignedIn => User?.token != null;

        public void UpdateUser(UserModel user)
        {
            User = user;
            var token = User?.token;

            if (token != null)
                api.SetToken(token);

            NotifyUserChanged();
        }
    }
}
