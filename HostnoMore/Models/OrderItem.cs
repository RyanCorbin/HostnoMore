using System;
using Prism.Mvvm;

namespace HostnoMore.Models
{
    public class OrderItem : BindableBase
    {
        private Blog _item;
        public Blog Item
        {
            get { return _item; }
            set { SetProperty(ref _item, value); }
        }

        //public override Blog ToString()
        //{
        //    return $"Item={Item}";
        //}

        //public string Value()
        //{
        //    return Item;
        //}
    }
}
