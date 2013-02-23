﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoServer.DataAccessLayer;

namespace PhotoServer_Tests.Support
{
    class FakeRepository<T>: IRepository<T, Guid> where T : PhotoServer.Domain.IEntity<Guid>
    {
        private List<T> data;

        private List<T> addedData; 
        public FakeRepository()
        {
            data = new List<T>();
            addedData = new List<T>();
        }
        public void Add(T item)
        {
            data.Add(item);
            addedData.Add(item);
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindAll()
        {
            return  data;
        }

        public T FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            foreach (var item in addedData)
            {
                if (item.Id == default(Guid))
                {
                    item.Id = Guid.NewGuid();
                }
            }
            addedData.Clear();
        }
    }
}
