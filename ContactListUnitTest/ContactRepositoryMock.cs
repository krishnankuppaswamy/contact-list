namespace ContactList.Models
{
	using ContactListUnitTest;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	public class ContactRepositoryMock : Mock<IContactRepository>, IContactRepository
	{
		private readonly CountCallers countCallers;
		private readonly CountCalls countCalls;
		private readonly Handlers handlers;
		private readonly Verifications verifications;
		private readonly Verifiers verifiers;

		public ContactRepositoryMock()
		{
			this.countCallers = new CountCallers(this);
			this.countCalls = new CountCalls(this);
			this.handlers = new Handlers(this);
			this.verifications = new Verifications(this);
			this.verifiers = new Verifiers(this);
		}

		public ObservableCollection<Contact> Contacts
		{
			get { ObservableCollection<Contact> result; this.InvokeGetProperty("Contacts", out result); return result; }
		}
		public IList<Contact> GetContacts()
		{
			IList<Contact> result;
			this.InvokeMember("GetContacts", new object[] {  }, out result);
			return result;
		}
		public bool SaveContact(Contact contact)
		{
			bool result;
			this.InvokeMember("SaveContact", new object[] { contact }, out result);
			return result;
		}
		public CountCallers HasBeenCalled()
		{
			return this.countCallers;
		}
		public CountCalls GetCalls()
		{
			return this.countCalls;
		}
		public Handlers AddHandlers()
		{
			return this.handlers;
		}
		public Verifications AddVerifications()
		{
			return this.verifications;
		}
		public Verifiers Verify()
		{
			return this.verifiers;
		}
		public class CountCallers
		{
			private readonly ContactRepositoryMock parent;
			internal CountCallers(ContactRepositoryMock parent)
			{
				this.parent = parent;
			}
			public CountCallerMethods Once()
			{
				return new CountCallerMethods(this.parent, 1);
			}
			public CountCallerMethods Twice()
			{
				return new CountCallerMethods(this.parent, 2);
			}
			public CountCallerMethods Thrice()
			{
				return new CountCallerMethods(this.parent, 3);
			}
			public CountCallerMethods Times(int times)
			{
				return new CountCallerMethods(this.parent, times);
			}
			public CountCallers ContactsGetter()
			{
				this.parent.CalledGet("Contacts");
				return this;
			}
			public CountCallers GetContacts()
			{
				this.parent.Called("GetContacts");
				return this;
			}
			public CountCallers SaveContact(Contact contact)
			{
				this.parent.CalledWith("SaveContact", contact);
				return this;
			}
			public CountCallers SaveContact()
			{
				this.parent.Called("SaveContact");
				return this;
			}
			public class CountCallerMethods
			{
				private readonly ContactRepositoryMock parent;
				private readonly int count;
				internal CountCallerMethods(ContactRepositoryMock parent, int count)
				{
					this.parent = parent;
					this.count = count;
				}
				public CountCallerMethods ContactsGetter()
				{
					this.parent.CalledGet(this.count, "Contacts");
					return this;
				}
				public CountCallerMethods GetContacts()
				{
					this.parent.Called(this.count, "GetContacts");
					return this;
				}
				public CountCallerMethods SaveContact(Contact contact)
				{
					this.parent.CalledWith(this.count, "SaveContact", contact);
					return this;
				}
				public CountCallerMethods SaveContact()
				{
					this.parent.Called(this.count, "SaveContact");
					return this;
				}
			}
		}
		public class CountCalls
		{
			private readonly ContactRepositoryMock parent;
			internal CountCalls(ContactRepositoryMock parent)
			{
				this.parent = parent;
			}
			public CountCallsMethods First()
			{
				return new CountCallsMethods(this.parent, 0);
			}
			public CountCallsMethods Second()
			{
				return new CountCallsMethods(this.parent, 1);
			}
			public CountCallsMethods Third()
			{
				return new CountCallsMethods(this.parent, 2);
			}
			public CountCallsMethods At(int position)
			{
				return new CountCallsMethods(this.parent, position);
			}
			public class CountCallsMethods
			{
				private readonly ContactRepositoryMock parent;
				private readonly int position;
				internal CountCallsMethods(ContactRepositoryMock parent, int position)
				{
					this.parent = parent;
					this.position = position;
				}
				public MemberInvocation ContactsGetter()
				{
					return this.parent.GetCall(this.position, "Contacts");
				}
				public MemberInvocation GetContacts()
				{
					return this.parent.GetCall(this.position, "GetContacts");
				}
				public MemberInvocation SaveContact()
				{
					return this.parent.GetCall(this.position, "SaveContact");
				}
			}
		}
		public class Handlers
		{
			private readonly ContactRepositoryMock parent;
			internal Handlers(ContactRepositoryMock parent)
			{
				this.parent = parent;
			}
			public Handlers Contacts(Func<ObservableCollection<Contact>> action)
			{
				this.parent.HandleGet("Contacts", action);
				return this;
			}
			public Handlers GetContacts(Func<IList<Contact>> action)
			{
				this.parent.Handle<IList<Contact>>("GetContacts", action);
				return this;
			}
			public Handlers SaveContact(Func<Contact, bool> action)
			{
				this.parent.Handle<Contact, bool>("SaveContact", action);
				return this;
			}
		}
		public class Verifications
		{
			private readonly ContactRepositoryMock parent;
			internal Verifications(ContactRepositoryMock parent)
			{
				this.parent = parent;
			}
			public Verifications Contacts()
			{
				this.parent.AddGetVerification("Contacts");
				return this;
			}
			public Verifications GetContacts()
			{
				this.parent.AddVerification("GetContacts", new object[0]);
				return this;
			}
			public Verifications SaveContact(Contact contact)
			{
				this.parent.AddVerification("SaveContact", contact);
				return this;
			}
		}
		public class Verifiers
		{
			private readonly ContactRepositoryMock parent;
			internal Verifiers(ContactRepositoryMock parent)
			{
				this.parent = parent;
			}
			public Verifiers Contacts()
			{
				this.parent.VerifyGet("Contacts");
				return this;
			}
			public Verifiers GetContacts()
			{
				this.parent.Verify("GetContacts", new object[0]);
				return this;
			}
			public Verifiers SaveContact(Contact contact)
			{
				this.parent.Verify("SaveContact", contact);
				return this;
			}
		}
	}
}
