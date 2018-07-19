using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    
        public class ContactData:  IEquatable<ContactData>, IComparable<ContactData>
    {
            

        public ContactData(string firstname)
            {
                Firstname = firstname;
            }
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null)) // если тот объект с которым мы сравниваем это null
            {
                return false; //так как текущий объект есть и он не null
            }
            if (Object.ReferenceEquals(this, other)) // те объекты совпадают
            {
                return true;
            }
            bool fn = Firstname == other.Firstname;
            bool ln = Lastname == other.Lastname;
            return fn && ln;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode();
        }

        public override string ToString()
        {
            return "firstname=" + Firstname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Firstname.CompareTo(other.Firstname);
        }
        public string Firstname { get; set; }
      
        public string Middlename { get; set; }

        public string Lastname { get; set; }
         
        public string Nickname { get; set; }

        public string Id { get; set; }

    }
    }
