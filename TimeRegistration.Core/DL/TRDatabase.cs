using System;
using System.Linq;
using System.Collections.Generic;
using TimeRegistration.Core.BL;
using TimeRegistration.Core.DL.SQLite;

namespace TimeRegistration.Core.DL
{
	public class TRDatabase : SQLiteConnection
	{
		static object locker = new object ();

		/// <summary>
		/// Initializes a new instance of the <see cref="Tasky.DL.TRDatabase"/> TRDatabase. 
		/// if the database doesn't exist, it will create the database and all the tables.
		/// </summary>
		/// <param name='path'>
		/// Path.
		/// </param>
		public TRDatabase (string path) : base (path)
		{
			// create the tables
			CreateTable<Customers> ();
			CreateTable<Projects> ();
			CreateTable<TimeRegistrations> ();
		}
		
		public IEnumerable<T> GetItems<T> () where T : BL.Contracts.IBusinessEntity, new ()
		{
            lock (locker) {
                return (from i in Table<T> () select i).ToList ();
            }
		}

		public T GetItem<T> (int id) where T : BL.Contracts.IBusinessEntity, new ()
		{
            lock (locker) {
                return Table<T>().FirstOrDefault(x => x.ID == id);
                // Following throws NotSupportedException - thanks aliegeni
                //return (from i in Table<T> ()
                //        where i.ID == id
                //        select i).FirstOrDefault ();
            }
		}

		public int SaveItem<T> (T item) where T : BL.Contracts.IBusinessEntity
		{
            lock (locker) {
                if (item.ID != 0) {
                    Update (item);
                    return item.ID;
                } else {
                    return Insert (item);
                }
            }
		}
		
		public int DeleteItem<T>(int id) where T : BL.Contracts.IBusinessEntity, new ()
		{
            lock (locker) {
#if NETFX_CORE
                return Delete(new T() { ID = id });
#else
                return Delete<T> (new T () { ID = id });
#endif
            }
		}
	}
}