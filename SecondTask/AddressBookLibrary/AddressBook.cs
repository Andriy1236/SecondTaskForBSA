using System;
using System.Collections.Generic;

namespace AddressBookLibrary
{
    public class AddressBook
    {
        public delegate void EventHandler(string type, string log);

        public AddressBook()
        {
            _addressBook = new List<User>();
        }
        public event EventHandler UserAdded;
        public event EventHandler UserRemoved;
        private List<User> _addressBook;
        public bool AddUser(User user)
        {
            try
            {
                var isUserAdded = false;

                if (_addressBook == null)
                {
                    throw new NullReferenceException("Книга не створена! ");
                }
                if (user == null)
                {
                    throw new NullReferenceException("Немає користувача! ");
                }

                UserAdded?.Invoke("debug", "Почався запис користувача в адресну книгу");

                if (IsUserInAdressBook(user, _addressBook)) //провірка на наявність юзера в книзі
                {
                    UserAdded?.Invoke("warning", "користувач з такими данними вже є!");
                }
                if (!IsUserInAdressBook(user, _addressBook)) //добавиться тільки тоді , коли не співпадає 
                {
                    _addressBook.Add(user);
                    UserAdded?.Invoke("info", string.Format("Був доданий користувач " + user.FirstName + " " + user.LastName));
                    UserAdded?.Invoke("debug", "Закінчився запис користувача в адресну книгу");
                    isUserAdded = true;
                }
                return isUserAdded;
            }
            catch (NullReferenceException ex)
            {
                UserAdded?.Invoke("error", string.Format(ex.Message + "StackTrace :" + ex.StackTrace));
                return false;
            }
            catch (Exception ex)
            {
                UserAdded?.Invoke("error", string.Format(ex.Message + "StackTrace :" + ex.StackTrace));
                return false;
            }
        }

        public bool RemoveUser(User user)
        {
            try
            {
                bool isUserRemoved = false;

                if (_addressBook == null)
                {
                    throw new NullReferenceException("Книга не створена!");
                }
                if (user == null)
                {
                    throw new NullReferenceException("Немає користувача!");
                }
                UserRemoved?.Invoke("debug", "Почався процес видалення користувача з  адресної книги");

                if (!IsUserInAdressBook(user, _addressBook)) //видалиться тільки тоді , коли такий користувач є
                {
                    _addressBook.Remove(user);
                    UserRemoved?.Invoke("info", string.Format(" Був видалений користувач " + user.FirstName + " " + user.LastName));
                    UserRemoved?.Invoke("debug", " Закінчився процес видалення користувача з адресної книгу ");
                    isUserRemoved = true;
                }
                return isUserRemoved;
            }
            catch (NullReferenceException ex)
            {
                UserRemoved?.Invoke("error", string.Format(ex.Message + "StackTrace :" + ex.StackTrace));
                return false;
            }
            catch (Exception ex)
            {
                UserRemoved?.Invoke("error", string.Format(ex.Message + "StackTrace :" + ex.StackTrace));
                return false;
            }
        }

        private bool IsUserInAdressBook(User user, IEnumerable<User> listOfUsers)
        {
            bool isUserInList = false;
            foreach (var record in listOfUsers)
            {
                if (user.FirstName == record.FirstName && user.LastName == record.LastName && user.PhoneNumber == record.PhoneNumber)
                {
                    isUserInList = true;
                }
            }
            return isUserInList;
        }
    }
}
