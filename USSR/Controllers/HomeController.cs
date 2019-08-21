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
    }
}