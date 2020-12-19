
using ShopServer.Model;
using ShopServer.Model.Items;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ShopServer.Controllers.Manipulators
{
    public abstract class AbstractManipulator
    {
        public Response execute()
        {
            using (SqlConnection connection = DatabaseConnection.getInstance().GetConnection())
            {

                using (SqlCommand command = new SqlCommand(getSqlCommand(), connection))
                {
                    addParameters(command);
                    command.ExecuteNonQuery();
                    return getSuccessMessage();
                }
            }
        }

        protected abstract void addParameters(SqlCommand command);
        protected abstract Response getSuccessMessage();


        protected abstract string getSqlCommand();
    }

}
    
