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
        }

        // Return distincy country names
        public IList<string> GetCountries()
        {
            IList<string> countries = null;
            try
            {
                _nothwindContext = new NorthwindDataContext();
                
                countries = (from c in _nothwindContext.Customers select c.Country).Distinct().ToList();
                countries.Insert(0, "--- select a country ---");
                return countries;
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get all the customers
        public IEnumerable<CustomerViewModel> GetCustomers()
        {
            IEnumerable<CustomerViewModel> customers = null;
            try
            {
                _nothwindContext = new NorthwindDataContext();
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
            catch (Exception)
            {
                throw;
            }
        }

        // Get customers by country
        public IEnumerable<CustomerViewModel> GetCustomerByCountry(string country)
        {
            IEnumerable<CustomerViewModel> customersByCountry = null;
            try
            {
                _nothwindContext = new NorthwindDataContext();
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
            catch (Exception)
            {
                throw;
            }
        }

        // Return customer by customer ID
        public Customer GetCustomerByID(string customerID)
        {
            Customer customer = null;
            try
            {
                _nothwindContext = new NorthwindDataContext();
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