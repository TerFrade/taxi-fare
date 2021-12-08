# Description:

The fun travel company is planning to build a travel fare service for all its taxi driver

and plans to expand this service to include bus and train fares in the future. For your task please create a taxi fare calculation application that supports the following functions. Using any programming language you like preferably Python, C#, Java, Angular, or Flutter.

1. Create a Web application that allows you to register, delete and update taxi driver profiles

The taxi drive profile consists of the following information.
1. Name
2. Surname
3. Email
4. Base Taxi Fare Price
5. Base Taxi Fare Distance

Create a Taxi fare calculation page that uses the registered taxi driver to calculate the cheapest fare. The tax fare information will be provided in CSV file format which needs to be uploaded via the web browser. The CSV file will contain the distance traveled, traveled unit, and cost per distance traveled.

The taxi fare is determined by the Base Taxi Fare Price, distance travel, and cost per distance traveled. Note that the cost per distance traveled is only applied if the distance traveled exceeds the base taxi Fare distance. The fare is calculated using the following formula:
Fare = Base Taxi Fare Price + (distance traveled units \* cost per distance traveled)

distance traveled units is calculated by:
distance traveled units = Base Taxi Fare Distance - distance traveled

For example
Taxi Drive A Base Taxi Fare Price = 200 Base Taxi Fare Distance = 150
Taxi Drive B Base Taxi Fare Price = 300 Base Taxi Fare Distance = 250

Input Text file
200,50,100

Taxi Driver A
Since taxi driver base distance is 150 and total travel is 200 meaning and the distance travel unit is 50

150-200 = 50
50/50 = 1
Price = 200 +(1\*100) = 300

Taxi Drive B Price = 250
250-200 = -50
Price = 250

Since a taxi Driver A base price does not cover the total travel distance you have to perform the taxi fare calculation. Whereas Tax Driver B&#39;s base price does cover the total travel distance.

2. Save the calculated tax fare amount in a history tab which you can view later.
