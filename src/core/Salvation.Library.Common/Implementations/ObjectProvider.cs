using Salvation.Library.Common.Abstractions;
using DapperExtensions.Predicate;
using Newtonsoft.Json;
using System.Reflection;

namespace Salvation.Library.Common.Implementations;

///<inheritdoc/>
internal class ObjectProvider : IObjectProvider
{
    ///<inheritdoc/>
    public T ConvertEntityUpdate<T>(T entity, object update)
    {
        foreach (var item in update.GetType().GetProperties())
        {
            var value = GetPropValue(update, item.Name);

            if (value != null)
            {
                SetPropValue(entity, item.Name, value);
            }
        }

        return entity;
    }

    ///<inheritdoc/>
    public object GetPropValue(object obj, string name)
    {
        foreach (var part in name.Split('.'))
        {
            if (obj == null)
            {
                return null;
            }

            PropertyInfo info = obj.GetType().GetProperty(part);

            if (info == null)
            {
                return null;
            }

            obj = info.GetValue(obj, null);
        }

        return obj;
    }

    ///<inheritdoc/>
    public object SetPropValue(object src, string propName, object value)
    {
        src.GetType().GetProperty(propName)?.SetValue(src, value);

        return src;
    }

    ///<inheritdoc/>
    public PredicateGroup ConvertCondition<T>(object filter, List<string>? ignore = null) where T : class
    {
        ignore ??= new List<string>();
        PredicateGroup condition = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };

        if (filter != null)
        {
            foreach (var item in filter.GetType().GetProperties())
            {
                var value = GetPropValue(filter, item.Name);

                if (value != null && !ignore.Contains(item.Name))
                {
                    condition.Predicates.Add(new FieldPredicate<T> { Value = value, Operator = Operator.Eq, PropertyName = item.Name });
                }
            }
        }

        return condition;
    }
    
    ///<inheritdoc/>
    public IEnumerable<string> ConvertObjectToParamsSql(object obj, List<string> ignore)
    {
        var result = new List<string>();

        foreach (var item in obj.GetType().GetProperties())
        {
            var value = item.GetValue(obj);
            string name = item.Name;

            if (!ignore.Contains(name) && value != null)
            {
                result.Add($"{name}=@{name}");
            }
        }

        return result;
    }
    
    ///<inheritdoc/>
    public T Clone<T>(T source)
    {
        if (source == null)
        {
            return default;
        }

        return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
    }
    
    ///<inheritdoc/>
    public T CloneOther<T>(object source)
    {
        if (source == null)
        {
            return default;
        }

        return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
    }

    ///<inheritdoc/>
    public List<ISort> ConvertSortList<T>(List<Sort> list) where T : class
    {
        List<ISort> condition = new List<ISort>();

        if (list.Any())
        {
            foreach (Sort item in list)
            {
                condition.Add(new Sort { Ascending = item.Ascending, PropertyName = item.PropertyName });
            }
        }

        return condition;
    }

    ///<inheritdoc/>
    public IList<string> ConvertObjectToListString(object data)
    {
        var result = new List<string>();

        foreach (var item in data.GetType().GetProperties())
        {
            string name = item.Name;
            {
                var value = GetPropValue(data, name);

                if (value != null)
                {
                    result.Add($"{name}={value}");
                }
            }
        }

        return result;
    }
}
