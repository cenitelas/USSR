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
            new RoomInfoModel(){Id=1,Name="Diamond Heist: Escape Room in St. Louis and St. Charles",Discription="Book Now - St. Louis Book Now - St. Charles Was \"Confessions of a Master Jewel Thief\" really about you? The Diamond Heist is an exciting room e", Delay=60, MaxUsers=9, MinUsers=2, UrlImage="room1.jpg", EscapeRate=30,Difficulty="Medium",AboutHeader=@"Was “Confessions of a Master Jewel Thief” really about you?", About=@"The Diamond Heist is an exciting room escape adventure for lovers of movies such as “Entrapment”, “Ocean’s Eleven”, and “Heat”. And lovers of the book, “Confession of a Master Jewel Thief.”

Whether you are into the movies, the book or both, Mastermind Room Escape has created a room just for you and your treasure-thieving crew!

Don’t get distracted by the diamond’s sparkling gleam, or the clock quickly losing precious seconds. Equally important, stay calm and efficient to make the ultimate heist or the police will surely arrive soon and take your team into custody!

Think you’ve got what it takes to be the world’s greatest cat burglar? Put your love of puzzles, riddles, and logic to the test, while attempting to pilfer the largest diamond known in history.",MissionHeader=@"The Diamond Heist Escape Room Mission", Mission=@"Your team will have sixty minutes to escape the room. In the same fashion as those epic heist stories, focus on quickly solving puzzles and uncovering the path leading directly to the giant diamond. Furthermore, watch the time so you can get out before the cops arrive and bust you."},

            new RoomInfoModel(){Id=2,Name="DaVinci’s Workshop: St. Charles Escape Room",Discription="Book Now - St. Charles Save the Mona Lisa in DaVinci's Workshop. Thieves are en route to DaVinci's workshop to steal this famous art piece forev", Delay=30, MaxUsers=5, MinUsers=2, UrlImage="room2.jpg", EscapeRate=40, Difficulty="Easy",AboutHeader=@"Save the Mona Lisa in DaVinci’s Workshop.",About=@"Thieves are en route to DaVinci’s workshop to steal this famous art piece forever and you must stop them.

In DaVinci’s workshop at the Mastermind Room Escape in St. Charles, DaVinci is working away on his latest invention.

Far ahead of his time, he pondered geometry, animal science, and mathematics to a level that perplexes us even today.

However, he receives word via carrier pigeon that thieves are en route to ransack his home. In light of hearing this shocking news, DaVinci pleads for somebody…anybody…to save his greatest masterpiece, the Mona Lisa.

Mastermind created a room that centers around his most infamous work of art: The Mona Lisa. You get to focus on an amazing piece of artwork while having escape room fun and excitement.",MissionHeader=@"The DaVinci’s Workshop Escape Room Mission",Mission=@"our team will be tasked with getting into his workshop, locating the Mona Lisa, and escaping the room before the thieves arrive. Because there is no telling what the thieves will do with you should you still be in the workshop when they arrive, you better hurry!"},

            new RoomInfoModel(){Id=3,Name="Secret Society: St. Louis Escape Room",Discription="Book Now (St Louis) Secret Societies abound around the world. Have you ever thought about joining? In the Secret Society Escape Room, you find y", Delay=40, MaxUsers=10, MinUsers=5, UrlImage="room3.jpg", EscapeRate=60, Difficulty="Advanced",AboutHeader=@"Do you love baseball and mystery? Both come together in the form of the Cardinals Quest Escape Room.",About=@"It’s the 7th inning stretch in a tied game of Cards versus Cubs, and the lights in Busch stadium have just gone dark. Furthermore, being the huge fan that you are, you decided to take a crack at figuring out how to get the lights back on.

Not only….but also because you want to make sure the game is finished in St. Louis. Because, as any true baseball fan knows), according to MLB rules, if a TIED game is suspended between innings, the game must be replayed on the opposing team’s home field.

Good thing you are a hero and prepared to save the day. Or in this case, escape the room using your sports knowledge to free your entire group. The first thing to remember is you must love baseball!",MissionHeader=@"The Cardinals Quest Escape Room Mission",Mission=@"Your mission is to go into the bowels of the stadium, switch the lights back on, then get back out to your seats before the last nail-biting inning begins. Correspondingly, don’t strike out, or we’ll have to replay the game in Chicago.

Mastermind Room Escape is located near the Gateway Arch. Escape the room pre or post game while you enjoy everything downtown has to offer. Additionally, this room is open year-round so you can celebrate your love of baseball at any time. Finally, know the Cardinals schedule."},

            new RoomInfoModel(){Id=4,Name="Cardinals Quest: St. Louis Escape Room",Discription="Book Now (St Louis) Do you love baseball and mystery? Both come together in the form of the Cardinals Quest Escape Room. It's the 7th inning str", Delay=130, MaxUsers=25, MinUsers=10, UrlImage="room4.jpg", EscapeRate=30,Difficulty="Medium",AboutHeader=@"Do you love baseball and mystery? Both come together in the form of the Cardinals Quest Escape Room.",About=@"It’s the 7th inning stretch in a tied game of Cards versus Cubs, and the lights in Busch stadium have just gone dark. Furthermore, being the huge fan that you are, you decided to take a crack at figuring out how to get the lights back on.

Not only….but also because you want to make sure the game is finished in St. Louis. Because, as any true baseball fan knows), according to MLB rules, if a TIED game is suspended between innings, the game must be replayed on the opposing team’s home field.

Good thing you are a hero and prepared to save the day. Or in this case, escape the room using your sports knowledge to free your entire group. The first thing to remember is you must love baseball!",MissionHeader=@"The Cardinals Quest Escape Room Mission",Mission=@"Your mission is to go into the bowels of the stadium, switch the lights back on, then get back out to your seats before the last nail-biting inning begins. Correspondingly, don’t strike out, or we’ll have to replay the game in Chicago.

Mastermind Room Escape is located near the Gateway Arch. Escape the room pre or post game while you enjoy everything downtown has to offer. Additionally, this room is open year-round so you can celebrate your love of baseball at any time. Finally, know the Cardinals schedule."}
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