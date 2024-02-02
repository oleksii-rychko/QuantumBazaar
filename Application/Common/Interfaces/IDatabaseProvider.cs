using Domain.Shared;

namespace Application.Common.Interfaces;

public interface IDatabaseProvider
{
    Task<Result<T>> QuerySingleAsync<T>(string sql, Dictionary<string, object> parameters);
    Task<Result<IEnumerable<T>>> QueryAsync<T>(string sql, Dictionary<string, object> parameters);
    Task<Result<bool>> ExecuteAsync(string sql, Dictionary<string, object> parameters);
}