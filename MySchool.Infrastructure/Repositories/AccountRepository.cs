using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using MySchool.Core.Interfaces;
using MySchool.Infrastructure.Data;

namespace MySchool.Infrastructure.Repositories;

public class AccountRepository:Repository<Accounts>, IAccountRepository
{
	public AccountRepository(DatabaseContext context) : base(context)
	{
	}
}
