# Assignment 1 - Sorting Algorithms
*cc211040 | Nathalie Klinger | BCC SS23*

## About the project

Our Assignment was to solve the Problem of the Tower of Hanoi with Recursion and Iteration. The program is written in C-Sharp and works in the Console. The Recursion works fine, the iterative way has an error which I couldn't fix in time.

## Getting Started

**.NET 6 needs to be installed!**

To build the app, unzip the file and open the Program.cs. 
Open the Console and type dotnet run with either **hanoi-recursive** or **hanoi-iterative** with the number of disks as int.


## Roadmap

### What has been implemented

#### Recursion

MoveDisksRecursive() is a method that initiates the recursive solving. It calls the second method MoveDisksRecursive(), passes the initial state of the sticks and number of disks to be moved and the indices of the fromStick and toStick.

The second method is actually the one that performs the actual recursive solving. It takes 4 parameters, which are the current state of the sticks, the number of disks remaining, and the indices of the fromStick and toStick.

The method checks if there is only one disk remaining to be moved. If so, it simply calls the MoveDisk() method to move that last disk from the fromStick to the toStick.

If there is more than one disk remaining, the method defines a third stick, as the stick that is neither the fromStick nor the toStick. It then makes a recursive call to itself, passing the initial state of the sticks, the number of disks remaining minus one, the fromStick, and the auxStick.

Once that recursive call returns, the method calls MoveDisk() to move the bottom disk from the fromStick to the toStick.

The recursive sorting continues until there is only one disk remaining, at which point the last disk is moved directly from the fromStick to the toStick.

##### Iteration
The Iteration also uses the MoveDisk() Method. The Main method for the Iteration is MoveDisksIterative(). It first calculates the total number of moves required to solve, using the formula 2^n - 1, where n is the number of disks. 

Afterwards it determines the order in which the disks should be moved based on if the number of disks is even or odd. The method then loops through each move and calls MoveDisk() with the appropriate stick indices. Finally, it increments a move counter each time a disk is moved.

##### Challenges
I had to fight with the Iteration for days because I had an error I couldn't find. Thankfully I managed to still find it in the end, but it felt like a battle. Since I had to spend so much time on the iterative Solution I didn't spend any time in looking into the ASCII art.


## Contact

Nathalie Klinger
cc211040@fhstp.ac.at
FH St. Pölten