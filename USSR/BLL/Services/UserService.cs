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
        public void RegistrationUser(UserDTO userDTO)
        {
            Users user = Database.Users.Find(x=>x.name.Equals(userDTO.Name)).FirstOrDefault();

            if (user != null)
                throw new ValidationException("Пользователь существует!", "");


            user = new Users()
            {
                name = userDTO.Name
            };
            Database.Users.Create(user);
            Database.Save();
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Users, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Users>, List<UserDTO>>(Database.Users.GetAll());
        }

        public UserDTO GetUser(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id пользователя", "");
            var user = Database.Users.Get(id.Value);
            if (user == null)
                throw new ValidationException("Пользователь не найден", "");

            return new UserDTO { Name = user.name, Id = user.id};
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
