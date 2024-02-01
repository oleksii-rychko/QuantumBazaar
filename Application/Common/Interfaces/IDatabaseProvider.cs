using Domain.Shared;

namespace Application.Common.Interfaces;

public interface IDatabaseProvider
{
    Task<Result<T>> ExecuteQuerySingleAsync<T>(string sql, Dictionary<string, object> parameters);
    Task<Result<IEnumerable<T>>> ExecuteQueryAsync<T>(string sql, Dictionary<string, object> parameters);
    Task<Result<bool>> ExecuteAsync(string sql, Dictionary<string, object> parameters);
}