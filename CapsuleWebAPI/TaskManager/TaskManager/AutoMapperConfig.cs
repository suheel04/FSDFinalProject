using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TaskManager.Entities;

namespace TaskManager.WebAPI
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
                        cfg.CreateMap<Entities.TaskDetail, TaskEntity>();
                        cfg.CreateMap<TaskEntity, Entities.TaskDetail>();
                    }
                );
                    _initialized = true;
                }
            }
        }
    }
}


