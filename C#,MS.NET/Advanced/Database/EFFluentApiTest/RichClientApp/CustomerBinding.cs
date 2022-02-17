using System.Collections.Generic;
using System.Linq;

namespace RichClientApp
{
    using MvvmSupport;

    public class CustomerBinding : BindableBase
    {
        ShopEntities model = new ShopEntities();

        public IEnumerable<Customer> Customers
        {
            get
            {
                //eager loading for child entities
                return model.Customers.Include("InvoiceEntries").ToList();
            }
        }

        public Customer CurrentCustomer
        {
            get
            {
                return currentCustomer;
            }

            set
            {
                SetProperty(ref currentCustomer, value);
                this.CurrentCustomerInvoice = currentCustomer.InvoiceEntries;
            }
        }

        public IEnumerable<InvoiceEntry> CurrentCustomerInvoice
        {
            get
            {
                return currentCustomerInvoice;
            }

            set
            {
                SetProperty(ref currentCustomerInvoice, value);
            }
        }

        public DelegateCommand Update
        {
            get { return new DelegateCommand(ExecuteUpdate, CanExecuteUpdate); }
        }

        private IEnumerable<InvoiceEntry> currentCustomerInvoice;

        private Customer currentCustomer;

        private bool CanExecuteUpdate()
        {
            return model.ChangeTracker.HasChanges();
        }

        private void ExecuteUpdate()
        {
            model.SaveChanges();
        }
    }
}
