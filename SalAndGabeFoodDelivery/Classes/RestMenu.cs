using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class RestMenu
    {
        private string itemID;
        private string menuID;
        private string name;
        private string foodType;
        private string image;
        private string title;
        private string description;


        public string ItemID
        {
            get{ return itemID; }
            set { itemID = value; }
        }

        public string MenuID
        {
            get { return menuID; }
            set { menuID = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string FoodType
        {
            get { return foodType; }
            set { foodType = value; }
        }

        public string Image
        {
            get { return image; }
            set { image = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
