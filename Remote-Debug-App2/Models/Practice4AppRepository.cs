﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remote_Debug_App2.Models
{
    public class Practice4AppRepository
    {
        public static Practice4AppRepository intance;
        public Practice4AppRepository()
        {
            intance = new Practice4AppRepository("https://github.com/customaccount/Practice4RepoCore2.1");
        }
        private Practice4AppRepository(string repository)
        {
            Repository = repository;
        }

        public string Repository ;
    }
}
