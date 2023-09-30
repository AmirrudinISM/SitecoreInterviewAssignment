using SitecoreAssignment;

//TASK 1
/**
Console.Write("Enter number of figures to create: ");
int numOfFigures = Convert.ToInt32(Console.ReadLine());

Aggregation aggregation = new Aggregation(numOfFigures);
Console.WriteLine("================= Figures Created ================");
aggregation.printInfo();

Console.Write("Enter number of units to move horizontally (X): ");
int xMove = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter number of units to move vertically (Y): ");
int yMove = Convert.ToInt32(Console.ReadLine());
aggregation.move(xMove, yMove);
Console.WriteLine("================= Agggregation Moved ================");
aggregation.printInfo();


Console.Write("Enter angle to rotate (negative value for counter-clockwise): ");
int rotateAngle = Convert.ToInt32(Console.ReadLine());
aggregation.rotate(rotateAngle);
Console.WriteLine("================= Agggregation Rotated ================");
aggregation.printInfo();

**/

//Task_2 palindrome = new Task_2();
//Console.WriteLine(palindrome.checkPalindrome("ra^$%c}$eca@r"));

// Task 3

                    // 0    1    2    3    4    5    6    7    8    9
char[,] grid =  {   { '0', '0', '0', '0', '*', '0', '*', '0', '0', '*' },//0
                    { '0', '*', '*', '0', '*', '*', '*', '0', '0', '*' },//1
                    { '0', '0', '*', '*', '0', '0', '*', '*', '*', '*' },//2
                    { '0', '0', '*', '0', '0', '0', '*', '0', '0', '0' },//3
                    { '*', '0', '*', '0', 'd', '0', '*', '*', '*', '0' },//4
                    { '*', '0', '*', '0', '*', '0', '*', '*', '0', '*' },//5
                    { 's', '0', '*', '0', '*', '0', '*', '*', '0', '*' },//6
                    { '0', '*', '0', '0', '0', '*', '*', '0', '*', '0' },//7
                    { '0', '0', '0', '0', '*', '*', '*', '*', '0', '*' },//8
                    { '0', '0', '0', '*', '*', '*', '*', '*', '*', '*' }};//9

/**
char[,] grid = {    {'*','s','0','0','*' },
                    {'0','0','*','0','*' },
                    {'*','0','0','*','0' },
                    {'0','*','0','*','0' },
                    {'*','0','d','*','*' },};
**/ 
Console.WriteLine(GFG.minDistance(grid, 10, 10));

