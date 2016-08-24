using Plugin.Contacts.Abstractions;
#if __UNIFIED__
using AddressBook;
using UIKit;
#else
using MonoTouch.AddressBook;
using MonoTouch.UIKit;
#endif
using System;
using System.Threading.Tasks;
using System.Linq;

namespace Plugin.Contacts
{
  /// <summary>
  /// Implementation for Contacts
  /// </summary>
  public class ContactsImplementation : IContacts
  {
    private AddressBook addressBook;
    private AddressBook AddressBook
    {
      get { return addressBook ?? (addressBook = new AddressBook()); }
    }

    public Task<bool> RequestPermission()
    {
            
      return AddressBook.RequestPermission();
    }

    public Task<bool> IsPermissionSet ()
    {
            var tcs = new TaskCompletionSource<bool> ();
            tcs.SetResult (AddressBook.IsPermissionSet ());
            return tcs.Task;
    }

    public IQueryable<Contact> Contacts
    {
      get { return (IQueryable<Contact>)AddressBook; }
    }

    public Contact LoadContact(string id)
    {
      return AddressBook.Load(id);
    }

    public bool LoadSupported
    {
      get { return true; }
    }

    public bool PreferContactAggregation
    {
      get;
      set;
    }

    public bool AggregateContactsSupported
    {
      get { return true; }
    }

    public bool SingleContactsSupported
    {
      get { return true; }
    }

    public bool IsReadOnly
    {
      get { return true; }
    }

  }
}