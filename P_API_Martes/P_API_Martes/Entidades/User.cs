﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P_API_Martes.Entidades
{
    public class User
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
    }
}