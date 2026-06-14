using ConsentOrchestrator.Domain.ValueObjects;

namespace ConsentOrchestrator.Domain.Exceptions;

public class PurposesNotFoundException(CollectionPointId collectionPointId)
    : Exception($"Purposes not found for collection point {collectionPointId}");
