//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace P_API_Martes.Models
{
    using System;
    
    public partial class UserRecoveryAccess_Result
    {
        public long Consecutivo { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public bool Estado { get; set; }
        public Nullable<bool> Temporary { get; set; }
        public Nullable<System.DateTime> Expiration { get; set; }
    }
}
