namespace SoldItemsFilter
{ 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

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
            throw new ArgumentException("Object is not a SoldItem");
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

        /*
         * Filters out items from list based off of 
         *  - if they are not profitable (if price < cost, there is no profit)
         *  - if the item was sold more than once
         *  - serial number consists of the capital letters of their name joined with their ID(punctuation and casing ignored)
         */
        public static List<SoldItem> SoldItemsFilter(List<SoldItem> items)
        {
            items.RemoveAll(notProfitable); // remove all items not sold at a profit

            List<String> dupSerials = FindDuplicates(items); //get duplicate Serial Codes

            List<SoldItem> itemsSoldOnce = new List<SoldItem>(); // create new list for items only sold once

            // add all items that were only sold once to list
            foreach(SoldItem i in items)
            {
                //if serial code was not duplicated, item was sold only 1 time
                if (!dupSerials.Contains(i.serialNumber))
                {
                    itemsSoldOnce.Add(i);
                }
            }


            List<SoldItem> filteredItems = SerialFormat(itemsSoldOnce); //filter out items without proper serial code

            return filteredItems;
        }

        /*
         * Predicate to determine if an item is not profitable
         * ex salesprice <= cost
         */
        private static bool notProfitable(SoldItem item)
        {
            if (item.salesPrice <= item.cost)
            {
                return true;
            }
            return false;
        }

        /*
         * Returns list of serial numbers for items that occur
         * multiple times in the inputed list
         */
        public static List<String> FindDuplicates(List<SoldItem> items)
        {
            List<String> origSnumbers = new List<String>();
            List<String> duplicateSnumbers = new List<String>();

            foreach (SoldItem item in items)
            {
                if (origSnumbers.Contains(item.serialNumber))
                {
                    duplicateSnumbers.Add(item.serialNumber);
                }
                else
                {
                    origSnumbers.Add(item.serialNumber);
                }
            }

            return duplicateSnumbers;
        }

        /*
         * Iterates through a list of SoldItems, and returns a new list with only items in the format:
         * serial number consists of the capital letters of item name joined with item ID (punctuation and casing ignored)
         */
        public static List<SoldItem> SerialFormat(List<SoldItem> items)
        {
            List<SoldItem> serialFormattedItems = new List<SoldItem>();

            foreach (SoldItem item in items)
            {
                String itemName = @item.name;
                String capitalLetters = String.Concat(itemName.Where(c => c >= 'A' && c <= 'Z'));

                String serialNoPunctuation = item.serialNumber.Replace("-","");
                Regex rx = new Regex(capitalLetters + item.id);

                if (rx.IsMatch(serialNoPunctuation))
                {
                    //Console.WriteLine("Added: " + item.toString());
                    serialFormattedItems.Add(item);
                }
                else
                {
                    //Console.WriteLine("Could not add: " + item.toString());
                }
            }
            return serialFormattedItems;

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
                  new SoldItem(11,"SwashBuckler's Buckled Swashes", "SBBS11",122,160,"Harry Lewis")
            };

            

                //List<String> dups = FindDuplicates(soldItems);
                //foreach(String dup in dups)
                //{
                //    Console.WriteLine(dup);
                //}
                Console.WriteLine("Original List: ");

                foreach (SoldItem item in soldItems)
                {
                    // Display Original List
                    Console.WriteLine(item.toString());
                }

                Console.WriteLine("-----------");
                Console.WriteLine("Filtered List: "); //only profit at this point

                List<SoldItem> filteredItems = SoldItemsFilter(soldItems);

                foreach (SoldItem item in filteredItems)
                {
                    // Display Filtered List
                    Console.WriteLine(item.toString());
                }

                Console.WriteLine("-----------");
                Console.WriteLine("Sorted List: ");
                filteredItems.Sort();

                foreach (SoldItem item in filteredItems)
                {
                    // Display Sorted List
                    Console.WriteLine(item.toString());
                }
            

        }
    }
}
