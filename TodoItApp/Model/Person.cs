using System;
using System.Collections.Generic;
using System.Text;

namespace TodoItApp.Model
{
    public class Person
    {
        // Fields

        readonly int personId;
        string firstName = "Majid";
        string lastName = "Babaei";

        // Properties

        public int PersonId 
        {
            get
            {
                return personId;
            }
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(" First Name cant be empty");
                }
                firstName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last Name cannot be empty.");
                }
                lastName = value;
            }
        }

        // Constructor
        public Person(int personId, string firstName, string lastName)
        {
            this.personId = personId;
            this.FirstName = firstName;
            this.LastName = lastName; 
        }
    }
}
