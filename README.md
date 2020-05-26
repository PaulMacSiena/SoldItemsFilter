# SoldItemsFilter
A .net program with a function that takes in a list of sold items and filters the sold items in such a way that includes only: 
* only profitable items (SalesPrice - Cost >0)
* that were sold exactly once (Only one instance of the product name and serial number)
* serial number consists of the capital letters of their name joined with their ID (punctuation and casing ignored)  
  
After the list is filtered, the resulting list in descending order of the overall most profitable salespeople (sales people with greatest difference between SalesPrices and Costs).  
  
Assumptions:  

Time/Space Efficiency: 
