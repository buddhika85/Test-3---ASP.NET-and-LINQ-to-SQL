using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test_3___ASP.NET_and_LINQ_to_SQL.DAL;
using Test_3___ASP.NET_and_LINQ_to_SQL.LINQ_TO_SQL;

namespace Test_3___ASP.NET_and_LINQ_to_SQL
{
    public partial class Default : System.Web.UI.Page
    {
        CustomerRepository _customerRepository = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            _customerRepository = _customerRepository == null ? new CustomerRepository() : _customerRepository;

            AttachGridViewEvents();
            AttachDetailsViewEvents();

            // manage data display based on the postback
            if (!IsPostBack)
            {
                BindDataToSelectList();
                BindDataToGridView();
            }
            else
            {
                CustomerDetailView.DataSource = null;           // remove bound data in the details view   
                CustomerDetailView.DataBind();
                CustomerByCountryGrid.SelectedIndex = -1;       // select nothing
                if (CountriesDDL.SelectedValue != "--- select a country ---")
                {
                    BindDataToGridViewByCountry();
                }
                else
                {
                    BindDataToGridView();
                }
            }
        }

        // Attach details view events
        private void AttachDetailsViewEvents()
        {
            // on Edit, New or Delete buttons clicked
            CustomerDetailView.ItemCommand += CustomerDetailView_ItemCommand;

            // fired at the time of the insert, edit modes changes
            CustomerDetailView.ModeChanging += CustomerDetailView_ModeChanging; 
            
            // fired when deleting items    
            CustomerDetailView.ItemDeleting += CustomerDetailView_ItemDeleting;

            // fired when inserting
            CustomerDetailView.ItemInserted += CustomerDetailView_ItemInserted;

            // fired when updating
            CustomerDetailView.ItemUpdating += CustomerDetailView_ItemUpdating;
            CustomerDetailView.ItemUpdated += CustomerDetailView_ItemUpdated;
            //CustomerDetailView.

        }

        // fired when a new customer is added
        private void CustomerDetailView_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            try
            {
                // refersh the grid
                BindDataToGridView();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CustomerDetailView_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        // Attach grid view events   
        private void AttachGridViewEvents()
        {
            // fired when pagination happens
            CustomerByCountryGrid.PageIndexChanging += CustomerByCountryGrid_PageIndexChanging;

            // fired when a record/row is selected in the grid
            CustomerByCountryGrid.SelectedIndexChanged += CustomerByCountryGrid_SelectedIndexChanged;
        }

        // fired when updating an existing customer from the details view 
        private void CustomerDetailView_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
        

        private void CustomerDetailView_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName == "New")
            {
                // add mode
                CustomerDetailView.ChangeMode(DetailsViewMode.Insert);
                CustomerDetailView.HeaderText = "Add new customer";
            }
            else if (e.CommandName == "Edit")
            {
                // set to edit mode
                CustomerDetailView.ChangeMode(DetailsViewMode.Edit);

                // get selected customer Id         
                string customerID = CustomerDetailView.HeaderText.Replace("Read only mode - Customer ID : ", "");
                // rebind data     
                Customer customer = _customerRepository.GetCustomerByID(customerID);
                CustomerDetailView.HeaderText = "Edit mode - Customer ID : " + customer.CustomerID;
                CustomerDetailView.DataSource = new List<Customer> { customer };
                CustomerDetailView.DataBind();
            }
            else if (e.CommandName == "Cancel")
            {
                // unbind any data on cancel button press                
                CustomerDetailView.DataSource = null;
                CustomerDetailView.DataBind();
            }
            else if (e.CommandName == "Insert")
            {
                // insert data
            }
        }

        // On delete customer
        private void CustomerDetailView_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
        {
            try
            {              
            }
            catch (Exception)
            {
                throw;
            }
        }

        // On details view mode change
        private void CustomerDetailView_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            CustomerDetailView.AllowPaging = false;            
        }

        



        // on gird view selection
        private void CustomerByCountryGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedCustomerID = CustomerByCountryGrid.SelectedDataKey.Value.ToString();
                Customer customer = _customerRepository.GetCustomerByID(selectedCustomerID);
                CustomerDetailView.ChangeMode(DetailsViewMode.ReadOnly);
                CustomerDetailView.HeaderText = "Read only mode - Customer ID : " + customer.CustomerID;                                    // Edit and delete purposes            
                CustomerDetailView.DataSource = new List<Customer> { customer };
                CustomerDetailView.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // bind data to the grid view by country selection
        private void BindDataToGridViewByCountry()
        {
            try
            {
                CustomerByCountryGrid.DataSource = _customerRepository.GetCustomerByCountry(CountriesDDL.SelectedValue);
                CustomerByCountryGrid.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }
               

        // fired when user paginates
        private void CustomerByCountryGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                CustomerByCountryGrid.PageIndex = e.NewPageIndex;
                CustomerByCountryGrid.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // initial data binding to the grid
        private void BindDataToGridView()
        {
            try
            {
                CustomerByCountryGrid.DataSource = _customerRepository.GetCustomers();
                CustomerByCountryGrid.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // data binding to the select list
        private void BindDataToSelectList()
        {
            try
            {
                CountriesDDL.DataSource = _customerRepository.GetCountries();
                CountriesDDL.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}