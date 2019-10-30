using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.Entity.Validation;
using TaskManager.DataAccess.GenericRepository;
using TaskManager.Entities;

namespace TaskManager.DataAccess.UnitOfWork
{

    public class UnitOfWork : IDisposable
    {
        private TaskManagerDBContext _context = null;

        private GenericRepository<TaskDetail> _TaskRepository;

        public GenericRepository<TaskDetail> TaskRepository
        {
            get
            {
                if (this._TaskRepository == null)
                    this._TaskRepository = new GenericRepository<TaskDetail>(_context);
                return _TaskRepository;
            }
        }


        public UnitOfWork()
        {
            _context = new TaskManagerDBContext();
        }




        public int Save()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                throw e;
            }

        }


        private bool disposed = false;


        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
