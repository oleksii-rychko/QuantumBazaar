using System.Data.SqlClient;
using System.Transactions;
using Application.Common.Interfaces;
using Dapper;
using Domain.Shared;

namespace Infrastructure;

public class DatabaseProvider(string connectionString) : IDatabaseProvider
{
    public async Task<Result<T>> QuerySingleAsync<T>(string sql, Dictionary<string, object> parameters)
    {
        await using var connection = new SqlConnection(connectionString); 
        using var transactionScope = new TransactionScope();
        var dynamicParams = ParametersToDynamicParameters(parameters);

        var result = (await connection.QueryAsync<T>(sql, dynamicParams)).AsList();
        
        transactionScope.Complete();

        if (!result.Any())
        {
            return Result<T>.Failure(Error.NotFound);
        }

        return Result<T>.Success(result.FirstOrDefault());
    }

    public async Task<Result<IEnumerable<T>>> QueryAsync<T>(string sql, Dictionary<string, object> parameters)
    {
        await using var connection = new SqlConnection(connectionString); 
        using var transactionScope = new TransactionScope();
        var dynamicParams = ParametersToDynamicParameters(parameters);

        var result = (await connection.QueryAsync<T>(sql, dynamicParams)).AsList();
        
        transactionScope.Complete();

        if (!result.Any())
        {
            return Result<IEnumerable<T>>.Failure(Error.NotFound);
        }

        return Result<IEnumerable<T>>.Success(result);
    }

    public async Task<Result<bool>> ExecuteAsync(string sql, Dictionary<string, object> parameters)
    {
        await using var connection = new SqlConnection(connectionString); 
        using var transactionScope = new TransactionScope();
        var dynamicParams = ParametersToDynamicParameters(parameters);

        var result = await connection.ExecuteAsync(sql, dynamicParams);
        
        transactionScope.Complete();

        if (result == 0)
        {
            return Result<bool>.Failure(Error.NoRowsAffected);
        }

        return Result<bool>.Success();
    }

    private DynamicParameters ParametersToDynamicParameters(Dictionary<string, object> parameters)
    {
        var dynamicParams = new DynamicParameters();
        foreach (var keyValue in parameters)
        {
            dynamicParams.Add(keyValue.Key, keyValue.Value);
        }

        return dynamicParams;
    }
}