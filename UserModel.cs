﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2
{
    public class UserModel
    {
        public string email { get; set; }
        public string username { get; set; }
        public string bio { get; set; }
        public string image { get; set; }
        public string token { get; set; }
        public string password { get; set; }

        public UserModel Clone()
        {
            return new UserModel
            {
                // Password and token will not be cloned.

                email = email,
                username = username,
                bio = bio,
                image = image
            };
        }
    }
}
