# ZARA TECH

This is the first exam of this Vueling University. We start from a statement and a .Csv file. This file contains all of the days that Inditex entry to the Shares Market in May of 2005 until December of 2017.  
The statement says that an employed by Zara received his salary every last Thursday of the months. And he was, decided to start investing in company stocks the last day from receiving his salary. If that day there is no shares, the day after there is.  
He sold his shares the December 28th, 2017. We must make a program that calculates how much money he won at the moment to sell the shares.

## Implementation

To implement this project I have tried to do my code autodescriptive, comply with naming convention, and with the single responsibility principle, with the SOLID principles.  
I divided the project for issues, thinking about the real tasks that the program must do.

## Planing the project development

The first task was to search by hand every day and the prices of the shares, to be able to calculate the final data and check if the program gives the correct data.  
Then I think how I can get the file content, and how was the best form to obtain the days that he buy  the shares.

## Tasks and Classes

I divided the project into tasks and I created a one class for each  task, trying to apply the single responsibility principle.  
- CsvManager class: contains one method to read the file and get the dates and other for set the dates in a dictionary collection
- SearchDays class: contains one method that gets the first and the last values of due dates. Another method give like a parameter this date and search each last Thursday of the month. The last method of this class the outline class method is in charge of finding the correct dates and prices.  
- StocksCalculator class: this class takes the necessaries dates for calculating how many shares were bought in total and how many shares were bought in total and how much it resulted in selling them.