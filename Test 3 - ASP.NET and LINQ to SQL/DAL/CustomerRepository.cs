using System;
using System.Collections.Generic;
using System.Linq;
using Test_3___ASP.NET_and_LINQ_to_SQL.LINQ_TO_SQL;

namespace Test_3___ASP.NET_and_LINQ_to_SQL.DAL
{
    // A view model class to display customer details in the grid view
    public class CustomerViewModel
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactTitle { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    public class CustomerRepository
    {
        private NorthwindDataContext _nothwindContext = null;

        public CustomerRepository()
        {
            if (_nothwindContext == null)
            {
                _nothwindContext = new NorthwindDataContext();
            }            
        }

        // Return distincy country names
        protected IEnumerable<string> GetCountries()
        {
            IEnumerable<string> countries = null;
            try
            {
                using (_nothwindContext)
                {
                    countries = (from c in _nothwindContext.Customers select c.Country).Distinct();
                    return countries;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get all the customers
        protected IEnumerable<CustomerViewModel> GetCustomers()
        {
            IEnumerable<CustomerViewModel> customers = null;
            try
            {
                using (_nothwindContext)
                {
                    customers = from c in _nothwindContext.Customers select new CustomerViewModel {
                        CustomerID = c.CustomerID,
                        CompanyName = c.CompanyName,
                        ContactTitle = c.ContactTitle,
                        ContactName = c.ContactName,
                        City = c.City,
                        Country = c.Country
                    };
                    return customers;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get customers by country
        protected IEnumerable<CustomerViewModel> GetCustomerByCountry(string country)
        {
            IEnumerable<CustomerViewModel> customersByCountry = null;
            try
            {
                using (_nothwindContext)
                {
                    customersByCountry = from c in _nothwindContext.Customers where c.Country.Equals(country) select new CustomerViewModel {
                        CustomerID = c.CustomerID,
                        CompanyName = c.CompanyName,
                        ContactTitle = c.ContactTitle,
                        ContactName = c.ContactName,
                        City = c.City,
                        Country = c.Country
                    };
                    return customersByCountry;                
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Return customer by customer ID
        protected Customer GetCustomerByID(string customerID)
        {
            Customer customer = null;
            try
            {
                customer = (from c in _nothwindContext.Customers where c.CustomerID.Equals(customerID) select c).SingleOrDefault<Customer>();
                return customer;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }    
}