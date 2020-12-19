using Commons.Items;
using ShopServer.Model.Items;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ShopServer.Controllers.Producers
{
    public class SingleItemProducer : AbstractProducer
    {

        private readonly int id;

        public SingleItemProducer(int id)
        {
            this.id = id;
        }

        protected override void addParameters(SqlCommand command)
        {
            command.Parameters.AddWithValue("@p0", id);
        }

        protected override object getItemFromReader(SqlDataReader reader)
        {
            return new SelectedItem(
                reader.GetInt32(0),
                reader.GetInt32(1),
                reader.GetString(2),
                reader.GetString(3),
                reader.GetDateTime(4),
                reader.GetString(5),
                reader.GetString(6),
                reader.GetString(7),
                reader.GetString(8),
                reader.GetString(9),
                reader.GetString(10),
                reader.GetString(11),
                reader.GetString(12),
                reader.GetString(13),
                reader.GetString(14),
                reader.GetString(15)
                );
        }

        protected override string getSqlCommand()
        {
            return "SELECT i.id , i.user_id,u.name, u.email, arrival,address,phone,description,title,price,img,img1,img2,img3,img4,img5 FROM Items i inner join Users u on i.user_id = u.id WHERE i.id=@p0";
        }
    }
}
