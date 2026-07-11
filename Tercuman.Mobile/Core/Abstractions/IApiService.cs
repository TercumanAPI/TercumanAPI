using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Contracts.DTOs.Common; // ApiResponse vb. buradan gelecek

namespace Tercuman.Mobile.Core.Abstractions;

public interface IApiService
{
    Task<TResponse> GetAsync<TResponse>(string endpoint);
    Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data);
}
