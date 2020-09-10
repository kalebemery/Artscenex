using Artsy.Data;
using Artsy.Models.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artsy.Services
{
    public class TransactionService
    {
        private readonly Guid _Id;

        public TransactionService(Guid userId)
        {
            _Id = userId;
        }

        public bool CreateTransaction(TransactionCreate model)
        {

            using (var ctx = new ApplicationDbContext())
            {

               

                var entity =
                    new Transaction()
                    {
                        CustomerId = model.CustomerId,
                        PieceId = model.PieceId,
                        PiecePrice = model.PiecePrice,
                        CreatedUTC = DateTime.Now

                    };

                var piece = ctx.Pieces.Find(model.PieceId);
                
                    if (piece.Stock < 1)
                    {
                        return false;
                    }
                    piece.Stock--;

                    ctx.Transactions.Add(entity);
                return ctx.SaveChanges() == 1;
                   
                    
            }

        }

        public IEnumerable<TransactionDetail> GetTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Transactions
                    .Select(
                        e =>
                        new TransactionDetail
                        {
                            TransactionId = e.TransactionId,
                            PiecePrice = e.PiecePrice,
                            CustomerId = e.CustomerId,
                            PieceId = e.PieceId,
                            CreatedUTC = e.CreatedUTC
                        });

                return query.ToArray();
                
            }
        }

        public TransactionDetail GetTransactionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Transactions
                    .Single(e => e.TransactionId == id );
                return
                    new TransactionDetail
                    {
                        TransactionId = entity.TransactionId,
                        PiecePrice = entity.PiecePrice,
                        CustomerId = entity.CustomerId,
                        PieceId = entity.PieceId,
                        CreatedUTC = entity.CreatedUTC
                    };
                    
            }
        }


        public bool DeleteTransaction(int TransactionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Transactions
                    .Single(e => e.TransactionId == TransactionId);

                ctx.Transactions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
