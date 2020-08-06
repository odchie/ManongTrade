using ManongTrade.Entity;
using ManongTrade.Repository.Interface;
using System;
using System.Collections.Generic;

namespace ManongTrade.Repository
{
    public class CustomerRepo : BaseRepo<Customer>, ICustomerRepo
    {
        private BaseRepo<Cart> _cart;
        private BaseRepo<Contact> _contact;
        public CustomerRepo(ManongTradeContext context) : base(context) { }
        public Customer CheckLogin(string Username)
        {
            BaseRepo<Customer> person = new BaseRepo<Customer>(base._context as ManongTradeContext);
            return person.SingleOrDefault(x => x.Username == Username);
        }
        public IEnumerable<Cart> CartGetAll(short CustomerId)
        {
            return this.CartInstance().Find(x => x.CustomerId == CustomerId);
        }
        public void CartAdd(Cart Cart)
        {
            this.CartInstance().Add(Cart);
        }
        public void CartRemove(int CartId)
        {
            if (this.CartInstance().SingleOrDefault(x => x.Id == CartId) is Cart findCart)
            {
                this.CartInstance().Remove(findCart);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
        public IEnumerable<Contact> ContactGetAll(short CustomerId)
        {
            return this.ContactInstance().Find(x => x.CustomerId == CustomerId);
        }
        public void ContactAdd(Contact Contact)
        {
            this.ContactInstance().Add(Contact);
        }
        public void ContactRemove(int ContactId)
        {
            if (this.ContactInstance().SingleOrDefault(x => x.Id == ContactId) is Contact findContact)
            {
                this.ContactInstance().Remove(findContact);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
        public void ProcessOrder(short CustomerId)
        {
            throw new NotImplementedException();
        }

        private BaseRepo<Cart> CartInstance()
        {
            return _cart ?? (_cart = new BaseRepo<Cart>(base._context as ManongTradeContext));
        }
        private BaseRepo<Contact> ContactInstance()
        {
            return _contact ?? (_contact = new BaseRepo<Contact>(base._context as ManongTradeContext));
        }
    }
}