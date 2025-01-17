﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user); // bu kullanıcının yetkileri neler ? 
        void Add(User user); 
        User GetByMail(string email);
    }
}
