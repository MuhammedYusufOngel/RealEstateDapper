using Dapper;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.StatisticsRepository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly Context _context;

        public StatisticsRepository(Context context)
        {
            _context = context;
        }

        public int ActiveCategoryCount()
        {
            string query = "Select Count(*) from Category where CategoryStatus=1";
            using(var con = _context.CreateConnection())
            {
                var value = con.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public int ActiveEmployeeCount()
        {
            string query = "Select Count(*) from Employee where Status=1";
            using (var con = _context.CreateConnection())
            {
                var value = con.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public int ApartmantCount()
        {
            string query = "Select Count(*) from Product where ProductCategory=2";
            using (var con = _context.CreateConnection())
            {
                var value = con.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public decimal AverageProductPriceByRent()
        {
            string query = "Select Avg(Price) from Product where Type='Satılık'";
            using (var con = _context.CreateConnection())
            {
                var value = con.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public decimal AverageProductPriceBySale()
        {
            string query = "Select Avg(Price) from Product where Type='Kiralık'";
            using (var con = _context.CreateConnection())
            {
                var value = con.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public int AverageRoomCount()
        {
            string query = "Select Avg(RoomCount) from ProductDetails";
            using (var con = _context.CreateConnection())
            {
                var value = con.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public int CategoryCount()
        {
            string query = "Select Count(*) from Category";
            using (var con = _context.CreateConnection())
            {
                var value = con.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public string CategoryNameByMaxProductCount()
        {
            string query = "Select Top(1) Category.CategoryName, Count(*) from Product inner join Category on Category.CategoryId = Product.ProductCategory Group By Category.CategoryName order by Count(*) desc";
            using (var con = _context.CreateConnection())
            {
                var value = con.QueryFirstOrDefault<string>(query);
                return value;
            }
        }

        public string CityNameByMaxProductCount()
        {
            string query = "Select Top(1) City, Count(*) as 'Ilan_Sayisi' from Product Group By City order by Count(*) desc";
            using (var con = _context.CreateConnection())
            {
                var value = con.QueryFirstOrDefault<string>(query);
                return value;
            }
        }

        public int DifferentCityCount()
        {
            string query = "Select Count(Distinct City) from Product";
            using (var con = _context.CreateConnection())
            {
                var value = con.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public string EmployeeNameByMaxProductCount()
        {
            string query = "Select Top(1) Employee.Name, Count(*) from Product inner join Employee on Employee.EmployeeId = Product.EmployeeId Group By Employee.Name order by Count(*) desc";
            using (var con = _context.CreateConnection())
            {
                var value = con.QueryFirstOrDefault<string>(query);
                return value;
            }
        }

        public decimal LastProductPrice()
        {
            string query = "Select top(1) Price from Product order by ProductId desc";
            using (var con = _context.CreateConnection())
            {
                var value = con.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public string NewestBuilding()
        {
            string query = "Select top(1) BuildYear from ProductDetails order by BuildYear desc";
            using (var con = _context.CreateConnection())
            {
                var value = con.QueryFirstOrDefault<string>(query);
                return value;
            }
        }

        public string OldestBuilding()
        {
            string query = "Select top(1) BuildYear from ProductDetails order by BuildYear";
            using (var con = _context.CreateConnection())
            {
                var value = con.QueryFirstOrDefault<string>(query);
                return value;
            }
        }

        public int PassiveCategoryCount()
        {
            string query = "Select Count(*) from Category where CategoryStatus=0";
            using (var con = _context.CreateConnection())
            {
                var value = con.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public int ProductCount()
        {
            string query = "Select Count(*) from Product";
            using (var con = _context.CreateConnection())
            {
                var value = con.QueryFirstOrDefault<int>(query);
                return value;
            }
        }
    }
}
