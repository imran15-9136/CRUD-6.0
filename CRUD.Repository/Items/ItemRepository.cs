using CRUD.Repository.Abstraction.Items;
using CRUD.Repository.Base;
using CRUD.Repository.Conection;
using Database.Database;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repository.Items
{
    public class ItemRepository: Repository<Item>, IItemRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        string connectinString = ConnectionString.CName;
        public ItemRepository(ApplicationDbContext dbcontext):base(dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public override List<Item> GetAll()
        {
            List<Item> items = new List<Item>();
            using (SqlConnection con = new SqlConnection(connectinString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetItems", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Item item = new Item();
                    item.Id = Convert.ToInt32(rdr["Id"]);
                    item.Name = rdr["Name"].ToString();
                    item.Price = Convert.ToInt32(rdr["Price"]);
                    item.Vat = Convert.ToInt32(rdr["Vat"]);
                    item.ItemCategoryId = Convert.ToInt32(rdr["ItemCategoryId"]);
                    //item.Created = Convert.ToDateTime(rdr["Created"].ToString());
                    item.ImagePath = rdr["ImagePath"].ToString();
                    items.Add(item);
                }
                con.Close();
            }
            return items;
        }

        public override bool Add(Item model)
        {
            using (SqlConnection con = new SqlConnection(connectinString))
            {
                SqlCommand cmd = new SqlCommand("SP_AddItem", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", model.Id);
                cmd.Parameters.AddWithValue("Name", model.Name);
                cmd.Parameters.AddWithValue("Price", model.Price);
                cmd.Parameters.AddWithValue("Vat", model.Vat);
                cmd.Parameters.AddWithValue("Created", model.Created);
                cmd.Parameters.AddWithValue("ItemCategoryId", model.ItemCategoryId);
                cmd.Parameters.AddWithValue("ImagePath", model.ImagePath);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            return true;
        }
    }
}
