using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DALLayer
{
    public class FoodOrderDAL
    {
        public Customer FindCustomerDAL(string username)
        {
            Customer customer = new Customer();
            try 
            {
                FoodSystemEntities ctx = new FoodSystemEntities();
                var result = ctx.Customers.FirstOrDefault(x => x.Username == username);
                if (result == null)
                    throw new Exception("Customer does not exist");
                else
                    customer = result;
            }
            catch(Exception ex)
            {
                throw ex;
            }

            
            return customer;
        }
        public bool ValidateExistingDAL(Customer customer)
        {
            bool validuser = false;
            try
            {
                FoodSystemEntities ctx = new FoodSystemEntities();
                var result=ctx.Customers.FirstOrDefault(x => x.Username == customer.Username);
                if (result != null)
                {
                    if (result.Password == customer.Password)
                        validuser = true;
                    else
                        throw new Exception("Password Does not match");
                }
                else
                    throw new Exception("Customer Does not exist");
                

            }

            catch(Exception ex)
            {
                throw ex;
            }
            return validuser;
        }

        public bool NewCustomerDAL(Customer customer)
        {
            bool custaddedBL = false;

            try
            {
                FoodSystemEntities ctx = new FoodSystemEntities();
                var result = ctx.Customers.FirstOrDefault(x => x.Username == customer.Username);
                if(result != null)
                    custaddedBL = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return custaddedBL;

        }
    }
}
