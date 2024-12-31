using Repositories.Models;
using System.Collections.Generic;

namespace Repositories.Repositories
{
    public interface ITablesRepository
    {
        RestaurantTables GetById(int tableCode);

        List<RestaurantTables> GetAllTables();

        List<RestaurantTables> GetTablesByNumOfSeats(int numOfSeats);

        List<RestaurantTables> GetTablesByStatusCode(int statusCode);
        List<RestaurantTables> GetAllAvailableTables();
        List<DictionaryTableOrder> GetAllBusyTables();
        void UpdateTableStatus(UpdateTableData data);
       int? GetTableStatusByTableCode(int tableCode);
    }
}