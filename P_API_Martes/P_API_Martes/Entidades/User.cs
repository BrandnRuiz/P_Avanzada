using P_API_Martes.Models;
using System;
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

    public class UserConfirm
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<UserLogin_Result> Information { get; set; }
        public UserLogin_Result Data { get; set; } 
    }
}