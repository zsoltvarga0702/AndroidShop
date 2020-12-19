
using ShopServer.Controllers.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShopServer.Model.Items
{
    public class SerializedUser
    {
        public string name { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public SerializedUser()
        {
        }

        public void validate()
        {
            validateName();
            validateEmail();
            validatePassword();
        }


        public void validateName()
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidInputException("The value of " + nameof(name) + " can not be empty!");
            }
        }

        public void validateEmail()
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new InvalidInputException("The value of " + nameof(email) + " can not be empty!");
            }
        }

        public void validatePassword()
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new InvalidInputException("The value of " + nameof(password) + " can not be empty!");
            }
        }
    }
}
