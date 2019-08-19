using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interfaces;
using BLL.Services;
namespace USSR.Util
{
    public class UserModule: NinjectModule
        {
            public override void Load()
            {
                Bind<IUserService>().To<UserService>();
            }
        
    }
}