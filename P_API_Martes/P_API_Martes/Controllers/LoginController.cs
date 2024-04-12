using P_API_Martes.Entidades;
using P_API_Martes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI;

namespace P_API_Martes.Controllers
{
    public class LoginController : ApiController
    {
        [Route("Login/RegistrarUsuario")]
        [HttpPost]
        public int UserRegister( User entidad )
        {
            try
            {
                //Abrir la base de datos
                using (var db = new martes_dbEntities())
                {
                    //Intanciar y llamar el procedimiento
                    return db.UserRegister(entidad.Id, entidad.Name, entidad.Mail, entidad.Password);
                }
            }
            catch(Exception ex)
            {
                return -1;
            }
        }

        //Este es de tipo POST por ser datos sensibles
        [Route("Login/IniciarSesionUsuario")]
        [HttpPost]
        public List<UserLogin_Result> UserLogin(User entidad)
        {
            try
            {                
                using (var db = new martes_dbEntities())
                {
                    //Intanciar y llamar el procedimiento
                    var datos = db.UserLogin(entidad.Id, entidad.Password).ToList();
                    if (datos.Count > 0)
                    {
                        return datos;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}