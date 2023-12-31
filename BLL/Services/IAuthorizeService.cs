﻿using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IAuthorizeService
    {
        public Task<ResponseMessage> SignUp(UserRegister paramUser);
        public Task<ResponseMessage> SignIn(UserAutorize paramUser);
    }
}
