using DapperExtensions.Predicate;

namespace Salvation.Library.Common.Abstractions;

/// <summary>
/// IObjectProvider
/// </summary>
public interface IObjectProvider
{
    /// <summary>
    /// ConvertEntityUpdate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="update"></param>
    /// <returns></returns>
    public T ConvertEntityUpdate<T>(T entity, object update);

    /// <summary>
    /// GetPropValue
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public object GetPropValue(object obj, string name);

    /// <summary>
    /// SetPropValue
    /// </summary>
    /// <param name="src"></param>
    /// <param name="propName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public object SetPropValue(object src, string propName, object value);

    /// <summary>
    /// ConvertCondition
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="filter"></param>
    /// <param name="ignore"></param>
    /// <returns></returns>
    public PredicateGroup ConvertCondition<T>(object filter, List<string>? ignore = null) where T : class;

    /// <summary>
    /// ConvertObjectToParamsSql
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="ignore"></param>
    /// <returns></returns>
    public IEnumerable<string> ConvertObjectToParamsSql(object obj, List<string> ignore);

    /// <summary>
    /// Clone
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public T Clone<T>(T source);

    /// <summary>
    /// CloneOther
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public T CloneOther<T>(object source);

    /// <summary>
    /// ConvertSortList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public List<ISort> ConvertSortList<T>(List<Sort> list) where T : class;

    /// <summary>
    /// ConvertObjectToListString
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public IList<string> ConvertObjectToListString(object data);
}
