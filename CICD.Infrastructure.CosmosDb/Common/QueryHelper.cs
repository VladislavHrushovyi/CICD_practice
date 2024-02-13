using System.Reflection;

namespace CICD.Infrastructure.CosmosDb.Common;

public static class QueryHelper
{
    public static string ObjectPropertiesToSqlConditional(object obj, string tableName)
    {
        var propsWithData = GetPropertiesWithoutDefaultValue(obj);

        var fieldPairsString = propsWithData.Select(x => $"{tableName}.{x.Name.ToLower()} = \"{x.GetValue(obj)}\"");

        var sqlConditionalString = string.Join(" and ", fieldPairsString);

        return sqlConditionalString;
    }
    
    private static IEnumerable<PropertyInfo> GetPropertiesWithoutDefaultValue<TEntity>(TEntity entity) where TEntity : class
    {
        var props = entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(x => !IsDefaultValue(x.GetValue(entity)));
        return props;
    }

    private static bool IsDefaultValue(object value)
    {
        return value == null || (value.GetType().IsValueType && value.Equals(GetDefault(value.GetType())));
    }
    
    static object? GetDefault(Type type)
    {
        if (type.IsValueType)
        {
            return Activator.CreateInstance(type);
        }
        return null;
    }
}