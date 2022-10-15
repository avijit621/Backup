using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DALLayer
{
    public class FoodOrderDAL
    {
        
        #region Using ADO.Net
        //public bool ValidateExistingDAL(Customers customer)
        //{

        //}



        #endregion


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
                var result = ctx.Customers.FirstOrDefault(x => x.Username == customer.Username);
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

            catch (Exception ex)
            {
                throw ex;
            }
            return validuser;
        }



        public bool NewCustomerDAL(Customer customer)
        {
            try {
                FoodSystemEntities ctx = new FoodSystemEntities();
                ctx.Customers.Add(customer);
                ctx.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

            return true;

        }


        public IList<FoodItem> ShowAllFoodItemsDAL()
        {
            IList<FoodItem> foodItems = new List<FoodItem>();   
            try
            {
                FoodSystemEntities context = new FoodSystemEntities();
                foodItems= context.FoodItems.ToList();
                if (foodItems==null)
                   
                    throw new Exception("No items in food list");

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return foodItems;
        }


        public IList<FoodItem> FilteredFoodItemsDAL(FoodItem foodItems, string type)
        {
           IList<FoodItem> foodItemList = new List<FoodItem>();
            try
            {
                FoodSystemEntities context = new FoodSystemEntities();
               foodItemList = context.FoodItems.Where(x => x.Type == type).ToList();
                if (foodItemList == null)
                    throw new Exception();

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return foodItemList;
        }

        public bool UpdateDetailsDAL(Customer customer)
        {
            bool custUpdated = false;
            try
            {
                FoodSystemEntities context = new FoodSystemEntities();
                var result = context.Customers.Find(customer.CustID);
                if (result!=null)
                {

                    result.Name = customer.Name;
                    result.Email=customer.Email;
                    result.Mobile = customer.Mobile;
                    result.city = customer.city;
                    result.Pincode = customer.Pincode;
                    result.Address=customer.Address;
                    result.Gender = customer.Gender;
                    context.SaveChanges();
                    custUpdated = true;


                }
                else
                    throw new Exception($"Cutomer with id {customer.CustID} not present");

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return custUpdated;
        }

        public IList<FoodItem> AddToOrderDAL(OrderDetail orderDetail)
        {
            IList<FoodItem> list = new List<FoodItem>();
            try
            {
                FoodSystemEntities ctx = new FoodSystemEntities();
                var result= ctx.OrderDetails.Where(x=>x.OrderID==orderDetail.OrderID);
                foreach(var item in result)
                {
                   var result1= ctx.FoodItems.Find(item.FoodID);
                    list.Add(result1);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public bool IsAddressNullDAL(Customer customer)
        {
            bool addressnull = false;
            try
            {
                if(customer.Address==null)
                addressnull = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return addressnull;
        }

        public bool EditAddressDAL(Customer customer, string address)
        {
            bool addressedited = false;
            try
            {
                FoodSystemEntities ctx = new FoodSystemEntities();
                var result = ctx.Customers.Find(customer.CustID);
                if (result != null)
                {
                    result.Address = customer.Address;
                    ctx.SaveChanges();
                    addressedited = true;

                }
                else
                    throw new Exception("No such customer exist");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return addressedited;
        }


    }
}
