using System;
using System.Collections.Generic;
using System.Text;
using TodoItApp.Model;

namespace TodoItApp.Data
{
    public class People
    {
        static Person[] personArray = new Person[0];
        
        public int Size()
        {
            return personArray.Length;
        }

        public Person[] FindAll()
        {
            return personArray;
        }

        public Person FindById(int personId)
        {
            foreach (var person in personArray)
            {
                if (person.PersonId == personId)
                    return person;
            }

            return null;

          
        }

        public void CreatePerson(string firstName, string lastName)
        {
            //Function to Create a new array to fit in the new person

            int newLength = personArray.Length + 1;
            Array.Resize<Person>(ref personArray, newLength);

            //Function to Add a person at the end of the newly resized array

            int personId = PersonSequencer.NextPersonId(); 
            personArray[newLength - 1] = new Person(personId, firstName, lastName);
        }
        
        //Method that Clears all persons Object

        public void Clear()
        {
            personArray = new Person[0];
        }



        public void RemovePerson(Person person)
        {
            int index = Array.IndexOf(personArray, person);
            if(index >= 0)
            {
               
                personArray[index] = personArray[^1];
            
                Array.Resize<Person>(ref personArray, personArray.Length - 1); 
            }
        }
    }
}
