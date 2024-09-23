using SSS.Domain.Common.Models;

namespace SSS.Domain.MenuAggregate.Events;

public record MenuCreated(Menu Menu) : IDomainEvent;