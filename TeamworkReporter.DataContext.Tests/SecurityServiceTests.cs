using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TeamworkReporter.Models;
using TeamworkReporter.Services.Configuration;
using TeamworkReporter.Types.Extensions;

namespace TeamworkReporter.DataContext.Tests
{
    [TestClass]
    public class SecurityServiceTests
    {
        [TestMethod]
        public void Login_should_return_True_forValid_user()
        {
            var accounts = new InMemoryDbSet<Account>(new[] { new Account { Id = new Guid("00000000-0000-0000-0000-000000000001"), Email = "test@mail.com", Password = "123" } });
            var settings = new Mock<ISettingsService>().Object;
            var securityService = new SecurityService(settings, accounts);

            //todo !!! finish the validate test
        }
    }

    public class InMemoryDbSet<T> : IDbSet<T> where T : class, new()
    {
        private IQueryable<T> _queryableSet;
        private HashSet<T> _set;

        public InMemoryDbSet() : this(Enumerable.Empty<T>())
        { }

        public InMemoryDbSet(IEnumerable<T> entities)
        {
            _set = new HashSet<T>();
            foreach (var entity in entities)
                _set.Add(entity);

            _queryableSet = _set.AsQueryable();
        }

        public Type ElementType
        {
            get
            {
                return _queryableSet.ElementType;
            }
        }

        public Expression Expression
        {
            get
            {
                return _queryableSet.Expression;
            }
        }

        public ObservableCollection<T> Local
        {
            get
            {
                return new ObservableCollection<T>(_set);
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                return _queryableSet.Provider;
            }
        }

        public T Add(T entity)
        {
            _set.Add(entity);
            return entity;
        }

        public T Attach(T entity)
        {
            _set.Add(entity);
            return entity;
        }

        public T Create()
        {
            return new T();
        }

        public T Find(params object[] keyValues)
        {
            var keyProps = typeof(T).GetKeyProperties();

            Assert.AreEqual(keyProps.Length, keyValues.Length, "Number of key values and properties must match.");

            return _set.Where(e =>
            {
                for (int i = 0; i < keyProps.Length; i++)
                {
                    var propValue = keyProps[i].GetValue(e);
                    if (Equals(propValue, keyValues[i]) == false) return false;
                }
                return true;
            })
            .SingleOrDefault();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _set.GetEnumerator();
        }

        public T Remove(T entity)
        {
            _set.Remove(entity);
            return entity;
        }

        TDerivedEntity IDbSet<T>.Create<TDerivedEntity>()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _set.GetEnumerator();
        }
    }
}
