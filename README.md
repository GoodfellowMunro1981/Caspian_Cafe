# Caspian_Cafe
Caspian Cafe Exercise

* Use TDD 
* Use Git for source control 
 
 
Complete the steps in order. Don’t read ahead.  
 
At each step build the simplest possible solution which meets our requirement.  

__Tag a git commit__ after each step so that your approach is clear. 
 
Scenario 
 
The Cafe Caspian menu consists of the following items: 
* Cola - Cold - 50p 
* Coffee - Hot - £1.00 
* Cheese Sandwich - Cold - £2.00 
* Steak Sandwich - Hot - £4.50

Customers don’t know how much to tip and staff need tips to survive! 
 
Step 1: Standard Bill 
 
Create a .NET Core (any version) application which will accept a list of purchased items and produce a total bill. 
e.g. [“Cola”, “Coffee”, “Cheese Sandwich”] returns 3.5 
 
Step 2: Service Charge 
 
Add support for a service charge: 
* When all purchased items are drinks no service charge is applied 
* When purchased items include __any__ food apply a service charge of 10% to the total bill (rounded to 2 decimal places) 
* When purchased items include __any hot__ food apply a service charge of 20% to the total bill with a maximum £20 service charge 
 
