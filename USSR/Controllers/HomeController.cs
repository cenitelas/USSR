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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}