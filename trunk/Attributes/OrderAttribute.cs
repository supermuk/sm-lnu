using System;

namespace CMT.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public sealed class OrderAttribute : Attribute
    {
        readonly int mOrder;

        public OrderAttribute(int order)
        {
            mOrder = order;
        }

        public int Order
        {
            get { return mOrder; }
        }
    }
}
