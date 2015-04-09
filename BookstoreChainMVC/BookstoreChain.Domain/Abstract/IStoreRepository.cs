using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreChain.Domain.Concrete;
using BookstoreChain.Domain.Entities;

namespace BookstoreChain.Domain.Abstract
{
    // Interface showing method definitions for the Store Class
    public interface IStoreRepository
    {
        // Retrieving all the stores from the database
        IQueryable<Store> Stores { get; }

        // Saving a store to the database
        void SaveStore(Store store);

        // Deleting a store from the database
        Store DeleteStore(int storeID);
    }
}
