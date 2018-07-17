using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    
        public class ContactData:  IEquatable<ContactData>, IComparable<ContactData>
    {
            private string firstname;
            private string middlename = "";
            private string lastname = "";
            private string nickname = "";

        public ContactData(string firstname)
            {
                this.firstname = firstname;
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
        public string Firstname
            {
                get
                {
                    return firstname;
                }
                set
                {
                firstname = value;
                }
            }
            public string Middlename
            {
                get
                {
                    return middlename;
                }
                set
                {
                middlename = value;
                }
            }
        

        public string Lastname
            {
                get
                {
                    return lastname;
                }
                set
                {
                lastname = value;
                }
            }
        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }
    }
    }
