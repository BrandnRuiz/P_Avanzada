using P_WebMartes.Entidades;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web.Mvc;

namespace P_WebMartes.Models
{
    public class UserModel
    {
        public string url = ConfigurationManager.AppSettings["UrlWebAPI"];
        public RequestMessage UserRegister( User entidad )
        {
            //De acá llamamos al API
            using (var client = new HttpClient())
            {
                url += "Login/RegistrarUsuario";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var res = client.PostAsync(url, jsonEntidad).Result;

                if (res.IsSuccessStatusCode)                
                    return res.Content.ReadFromJsonAsync<RequestMessage>().Result;
                else
                    return null;
            }
        }

        public UserConfirm UserLogin(User entidad)
        {
            //De acá llamamos al API
            using (var client = new HttpClient())
            {
                url += "Login/IniciarSesionUsuario";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var res = client.PostAsync(url, jsonEntidad).Result;

                if (res.IsSuccessStatusCode)
                    return res.Content.ReadFromJsonAsync<UserConfirm>().Result;
                else
                    return null;
            }
        }

        public RequestMessage UserRecoverAccess(User entidad)
        {
            //De acá llamamos al API
            using (var client = new HttpClient())
            {
                url += "Login/RecuperarAccesoUsuario";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var res = client.PostAsync(url, jsonEntidad).Result;

                if (res.IsSuccessStatusCode)
                    return res.Content.ReadFromJsonAsync<RequestMessage>().Result;
                else
                    return null;
            }
        }
    }
}