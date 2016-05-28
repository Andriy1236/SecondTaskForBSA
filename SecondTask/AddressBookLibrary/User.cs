using System;

namespace AddressBookLibrary
{
    public enum Gender
    {
        Male,
        Female
    }
    public class User
    {
        public User(string firstName, string lastName, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime TimeAdded { get; set; }
        public string City { get; set; }
        public string Addres { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
    }
}
