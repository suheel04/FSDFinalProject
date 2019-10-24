using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.Entity.Validation;
using ProjectManager.DataAccess.GenericRepository;
using ProjectManager.Entities;

namespace ProjectManager.DataAccess.UnitOfWork
{

    public class UnitOfWork : IDisposable
    {
        private ProjectManagerDBContext _context = null;

        private GenericRepository<TaskDetail> _TaskRepository;
        private GenericRepository<User> _UserRepository;
        private GenericRepository<Project> _ProjectRepository;

        public GenericRepository<TaskDetail> TaskRepository
        {
            get {
                if (this._TaskRepository == null)
                    this._TaskRepository = new GenericRepository<TaskDetail>(_context);
                return _TaskRepository;
            }
        }
        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this._UserRepository == null)
                    this._UserRepository = new GenericRepository<User>(_context);
                return _UserRepository;
            }
        }
        public GenericRepository<Project> ProjectRepository
        {
            get
            {
                if (this._ProjectRepository == null)
                    this._ProjectRepository = new GenericRepository<Project>(_context);
                return _ProjectRepository;
            }
        }


        public UnitOfWork()
        {
            _context = new ProjectManagerDBContext();
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
