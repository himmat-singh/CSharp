using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace QNA.DataSet
{
    public class QNAData<T> where T : class
    {
        QNADataContext db;

        public QNAData(string connectionString)
        {
            db = new QNADataContext(connectionString);
        }

        public List<T> GetAll()
        {
            return db.Set<T>().ToList<T>();
        }

        public T Get(object id)
        {
            T result = GetRecord<T>(db.Set<T>().ToList<T>(), t => t.GetType().GetProperty(GetKey<T>()).GetValue(t).Equals(id));
            return result;
        }

        private M Get<M>(object id) where M :class
        {
            M result = GetRecord<M>(db.Set<M>().ToList<M>(), m => m.GetType().GetProperty(GetKey<M>()).GetValue(m).Equals(id));
            return result;
        }

        private string GetKey<K>() where K :class
        {
            System.Data.Entity.Core.Objects.ObjectContext objContext = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)db).ObjectContext;
            System.Data.Entity.Core.Objects.ObjectSet<K> set = objContext.CreateObjectSet<K>();
            string keyName = set.EntitySet.ElementType.KeyMembers.Select(k => k.Name).First().ToString();
            return keyName;
        }

        private T GetRecord<T>(List<T> records,Predicate<T> fnc)
        {
            T result = default(T);

            foreach (var record in records)
            {
                if (fnc.Invoke(record)) {
                    result = record;
                    break;
                }
            }
            return result;
        }

        public bool Create(T obj)
        {
            if (obj == null) return false;
            db.Entry<T>(obj).State = System.Data.Entity.EntityState.Added;
            return db.SaveChanges() > 0 ? true : false;
        }

        public bool Update(T obj, object id)
        {
            if (obj == null || id==null) return false;
            T t = Get(id);
            
            Type tType = t.GetType();
            PropertyInfo[] fi = tType.GetProperties();

            foreach (var field in fi)
            {
                PropertyInfo f = obj.GetType().GetProperty(field.Name);
                field.SetValue(t, f.GetValue(obj));
            }
            
            db.Entry<T>(t).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return true;
        }

        public bool Update<M>(T obj,  object id) where M: class
        {
            if (obj == null || id == null) return false;
            T t = Get(id);
            
            Type tType = t.GetType();
            PropertyInfo[] fi = tType.GetProperties();
            ICollection<M> children = null;
            ICollection<M> currentChilds = null;
            foreach (var field in fi)
            {
                PropertyInfo f = obj.GetType().GetProperty(field.Name);
                if (f.PropertyType == typeof(ICollection<M>))
                    continue;
                field.SetValue(t, f.GetValue(obj));
            }

            //Save parent details
            db.Entry<T>(t).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            //Save child details
            foreach (var field in fi)
            {
                PropertyInfo f = obj.GetType().GetProperty(field.Name);
                if (f.PropertyType == typeof(ICollection<M>))
                {
                    children = (ICollection<M>)f.GetValue(t);
                    currentChilds = (ICollection<M>)f.GetValue(obj);
                    foreach (var child in currentChilds)
                    {
                        var childVal = child.GetType().GetProperty(GetKey<M>()).GetValue(child);
                        if ((int)childVal == 0) //Assume that all keys are of type 'Int'
                            db.Entry<M>(child).State = System.Data.Entity.EntityState.Added;
                        else if (children.Where<M>(c => (int)c.GetType().GetProperty(GetKey<M>()).GetValue(c) == (int)childVal).Count() > 0)
                        {
                            var childToUpdate = Get<M>(childVal);
                            foreach (var fld in childToUpdate.GetType().GetProperties())
                            {
                                //if (fld.Name == GetKey<M>()) continue;
                                PropertyInfo fc = childToUpdate.GetType().GetProperty(fld.Name);
                                if (fc.PropertyType == typeof(ICollection<M>))
                                    continue;
                                fld.SetValue(childToUpdate, fld.GetValue(child));
                            }

                            db.Entry<M>(childToUpdate).State = System.Data.Entity.EntityState.Modified;
                        }
                        else {
                            var childToUpdate = Get<M>(childVal);
                            db.Entry<M>(childToUpdate).State = System.Data.Entity.EntityState.Deleted;
                        }
                        db.SaveChanges();
                    }
                }
            }

            return true;
        }

        public bool Delete(object id)
        {
            if (id == null) return false;
            T t = Get(id);

            db.Entry<T>(t).State = System.Data.Entity.EntityState.Deleted;
            return db.SaveChanges() > 0 ? true : false;
        }


    }
}
