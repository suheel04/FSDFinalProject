using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Entities;

namespace ProjectManager.Test
{
    public static class AutoMapperConfig
    {
        private static object _thisLock = new object();
        private static bool _initialized = false;
        // Centralize automapper initialize
        public static void Initialize()
        {
            // This will ensure one thread can access to this static initialize call
            // and ensure the mapper is reseted before initialized
            lock (_thisLock)
            {
                if (!_initialized)
                {
                    Mapper.Initialize(cfg =>
                    {
                        cfg.CreateMap<TaskDetail, TaskDetailEntity>();
                        cfg.CreateMap<TaskDetailEntity, TaskDetail>();
                        cfg.CreateMap<User, UserEntity>();
                        cfg.CreateMap<UserEntity, User>();
                        cfg.CreateMap<Project, ProjectEntity>();
                        cfg.CreateMap<ProjectEntity, Project>();
                    }
                );
                    _initialized = true;
                }
            }
        }
    }

  
    
}