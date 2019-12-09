using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Resturant
    {
        private string resturantID;
        private string resturantName;
        private string resturantImage;
        private string password;
        private string address;
        private string phoneNumber;
        private string emailAddress;
        private string menuID;
        private string resurantType;


        public string ResturantID
        {
            get { return resturantID; }
            set { resturantID = value; }
        }

        public string ResturantName
        {
            get { return resturantName; }
            set { resturantName = value; }
        }

        public string ResturantImage
        {
            get { return resturantImage; }
            set { resturantImage = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        public string MenuID
        {
            get { return menuID; }
            set { menuID = value; }
        }

        public string ResurantType
        {
            get { return resurantType; }
            set { resurantType = value; }
        }
    }
}
