using IC.Common;
using IC.DataAccess;
using System;
using System.Collections;
using System.Reflection;

namespace IC.EntityManager
{
    public class EntityPropertyMgr
    {

        private Hashtable properties;
        //private EntityPropertyMgr instance;

        public EntityPropertyMgr()
        {
            properties = new Hashtable();
        }


        public EntityProperty getEntityProperty(string entity)
        {
            Assembly assemblyObj;
            Type typeObj;
            try
            {
                //Load the requested assembly andget the requested type
                assemblyObj = Assembly.Load (CONSTDEFINE.CONST_ETNAME);
                if(assemblyObj == null)
                    assemblyObj = Assembly.LoadFrom("IC.Common."+CONSTDEFINE.CONST_ETNAME);
                typeObj = assemblyObj.GetType(entity,true,true);
            }
            catch(TypeLoadException ex)
            {
                Console.WriteLine(ex.Message + "\r\n Cannot load type: {0} from assembly: {1}");
                return null;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            Object[] arg = null ;
            Object trgObj = Activator.CreateInstance(typeObj, arg);
            return (EntityProperty)trgObj;
        }

    }
}
