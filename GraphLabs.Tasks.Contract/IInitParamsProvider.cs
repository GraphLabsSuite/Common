using System;
using System.Diagnostics.Contracts;
using JetBrains.Annotations;

namespace GraphLabs.Tasks.Contract
{
    using Contract = System.Diagnostics.Contracts.Contract;

    /// <summary> Поставщик параметров инициализации задания </summary>
    [ContractClass(typeof(InitParamsProviderContracts))]
    public interface IInitParamsProvider
    {
        /// <summary> Получить строку с параметрами инициализации </summary>
        [NotNull]
        string GetInitParamsString(InitParams parameters);

        /// <summary> Разобрать строку с параметрами инициализации </summary>
        [NotNull]
        InitParams ParseInitParamsString(string initParamsString);
    }


    /// <summary> Поставщик параметров инициализации задания - контракты </summary>
    [ContractClassFor(typeof(IInitParamsProvider))]
    public class InitParamsProviderContracts : IInitParamsProvider
    {
        // ReSharper disable AssignNullToNotNullAttribute

        /// <summary> Получить строку с параметрами инициализации </summary>
        public string GetInitParamsString(InitParams parameters)
        {
            Contract.Requires<ArgumentNullException>(parameters != null);
            Contract.Ensures(!string.IsNullOrWhiteSpace(Contract.Result<string>()));

            return default(string);
        }

        /// <summary> Разобрать строку с параметрами инициализации </summary>
        public InitParams ParseInitParamsString(string initParamsString)
        {
            Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(initParamsString));
            Contract.Ensures(Contract.Result<InitParams>() != null);

            return default(InitParams);
        }
    }
}