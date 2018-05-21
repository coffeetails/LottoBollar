using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoBollar {
    class Program {
        static void Main(string[] args) {
            //      DEFINING SOME DATA
            int[] guessedNumbersByUserInput = new int[10];

            Random randomNumber = new Random();
            int winningNumber = randomNumber.Next(1, 25);
            //Console.WriteLine("winningNumber: " + winningNumber); // Debug info

            bool isItAWin = false;
            int userInput = 0;

            //      INTRO
            Console.WriteLine("=== Välkommen till Lotto === \n" +
                              "Här kan med stort nöje \n" +
                              "spela om att hitta de \n" +
                              "gyllende talet. Lycka till! \n");


            //      INPUT FROM USER
            for(int i = 0; i < 10; i++) {
                bool validInputData = false;
                do {
                    Console.Write("Välj ett tal mellan 1 och 25: ");
                    try {
                        userInput = Convert.ToInt32(Console.ReadLine());
                        validInputData = true;
                    }
                    catch(FormatException) {
                        Console.WriteLine("Var snäll och skriv endast heltal \n");
                    }
                    catch(Exception ex) {
                        Console.WriteLine(ex.Message + "\n");
                    }
                } while(validInputData == false);

                //Checks if the number has been written before
                if(userInput >= 1 && userInput <= 25) {
                    //Console.WriteLine("Siffra 1 till 25? Bra. Bokstav? Ohshit."); // Debug info
                    bool guessedBefore = false;

                    for(int j = 0; j < 10; j++) {
                        if(guessedNumbersByUserInput[j] == userInput) {
                            guessedBefore = true;
                            Console.WriteLine("Du har redan gissat på det talet \n");
                            i--;
                            break;
                        }
                    }

                    if (!guessedBefore) {
                        guessedNumbersByUserInput[i] = userInput;   // If the number is unique it will be added to the element
                    }

                }
                else if(userInput < 1 && userInput > int.MinValue) {
                    Console.WriteLine("Talet måste vara 1 eller högre \n");
                    i--;
                }
                else if(userInput > 25 && userInput < int.MaxValue) {
                    Console.WriteLine("Talet måste vara 25 eller lägre \n");
                    i--;
                }
            }


            //      OUTPUT AND WIN/LOSE RESULT
            Console.WriteLine("\nDu har valt följande tal:");

            //  Checks if there is a matching number, a win.
            for(int i = 0; i < 10; i++) {
                if(guessedNumbersByUserInput[i] == winningNumber) {
                    isItAWin = true;
                }
                Console.Write(guessedNumbersByUserInput[i] + " ");
            }
            
            if(isItAWin == true) {
                Console.WriteLine("\nDu hittade det gyllende talet; {0}!", winningNumber);
            }
            else {
                Console.WriteLine("\nDu hitta den inte denna gången...");
            }

            Console.ReadKey();
        }
    }
}
