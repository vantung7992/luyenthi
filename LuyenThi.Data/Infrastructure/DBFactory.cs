namespace LuyenThi.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private LuyenthiDBContext dbContext;

        public LuyenthiDBContext Init()
        {
            return dbContext ?? (dbContext = new LuyenthiDBContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}