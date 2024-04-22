using P_WebMartes.Entidades;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web.Mvc;

namespace P_WebMartes.Models
{
    public class UserModel
    {
        public string url = "https://localhost:44354/";
        public int UserRegister( User entidad )
        {
            //De acá llamamos al API
            using (var client = new HttpClient())
            {
                url += "Login/RegistrarUsuario";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var res = client.PostAsync(url, jsonEntidad).Result;

                if (res.IsSuccessStatusCode)                
                    return res.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public List<User> UserLogin(User entidad)
        {
            //De acá llamamos al API
            using (var client = new HttpClient())
            {
                url += "Login/IniciarSesionUsuario";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var res = client.PostAsync(url, jsonEntidad).Result;

                if (res.IsSuccessStatusCode)
                    return res.Content.ReadFromJsonAsync<List<User>>().Result;

                return null;
            }
        }
    }
}