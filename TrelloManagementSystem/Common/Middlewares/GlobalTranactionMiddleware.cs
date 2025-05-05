using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using TrelloManagementSystem.Common.Database.Context;

namespace TrelloManagementSystem.Common.Middlewares
{
    public class GlobalTranactionMiddleware :IMiddleware
    {
        private readonly TrelloContext _context;

        public GlobalTranactionMiddleware(TrelloContext context)
        {
            this._context = context;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            IDbContextTransaction Transaction = null!;
            try
            {
                Transaction = _context.Database.BeginTransaction();

                await next(context);
                Transaction.Commit();

            }
            catch (Exception)
            {

                Transaction?.Rollback();
                throw;
            }


        }
    }
}
