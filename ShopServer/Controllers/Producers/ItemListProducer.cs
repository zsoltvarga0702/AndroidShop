
using Commons.Items;
using ShopServer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ShopServer.Controllers.Producers
{
    public class ItemListProducer : AbstractProducer
    {
        
        protected override void addParameters(SqlCommand command)
        {
            
        }

        protected override Object getItemFromReader(SqlDataReader reader)
        {
            return new Item(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetDateTime(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetString(6),
                    reader.GetString(7),
                    reader.GetString(8),
                    reader.GetString(9),
                    reader.GetString(10),
                    reader.GetString(11),
                    reader.GetString(12),
                    reader.GetString(13)
                );
        }

        protected override string getSqlCommand()
        {
            return "SELECT i.id , i.user_id, arrival,address,phone,description,title,price,img,img1,img2,img3,img4,img5 FROM Items i inner join Users u on i.user_id = u.id ORDER BY arrival DESC";
        }
    }
}
