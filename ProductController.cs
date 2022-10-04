using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crud.Models;
using System.Data;
using System.Data.SqlClient;


namespace crud.Controllers
{
    public class ProductController : Controller
    {
        string Str = @"Data Source=DESKTOP-KS71MCP\SQLSERVER1;Initial Catalog=MvcCrud;Integrated Security=True";
        // GET: Product
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Str))
            {
                con.Open();
                string q = "select * from product";
                SqlDataAdapter da = new SqlDataAdapter(q, con);
                da.Fill(dt);

            }
            return View(dt);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View(new Product());
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Str))
                {

                    con.Open();
                    string q = "insert into Product values('" + product.productcode + "','" + product.productName + "','" + product.productcategory + "','" + product.Salesrate + "','" + product.Hsncode + "') ";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = new Product();
            DataTable dataTable = new DataTable();
            using (SqlConnection con = new SqlConnection(Str))
            {
                con.Open();
                string q = "select * from product where id=" + id;
                SqlDataAdapter da = new SqlDataAdapter(q, con);
                da.Fill(dataTable);

            }
            if (dataTable.Rows.Count == 1)
            {
                product.productcode = dataTable.Rows[0][1].ToString();
                product.productName = dataTable.Rows[0][2].ToString();
                product.productcategory = dataTable.Rows[0][3].ToString();
                //    product.productSalesrate = dataTable.Rows[0][4].ToString();
                //  product.productHsncode = dataTable.Rows[0][5].ToString();

                return View(product);
            }
            return RedirectToAction("Index");
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Str))
                {
                    con.Open();
                    string q = "Updates product SET productcode=@productcode,productName=@productName,productcategory=@productcategory,productSalesrate=@productSalesrate,productHsncode=@productHsncode where id=@id";
                    SqlCommand cmd = new SqlCommand(q,con);
                    cmd.Parameters.AddWithValue("@productcode",product.productcode);
                    cmd.Parameters.AddWithValue("@productName", product.productName);
                    cmd.Parameters.AddWithValue("@productcategory", product.productcategory);
                   // cmd.Parameters.AddWithValue("@productSalesrate", product.productSalesate);
                 //   cmd.Parameters.AddWithValue("@productcode", product.productHsncode);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
    

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(Str))
            {
                con.Open();
                string q = "Delete from product where id=@id";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");

        }

        // POST: Product/Delete/5
       
    }
}
