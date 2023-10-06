# Bankomat
## About the program
Bankomat is a program which simulates simple cash machine. This program is written in C#, and consists of 2 classes and 8 methods. 

It has 5 users information to use.
When the user starts the program, the ueser needs to log in with theie IDs. If IDs are not invalid, they need to wait to log in again for 3 minutes.

Users can  
1. see their account, how much money they have
2. transfer money among their own account
3. withdraw money
4. deposit money
5. log out

## planning and implemention
When I planned to make the project, I had problems coming up with good solutions to make log-in system. So I started to plan with other functions, such as tranfer money, see theie accounts.
When I started coding the program, I first used List to store users' infomation such as user name etc. I first misunderstood that users needed to be able to transfer money each other and they have just one account. So I first used List then changed into arrays and jagged array so that users can have several accounts.

To store users infomation, such as username, passwords and their balance, I used arrays.
When I made the program first, I used List instead of array becuase I misunderstood that users needed to be able to transfer money each other.


## Reflection
After making the project and trying to do extra tasks, I noticed I should have used List to be able to register new users.
But then I did not know how to change jagged aray to List.

### Authour
* Asuka Hanada
