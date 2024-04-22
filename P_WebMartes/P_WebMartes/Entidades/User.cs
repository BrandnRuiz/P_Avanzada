using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P_WebMartes.Entidades
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
        public List<User> Information { get; set; }
        public User Data { get; set; }
    }
}