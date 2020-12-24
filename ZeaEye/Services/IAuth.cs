﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZeaEye.Services
{
    public interface IAuth
    {
        Task<string> LogInWithEmailAndPassword(string email, string password);
        Task<string> SignUpWithEmailAndPassword(string email, string password);
        bool SignOut();
        bool IsSignIn();
        String GetUserId();
    }
}
