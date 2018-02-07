using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetExercise.DAL.Entities;
using DotNetExercise.DAL.Interfaces;
using System.Data.Entity;
using System.Data;
using DotNetExercise.DAL.Entities;

namespace DotNetExercise.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private SampleDbEntities _context;
        private DbContextTransaction _dbContextTransaction;

        private IRepository<Customer> _customerRepository;
        private IRepository<Employee> _employeeRepository;

        public UnitOfWork()
        {
            _context = new SampleDbEntities();
        }

        public IRepository<Customer> CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new GenericRepository<Customer>(_context);
                }
                return _customerRepository;
            }
        }


        public IRepository<Employee> EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new GenericRepository<Employee>(_context);
                }
                return _employeeRepository;
            }
        }

        public void BeginTransaction()
        {
            _dbContextTransaction = _context.Database.BeginTransaction();
        }

        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            _dbContextTransaction = _context.Database.BeginTransaction(isolationLevel);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Commit()
        {
            if (_dbContextTransaction!=null)
            {
                _dbContextTransaction.Commit();
            }
        }

        public void RollBack()
        {
            if (_dbContextTransaction != null)
            {
                _dbContextTransaction.Rollback();
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                    if (_dbContextTransaction != null)
                    {
                        _dbContextTransaction.Dispose();
                    }
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}