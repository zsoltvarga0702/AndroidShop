using ShopServer.Controllers.Exceptions;
using ShopServer.Model.Items;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ShopServer.Controllers.Manipulators
{
    public class UserLoginer  : AbstractManipulator
    {
        private SerializedUser user { get; }
        private SqlParameter returnValue { get; set; }
        public UserLoginer(SerializedUser user)
        {
            this.user = user;
        }
        protected override void addParameters(SqlCommand command)
        {
            validateParameters();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@email", user.email);
            command.Parameters.AddWithValue("@password", user.password);
            this.returnValue = command.Parameters.Add("@returnValue", System.Data.SqlDbType.Int);
            returnValue.Direction = System.Data.ParameterDirection.ReturnValue;
        }
        private void validateParameters()
        {
            user.validateEmail();
            user.validatePassword();
        }
        protected override string getSqlCommand()
        {
            return "login_user";
        }

        protected override Response getSuccessMessage()
        {
            if ((int)returnValue.Value == -1)
            {
                Console.WriteLine("The email and password not match!");
                throw new InvalidInputException("The email and password not match!");

            }
            return new Response("User successfully logged in!");
        }
    }
}