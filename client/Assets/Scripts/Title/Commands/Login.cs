﻿using UnityEngine;
using System;
using System.Collections;
using UniRx;
using Zenject;
using Zenject.Commands;

namespace Submarine.Commands
{
    public class Login : Command
    {
        public class Handler : ICommandHandler
        {
            [Inject]
            Models.User user;
            [Inject]
            Services.LoginApi loginApi;
            [Inject]
            Services.PermanentDataStore dataStore;
            [Inject]
            TitleEvent titleEvent;

            public void Execute()
            {
                if (!dataStore.HasSigned)
                {
                    throw new InvalidOperationException("Not signed to the API server.");
                }

                loginApi.Login(dataStore.UserName, dataStore.Password).Subscribe(res =>
                {
                    user.LoggedInUser = res.LoggedInUser;
                    user.ApiSessionKey = res.SessionKey;
                    titleEvent.LoginSucceeded.Invoke();
                });
            }
        }
    }
}