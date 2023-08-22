using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace InventoryManagemantSystem.Models;

public partial class Purchase
{
    public int Id { get; set; }

    public string PurchaseProd { get; set; } = null!;

    public string PurchaseQnty { get; set; } = null!;

    public DateTime PurchaseDate { get; set; }

    public List<Purchase> GetPurchase()
    {
        List<Purchase> proLst = new List<Purchase>();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=InventoryManagement;Integrated Security=true";
        con.Open();

        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Purchase";
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Purchase pro = new Purchase();
                pro.Id = dr.GetInt32("Id");
                pro.PurchaseProd = dr.GetString("Purchase_prod");
                pro.PurchaseQnty = dr.GetString("Purchase_qnty");
                pro.PurchaseDate = dr.GetDateTime("Purchase_date");

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

    public Purchase GetSinglePurchase(int id)
    {
        Purchase pro = new Purchase();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=InventoryManagement;Integrated Security=true";
        con.Open();

        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Purchase where Id=@Id";
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            pro.Id = dr.GetInt32("Id");
            pro.PurchaseProd = dr.GetString("Purchase_prod");
            pro.PurchaseQnty = dr.GetString("Purchase_qnty");
            pro.PurchaseDate = dr.GetDateTime("Purchase_date");

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

    public void insert(Purchase pro)
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
            cmd.CommandText = "insert into Purchase values(@PurchaseName,@PurchaseQnty,@Purchase_date)";
            cmd.Parameters.AddWithValue("@PurchaseName", pro.PurchaseProd);
            cmd.Parameters.AddWithValue("@PurchaseQnty", pro.PurchaseQnty);
            cmd.Parameters.AddWithValue("@Purchase_date", pro.PurchaseDate);

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

    public void update(int Id, string PurchaseProd, string PurchaseQnty, DateTime PurchaseDate)
    {

        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=InventoryManagement;Integrated Security=true";
        con.Open();
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Purchase set Purchase_prod=@PurchaseProd,Purchase_qnty=@PurchaseQnty,Purchase_date=@Purchasedate where Id=@Id";
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Purchase_prod", PurchaseProd);
            cmd.Parameters.AddWithValue("@PurchaseQnty", PurchaseQnty);
            cmd.Parameters.AddWithValue("@Purchase_date", PurchaseDate);

            cmd.ExecuteNonQuery();
            Console.WriteLine($"Record Updated of Purchase having ID {Id}");
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
            cmd.CommandText = "Delete from Purchase where Id=@Id";
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
