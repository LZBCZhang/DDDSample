namespace ConsentOrchestrator.Domain.Exceptions;

public class ConsentUpdateException(string message, Exception? inner = null)
    : Exception(message, inner);
