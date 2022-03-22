using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace AddressBookApplication.Models
{
    public class ContactImplementation
    {
        public List<ContactModel> GetContact()
        {
            List<ContactModel> contacts = new List<ContactModel>();
            string mainconn = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(mainconn);
            string sqlquery = "select * from contact";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();
            foreach (DataRow dr in dt.Rows)
            {
                contacts.Add(new ContactModel
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    PhoneNumber = Convert.ToString(dr["PhoneNumber"]),
                    FullName = Convert.ToString(dr["FullName"]),
                    EmailAddress = Convert.ToString(dr["EmailAddress"]),
                    PhysicalAddress = Convert.ToString(dr["PhysicalAddress"])

                });
            }
            return contacts;
        }
        public bool InsertContact(ContactModel contactInsert) 
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(mainconn);
            string sqlquery = "insert into contact (PhoneNumber,FullName,EmailAddress,PhysicalAddress) values ('"+ contactInsert.PhoneNumber + "','" + contactInsert.FullName + "','" + contactInsert.EmailAddress + "','" + contactInsert.PhysicalAddress + "')";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            int count = mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            if (count>1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool EditContact(ContactModel editcontact) 
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(mainconn);
            string sqlquery = " update contact set  PhoneNumber = '" + editcontact.PhoneNumber +"',FullName ='"+editcontact.FullName+ "',EmailAddress ='"+editcontact.EmailAddress+"',PhysicalAddress ='"+editcontact.PhysicalAddress+"' where Id='" + editcontact.Id + "'";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            
            mySqlConnection.Open();
            int count = mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            if (count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool DeleteContact(int id) 
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(mainconn);
            string sqlquery = "delete from contact where Id='" + id + "'";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            int count = mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            if (count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}