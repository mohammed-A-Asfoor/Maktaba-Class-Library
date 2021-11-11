using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
    public class Item 
    {
        private string id;
        private bool vaild;
        private string errorMessage;

        public Item(string id)
        {
            this.id = id;
            vaild = true;
        }
        public Item()
        {
            vaild = true;
        }
        public string getID()
        {
            return this.id;
        }
        public void setID(string id)
        {
            this.id = id;
        }
        public bool getVaild()
        {
            return this.vaild;
        }
        public void setVaild(bool vaild)
        {
            this.vaild = vaild;
        }
        public string getErroMessage()
        {
            return this.errorMessage;
        }
        public void setErrorMessage(string erroMsg)
        {
            this.errorMessage = erroMsg;
        }
    }
}
