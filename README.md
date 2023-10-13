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

Where and how to store users’ information was the part which I needed to think about most. If I should use Array or ListArray, if I should store information in Main()-method or in each method/function, and I made several tries. 

The first idea was to make a class for the log-in System.
![account](https://github.com/askahana/Bankomat/assets/144675449/e44f29a8-1fd1-4ec5-9a46-0f0522e7200e)

And then,

![Challenge1](https://github.com/askahana/Bankomat/assets/144675449/2aa53281-3c16-49a8-9da0-d7176e36f60f)

In this way, you can store users' information in List. But I did not know how to handle Jagged Array. So I stored all information as below. At first all information was stored under each method, but I initialized Arrays in constructor to avoid repeted code.
![constructor](https://github.com/askahana/Bankomat/assets/144675449/bac3ad96-293d-4931-8790-8d5f926cc388)

I used Array and not ArrayList becuase the number of users is fixed as 5. And as I mentioned above, jagged array was used to store balance so that each user can have different numbers of accounts although I first used ArrayList because I misunderstood that users needed to be able to transfer money to each other.

Also I had not understood variable "decimal" correctly and could not transfer or widthdraw decimalnumbers, "Öre". Say I want to withdraw 100.10 kr and if I type 100.10, it is not recognized as a number and all I get is the error message.
To be able to solve this, I added "CultureInfo.InvariantCulture". 

![decimal](https://github.com/askahana/Bankomat/assets/144675449/186bbf14-f162-4915-be82-b677f9d5b96f)

Or I needed to use comma instead of period when to input the number. So programming in English but inputting should be done according to the language settings of the computer.


## Reflection
Here are some points I would like to change next time.

- ArrayList instead Array
- Where to declare or initialize

After making the project and trying to do extra tasks, I noticed I should have used ListArray to be able to register more accounts and transfer money to each other, or I should have used Array.Resize to make Array bigger. But I did not know how to handle Jaggaed Array in those cases. So I need to deepen my knowledge about this. 

Also I am wondering if I should have declare/ initialize user's information in the field or in the constructor as I did. Next time, I would like to try as my first plan and try extra tasks.

### Authour
* Asuka Hanada
