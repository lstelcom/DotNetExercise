using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DotNetExercise.DAL.Entities;

namespace DotNetExercise.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Employee> EmployeeRepository { get; }
        IRepository<Customer> CustomerRepository { get; }

        void BeginTransaction();
        void BeginTransaction(IsolationLevel isolationLevel);
        void Save();
    }
}