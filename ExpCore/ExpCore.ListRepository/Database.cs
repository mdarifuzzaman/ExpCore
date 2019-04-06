using ExpCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpCore.ListRepository
{
    public class Database
    {
        public Database()
        {
            Employees.Add(new Employee { Id = "1", Email = "a@b.com", Address = "Address 1", Mobile = "12121212", Name = "Arif1" });
            Employees.Add(new Employee { Id = "2", Email = "b@b.com", Address = "Address 2", Mobile = "12121212", Name = "Arif1" });
            Employees.Add(new Employee { Id = "3", Email = "c@b.com", Address = "Address 3", Mobile = "12121212", Name = "Arif1" });
            Employees.Add(new Employee { Id = "4", Email = "d@b.com", Address = "Address 4", Mobile = "12121212", Name = "Arif1" });
            Employees.Add(new Employee { Id = "5", Email = "e@b.com", Address = "Address 5", Mobile = "12121212", Name = "Arif1" });
            Employees.Add(new Employee { Id = "6", Email = "f@b.com", Address = "Address 6", Mobile = "12121212", Name = "Arif1" });
            Employees.Add(new Employee { Id = "7", Email = "g@b.com", Address = "Address 7", Mobile = "12121212", Name = "Arif1" });
            Employees.Add(new Employee { Id = "8", Email = "h@b.com", Address = "Address 8", Mobile = "12121212", Name = "Arif1" });
            Employees.Add(new Employee { Id = "9", Email = "i@b.com", Address = "Address 9", Mobile = "12121212", Name = "Arif1" });
            Employees.Add(new Employee { Id = "10", Email = "j@b.com", Address = "Address 10", Mobile = "12121212", Name = "Arif1" });
        }

        public List<Employee> Employees { get; set; }

        public List<T> GetData<T>() where T: IEntity
        {
            if(typeof(T) == typeof(Employee))
            {
                return Employees as List<T>;
            }
            return null;
        }

        public void Add<T>(T entity) where T: IEntity
        {
            Employees.Add(entity as Employee);
        }

        public void Delete<T>(T entity) where T : IEntity
        {
            Employees.Remove(Employees.Single(e => e.Id == entity.Id));
        }

        public bool Exists(string key)
        {
            return Employees.Exists(e=> e.Id == key);
        }

        public void Update<T>(T entity) where T: IEntity
        {
            var updated = Employees.Single(e => e.Id == entity.Id);
            var toUpdate = entity as Employee;
            updated.Address = toUpdate.Address;
            updated.Email = toUpdate.Email;
            updated.Name = toUpdate.Name;
        }
    }
}
