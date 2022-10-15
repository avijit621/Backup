using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DALLayer;
namespace BLLayer
{
    public class FoodOrderBL
    {
       
        /*
         * Customer Functionalities Business Logic
         */
        public Customer FindCustomers(string username)
        {
            Customer customer = new Customer();
            try
            {
                FoodOrderDAL foodOrderDAL = new FoodOrderDAL();
                customer= foodOrderDAL.FindCustomerDAL(username);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customer;
        }
        public bool NewCustomerBL(Customer customer)
        {
            bool newcustadded = false;
            try
            {
                FoodOrderDAL foodOrderDAL=new FoodOrderDAL();
                if (foodOrderDAL.NewCustomerDAL(customer))
                    newcustadded = true;
                else
                    throw new Exception("Customer Creation failed");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return newcustadded;
        }
        public bool UpdateDetailsBL(Customer customer)
        {
            bool updated = false;
            try
            {
                FoodOrderDAL foodOrderDAL = new FoodOrderDAL();
                if(foodOrderDAL.UpdateDetailsDAL(customer))
                 updated = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            return updated;
        }
        public bool ValidateExistingBL(Customer customer)
        {
            bool validuser = false;
            try
            {
                FoodOrderDAL foodOrderDAL = new FoodOrderDAL();
                if(foodOrderDAL.ValidateExistingDAL(customer))
                     validuser = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return validuser;
        }
        public IList<OrderDetails> OrderDetailsBL(Customers customer)
        {
            IList<OrderDetails> list = new List<OrderDetails>();
            try
            {
                // Write logic here

                //------------------
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public IList<Payments> PaymentDetailsBL(Customers customer)
        {
            IList<Payments> list = new List<Payments>();
            try
            {
                // Write logic here

                //------------------
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public string TrackOrderBL(Customers customer)
        {
            string status = "";
            try
            {
                // write logic here

                //-----------------
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }
        public bool IsReadyForPayment(Customers customer)
        {
            bool ready = false;
            try
            {
                //write logic here

                //----------------
                ready = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ready;
        }
        public bool MakePaymentBL(Payments payments)
        {
            bool success = false;
            try
            {
                //write logic here

                //----------------
                success = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return success;
        }
        public IList<FoodItem> ShowAllFoodItemsBL()
        {
            IList<FoodItem> list = new List<FoodItem>();
            try
            {
               FoodOrderDAL foodOrderDAL = new FoodOrderDAL();
                list=foodOrderDAL.ShowAllFoodItemsDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public IList<FoodItem> FilteredFoodItemsBL(FoodItem foodItems, string type)
        {
            IList<FoodItem> list = new List<FoodItem>();
            try
            {
                FoodOrderDAL foodOrderDAL = new FoodOrderDAL();
                list = foodOrderDAL.FilteredFoodItemsDAL(foodItems, type);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public IList<FoodItem> AddToOrderBL(OrderDetail orderDetail)
        {
            IList<FoodItem> list = new List<FoodItem>();
            try
            {
                //write logic here

                //-----------------
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public bool IsAddressNullBL(Customer customer)
        {
            bool addressnull = false;
            try
            {
                FoodOrderDAL foodOrderDAL = new FoodOrderDAL();
                if (foodOrderDAL.IsAddressNullDAL(customer))
                addressnull = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return addressnull;
        }
        public bool EditAddressBL(Customer customer, string address)
        {
            bool addressedited = false;
            try
            {
                FoodOrderDAL foodOrderDAL = new FoodOrderDAL();
                if(foodOrderDAL.EditAddressDAL(customer, address))
                 addressedited = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return addressedited;
        }
        public void PlaceOrderBL(Customer customer, OrderDetail orderDetails, IList<FoodItem> foodItemsList)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ModifyOrderBL(OrderDetails orderDetails)
        {
            bool modified = false;
            try
            {
                //write logic here

                //----------------
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return modified;
        }
        public bool CancelOrderBL(OrderDetails orderDetails)
        {
            bool cancel = false;
            try
            {
                //write logic here

                //---------------
                cancel = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cancel;
        }
        public bool ValidateCustomersBL(Customers customer)
        {
            bool valid = true;
            try
            {
                //write code here

                //---------------
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return valid;
        }
        public bool ValidatePaymentDetailsBL(Payments payments)
        {
            bool pay = true;
            try
            {
                //write code here

                //---------------
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pay;
        }
        public bool ValidateFoodItemsBL(FoodItems foodItems)
        {
            bool food = true;
            try
            {
                //write code here

                //---------------
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return food;
        }
        public bool ValidateOrderDetailsBL(OrderDetails orderDetails)
        {
            bool order = true;
            try
            {
                //write code here

                //---------------
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return order;
        }
        public bool ValidateOrdersBL(Orders orders)
        {
            bool order = true;
            try
            {
                //write code here

                //---------------
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return order;
        }
        /*
         * Admin Fucntionalities Business Logic
         */
    }
}
