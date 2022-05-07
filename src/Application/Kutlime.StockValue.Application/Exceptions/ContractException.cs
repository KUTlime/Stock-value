using System;

namespace Kutlime.StockValue.Application.Exceptions;

public class ContractException : Exception
{
	public ContractException(string message) : base($"Contract violation: {message}")
	{
	}
}