using ShopServer.Controllers.Exceptions;
using ShopServer.Model.Items;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ShopServer.Controllers.Manipulators
{
    public class ItemCreator : AbstractManipulator
    {
        private SerializedItem item { get; }
        private SqlParameter returnValue { get; set; }
        public ItemCreator(SerializedItem item)
        {
            this.item = item;
        }
        protected override void addParameters(SqlCommand command)
        {
            //validateParameters();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@user_id", item.user_id);
            command.Parameters.AddWithValue("@address", item.address);
            command.Parameters.AddWithValue("@phone", item.phone);
            command.Parameters.AddWithValue("@description", item.description);
            command.Parameters.AddWithValue("@title", item.title);
            command.Parameters.AddWithValue("@price", item.price);
            command.Parameters.AddWithValue("@img", item.img);
            command.Parameters.AddWithValue("@img1", item.img1);
            command.Parameters.AddWithValue("@img2", item.img2);
            command.Parameters.AddWithValue("@img3", item.img3);
            command.Parameters.AddWithValue("@img4", item.img4);
            command.Parameters.AddWithValue("@img5", item.img5);
            this.returnValue = command.Parameters.Add("@returnValue", System.Data.SqlDbType.Int);
            returnValue.Direction = System.Data.ParameterDirection.ReturnValue;
        }
        /*
        private void validateParameters()
        {
            user.validate();
        }*/
        protected override string getSqlCommand()
        {
            return "insert_item";
        }

        protected override Response getSuccessMessage()
        {
            if ((int)returnValue.Value == -1)
            {
                Console.WriteLine("User ID not exists!");
                throw new InvalidInputException("User ID not exists");

            }
            return new Response("Item succesfully created!");
        }
    }
}