using DemoAspNetCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAspNetCore.DBControllers
{
    public class TransactionDbController
    {
        private TransactionRepository transactionRepository;

        public TransactionDbController()
        {
            transactionRepository = new TransactionRepository(new DAL.ApiDBContext());
        }
        public List<DAL.Transaction> GetAllTransactions()
        {
            return transactionRepository.GetAllTransactions();
        }
        public void AddTransaction(DAL.Transaction model)
        {
            var allTransactions = transactionRepository.GetAll();
            int lastId = 0;
            if (allTransactions.Count() > 0)
                lastId = allTransactions[allTransactions.Count() - 1].Id;
            model.Id = lastId + 1;
            transactionRepository.Insert(model);
            transactionRepository.Save();
        }
        public void EditTransaction(int transactionId, DAL.Transaction newTransaction)
        {
            DAL.Transaction model = transactionRepository.GetById(transactionId);
            model.Amount = newTransaction.Amount;
            model.CurrencyCode = newTransaction.CurrencyCode;
            EditTransaction(model);
        }
        private void EditTransaction(DAL.Transaction model)
        {
            transactionRepository.Update(model);
            transactionRepository.Save();
        }
        public void DeleteTransaction(int areaId)
        {
            DAL.Transaction model = transactionRepository.GetById(areaId);
            if (model == null)
                return;
            Delete(areaId);
        }

        private void Delete(int areaId)
        {
            transactionRepository.Delete(areaId);
            transactionRepository.Save();
        }
        public DAL.Transaction getById(int id)
        {
            return transactionRepository.GetById(id);
        }
    }
}
