﻿using LearnPortal.DAL.Interfaces;

namespace LearnPortal.DAL.Entities.Course
{
    public class Course : ICourse
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public Guid OwnerId { get; set; }
        
        public IEnumerable<IMaterial> Materials { get; set; }
        
        public IEnumerable<ISkill> Skills { get; set; }
    }
}