using System;

namespace Kutlime.StockValue.Application.Exceptions
{
	public class InvalidServiceProviderException : Exception
	{
		public InvalidServiceProviderException(string name) : base($"The service provider\"{name}\" can't be resolved.")
		{
		}
	}
}
