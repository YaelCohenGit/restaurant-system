using System.Collections.Generic;
using System.Linq;
using Repositories.Models;

namespace Repositories.Repositories
{
    public class TablesRepository : ITablesRepository
    {
        RestaurantObject context;
        public TablesRepository(RestaurantObject context)
        {
            this.context = context;
        }

        public List<RestaurantTables> GetAllAvailableTables()
        {
            return context.RestaurantTables.Where(t => t.TableStatusCode == 500).ToList();
        }

        public List<RestaurantTables> GetAllTables()
        {
            return context.RestaurantTables.ToList();
        }

        public RestaurantTables GetById(int tableCode)
        {
            return context.RestaurantTables.Where(t => t.RestaurantTableCode == tableCode).FirstOrDefault();
        }

        public List<RestaurantTables> GetTablesByNumOfSeats(int numOfSeats)
        {
            return context.RestaurantTables.Where(t => t.NumOfSeats == numOfSeats).ToList();
        }

        public List<RestaurantTables> GetTablesByStatusCode(int statusCode)
        {
            return context.RestaurantTables.Where(t => t.TableStatusCode == statusCode).ToList();
        }

        public List<DictionaryTableOrder> GetAllBusyTables()
        {
            var t1 = context.RestaurantTables.Select(t => t.TableStatusCode != 500).ToList();

            var tables = context.RestaurantTables.Where(t => t.TableStatusCode != 500);
            List<RestaurantTables> restaurantTables = context.RestaurantTables.Where(t => t.TableStatusCode != 500).ToList();
            List<DictionaryTableOrder> dictionaryList = new List<DictionaryTableOrder>();
            foreach (var item in restaurantTables)
            {
                DictionaryTableOrder dictionaryObject = new DictionaryTableOrder();
                dictionaryObject.TableCode = item.RestaurantTableCode;
                Orders order = context.Orders.Where(o => o.RestaurantTableCode == item.RestaurantTableCode).FirstOrDefault();
                if (order != null)
                {
                    dictionaryObject.OrderCode = order.OrderCode;
                    dictionaryList.Add(dictionaryObject);
                }
            }
            return dictionaryList;
        }
        public void UpdateTableStatus(UpdateTableData data)
        {
            var query = context.RestaurantTables.Where(t => t.RestaurantTableCode == data.TableCode).FirstOrDefault();
            if (query != null)
            {
                query.TableStatusCode = data.TableStatusCode;
                context.SaveChanges();
            }
        }
        public int? GetTableStatusByTableCode(int tableCode)
        {
            RestaurantTables table = context.RestaurantTables.Where(t => t.RestaurantTableCode == tableCode).FirstOrDefault();
            return table.TableStatusCode;
        }
    }
}
