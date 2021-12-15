The main idea of this is to mimic a Monopoly board with player automation.

There are 4 types of players:
1. Random Player -> The random player buy any property with a random possibility of 50%
2. Picky Player -> The pick player only buy properties that the Rent Value is greater than 50 coins
3. Cautious Player -> The cautious player only buy properties if after paying for the property his bank account has at least 80 coins left.
4. Impulsive Player -> The impulsive player buy everything.

The gameconfig.txt has the board property values for buying and renting.
 
This solutions is based on .net core 2.0. Please install it to compile and run the solution

1. Open the solution folder (BankruptTapps\BankruptTapps) on the cmd 
2. dotnet restore
3. dotnet run

Optional

Unit Test 
1. Open the solution folder (BankruptTapps\UnitTestBankruptTapps) on the cmd
2. dotnet restore
3. dotnet run test


Log
The log verbosity can be changed in nlog.config
