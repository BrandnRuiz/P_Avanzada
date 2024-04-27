using P_API_Martes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P_API_Martes.Entidades
{
    public class Product
    {
        public long IdProduct { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }
        public bool Status { get; set; }
        public string PicPath { get; set; }
        public int IdCategory { get; set; }
        public string CategoryName { get; set; }
    }

    public class ProductConfirm
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<ConsultProduct_Result> Information { get; set; }
        public ConsultProduct_Result Data { get; set; }
    }
}