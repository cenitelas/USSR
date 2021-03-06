﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace USSR.Models
{
    public class RoomInfoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string AboutHeader { get; set; }
        public string About { get; set; }
        public string MissionHeader { get; set; }
        public string Mission { get; set; }
        public string UrlImage { get; set; }
        public int MinUsers { get; set; }
        public int MaxUsers { get; set; }
        public int Delay { get; set; }
        public int EscapeRate { get; set; }
        public string Difficulty { get; set; }
    }
}