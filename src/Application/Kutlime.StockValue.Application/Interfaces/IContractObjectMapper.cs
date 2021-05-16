using System.Diagnostics.CodeAnalysis;

namespace Kutlime.StockValue.Application.Interfaces
{
	internal interface IContractObjectMapper<in TSourceObject, in TTargetObject>
	{
		[return: NotNull]
		internal TResult Map<TInput, TResult>(TInput inputObject) where TInput : TSourceObject where TResult : TTargetObject;
	}
}