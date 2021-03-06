using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Required, Display(Name ="First Name")]
        public string Customer_fname
        {
            get { return customerFname; }
            set { this.customerFname = value; }
        }
        [Required, Display(Name = "Last Name")]
        public string customer_lname
        {
            get { return customerLname; }
            set { this.customerLname = value; }
        }
        [Required, Display(Name = "Date Of Birth")]
        public string Customer_DOB
        {
            get { return customer_DOB; }
            set { this.customer_DOB = value; }
        }
        [Required, Display(Name = "Email")]
        public string Customer_Email
        {
            get { return customer_Email; }
            set { this.customer_Email = value; }
        }
        [Required,DataType(DataType.PhoneNumber), Display(Name = "Phone Number")]
        public string Customer_Phone
        {
            get { return customerPhone; }
            set { this.customerPhone = value; }
        }
        [Required, MinLength(8), Display(Name = "Password")]
        public string Customer_password
        {
            get { return customer_Password; }
            set { this.customer_Password = value; }
        }
        
    }
}
