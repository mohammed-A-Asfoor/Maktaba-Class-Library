﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
    public class customer : Item
    {
        private string customerFname;
        private string customerLname;
        private string customer_DOB;
        private string customer_Email;
        private string customer_Password;
        private string customerPhone;

        public customer(string id) : base(id)
        {

        }
        public customer()
        {

        }
        public string customerID
        {
            get { return base.getID(); }
            set { base.setID(value); }
        }
        public string CustomerFname
        {
            get { return customerFname; }
            set { this.customerFname = value; }
        }
        public string CustomerLname
        {
            get { return customerLname; }
            set { this.customerLname = value; }
        }
        public string Customer_DOB
        {
            get { return customer_DOB; }
            set { this.customer_DOB = value; }
        }
        public string Customer_Emial
        {
            get { return customer_Email; }
            set { this.customer_Email = value; }
        }
        public string CustomerPhone
        {
            get { return customerPhone; }
            set { this.customerPhone = value; }
        }
        public string Customer_Password
        {
            get { return customer_Password; }
            set { this.customer_Password = value; }
        }
        
    }
}