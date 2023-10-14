# Bankomat
## About the program
Bankomat is a program which simulates a simple cash machine. 
It has 5 users' information to use, and each user has a different number of accounts.

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

This program is written in C#, and it consists of 3 classes and 11 methods. 

I planned the program by dividing it into two parts, log-in system part and other function parts, such as withdrawing money and transferring money. 
As I could not come up with good solutions for the log-in system part at first, I started with the other function part. For function parts, the switch-statement was used and I made methods and wrote codes in the same order as the switch statement.

For log-in part, I used for-loop and Array. If the username, which the user input, is the same as one of the usernames in the Array, the index number will be assigned to the index. 
In this way you can know which index number each user has and it works with password and accounts also. So say the user’s index is 0, and you can access their account by this index number. 

![CheckIndexAndName](https://github.com/askahana/Bankomat/assets/144675449/50f0c668-0acb-48cc-a517-702c7cd558e5)

How and where to store users’ information was the part which I needed to think about most. If I should use Array or ListArray, if I should store information in Main()-method or in each method/function, and I made several tries. 

The first idea was to make a class for the log-in System.
![account](https://github.com/askahana/Bankomat/assets/144675449/e44f29a8-1fd1-4ec5-9a46-0f0522e7200e)

And then,

![Challenge1](https://github.com/askahana/Bankomat/assets/144675449/2aa53281-3c16-49a8-9da0-d7176e36f60f)

In this way, you can store users' information in List. But I did not know how to handle Jagged Array, which I used to store users' balance. So I stored all information as below instead. At first all information was stored under each method, but I initialized Arrays in constructor to avoid repeted code.
![constructor](https://github.com/askahana/Bankomat/assets/144675449/bac3ad96-293d-4931-8790-8d5f926cc388)

I used Array and not ArrayList to store all users' information, becuase the number of users is fixed as 5. And as I mentioned above, jagged array was used to store balance so that each user can have different numbers of accounts. But when I tried to do extra tasks, I noticed I should have used ArrayList to make new account or transfer money to each other. So I needed to change it to List. I wondered if I could store ArrayList in ArrayList.
![List](https://github.com/askahana/Bankomat/assets/144675449/59b54c07-7737-4c2f-933f-ae612c103b96)

I managed to store ArrayList in ArrayList.

One more thing I had prooblems with is variabel "decimal" as I had not understood it correctly and could not transfer or widthdraw decimalnumbers, "Öre". Say the user wants to withdraw 100.10 kr and type 100.10, it is not recognized as a number and all I get is the error message. To be able to solve this, I added "CultureInfo.InvariantCulture". 

![decimal](https://github.com/askahana/Bankomat/assets/144675449/186bbf14-f162-4915-be82-b677f9d5b96f)

Or I needed to use comma instead of period when to input the number. So programming in English but inputting should be done according to the language settings of the computer.


## Reflection
Here are some points I would like to try next time.

- To make Array bigger
- Less similar codes
- Where to declare or initialize

I used Array for all users' data at first but while making the project, I noticed I should use ArrayList for users' balance to be able to register more accounts and transfer money between users, or I should use Array.Resize to make Array bigger. This time I used ArrayList as I did not know how to make Jagged Array bigger but next time I would like to try Array.Resize to make Array bigger.

Second, I have some similar codes where I could not find how to avoid them as they are similar but not exactly same. 

Finally, I am wondering if I should have declared and/or initialized the user's information in the field or in the constructor as I did. 

### Authour
* Asuka Hanada
