# Bankomat
## About the program
Bankomat is a program which simulates a simple cash machine. 
It has 5 users information to use and each user has a different number of accounts.

Once the user starts the program, they need to log in with their ID, which is already prepared in the program. 
If the ID which they input is invalid, then the user needs to wait for 3 minutes to log in again.

Users have to do the following to use the system.
1. input user name
2. input password

If users ID is valid,
Users can  
1. see their account, how much money they have
2. transfer money between their own accounts
3. withdraw money
4. deposit money
5. log out

## planning and implementation

This program is written in C#, and it consists of 2 classes and 9 methods. 

I planned the program by dividing it into two parts, log-in system part and other function parts. 
As I could not come up with good solutions for the log-in system part, I started with the other function part. 
For function parts, such as withdrawing money and transferring money, the switch-statement was used and I wrote codes in the same order as the switch statement.

For log-in part, I used for-loop and Array. If the username which the user input is the same as one of the usernames in the Array, the index number will be assigned to the index. 
In this way you can know which index number each user has and it works with password and accounts also. So say the user’s index is 0, and you can access their account by this index number.

Where and how to store users’ information was the part which I needed to think about most. 
If I should use Array or ListArray or declar in the class, if I should store information in Main()-method or in each method/ function under class, Account, and I made several tries. For example, I used ArrayList first instead of Array for users' balance because I misunderstood that users needed to be able to transfer money to each other. Then I noticed users need several accounts and used a jagged array instead. 

All users' information was stored in the Main()-method at first. But once the log-in system worked, I made a class, Account, and moved username Array to CheckName()-method, passwords Array to CheckPass()-method. Like this I made Arrays in each method at first, but to avoid it I tried if I can initiate Arrays under class fields and did it.

## Reflection
After making the project and trying to do extra tasks, I noticed I should have used ListArray to be able to register new users and more accounts. However, I could not change a jagged array to ListArray. Because  I wanted to try making class, I did it but I still am unsure with this. So I need to study more about this.

Also I used a variable decimal for currency, but I am wondering what I should do with öre.


### Authour
* Asuka Hanada
