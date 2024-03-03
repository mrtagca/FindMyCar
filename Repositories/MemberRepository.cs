using BaseTypes;
using DbDapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class MemberRepository
    {
        public DbResultBase AddMember(Member member)
        {
            string sql = @"insert into Members (Phone,Gender) values (@Phone,@Gender)";
            return Executer.Insert(sql, member);
        }
    }
}
