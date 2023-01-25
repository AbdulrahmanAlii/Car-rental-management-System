using RentalsDAL.Model;
using RentalsDAL.RentalDAOs;

namespace Exotic_Rentals.Business
{
    public class CarRentalBL
    {
        private CarRentalDAO DAL = new CarRentalDAO();

        public bool ValidateLogin(string username, string password)
        {
            return DAL.ValidateLogin(username, password);
        }

        public List<CarDTO> GetAllCars()
        {
            return DAL.GetAllCars();
        }

        public bool AddCar(string RegNum, string Brand, string Model, string Available, double Price)
        {
            return DAL.AddCar(RegNum, Brand, Model, Available, Price);
        }

        public bool DeleteCar(string RegNum)
        {
            return DAL.DeleteCar(RegNum);
        }

        public bool UpdateCar(string RegNum, string Brand, string Model, string Available, double Price)
        {
            return DAL.UpdateCar(RegNum, Brand, Model, Available, Price);
        }

        public List<CustomerDTO> GetAllCustomers()
        {
            return DAL.GetAllCustomers();
        }

        public bool AddCustomer(int id, string CustName, string CustAddress, string CustPhone)
        {
            return DAL.AddCustomer(id, CustName, CustAddress, CustPhone);
        }

        public bool DeleteCustomer(int id)
        {
            return DAL.DeleteCustomer(id);
        }

        public bool UpdateCustomer(int id, string CustName, string CustAddress, string CustPhone)
        {
            return DAL.UpdateCustomer(id, CustName, CustAddress, CustPhone);
        }

        public List<UserDTO> GetAllUsers()
        {
            return DAL.GetAllUsers();
        }

        public bool AddUser(int id, string UName, string Password)
        {
            return DAL.AddUser(id, UName, Password);
        }

        public bool DeleteUser(int id)
        {
            return DAL.DeleteUser(id);
        }

        public bool UpdateUser(int id, string UName, string Password)
        {
            return DAL.UpdateUser(id, UName, Password);
        }

        public List<string> GetCarsInfo()
        {
            return DAL.GetCarsInfo();
        }

        public List<string> GetCustomersInfo()
        {
            return DAL.GetCustomersInfo();
        }

        public string GetCustomersName(int id)
        {
            return DAL.GetCustomersName(id);
        }

        public List<RentalDTO> GetRentalsRecord()
        {
            return DAL.GetRentalsRecord();
        }

        public bool UpdateCarAvailability(string available, string regNum)
        {
            return DAL.UpdateCarAvailability(available, regNum);
        }

        public bool AddCarRental(int id, string regNum, string customer, DateTime date, int fee)
        {
            return DAL.AddCarRental(id, regNum, customer, date, fee);
        }

        public bool DeleteCarRental(int id)
        {
            return DAL.DeleteCarRental(id);
        }

        public List<ReturnDTO> GetReturnsRecord()
        {
            return DAL.GetReturnsRecord();
        }

        public bool CarRentalReturn(int id, string regNum, string customer, DateTime date, int fine)
        {
            return DAL.CarRentalReturn(id, regNum, customer, date, fine);
        }
    }
}