using ModelClasses.Contracts;

namespace BusinessLogicServer.Networking.Orders;

public interface IOrderNetworkingExtendingIOrderDao : IOrdersDao
{
    // the purpose of this interface, is to differentiate two singleton implementations
    // of IOrdersDao.cs interface within BusinessLogic project (see Program.cs)
}