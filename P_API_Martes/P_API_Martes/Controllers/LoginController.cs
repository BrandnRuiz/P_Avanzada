using P_API_Martes.Entidades;
using P_API_Martes.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        [Route("Login/RegistrarUsuario")]
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
        [Route("Login/IniciarSesionUsuario")]
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
                        response.Code = 0;
                        response.Message = string.Empty;
                        response.Data = res;
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
        [Route("Login/RecuperarAccesoUsuario")]
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
                        SendMail(res.Mail, "Accesso Temporal", res.Password);

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

        private void SendMail (string destiny, string subject, string content)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(ConfigurationManager.AppSettings["cuentaCorreo"]);
            message.To.Add(new MailAddress(destiny));
            message.Subject = subject;
            message.Body = content;
            message.Priority  = MailPriority.Normal;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("smtp.office365.com", 587);
            client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["cuentaCorreo"], 
                                                                  ConfigurationManager.AppSettings["claveCorreo"]);
            client.EnableSsl = true;
            client.Send(message);
        }
    }
}