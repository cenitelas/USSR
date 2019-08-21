using System;
using System.Collections.Generic;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Infrastructure;
using AutoMapper;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public UserDTO RegistrationUser(UserDTO userDTO)
        {
            Users user = Database.Users.Find(x=>x.name.Equals(userDTO.Name)).FirstOrDefault();

            if (user != null)
                return userDTO;


            user = new Users()
            {
                name = userDTO.Name,
                pass = userDTO.Pass
            };
            Database.Users.Create(user);
            Database.Save();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Users, UserDTO>()).CreateMapper();
            var newUser =  mapper.Map<Users, UserDTO>(Database.Users.Get(user.name));
            return newUser;
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Users, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Users>, List<UserDTO>>(Database.Users.GetAll());
        }

        public UserDTO GetUser(int? id)
        {
            if (id == null)
                return null;
            var user = Database.Users.Get(id.Value);
            if (user == null)
                return null;

            return new UserDTO { Name = user.name, Id = user.id, Pass = user.pass};
        }

        public UserDTO GetUser(string name)
        {
            if (name == null)
                return null;
            var user = Database.Users.Get(name);
            if (user == null)
                return null;

            return new UserDTO { Name = user.name, Id = user.id, Pass=user.pass};
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
