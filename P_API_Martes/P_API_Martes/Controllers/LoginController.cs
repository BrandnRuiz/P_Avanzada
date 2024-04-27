using Microsoft.Ajax.Utilities;
using P_API_Martes.Entidades;
using P_API_Martes.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI;

namespace P_API_Martes.Controllers
{
    public class LoginController : ApiController
    {
        UtilsModel Utilities = new UtilsModel(); 
        
        [Route("Inicio/RegistrarUsuario")]
        [HttpPost]
        public RequestMessage UserRegister( User entidad )
        {
            /**
             * Se instancia un objeto de tipo RequestMessage para captar los 
             * mensajes de confirmación o error.
             */
            var response = new RequestMessage();

            try
            {
                //Abrir la base de datos
                using (var db = new martes_dbEntities())
                {
                    //Intanciar y llamar el procedimiento
                    var res = db.UserRegister(entidad.Id, entidad.Name, entidad.Mail, entidad.Password);

                    if(res > 0)
                    {
                        response.Code = 0;
                        response.Message = string.Empty;
                    }
                    else
                    {
                        response.Code = -1;
                        response.Message = "Su información ya se encuentra registrada en el sistema";
                    }
                }
            }
            catch(Exception)
            {
                //Registrar el error den la Base de datos.
                response.Code = -1;
                response.Message = "Se presentó un error en el sistema";
            }
            return response;
        }

        //Este es de tipo POST por ser datos sensibles
        [Route("Inicio/IniciarSesionUsuario")]
        [HttpPost]
        public UserConfirm UserLogin(User entidad)
        {
            var response = new UserConfirm();

            try
            {                
                using (var db = new martes_dbEntities())
                {
                    //Intanciar y llamar el procedimiento
                    var res = db.UserLogin(entidad.Id, entidad.Password).FirstOrDefault();

                    if (res != null)
                    {
                        if (res.Temporary && DateTime.Now > res.Expiration)
                        {
                            response.Code = -1;
                            response.Message = "Su contraseña temporal ha caducado";
                        }
                        else
                        {
                            response.Code = 0;
                            response.Message = string.Empty;
                            response.Data = res;
                        }
                    }
                    else
                    {
                        response.Code = -1;
                        response.Message = "No se pudo validar su información";
                    }
                }
            }
            catch (Exception )
            {
                response.Code = -1;
                response.Message = "Se presentó un error en el sistema";
            }
            return response;
        }

        //Este es de tipo POST por ser datos sensibles
        [Route("Inicio/RecuperarAccesoUsuario")]
        [HttpPost]
        public RequestMessage UserRecoveryAccess(User entidad)
        {
            var response = new RequestMessage();

            try
            {
                using (var db = new martes_dbEntities())
                {
                    //Intanciar y llamar el procedimiento
                    var res = db.UserRecoveryAccess(entidad.Id, entidad.Mail).FirstOrDefault();

                    if (res != null)
                    {
                        string path = AppDomain.CurrentDomain.BaseDirectory + "Password.html";
                        string contain = File.ReadAllText(path);

                        contain = contain.Replace("@@Name", res.Name);
                        contain = contain.Replace("@@Password", res.Password);
                        contain = contain.Replace("@@Expiration", res.Expiration.ToString("dd/MM/yyyy hh:mm:ss tt"));

                        Utilities.SendMail(res.Mail, "Accesso Temporal", contain);

                        response.Code = 0;
                        response.Message = string.Empty;                    
                    }
                    else
                    {
                        response.Code = -1;
                        response.Message = "No se pudo validar su información";
                    }
                }
            }
            catch (Exception)
            {
                response.Code = -1;
                response.Message = "Se presentó un error en el sistema";
            }
            return response;
        }
    }
}