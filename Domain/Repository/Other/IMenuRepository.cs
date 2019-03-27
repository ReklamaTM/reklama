﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity.Other;
using Domain.Repository.Shared;

namespace Domain.Repository.Other
{
    public interface IMenuRepository: IRepository<Menu>
    {
        Menu ReadByName(string name);
    }
}
