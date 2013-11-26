using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using TimeRegistration.Core.BL;
using TimeRegistration.Core.DL;


namespace TimeRegistration.Core.DAL
{
    public class TRRepository {
		DL.TRDatabase db = null;
		protected static string dbLocation;		
		protected static TRRepository me;		
		
		static TRRepository ()
		{
			me = new TRRepository();
		}
		
		protected TRRepository()
		{
			// set the db location
			dbLocation = DatabaseFilePath;
			
			// instantiate the database	
			db = new DL.TRDatabase(dbLocation);
		}
		
		public static string DatabaseFilePath {
			get { 
				var sqliteFilename = "TaskDB.db3";

#if NETFX_CORE
                var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);
#else

#if SILVERLIGHT
				// Windows Phone expects a local path, not absolute
	            var path = sqliteFilename;
#else

#if __ANDROID__
				// Just use whatever directory SpecialFolder.Personal returns
	            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
#else
				// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
				// (they don't want non-user-generated data in Documents)
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine (documentsPath, "../Library/"); // Library folder
#endif
				var path = Path.Combine (libraryPath, sqliteFilename);
#endif		

#endif
				return path;	
			}
		}

		public static Customers GetCustomer(int id)
		{
            return me.db.GetItem<Customers>(id);
		}
		
		public static IEnumerable<Customers> GetCustomers ()
		{
			return me.db.GetItems<Customers>();
		}
		
		public static int SaveCustomer (Customers item)
		{
			return me.db.SaveItem<Customers>(item);
		}

		public static int DeleteCustomer(int id)
		{
			return me.db.DeleteItem<Customers>(id);
		}

        public static Projects GetProject(int id)
        {
            return me.db.GetItem<Projects>(id);
        }

        public static IEnumerable<Projects> GetProjects()
        {
            return me.db.GetItems<Projects>();
        }

        public static int SaveProject(Projects item)
        {
            return me.db.SaveItem<Projects>(item);
        }

        public static int DeleteProject(int id)
        {
            return me.db.DeleteItem<Projects>(id);
        }

        public static TimeRegistrations GetTimeRegistration(int id)
        {
            return me.db.GetItem<TimeRegistrations>(id);
        }

        public static IEnumerable<TimeRegistrations> GetTimeRegistrations()
        {
            return me.db.GetItems<TimeRegistrations>();
        }

        public static int SaveTimeRegistration(TimeRegistrations item)
        {
            return me.db.SaveItem<TimeRegistrations>(item);
        }

        public static int DeleteTimeRegistration(int id)
        {
            return me.db.DeleteItem<TimeRegistrations>(id);
        }
	}
}

