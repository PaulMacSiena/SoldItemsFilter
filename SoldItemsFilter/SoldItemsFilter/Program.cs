namespace SoldItemsFilter
{ 
    using System;
    using System.Collections.Generic;

    public class SoldItem: IComparable
    {
        private int id;
        private String name;
        private String serialNumber;
        private int cost;
        private int salesPrice;
        private String salesPerson;

        /*
         * Constructor for the SoldItem Class
         */
        public SoldItem(int id, String name, String serialNumber, int cost,
            int salesPrice, String salesPerson)
        {
            this.id = id;
            this.name = name;
            this.serialNumber = serialNumber;
            this.cost = cost;
            this.salesPrice = salesPrice;
            this.salesPerson = salesPerson;
        }

        /*
         * Implement the CompareTo Method so that a list of SoldItems can be sorted
         */
        public int CompareTo(object obj)
        {
            if (obj is SoldItem)
            {
                return this.name.CompareTo((obj as SoldItem).name);
                //for now, SoldItems will be compared by the name attribute
            }
            throw new ArgumentException("Object is not a User");
        }

        /*
         * toString method to print a readable version of the SoldItem Class
         */
        public String toString()
        {
            return "id: " + this.id + ", name: " + this.name + ", serialNumber: " +
                this.serialNumber + ", cost: " + this.cost + ", salesPrice: " +
                this.salesPrice + ", salesPerson: " + this.salesPerson;
        }

        // Main Method to print output to console
        public static void Main()
        {
            // Initialize the original data
            List<SoldItem> soldItems = new List<SoldItem>
        { 
              new SoldItem(1,"Rock Salt", "RS1",10,50,"Andy Ghadban"),
              new SoldItem(2,"Planter's Nuts", "XO28-V",4,23,"Reginald VelJohnson"),
              new SoldItem(3,"Bulk Pack SuperWash Fire Hoses", "BPSW-FH3",122,122,"Harry Lewis"),
              new SoldItem(4,"BlackBOX carnival sticks", "BBOX4",215,460,"Jean-Luc Picard"),
              new SoldItem(5,"ARMY surplus Canned Beef", "5-ARMYCB",34,513,"Jean-Luc Picard"),
              new SoldItem(6,"Compressed Air", "CA6",80,900,"Frank Castle"),
              new SoldItem(7,"Rock Salt", "RS1",10,2,"Reginald VelJohnson"),
              new SoldItem(8,"Werther's Original", "WO-8",12,75,"Andy Ghadban"),
              new SoldItem(9,"tonka truck passenger door", "TT-PD-9",336,275,"Jean-Luc Picard"),
              new SoldItem(10,"ARMY surplus Canned Beef", "5-ARMYCB",12,6000,"Frank Castle"),
              new SoldItem(11,"SwashBuckler's Buckled Swashes", "RS1",122,160,"Harry Lewis")
        };

            Console.WriteLine("Original List: ");

            foreach (SoldItem item in soldItems)
            {
                // Display Original List
                Console.WriteLine(item.toString());
            }

            Console.WriteLine("-----------");
            Console.WriteLine("Sorted List: ");
            soldItems.Sort();

            foreach (SoldItem item in soldItems)
            {
                // Display Sort List
                Console.WriteLine(item.toString());
            }

        }
    }
}
