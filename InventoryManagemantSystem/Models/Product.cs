using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace InventoryManagemantSystem.Models;

public class Product
{ 
    public int Id { get; set; }

    public string? ProductName { get; set; } 

    public string ProductQnty { get; set; }

    public List<Product> GetProduct()
    {
        List<Product> proLst = new List<Product>();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=InventoryManagement;Integrated Security=true";
        con.Open();

        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Product";
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Product pro = new Product();
                pro.Id = dr.GetInt32("Id");
                pro.ProductName = dr.GetString("Product_name");
                pro.ProductQnty = dr.GetString("Product_qnty");

                proLst.Add(pro);
            }
            return proLst;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return proLst;
    }

    public Product GetSingleProduct(int id)
    {
        Product pro = new Product();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=InventoryManagement;Integrated Security=true";
        con.Open();

        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Product where Id=@Id";
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            pro.Id = dr.GetInt32("Id");
            pro.ProductName = dr.GetString("Product_name");
            pro.ProductQnty = dr.GetString("Product_qnty");

            return pro;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return pro;
    }

    public Product GetSingleProduct(string productname)
    {
        Product pro = new Product();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=InventoryManagement;Integrated Security=true";
        con.Open();

        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Product where Product_name=@productname";
            cmd.Parameters.AddWithValue("@productname", productname);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            pro.Id = dr.GetInt32("Id");
            pro.ProductName = dr.GetString("Product_name");
            pro.ProductQnty = dr.GetString("Product_qnty");

            return pro;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return pro;
    }

    public void insert(Product pro)
    {
        //Employee emp = new Employee { EmpNo = EmpNo, Name = Name, Basic = Basic, DeptNo = DeptNo};
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=InventoryManagement;Integrated Security=true";
        con.Open();
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Product values(@Id,@ProductName,@ProductQnty)";
            cmd.Parameters.AddWithValue("@Id", pro.Id);
            cmd.Parameters.AddWithValue("@ProductName", pro.ProductName);
            cmd.Parameters.AddWithValue("@ProductQnty", pro.ProductQnty);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Record inserted into table");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }

    public void update(int Id, string ProductName, string ProductQnty)
    {

        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=InventoryManagement;Integrated Security=true";
        con.Open();
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Product set Product_Name=@ProductName,Product_qnty=@ProductQnty where Id=@Id";
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@ProductName", ProductName);
            cmd.Parameters.AddWithValue("@ProductQnty", ProductQnty);

            cmd.ExecuteNonQuery();
            Console.WriteLine($"Record Updated of Product having ID {Id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }

    public void update(Purchase obj)
    {
        Product pro = new Product();
        Product product = pro.GetSingleProduct(obj.PurchaseProd);
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=InventoryManagement;Integrated Security=true";
        con.Open();

        try
        {
            SqlCommand cmd = new SqlCommand();
            int quntityPro = Convert.ToInt32(product.ProductQnty) - Convert.ToInt32(obj.PurchaseQnty);
            string qunt = quntityPro.ToString();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Product set Product_qnty=@ProductQnty where Product_Name=@ProductName";
            cmd.Parameters.AddWithValue("@ProductName", obj.PurchaseProd);
            cmd.Parameters.AddWithValue("@ProductQnty",qunt);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Record Updated of Product having name {product.ProductName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }

    public void delete(int Id)
    {

        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=InventoryManagement;Integrated Security=true";
        con.Open();
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete from Product where Id=@Id";
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Record Deleted of ID {Id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }
}
