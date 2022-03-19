using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using PlaneShare;

namespace PlaneService
{
    class PlaneDAO
    {
        MyDbDataContext db = new MyDbDataContext(ConfigurationManager.ConnectionStrings["strCon"].ConnectionString);
    //    String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
        public List<Plane> SelectAll()
        {
            db.ObjectTrackingEnabled = false;

            List<Plane> planes = db.Planes.ToList();
            return planes;
            //List<Plane> planes = new List<Plane>();
            //SqlConnection con = new SqlConnection(strCon);
            //con.Open();
            //String strCom = "SELECT * FROM Plane";
            //SqlCommand com = new SqlCommand(strCom, con);
            //SqlDataReader dr = com.ExecuteReader();
            //while (dr.Read())
            //{
            //    Plane plane = new Plane()
            //    {
            //        Id = (int)dr["Id"],
            //        Brand = (String)dr["Brand"],
            //        Name = (String)dr["Name"],
            //        Price = (int)dr["Price"],
            //        Size = (int)dr["Size"]
            //    };
            //    planes.Add(plane);
            //}
            //con.Close();
            //return planes;
        }
        public List<Plane> SelectByKeyword(String keyword)
        {

            db.ObjectTrackingEnabled = false;
            //List<Plane> planes = new List<Plane>();
            //SqlConnection con = new SqlConnection(strCon);
            //con.Open();
            //String strCom = "SELECT * FROm Plane Where Name LIKE @Keyword";
            //SqlCommand com = new SqlCommand(strCom, con);
            //com.Parameters.Add(new SqlParameter("@Keyword", "%" + keyword + "%"));
            //SqlDataReader dr = com.ExecuteReader();
            //while (dr.Read())
            //{
            //    Plane plane = new Plane()
            //    {
            //        Id = (int)dr["Id"],
            //        Brand = (String)dr["Brand"],
            //        Name = (String)dr["Name"],
            //        Price = (int)dr["Price"],
            //        Size = (int)dr["Size"]
            //    };
            //    planes.Add(plane);
            //}
            //con.Close();
            //return planes;
            List<Plane> planes = db.Planes.Where(b => b.Name.Contains(keyword)).ToList();
            return planes;

        }



        public Plane SelectById(int Id)
        {
            db.ObjectTrackingEnabled = false;
            //Plane plane = null;
            //SqlConnection con = new SqlConnection(strCon);
            //con.Open();
            //String strCom = "SELECT * FROM Plane Where Id = @Id";
            //SqlCommand com = new SqlCommand(strCom, con);
            //com.Parameters.Add(new SqlParameter("@Id", Id));
            //SqlDataReader dr = com.ExecuteReader();
            //if (dr.Read())
            //{
            //    plane = new Plane()
            //    {
            //        Id = (int)dr["Id"],
            //        Brand = (String)dr["Brand"],
            //        Name = (String)dr["Name"],
            //        Price = (int)dr["Price"],
            //        Size = (int)dr["Size"]
            //    };
            //}
            //con.Close();
            //return plane;
            Plane plane = db.Planes.SingleOrDefault(b => b.Id == Id);
            return plane;
        }




        public bool Insert(Plane newPlane)
        {
           
            // bool result = false;
            // SqlConnection con = new SqlConnection(strCon);
            // con.Open();
            // String strCom = "INSERT INTO Plane(Brand,Name,Price,Size) VALUES (@Brand,@Name,@Price,@Size)";
            // SqlCommand com = new SqlCommand(strCom, con);
            // com.Parameters.Add(new SqlParameter("@Brand", newPlane.Brand));
            // com.Parameters.Add(new SqlParameter("@Name", newPlane.Name));
            // com.Parameters.Add(new SqlParameter("@Price", newPlane.Price));
            // com.Parameters.Add(new SqlParameter("@Size", newPlane.Size));
            //// SqlDataReader dr = com.ExecuteReader();
            // try { result = com.ExecuteNonQuery() > 0; }
            // catch { result = false; }
            // con.Close();
            // return result;
            try
            {
                db.Planes.InsertOnSubmit(newPlane);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }

        }

        public bool Delete(int Id)
        {
          
            //bool result = false;
            //SqlConnection con = new SqlConnection(strCon);
            //con.Open();
            //String strCom = "DELETE FROM Plane WHERE Id=@Id";
            //SqlCommand com = new SqlCommand(strCom, con);
            //com.Parameters.Add(new SqlParameter("@Id", Id));
            //try { result = com.ExecuteNonQuery() > 0; }
            //catch { result = false; }
            //con.Close();
            //return result;
            Plane dbPlane = db.Planes.SingleOrDefault(b => b.Id == Id);
            if(dbPlane != null)
            {
                try
                {
                    db.Planes.DeleteOnSubmit(dbPlane);
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }
            }
            return false;
         
        }

        public bool Update(Plane newPlane)
        {
        
            //bool result = false;
            //SqlConnection con = new SqlConnection(strCon);
            //con.Open();
            //String strCom = "UPDATE Plane SET Brand=@Brand, Name =@Name, Price = @Price, Size = @Size WHERE Id=@Id";
            //SqlCommand com = new SqlCommand(strCom, con);
            //com.Parameters.Add(new SqlParameter("@Brand", newPlane.Brand));
            //com.Parameters.Add(new SqlParameter("@Name", newPlane.Name));
            //com.Parameters.Add(new SqlParameter("@Price", newPlane.Price));
            //com.Parameters.Add(new SqlParameter("@Size", newPlane.Size));
            //com.Parameters.Add(new SqlParameter("Id", newPlane.Id));

            //try { result = com.ExecuteNonQuery() > 0; }
            //catch { result = false; }
            //con.Close();
            //return result;
            Plane dbPlane = db.Planes.SingleOrDefault(b => b.Id == newPlane.Id);
            if(dbPlane != null)
            {
                try
                {
                    dbPlane.Brand = newPlane.Brand;
                    dbPlane.Name = newPlane.Name;
                    dbPlane.Price = newPlane.Price;
                    dbPlane.Size = newPlane.Size;
                    db.SubmitChanges();
                    return true;

                }
                catch { return false; }
            }
            return false;

        }

    }
}


    

