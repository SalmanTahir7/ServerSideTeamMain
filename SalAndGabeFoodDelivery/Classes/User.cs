using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class User
    {
        private string loginID;
        private string email;
        private string password;
        private string userType;
        private string name;
        private string image;
        private string address;
        private string billingAddress;
        private string phoneNum;
        private string menuID;
        private string resturantType;
        private int bankNumber;

        public string LoginID
        {
            get { return loginID; }
            set { loginID = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string UserType
        {
            get { return userType; }
            set { userType = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Image
        {
            get { return image; }
            set { image = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string BillingAddress
        {
            get { return billingAddress; }
            set { billingAddress = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNum; }
            set { phoneNum = value; }
        }

        public string MenuID
        {
            get { return menuID; }
            set { menuID = value; }
        }

        public string ResturantType
        {
            get { return resturantType; }
            set { resturantType = value; }
        }

        public int BankAccount
        {
            get { return bankNumber; }
            set { bankNumber = value; }
        }
    }
}
