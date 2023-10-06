# Bankomat
## Bankomat is a program which simulates simple cash machine.
This program is written in C#. It has 5 users information to use.
The users need to log in with their ID and if they do not input correctly, they need to wait to log in again for 3 minutes.

Users can  
1. see their account, how much money they have
2. transfer money among their own account
3. withdraw money
4. deposit money
5. log out

This program consists of 2 classes and 8 methods. 

To store users infomation, such as username, passwords and their balance, I used arrays.
When I made the program first, I used List instead of array becuase I misunderstood that users needed to be able to transfer money each other.
Then I noticed users need several coounts and I decided to use jagged array.

## Reflection
After making the project and trying to do extra tasks, I noticed I should have used List to be able to register new users.
But then I did not know how to change jagged aray to List and time did not allow me to do this.

### Authour
* Asuka Hanada
