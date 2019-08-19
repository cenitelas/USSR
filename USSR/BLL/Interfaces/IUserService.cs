using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
namespace BLL.Interfaces
{
    public interface IUserService
    {
        void RegistrationUser(UserDTO userDto);
        UserDTO GetUser(int? id);
        IEnumerable<UserDTO> GetUsers();
        void Dispose();
    }
}
