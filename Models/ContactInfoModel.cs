using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChantemerleApi.Models
{
    public class ContactInfoModel
    {
        public string house_nickname { get; set; }
        public string place { get; set; }
        public string address { get; set; }
        public string postal_code { get; set; }

        public string family_name { get; set; }
        public string telephone { get; set; }
        public string mail { get; set; }

        public ContactInfoModel(string house_nickname, string place, string address, string postal_code, string family_name, string telephone, string mail)
        {
            this.house_nickname = house_nickname;
            this.place = place;
            this.address = address;
            this.postal_code = postal_code;
            this.family_name = family_name;
            this.telephone = telephone;
            this.mail = mail;
        }

        internal void changeContactInfoByModelInDatabase(ContactInfoModel contactInfo)
        {
            throw new NotImplementedException();
        }
    }
}
