using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

internal static class GenericContextMethods
{
    /// <summary>
    /// This method return one list with multiples rows, it's receives as parameter one sql query that return one collection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dbSet"></param>
    /// <param name="sql"></param>
    /// <returns></returns>
    public static List<T> GetList<T>(this DbSet<T> dbSet, string sql)
        where T : class
    {
        return dbSet.FromSqlRaw<T>(sql).ToList();
    }

    /// <summary>
    /// This as async method that return one list with multiple rows, it's receives as parameter one sql query that return one collection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dbSet"></param>
    /// <param name="sql">Parameter sql (SELECT * FROM TABLE or Store procedure that return one collection.)</param>
    /// <returns></returns>
    public static async Task<List<T>> GetListAsync<T>(this DbSet<T> dbSet, string sql)
        where T : class 
    {
        return await dbSet.FromSqlRaw<T>(sql).ToListAsync();
    }


    public static T FirstOrDefault<T>(this DbSet<T> dbSet, string sql)
        where T : class
    {
        return dbSet.FromSqlRaw<T>(sql).FirstOrDefault();
    }

    public static async Task<T> FirstOrDefaultAsync<T>(this DbSet<T> dbSet, string sql)
        where T : class
    {
          return await dbSet.FromSqlRaw<T>(sql).FirstOrDefaultAsync();
    }

    public static async Task<object> ExecuteSqlAsync(this DbContext context, FormattableString sql) {
        return await context.Database.ExecuteSqlInterpolatedAsync(sql);
    }

    public static object ExecuteSql(this DbContext context, FormattableString sql) {
        return context.Database.ExecuteSqlInterpolated(sql);
    }


}
