﻿using System;
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
            CustomerDetailView.ModeChanging += CustomerDetailView_ModeChanging;
        }

        // On add, modify or delete
        private void CustomerDetailView_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            //if (e.NewMode = "")
            //{ }
        }

        // Attach grid view events   
        private void AttachGridViewEvents()
        {                    
            CustomerByCountryGrid.PageIndexChanging += CustomerByCountryGrid_PageIndexChanging;
            CustomerByCountryGrid.SelectedIndexChanged += CustomerByCountryGrid_SelectedIndexChanged;
        }



        // on gird view selection
        private void CustomerByCountryGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedCustomerID = CustomerByCountryGrid.SelectedDataKey.Value.ToString();
                Customer customer = _customerRepository.GetCustomerByID(selectedCustomerID);
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

        // manage sorting
        //private void CustomerByCountryGrid_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    try
        //    {
        //        DataTable boundData = DirectCast(CustomerByCountryGrid.DataSource, DataTable);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        // manage paging
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