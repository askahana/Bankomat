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

This program is written in C#, and it consists of 2 classes and 11 methods. 

I planned the program by dividing it into two parts, log-in system part and other function parts. 
As I could not come up with good solutions for the log-in system part, I started with the other function part. 
For function parts, such as withdrawing money and transferring money, the switch-statement was used and I made methods and wrote codes in the same order as the switch statement.

For log-in part, I used for-loop and Array. If the username which the user input is the same as one of the usernames in the Array, the index number will be assigned to the index. 
In this way you can know which index number each user has and it works with password and accounts also. So say the user’s index is 0, and you can access their account by this index number.
![CheckIndex](https://github.com/askahana/Bankomat/assets/144675449/c8432af8-44e5-4f5c-b2e4-98ef76712433)

Where and how to store users’ information was the part which I needed to think about most. If I should use Array or ListArray, if I should store information in Main()-method or in each method/ function, and I made several tries. 
The first idea was to make class for log-in System.
![ClassProperty](https://github.com/askahana/Bankomat/assets/144675449/554551f6-b276-4f3a-a772-d931ebf1e1fd)

And then you can use them like this.

![Challenge1](https://github.com/askahana/Bankomat/assets/144675449/2aa53281-3c16-49a8-9da0-d7176e36f60f)

But I could not make it. So I tried to store all information in the Main()-method, and then moved them to class, Account. At first all information was stored under each method. But I initiate Arrays under class fields to avoid repetition.
![Arrays](https://github.com/askahana/Bankomat/assets/144675449/369df15b-a485-4183-a199-4d9a83b7420b)

## Reflection
After making the project and trying to do extra tasks, I noticed I should have used ListArray to be able to register new users and more accounts. However, I could not come up with solutions to make more accounts for new user. I guess I need to use ListArray for Jagged Array somehow. So I need to deepen knowlege about this.

Also I used a variable decimal for currency, but I am wondering what I should do with öre.

'
### Authour
* Asuka Hanada
