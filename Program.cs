﻿// the ourAnimals array will store the following: 
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";
string suggestedDonation = ""; 

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";
decimal decimalDonation = 0.00m;

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 7];

// TODO: Convert the if-elseif-else construct to a switch statement

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            suggestedDonation = "85.00";
            break;
        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            suggestedDonation = "49.99";
            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            suggestedDonation = "40.00";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
    ourAnimals[i, 6] = "Suggested Donation: " + suggestedDonation;

    //Ensure that suggestedDonation is a valid decimal number if it doesnt, assign default value 45.00
    if(!decimal.TryParse(suggestedDonation, out decimalDonation)){
        decimalDonation = 45.00m;
    }

    //decimal donation version of the data
    ourAnimals[i,6] = $"Suggested Donation: {decimalDonation:C2}";
}

// display the top-level menu options

do
{

    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    // Console.WriteLine($"You selected menu option {menuSelection}.");
    // Console.WriteLine("Press the Enter key to continue");

    // // pause code execution
    // readResult = Console.ReadLine();

    switch (menuSelection)
    {
        case "1":
            // List all of our current pet information
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 7; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "2":
            // Add a new animal friend to the ourAnimals array
            string anotherPet = "y";
            int petCount = 0;
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount += 1;
                }
            }

            if (petCount < maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
            }

            while (anotherPet == "y" && petCount < maxPets)
            {
                bool validEntry = false;

                // get species (cat or dog) - string animalSpecies is a required field 
                do
                {
                    Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower();
                        if (animalSpecies != "dog" && animalSpecies != "cat")
                        {
                            validEntry = false;
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }
                } while (validEntry == false);
                // build the animal the ID number - for example C1, C2, D3 (for Cat 1, Cat 2, Dog 3)
                animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                // get the pet's age. can be ? at initial entry.
                do
                {
                    int petAge;
                    Console.WriteLine("Enter the pet's age or enter ? if unknown");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalAge = readResult;
                        if (animalAge != "?")
                        {
                            validEntry = int.TryParse(animalAge, out petAge);
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }
                } while (validEntry == false);


                // get a description of the pet's physical appearance/condition - animalPhysicalDescription can be blank.
                do
                {
                    Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPhysicalDescription = readResult.ToLower();
                        if (animalPhysicalDescription == "")
                        {
                            animalPhysicalDescription = "tbd";
                        }
                    }
                } while (animalPhysicalDescription == "");

                // get a description of the pet's personality - animalPersonalityDescription can be blank.
                do
                {
                    Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPersonalityDescription = readResult.ToLower();
                        if (animalPersonalityDescription == "")
                        {
                            animalPersonalityDescription = "tbd";
                        }
                    }
                } while (animalPersonalityDescription == "");

                // get the pet's nickname. animalNickname can be blank.
                do
                {
                    Console.WriteLine("Enter a nickname fot the pet");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalNickname = readResult.ToLower();
                        if (animalNickname == "")
                        {
                            animalNickname = "tdb";
                        }
                    }
                } while (animalNickname == "");

                // store the pet information in the ourAnimals array (zero based)
                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;


                // increment petCount (the array is zero-based, so we increment the counter after adding to the array)
                petCount = petCount + 1;

                // check maxPet limit
                if (petCount < maxPets)
                {
                    // another pet?
                    Console.WriteLine("Do you want to enter info for another per (y/n)");

                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }
                    } while (anotherPet != "y" && anotherPet != "n");
                }
            }

            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
            }
            break;

        case "3":
            // Ensure animal ages and physical descriptions are complete
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    //Ensure that a valid numeric value is asigned to animalAge
                    int newAge;
                    int found = ourAnimals[i, 2].IndexOf(": ");
                    bool validAge = int.TryParse(ourAnimals[i, 2].Substring(found + 2), out newAge);
                    if (!validAge)
                    {
                        do
                        {
                            Console.WriteLine("\nEnter an age for " + ourAnimals[i, 0].ToString());
                            readResult = Console.ReadLine();
                            validAge = int.TryParse(readResult, out newAge);
                            if (validAge)
                            {
                                ourAnimals[i, 2] = "Age: " + newAge.ToString();
                            }
                        } while (validAge == false);
                    }

                    //Ensure that a valid string is asigned to animalPhysicalDescription
                    found = ourAnimals[i, 4].IndexOf(": ");
                    bool lengthValue = string.IsNullOrEmpty(ourAnimals[i, 4].Substring(found + 2));
                    bool validEntry = false;
                    if (lengthValue)
                    {
                        do
                        {
                            Console.WriteLine("\nEnter a physical description for " + ourAnimals[i, 0].ToString() + " (size, color, breed, gener, weight, housebroken)");
                            readResult = Console.ReadLine();
                            validEntry = string.IsNullOrEmpty(readResult);
                            if (!validEntry)
                            {
                                ourAnimals[i, 4] = "Pysical description: " + readResult;
                                lengthValue = false;
                            }
                        } while (lengthValue);
                    }
                }
            }
            Console.WriteLine("\nAge and phisical description fields are complete for all of our friends.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "4":
            // Ensure that pet nicknames and personality descriptions are complete
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    // Ensure that pet nicknames are complete
                    int found = ourAnimals[i, 3].IndexOf(": ");
                    bool nickNameValue = string.IsNullOrEmpty(ourAnimals[i, 3].Substring(found + 2));
                    if (nickNameValue)
                    {
                        do
                        {
                            Console.WriteLine("Enter a nickname for " + ourAnimals[i, 0].ToString());
                            readResult = Console.ReadLine();
                            bool validEntry = string.IsNullOrEmpty(readResult);

                            if (readResult != null && !validEntry)
                            {
                                ourAnimals[i, 3] = "Nickname: " + readResult;
                                nickNameValue = false;
                            }
                        } while (nickNameValue);
                    }

                    // Ensure that personality descriptions are complete

                    found = ourAnimals[i, 5].IndexOf(": ");
                    bool personalityValue = string.IsNullOrEmpty(ourAnimals[i,5].Substring(found + 2));
                    if (personalityValue)
                    {   
                        do
                        {
                        Console.WriteLine("Enter a personality description for " + ourAnimals[i, 0].ToString() + "(likes or dislike, tricks, energy level)");
                        readResult = Console.ReadLine();
                        bool validEntry = string.IsNullOrEmpty(readResult);

                        if (readResult != null && !validEntry)
                        {
                            ourAnimals[i, 5] = "Personality: " + readResult;
                            personalityValue = false;
                        }
                        }while(personalityValue);
                    }
                }
            }
            Console.WriteLine("\nNickname and personality description fields are complete for all of our friends.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "5":
            // Ensure animal ages and physical descriptions are complete
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "6":
            // Ensure animal ages and physical descriptions are complete
            Console.WriteLine("this app feature is coming soon - please check back to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "7":
            // Display all cats with a specified characteristic
            Console.WriteLine("this app feature is coming soon - please check back to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "8":
            // Display all dogs with a specified characteristic
            string dogCharacteristic = "";
            string[] dogManyChars = new string[1];
            while (dogCharacteristic == "")
            {
                // have the user enter physical characteristic to search for
                Console.WriteLine($"\nEnter dog characteristic to search for separated by commas");
                readResult = Console.ReadLine();
                if(readResult != null)
                {
                    dogCharacteristic = readResult.ToLower().Trim();
                    string[] splitChar = dogCharacteristic.Split(',');
                    Array.Sort(splitChar);
                    dogManyChars = splitChar;
                    Array.Resize(ref dogManyChars, splitChar.Length);
                }
            }
            // loop through the ourAnimals array to search for matching animals
            string dogDescription = "";
            string dogOneCharacteristic = "";
            bool noMatchesDog = true;
            // #4 update to "rotating" animation with countdown
            string[] searchingIcons = {"/ 2", "- 2", "\\ 1","| 1","/ 0"};
            Console.WriteLine("");
            for (int i = 0; i < maxPets; i++)
            {
                if(ourAnimals[i,1].Contains("dog"))
                {
                    //Search combined descriptions and report results
                    dogDescription = ourAnimals[i,4] + "\n" + ourAnimals[i,5];
                    
                    for (int j = 0; j < dogManyChars.Length; j++)
                    {
                        dogOneCharacteristic = dogManyChars[j];
                        // #5 update "searching" message to show countdown 
                        foreach (string icon in searchingIcons)
                        {
                            Console.Write($"\rsearching our dog {ourAnimals[i,3]} for {dogOneCharacteristic} {icon}");
                            Thread.Sleep(350);
                        }
                        Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                        if (dogDescription.Contains(dogOneCharacteristic))
                        {
                        Console.WriteLine($"\rOur Dog {ourAnimals[i,3]} is a match for a {dogOneCharacteristic}!");
                        noMatchesDog = false;
                        }
                        
                    }
                    if(!noMatchesDog){
                    Console.WriteLine($"\n{ourAnimals[i,3]} ({ourAnimals[i,0]})\n{dogDescription}\n");
                    }
                }
            }
            if(noMatchesDog){ 
                Console.WriteLine("\rNone of our dogs are a match found for: " + dogCharacteristic + '\n');
            }

            Console.Write("Press the Enter key to continue");
            readResult = Console.ReadLine();
            break;

        default:
            break;

    }

} while (menuSelection != "exit");
