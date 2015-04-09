using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreChain.Domain.Abstract;
using BookstoreChain.Domain.Entities;

namespace BookstoreChain.Domain.Concrete
{
    public class EFStoreRepository : IStoreRepository
    {
        // Creating a new instance of the store table in the database
        private EFDbContext context = new EFDbContext();

        // Retrieving all stores from the new instance
        public IQueryable<Store> Stores
        {
            // Setting the get attribute to return all stores
            get
            {
                return context.Stores;
            }
        }

        // Saving a store to the database
        public void SaveStore(Store store)
        {
            // If statement to save store to the database
            if (store.StoreID == 0)
            {
                context.Stores.Add(store);
            }

            else
            {
                // Finding an existing store by ID
                Store storeEntry = context.Stores.Find(store.StoreID);

                // If the storeEntry is null, link the storeEntry information to the store information
                if (storeEntry != null)
                {
                    storeEntry.Name = store.Name;
                    storeEntry.Address = store.Address;
                    storeEntry.City = store.City;
                    storeEntry.State = store.State;
                    storeEntry.PhoneNumber = store.PhoneNumber;
                }
            }

            // Saving the changes to the database
            context.SaveChanges();
        }

        // Deleting a store from the database
        public Store DeleteStore(int storeID)
        {
            // Finding the requested store by storeID
            Store storeEntry = context.Stores.Find(storeID);

            // Deleting the store if found and saving the changes to the database
            if (storeEntry != null)
            {
                context.Stores.Remove(storeEntry);
                context.SaveChanges();
            }

            // return the storeEntry
            return storeEntry;
        }
    }
}
