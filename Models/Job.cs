﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace TasksIngrijitori.Models
{
    public class Job
    {
        [PrimaryKey, AutoIncrement] public int ID { get; set; }
        public string Description { get; set; }
        [OneToMany] public List<JobList> JobList { get; set; }
    }
}
