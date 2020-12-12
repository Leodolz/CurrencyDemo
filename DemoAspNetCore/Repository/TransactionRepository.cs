using DemoAspNetCore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAspNetCore.Repository
{
    public class TransactionRepository : Generic.GenericRepository<Transaction>
    {
        public TransactionRepository(ApiDBContext context) : base(context)
        {}

        public List<Transaction> GetAllTransactions()
        {
            return table.ToList();
        }
    }
}
