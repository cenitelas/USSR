using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces;
using BLL.DTO;
using AutoMapper;
using USSR.Models;

namespace USSR.Controllers
{
    public class HomeController : Controller
    {
        IUserService userService;

        static List<RoomInfoModel> roomInfo = new List<RoomInfoModel>()
        {
            new RoomInfoModel(){Id=1,Name="First room",Discription="NIce Room asdjkfhaksljdfhksjadhk", Delay=60, MaxUsers=9, MinUsers=2, UrlImage="room1.jpg", EscapeRate=30},
            new RoomInfoModel(){Id=2,Name="Second room",Discription="NIce Second Room asdjkfhaksljdfhksjadhk", Delay=30, MaxUsers=5, MinUsers=2, UrlImage="room2.jpg", EscapeRate=40},
            new RoomInfoModel(){Id=3,Name="Third room",Discription="NIce Third Room asdjkfhaksljdfhksjadhk", Delay=40, MaxUsers=10, MinUsers=5, UrlImage="room3.jpg", EscapeRate=60},
            new RoomInfoModel(){Id=4,Name="Four room",Discription="NIce Four Room asdjkfhaksljdfhksjadhk", Delay=130, MaxUsers=25, MinUsers=10, UrlImage="room4.jpg", EscapeRate=30}
        };

        public HomeController(IUserService serv)
        {
            userService = serv;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUsers()
        {
            IEnumerable<UserDTO> userDTO = userService.GetUsers();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserModel>()).CreateMapper();
            var users = mapper.Map<IEnumerable<UserDTO>, List<UserModel>>(userDTO);

            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            var userDTO = userService.GetUser(user.Name);
            if (userDTO!=null && user.Pass.Equals(userDTO.Pass))
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserModel>()).CreateMapper();
                var result = mapper.Map<UserDTO, UserModel>(userDTO);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return Json(user, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Reg(UserModel user)
        {

            if (userService.RegistrationUser(new UserDTO() { Name = user.Name, Pass = user.Pass }).Id!=0)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserModel>()).CreateMapper();
                var result = mapper.Map<UserDTO, UserModel>(userService.GetUser(user.Name));
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRoomsInfo()
        {
            return Json(roomInfo, JsonRequestBehavior.AllowGet);
        }
    }
}