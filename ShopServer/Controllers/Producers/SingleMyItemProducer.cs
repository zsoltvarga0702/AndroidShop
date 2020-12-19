using Commons.Items;
using ShopServer.Model.Items;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ShopServer.Controllers.Producers
{
    public class SingleMyItemProducer : AbstractProducer
    {

        private readonly int id;
        private readonly string filter;

        public SingleMyItemProducer(string filter)
        {
            this.filter = filter;
        }

        protected override void addParameters(SqlCommand command)
        {
            command.Parameters.AddWithValue("@p0", filter);
        }

        protected override object getItemFromReader(SqlDataReader reader)
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
                reader.GetString(13));
                
        }

        protected override string getSqlCommand()
        {
            return "SELECT id,user_id,arrival,address,phone,description,title,price,img,img1,img2,img3,img4,img5  FROM Items WHERE user_id=@p0 ORDER BY arrival DESC";
        }
    }
}
