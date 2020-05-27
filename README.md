# SoldItemsFilter  
Paul Macfarlane  
A .net program with a function that takes in a list of sold items and filters the sold items in such a way that includes only: 
* only profitable items (SalesPrice - Cost >0)
* that were sold exactly once (Only one instance of the product name and serial number)
* serial number consists of the capital letters of their name joined with their ID (punctuation and casing ignored)  
  
After the list is filtered, the resulting list in descending order of the overall most profitable salespeople (sales people with greatest difference between SalesPrices and Costs).  
  
Assumptions Made:  
* The punction for serial codes of a SoldItem is limited to a "-" character. 
* When sorting by most profitable salesperson, the sorting criteria is based off of the original data, not the filtered data
  
Time/Space Complexity of SoldItemsFilter(soldItems:   
* Worst Case Time Efficiency is O(n^2 * m), where n is number of items in the list of sold Items, and m is the amount of unique items.  
* Worst Cast Space Efficiency is O(n), where n is number items in soldItems. A few methods within SoldItemsFilter() create a new generic list, which in the worst case will be size n.  
* This worst case time efficiency is due to the method SetProfits() called inside of SoldItemsFilter(), where SetProfits is called once with a nested loop structure. The SetProfits static method is an area to target for refactoring efficiency.  
* Specific details for the time and space complexity of each method can be found in the comments and headers of functions in SoldItem.cs  
