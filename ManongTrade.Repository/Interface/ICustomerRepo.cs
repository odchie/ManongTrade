using ManongTrade.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManongTrade.Repository.Interface
{
    public interface ICustomerRepo : IBaseRepo<Customer>
    {
        Customer CheckLogin(string Username);
        IEnumerable<Cart> CartGetAll(short CustomerId);
        void CartAdd(Cart Cart);
        void CartRemove(int CartId);
        IEnumerable<Contact> ContactGetAll(short CustomerId);
        void ContactAdd(Contact Contact);
        void ContactRemove(int ContactId);
        void ProcessOrder(short CustomerId);
    }
}