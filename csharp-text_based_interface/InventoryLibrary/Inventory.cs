using System;
using System.Collections.Generic;

namespace InventoryLibrary
{
    public class Inventory : BaseClass
    {
        public string user_id { get; set; }
        public string item_id { get; set; }
        private int _quantity;

        public int quantity
        {
            get { return _quantity; }
            set
            {
                if (value >= 0)
                {
                    _quantity = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("quantity", "Quantity cannot be less than 0.");
                }
            }
        }
    }
}