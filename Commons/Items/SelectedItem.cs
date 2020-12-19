using System;
using System.Collections.Generic;
using System.Text;

namespace Commons.Items
{
    public class SelectedItem
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public DateTime arrival { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public string price { get; set; }
        public string img { get; set; }
        public string img1 { get; set; }
        public string img2 { get; set; }
        public string img3 { get; set; }
        public string img4 { get; set; }
        public string img5 { get; set; }

        public SelectedItem(int id, int user_id, string name, string email, DateTime arrival, string address, string phone, string description, string title, string price, string img, string img1, string img2, string img3, string img4, string img5)
        {
            this.id = id;
            this.user_id = user_id;
            this.name = name;
            this.email = email;
            this.arrival = arrival;
            this.address = address;
            this.phone = phone;
            this.description = description;
            this.title = title;
            this.price = price;
            this.img = img;
            this.img1 = img1;
            this.img2 = img2;
            this.img3 = img3;
            this.img4 = img4;
            this.img5 = img5;
        }

        public SelectedItem()
        {

        }
    }
}
