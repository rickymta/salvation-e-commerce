using Salvation.Library.Models.Enums;
using Salvation.Library.Models.Response;
using System.Collections;

namespace Salvation.Library.Common.Abstractions;

/// <summary>
/// ICoreApiProvider
/// </summary>
public interface ICoreApiProvider
{
    /// <summary>
    /// CallCoreApi
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="url"></param>
    /// <param name="httpMethod"></param>
    /// <param name="body"></param>
    /// <param name="queries"></param>
    /// <param name="headers"></param>
    /// <param name="contentType"></param>
    /// <param name="keyToken"></param>
    /// <param name="recall"></param>
    /// <returns></returns>
    public Task<ResponseObject<T>> CallCoreApi<T>(
        string url,
        HttpMethod httpMethod,
        object? body = null,
        object? queries = null,
        IDictionary? headers = null,
        ContentType contentType = ContentType.Json,
        string keyToken = "",
        bool recall = true);

    /// <summary>
    /// PostCore
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="url"></param>
    /// <param name="body"></param>
    /// <param name="queries"></param>
    /// <param name="headers"></param>
    /// <param name="contentType"></param>
    /// <param name="keyToken"></param>
    /// <param name="recall"></param>
    /// <returns></returns>
    public Task<ResponseObject<T>> PostCore<T>(
        string url,
        object body,
        object? queries = null,
        IDictionary? headers = null,
        ContentType contentType = ContentType.Json,
        string keyToken = "",
        bool recall = true);

    /// <summary>
    /// GetCore
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="url"></param>
    /// <param name="body"></param>
    /// <param name="queries"></param>
    /// <param name="headers"></param>
    /// <param name="contentType"></param>
    /// <param name="keyToken"></param>
    /// <param name="recall"></param>
    /// <returns></returns>
    public Task<ResponseObject<T>> GetCore<T>(
        string url,
        object? body = null,
        object? queries = null,
        IDictionary? headers = null,
        ContentType contentType = ContentType.Json,
        string keyToken = "",
        bool recall = true);

    /// <summary>
    /// PutCore
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="url"></param>
    /// <param name="body"></param>
    /// <param name="queries"></param>
    /// <param name="headers"></param>
    /// <param name="contentType"></param>
    /// <param name="keyToken"></param>
    /// <param name="recall"></param>
    /// <returns></returns>
    public Task<ResponseObject<T>> PutCore<T>(
        string url,
        object body,
        object? queries = null,
        IDictionary? headers = null,
        ContentType contentType = ContentType.Json,
        string keyToken = "",
        bool recall = true);

    /// <summary>
    /// DeleteCore
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="url"></param>
    /// <param name="body"></param>
    /// <param name="queries"></param>
    /// <param name="headers"></param>
    /// <param name="contentType"></param>
    /// <param name="keyToken"></param>
    /// <param name="recall"></param>
    /// <returns></returns>
    public Task<ResponseObject<T>> DeleteCore<T>(
        string url,
        object body,
        object? queries = null,
        IDictionary? headers = null,
        ContentType contentType = ContentType.Json,
        string keyToken = "",
        bool recall = true);
}
