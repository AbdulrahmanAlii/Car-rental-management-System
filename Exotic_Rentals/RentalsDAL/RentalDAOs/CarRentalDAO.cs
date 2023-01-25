using RentalsDAL.Model;
using System.Data;

namespace RentalsDAL.RentalDAOs
{
    public class CarRentalDAO
    {
        private RentalsDbContext GetDbContext()
        {
            var rentalsDbContextFactory = new RentalsDbContextFactory();
            return rentalsDbContextFactory.CreateDbContext();
        }

        public bool ValidateLogin(string username, string password)
        {
            bool result = false;

            try
            {
                var db = GetDbContext();

                var user = db.Users.FirstOrDefault(x => x.Username == username && x.Password == password);

                result = user != null;
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public List<CarDTO> GetAllCars()
        {
            var list = new List<CarDTO>();
            try
            {
                var db = GetDbContext();
                list = db.Cars.ToList();
            }
            catch (Exception)
            {
            }

            return list;
        }

        public bool AddCar(string RegNum, string Brand, string Model, string Available, double Price)
        {
            bool result = false;
            try
            {
                var db = GetDbContext();

                CarDTO car = new CarDTO
                {
                    RegNum = RegNum,
                    Brand = Brand,
                    Available = Available,
                    Model = Model,
                    Price = Price
                };

                db.Cars.Add(car);
                db.SaveChanges();

                result = true;
            }
            catch (Exception)
            {
                return false;
            }

            return result;
        }

        public bool DeleteCar(string RegNum)
        {
            bool result = false;
            try
            {
                var db = GetDbContext();

                var car = db.Cars.FirstOrDefault(x => x.RegNum == RegNum);

                if (car != null)
                {
                    db.Cars.Remove(car);
                    db.SaveChanges();

                    result = true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return result;
        }

        public bool UpdateCar(string RegNum, string Brand, string Model, string Available, double Price)
        {
            bool result = false;
            try
            {
                var db = GetDbContext();

                var car = db.Cars.FirstOrDefault(x => x.RegNum == RegNum);

                if (car != null)
                {
                    car.Price = Price;
                    car.Model = Model;
                    car.Available = Available;
                    car.Brand = Brand;

                    db.SaveChanges();

                    result = true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return result;
        }

        /// ////////////////////////////////////////////

        public List<CustomerDTO> GetAllCustomers()
        {
            var list = new List<CustomerDTO>();
            try
            {
                var db = GetDbContext();

                list = db.Customers.ToList();
            }
            catch (Exception)
            {
            }

            return list;
        }

        public bool AddCustomer(int id, string CustName, string CustAddress, string CustPhone)
        {
            bool result = false;
            try
            {
                var db = GetDbContext();

                CustomerDTO customer = new CustomerDTO
                {
                    CustAddress = CustAddress,
                    CustName = CustName,
                    CustPhone = CustPhone
                };

                db.Customers.Add(customer);
                db.SaveChanges();

                result = true;
            }
            catch (Exception)
            {
                return false;
            }

            return result;
        }

        public bool DeleteCustomer(int id)
        {
            bool result = false;
            try
            {
                var db = GetDbContext();

                var customer = db.Customers.FirstOrDefault(x => x.CustId == id);

                if (customer != null)
                {
                    db.Customers.Remove(customer);
                    db.SaveChanges();

                    result = true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return result;
        }

        public bool UpdateCustomer(int id, string CustName, string CustAddress, string CustPhone)
        {
            bool result = false;
            try
            {
                var db = GetDbContext();

                var customer = db.Customers.FirstOrDefault(x => x.CustId == id);

                if (customer != null)
                {
                    customer.CustAddress = CustAddress;
                    customer.CustName = CustName;
                    customer.CustPhone = CustPhone;

                    db.SaveChanges();

                    result = true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return result;
        }

        //////////////////////////////////////////////////

        public List<UserDTO> GetAllUsers()
        {
            var list = new List<UserDTO>();
            try
            {
                var db = GetDbContext();

                list = db.Users.ToList();
            }
            catch (Exception)
            {
            }

            return list;
        }

        public bool AddUser(int id, string UName, string Password)
        {
            bool result = false;
            try
            {
                var db = GetDbContext();

                var user = new UserDTO
                {
                    Username = UName,
                    Password = Password
                };

                db.Users.Add(user);
                db.SaveChanges();

                result = true;
            }
            catch (Exception)
            {
                return false;
            }

            return result;
        }

        public bool DeleteUser(int id)
        {
            bool result = false;
            try
            {
                var db = GetDbContext();

                var user = db.Users.FirstOrDefault(x => x.Id == id);

                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();

                    result = true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return result;
        }

        public bool UpdateUser(int id, string UName, string Password)
        {
            bool result = false;
            try
            {
                var db = GetDbContext();

                var user = db.Users.FirstOrDefault(x => x.Id == id);

                if (user != null)
                {
                    user.Username = UName;
                    user.Password = Password;

                    db.SaveChanges();

                    result = true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return result;
        }

        ///////////////////////////////////////////////////////

        public List<string> GetCarsInfo()
        {
            List<string> result = new List<string>();
            try
            {
                var db = GetDbContext();

                result = db.Cars?.Where(x => x.Available == "YES")?.Select(x => x.RegNum)?.ToList();
            }
            catch (Exception ex)
            {
            }

            return result;
        }

        public List<string> GetCustomersInfo()
        {
            List<string> result = new List<string>();
            try
            {
                var db = GetDbContext();
                result = db.Customers.Select(x => x.CustId.ToString())?.ToList();
            }
            catch (Exception)
            {
            }

            return result;
        }

        public string GetCustomersName(int id)
        {
            string name = "";
            try
            {
                var db = GetDbContext();
                name = db.Customers.FirstOrDefault(x => x.CustId == id)?.CustName;
            }
            catch (Exception ex)
            {
            }

            return name;
        }

        public List<RentalDTO> GetRentalsRecord()
        {
            var list = new List<RentalDTO>();

            try
            {
                var db = GetDbContext();

                list = db.Rentals?.ToList();
            }
            catch (Exception)
            {
            }

            return list;
        }

        public bool UpdateCarAvailability(string available, string regNum)
        {
            bool result = false;
            try
            {
                var db = GetDbContext();

                var car = db.Cars.FirstOrDefault(x => x.RegNum == regNum);

                if (car != null)
                {
                    car.Available = available;
                    db.SaveChanges();

                    result = true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return result;
        }

        public bool AddCarRental(int id, string regNum, string customer, DateTime date, int fee)
        {
            bool result = false;
            try
            {
                var db = GetDbContext();

                var rental = new RentalDTO
                {
                    //RentID = id,
                    carReg = regNum,
                    CustName = customer,
                    RentDate = date,
                    RentFee = fee
                };

                db.Rentals.Add(rental);
                db.SaveChanges();

                result = true;
            }
            catch (Exception)
            {
                return false;
            }

            return result;
        }

        public bool DeleteCarRental(int id)
        {
            bool result = false;
            try
            {
                var db = GetDbContext();

                var rental = db.Rentals.FirstOrDefault(x => x.RentID == id);

                if (rental != null)
                {
                    db.Rentals.Remove(rental);
                    db.SaveChanges();

                    result = true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return result;
        }

        public List<ReturnDTO> GetReturnsRecord()
        {
            var list = new List<ReturnDTO>();
            try
            {
                var db = GetDbContext();

                list = db.Returns?.ToList();
            }
            catch (Exception)
            {
            }

            return list;
        }

        public bool CarRentalReturn(int id, string regNum, string customer, DateTime date, int fine)
        {
            bool result = false;
            try
            {
                var db = GetDbContext();

                var returnObj = new ReturnDTO
                {
                   // ReturnID = id,
                    CarReg = regNum,
                    CustName = customer,
                    Fine = fine,
                    ReturnDate = date
                };

                db.Returns.Add(returnObj);
                db.SaveChanges();

                result = true;
            }
            catch (Exception)
            {
                return false;
            }

            return result;
        }
    }
}