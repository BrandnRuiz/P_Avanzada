using P_API_Martes.Entidades;
using P_API_Martes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace P_API_Martes.Controllers
{
    public class ProductController : ApiController
    {        
        [Route("Producto/ConsultarProducto")]
        [HttpGet]
        public ProductConfirm ConsultProduct(bool VIewAll)
        {
            var response = new ProductConfirm();

            try
            {
                using (var db = new martes_dbEntities())
                {
                    //Intanciar y llamar el procedimiento
                    var res = db.ConsultProduct(VIewAll).ToList();

                    if (res.Count > 0)
                    {
                        response.Code = 0;
                        response.Message = string.Empty;
                        response.Information = res;
                        
                    }
                    else
                    {
                        response.Code = -1;
                        response.Message = "No se encontraron resultados";
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
