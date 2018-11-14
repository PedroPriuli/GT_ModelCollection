using System;
using System.Collections.Generic;

namespace gt.business.container
{
    public class ModelCollection
    {
        #region Attribute
        private int _count = 0;
        private IList<string> _objectname = new List<string>();
        private IDictionary<Type, object> models = new Dictionary<Type, object>();
        #endregion

        #region Property
        public int Count { get { return _count; } }
        public IList<string> collectionObjectName { get { return _objectname; } }
        #endregion

        /// <summary>
        /// Storage of used collections
        /// </summary>
        private void listObject()
        {
            foreach (var keyValue in models)
                collectionObjectName.Add(keyValue.ToString().ToLower());
        }


        /// <summary>
        /// Method that adds objects to the collection, one type per collection
        /// </summary>
        /// <typeparam name="T">Object Type: Anonymous, type reference to be added</typeparam>
        /// <param name="t">Objetct Type: Predicate</param>
        public void AddModel<T>(T t)
        {
            models.Add(t.GetType(), t);
            _count++;
            listObject();
        }

        /// <summary>
        /// Method to rescue the collection, inside the container there can be many objects
        /// </summary>
        /// <typeparam name="T">Object Type: Anonymous, type reference to be added</typeparam>
        /// <param name="t">Objetct Type: Predicate</param>
        public T GetModel<T>()
        {
            try
            {
                return (T)models[typeof(T)];
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("Fail GetModel", e);
            }

        }
    }
}
