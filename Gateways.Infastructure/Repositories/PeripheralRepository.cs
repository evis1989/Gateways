﻿using Gateways.Data.AbstractRepositories;
using Gateways.Data.Entities;
using Gateways.Insfastructure.AppContext;
using Gateways.Insfastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gateways.Insfastructure.Repositories
{
    public class PeripheralRepository : Repository<PeripheralEntity>, IPeripheralRepository
    {
        public PeripheralRepository(IDbContext context) : base(context)
        {

        }
    }
}