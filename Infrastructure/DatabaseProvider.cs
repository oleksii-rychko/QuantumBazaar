using Application.Common.Interfaces;
using Domain.Shared;

namespace Infrastructure;

public class DatabaseProvider: IDatabaseProvider
{
    public Task<Result<T>> ExecuteQuerySingleAsync<T>(string sql, Dictionary<string, object> parameters)
    {
        throw new NotImplementedException();
    }

    public Task<Result<IEnumerable<T>>> ExecuteQueryAsync<T>(string sql, Dictionary<string, object> parameters)
    {
        throw new NotImplementedException();
    }

    public Task<Result<bool>> ExecuteAsync(string sql, Dictionary<string, object> parameters)
    {
        throw new NotImplementedException();
    }
}