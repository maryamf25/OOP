using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAppconversion
{

    internal class BusinessAppConversio1
    {
        // STOI function
        static public string[] stringArray = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        static public int[] intArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        static int STOI(string num)
        {
            int integer=0;
            for (int i = 0; i < 10; i++)
            {
                if (num == stringArray[i])
                {
                    integer = i;
                }
            }
           
            return intArray[integer];
        }
        static void Main(string[] args)
        {
            // login SCreen
            string Option;
            // signUp Variables
            string[] ThreeUsers = { "Admin", "Customer", "Veterinarian" };
            string Username = "";
            string Password = "";
            string role = "";
            int Role = 0;
            int countUser = 0;
            string[] ValidUsername = new string[100];
            string[] ValidPassword = new string[100];
            string[] ValidRole = new string[100];
            int[] Roles = new int[100];
            bool signUpValidity;
            string SignUpFile = "signUp.txt";
            loadSignUpDetails(ThreeUsers, ValidUsername, ValidPassword, ValidRole, Roles, ref countUser, SignUpFile);

            // Signin
            string signInUserName="";
            string signInPassword="";
            int idx = 0;
            int valididx = 0;

            // Approved Users
            int signUpcount = 0;
            string[] ApprovalStatus = new string[100];
            string[] ApprovedRoles = new string[100];
            string[] ApprovedUsers = new string[100];
            string[] ApprovedPwd = new string[100];
            int approved = 0;
            int unapproved = 0;
            int useridx = 0;
            string ApprovedFile = "Approved.txt";
            loadApprovedUsers(ApprovalStatus, ApprovedUsers, ApprovedPwd, ApprovedRoles, ref signUpcount, ApprovedFile);


            // customer details
            string[] CustomerName = new string[100];
            string[] CustomerPassword = new string[100];
            int customeridx = 0;
            int countCustomers = 0;
            string CustomerFile = "Customer.txt";
            loadCustomerDetails(ThreeUsers, CustomerName, CustomerPassword, ref countCustomers, CustomerFile);


            // Appointment Details
            int AppointmentsCount = 0;
            int Appointmentidx = -1;
            string[] DoctorName = new string[100];
            string[] TimeAppointed = new string[100];
            string[] DoctorAppointed = new string[100];
            string[] DayAppointed = new string[100];
            string[] BookedForPet = new string[100];
            string[] Veterinarians = { "Dermatology", "Primary Care", "Internal Medicine" };
            string[] PetOwnerName = new string[100];
            string[] PetOwnerNumber = new string[100];
            string[] PetOwnerEmail = new string[100];
            string[] PetOwnerLocation = new string[100];
            string[] PetTypeForAppointment = new string[100];
            string[] PetName = new string[100];
            string[] PetAge = new string[100];
            string[] PetGender = new string[100];
            string[] PetWeight = new string[100];
            string[] Doctor = new string[100];
            string[] Time = new string[100];
            string[] Day = new string[100];
            string[] BookedBy = new string[100];
            string[] BookedByPassword = new string[100];
            int SelectDoctorType = 0;
            int SelectDay = 0;
            int SelectedTime = 0;
            int condition = 0;
            int Bookingidx = 0; // bookingIndexNumber
            int Total = 0;      // calculating total appointments by one user
            string[] AppointmentBookOrPending = new string[100];
            string AppointmentFile = "CustomerAppointments.txt";
            loadCustomerAppointments(PetOwnerName, PetOwnerNumber, PetOwnerEmail, PetOwnerLocation,
                         PetTypeForAppointment, PetName, PetAge, PetGender, PetWeight,
                         Doctor, AppointmentBookOrPending, ref AppointmentsCount, BookedBy,
                         BookedByPassword, DoctorAppointed, DayAppointed, AppointmentFile);


            // Vet Details
            string VetFile = "Vet.txt";
            string[] AvailableService = { "Dermatology", "Primary Care", "Internal Medicine" };
            string[] AvailableDays = { "Monday", "Tuesday", "Wednesesday", "Thursday", "Friday", "Saturday" };
            string[] VetDays = new string[100];
            string[] VetService = new string[100];
            string[] VetName = new string[100];
            string[] VetPassword = new string[100];
            string[] VetEmail = new string[100];
            string[] VetContact = new string[100];
            string VUserName = "";
            string VPassword = "";
            string VEmail = "";
            string VContact = "";
            int VDay = 0;
            int VService=0;
            int countVeterinarians = 0;
            int countVets = 0;
            int vetidx = 0;
            int BookedAppointmentsTotal = 0;
            int PendingAppointmentsTotal = 0;
            loadVetDetails(VetName, VetPassword, VetEmail, VetContact, VetDays, VetService, ref countVets, ref countVeterinarians, VetFile);

            while (true)
            {
                printHeader();
                tagline();
                printpet();
                printLoginScreen();
                Console.SetCursorPosition(63, 28);
                Console.Write( "Enter Your Requirement: ");
                Option = Console.ReadLine();
                while (Option != "1" && Option != "2" && Option != "3")
                {
                    Console.SetCursorPosition(63, 30);
                    Console.Write( "Please Enter Correct Option! ");
                    Console.SetCursorPosition(63, 28);
                    Console.Write( "                                              ");
                    Console.SetCursorPosition(63, 28);
                    Console.Write( "Enter Your Requirement: ");
                    Option = Console.ReadLine();
                    Console.SetCursorPosition(63, 30);
                    Console.Write( "                                               ");
                }
                int option = int.Parse(Option);
                if (option == 3)
                {
                    break;
                }
                else if (option == 1)
                {
                    printHeader();
                    printBox();
                    GetSignUpDetails(ref Username,ref  Password, ref Role, ref role);
                    signUpValidity = signUp(ThreeUsers, Username, Password, Role, ValidUsername, ValidPassword, ValidRole, countUser);
                    if (signUpValidity)
                    {
                        // saving every user except admin in arrays of useres to be approved by admin
                        if (ThreeUsers[Role - 1] != "Admin")
                        {
                            ApprovalStatus[signUpcount] = "Unapproved";
                            ApprovedRoles[signUpcount] = ThreeUsers[Role - 1];
                            ApprovedUsers[signUpcount] = Username;
                            ApprovedPwd[signUpcount] = Password;
                            signUpcount++;
                            unapproved++;
                            saveApprovedUsers(ApprovalStatus, ApprovedUsers, ApprovedPwd, ApprovedRoles, ref signUpcount, ApprovedFile);
                        }
                        // saving all users in arrays
                        ValidUsername[countUser] = Username;
                        ValidPassword[countUser] = Password;
                        ValidRole[countUser] = ThreeUsers[Role - 1];
                        Roles[countUser] = Role;
                        countUser++;
                        // saving data of users to file
                        saveSignUpDetails(ValidUsername, ValidPassword, Roles, countUser, SignUpFile);

                        Console.SetCursorPosition(50, 31);
                        Console.Write( "You are signed up successfully as " + ThreeUsers[Role - 1] + "!");
                        if (ThreeUsers[Role - 1] == "Admin")
                        {
                            Console.SetCursorPosition(50, 33);
                            Console.Write( "Press any key to continue......");
                            Console.ReadKey();
                        }
                        else if (ThreeUsers[Role - 1] == "Customer")
                        {
                            Console.SetCursorPosition(50, 33);
                            Console.Write( "Your Account will be Activated after Admin Approval!");
                            Console.SetCursorPosition(50, 35);
                            Console.Write( "Press any key to continue......");
                            Console.ReadKey();
                            CustomerName[countCustomers] = Username;
                            CustomerPassword[countCustomers] = Password;
                            countCustomers++;
                            checkindex(countCustomers, ref customeridx, Username, Password, CustomerName, CustomerPassword);
                            // saving data of customers to file
                            saveCustomerDetails(CustomerName, CustomerPassword, ref countCustomers, CustomerFile);
                        }
                        else if (ThreeUsers[Role - 1] == "Veterinarian")
                        {
                            countVeterinarians++;
                            VetName[countVets] = ValidUsername[countUser - 1];
                            VetPassword[countVets] = ValidPassword[countUser - 1];
                            Console.SetCursorPosition(60, 33);
                            Console.Write( "Let's create a profile first!");
                            Console.SetCursorPosition(60, 35);
                            Console.Write( "Press any key to continue......");
                            Console.ReadKey();
                            VetHeader();
                            CreateProfile(ref VetName[countVets],ref VetPassword[countVets],ref VEmail, ref VContact,ref VDay, ref VService);
                            VetEmail[countVets] = VEmail;
                            VetContact[countVets] = VContact;
                            VetDays[countVets] = AvailableDays[VDay - 1];
                            VetService[countVets] = AvailableService[VService - 1];
                            countVets++;
                            Console.SetCursorPosition(60, 36);
                            Console.Write( "Your Account will be Activated after Admin Approval!");
                            Console.SetCursorPosition(60, 38);
                            Console.Write( "Press any key to continue......");
                            Console.ReadKey();
                            saveVetDetails(VetName, VetPassword, VetEmail, VetContact, VetDays, VetService,ref countVets,ref countVeterinarians, VetFile, DoctorAppointed, AppointmentsCount, AppointmentBookOrPending, vetidx);
                        }
                    }
                    else if (!(signUpValidity))
                    {
                        Console.SetCursorPosition(55, 31);
                        Console.Write( "This Username and Password are not available..!");
                        Console.SetCursorPosition(55, 33);
                        Console.Write( "   Press any key to continue......");
                        Console.ReadKey();
                    }
                }
                else if (option == 2)
                {
                    printHeader();
                    printBox();
                    getSignInDetails(ref signInUserName, ref signInPassword);
                    string signInValidity = signIn(signInUserName, signInPassword, Role, ValidUsername, ValidPassword, ValidRole, countUser, idx);

                    if (signInValidity == "Invalid")
                    {
                        Console.SetCursorPosition(58, 24);
                        Console.Write( "Invalid Credentials");
                        Console.SetCursorPosition(58, 26);
                        Console.Write( "Press any key to continue......");
                        Console.ReadKey();
                    }
                    else if (signInValidity == "Admin")
                    {
                        Console.SetCursorPosition(58, 24);
                        Console.Write( "You are logged in successfully as " + signInValidity + "!");
                        Console.SetCursorPosition(58, 26);
                        Console.Write( "Press any key to continue......");
                        Console.ReadKey();
                        printHeader();
                        AdminMainMenu(SignUpFile, Roles, ApprovedFile, CustomerFile, AppointmentFile, VetFile, useridx, ThreeUsers, ref countUser, idx,
                                      Username, ValidUsername, signInUserName, Password, ValidPassword, signInPassword, role,
                                      ValidRole, Option, ref countVets,ref  countCustomers, Role, vetidx, customeridx,ref AppointmentsCount,
                                      ref Appointmentidx, ref BookedAppointmentsTotal, ref PendingAppointmentsTotal, ref countVeterinarians, CustomerName,
                                      CustomerPassword, TimeAppointed,
                                      DoctorAppointed, DayAppointed, DoctorName, BookedForPet, Veterinarians,
                                      PetOwnerName, PetOwnerNumber, PetOwnerEmail, PetOwnerLocation, PetTypeForAppointment,
                                      PetName, PetAge, PetGender, PetWeight, Doctor, Time, Day,
                                      BookedBy, BookedByPassword, ref Bookingidx, ref Total, AppointmentBookOrPending, AvailableService,
                                      AvailableDays, VetDays, VetService, VetName, VetPassword, VetEmail,
                                      VetContact, VUserName, VPassword, VEmail, VContact, ApprovalStatus, ApprovedRoles,
                                      ApprovedUsers, ApprovedPwd, ref signUpcount, ref approved, ref unapproved);
                    }
                    else if (signInValidity == "Customer")
                    {

                        checkindex(signUpcount, ref useridx, signInUserName, signInPassword, ApprovedUsers, ApprovedPwd);
                        if (ApprovalStatus[useridx] == "Approved")
                        {
                            Console.SetCursorPosition(58, 24);
                            Console.Write( "You are logged in successfully as " + signInValidity + "!");
                            Console.SetCursorPosition(58, 26);
                            Console.Write( "Press any key to continue......");
                            Console.ReadKey();
                            checkindex(countCustomers, ref customeridx, signInUserName, signInPassword, CustomerName, CustomerPassword);
                            CustomerMainMenu(ValidUsername, ref BookedAppointmentsTotal, ref PendingAppointmentsTotal, Appointmentidx, Total, Bookingidx, countCustomers, customeridx, countUser, ThreeUsers, TimeAppointed,
                                             DoctorAppointed, DayAppointed, BookedForPet, Veterinarians, PetOwnerName, PetOwnerNumber, PetOwnerEmail, PetOwnerLocation, PetTypeForAppointment, PetName, PetAge,
                                             PetGender, PetWeight, Doctor, DoctorName, Time, Day, SelectDoctorType, SelectDay, SelectedTime, condition, ref AppointmentsCount, AppointmentBookOrPending, CustomerName,
                                             CustomerPassword, BookedBy, BookedByPassword, AppointmentFile, VetName, VetPassword, VetEmail, VetContact, VetDays,
                                             VetService, ref countVets, ref countVeterinarians, VetFile, vetidx);
                        }
                        else
                        {
                            Console.SetCursorPosition(60, 24);
                            Console.Write( "Your Account is not Approved By Admin");
                            Console.SetCursorPosition(60, 26);
                            Console.Write( "Press any key to continue......");
                            Console.ReadKey();
                        }
                    }
                    else if (signInValidity == "Veterinarian")
                    {
                        checkindex(signUpcount, ref useridx, signInUserName, signInPassword, ApprovedUsers, ApprovedPwd);
                        checkindex(countUser, ref valididx, signInUserName, signInPassword, ValidUsername, ValidPassword);
                        if (ApprovalStatus[useridx] == "Approved")
                        {
                            Console.SetCursorPosition(55, 24);
                            Console.Write( "You are logged in successfully as " + signInValidity + "!");
                            Console.SetCursorPosition(56, 26);
                            Console.Write( "Press any key to continue......");
                            Console.ReadKey();
                            checkindex(countVets, ref vetidx, signInUserName, signInPassword, VetName, VetPassword);
                            VetMainMenu(signInUserName, CustomerName, signInPassword, ValidRole, valididx, useridx, ref BookedAppointmentsTotal, ref PendingAppointmentsTotal, vetidx, ValidUsername, ValidPassword, ref countUser, idx,
                                        ThreeUsers, ref countVets, VetName, VetPassword, VetEmail, VetContact, VetDays, VetService,
                                        AvailableDays, AvailableService, DoctorAppointed, DayAppointed, DoctorName, PetOwnerName,
                                        PetOwnerNumber, PetOwnerEmail, PetOwnerLocation, PetTypeForAppointment, PetName, PetAge, PetGender,
                                        PetWeight, Doctor, Time, Day, ref AppointmentsCount, AppointmentBookOrPending, BookedBy,
                                        VetFile, ref countVeterinarians, BookedByPassword, AppointmentFile, SignUpFile, Roles, ApprovalStatus, ApprovedUsers,
                                        ApprovedPwd, ApprovedRoles, ref signUpcount, ApprovedFile, customeridx);
                        }

                        else
                        {
                            Console.SetCursorPosition(60, 24);
                            Console.Write( "Your Account is not Approved By Admin");
                            Console.SetCursorPosition(60, 26);
                            Console.Write( "Press any key to continue......");
                            Console.ReadKey();
                        }
                    }
                }
            }

        }
        
        static string parseData(string line, int field)
        {
            
            string item = "";
            int commaCount = 1;
            int length = line.Length;
            for (int x = 0; x < length; x++)
            {
                if (line[x] == ',')
                {
                    commaCount++;
                }
                else if (field == commaCount)
                {
                    item += line[x];
                }
            }
            
            return item;
        }
        static void loadSignUpDetails(string[] ThreeUsers, string[] ValidUsername, string[] ValidPassword, string[] ValidRole, int[] Roles, ref int countUser, string SignUpFile)
        {
            string line = "";
           
            int x = 0;
            string Username, Password;
            
            if (File.Exists(SignUpFile))
            {
                StreamReader fileVariable = new StreamReader(SignUpFile);
                while ((line = fileVariable.ReadLine()) != null)
                {
                    Username = parseData(line, 1);
                    Password = parseData(line, 2);
                    string r = parseData(line, 3);
                    
                    int Role = STOI(r);
                  
                    Roles[x] = Role;
                    ValidUsername[x] = Username;
                    ValidPassword[x] = Password;
                    ValidRole[x] = ThreeUsers[Role-1];
                    
                    x++;
                }
                countUser = x;
                fileVariable.Close();
            }
            else
            {
                Console.Write("File does not exist!");
            }
        }
        static void loadApprovedUsers(string[] ApprovalStatus, string[] ApprovedUsers, string[] ApprovedPwd, string[] ApprovedRoles, ref int signUpcount, string ApprovedFile)
        {
            string line = "";
            
            int x = 0;
            string Status, Username, Password, Role;
            if (File.Exists(ApprovedFile))
            {
                StreamReader fileVariable = new StreamReader(ApprovedFile);
                while ((line = fileVariable.ReadLine()) != null)
                {

                    Status = parseData(line, 1);
                    Username = parseData(line, 2);
                    Password = parseData(line, 3);
                    Role = parseData(line, 4);

                    ApprovalStatus[x] = Status;
                    ApprovedUsers[x] = Username;
                    ApprovedPwd[x] = Password;
                    ApprovedRoles[x] = Role;
                    x++;
                }
                signUpcount = x;
                fileVariable.Close();

            }
            else
            {
                Console.Write("File does not exist!");
            }
        }
        static void loadCustomerDetails(string[] ThreeUsers, string[] CustomerName, string[] CustomerPassword, ref int countCustomers, string CustomerFile)
        {
            string line = "";
            
            int x = 0;
            string Name, Password;
            if (File.Exists(CustomerFile))
            {
                StreamReader fileVariable = new StreamReader(CustomerFile);
                while ((line = fileVariable.ReadLine()) != null)
                {

                    Name = parseData(line, 1);
                    Password = parseData(line, 2);
                    CustomerName[x] = Name;
                    CustomerPassword[x] = Password;
                    x++;
                }
                countCustomers = x;
                fileVariable.Close();
            }
            else
            {
                Console.Write("File does not exist!");
            }
        }
        static void loadCustomerAppointments(string[] PetOwnerName, string[] PetOwnerNumber, string[] PetOwnerEmail, string[] PetOwnerLocation, string[] PetTypeForAppointment, string[] PetName, string[] PetAge, string[] PetGender, string[] PetWeight, string[] Doctor, string[] AppointmentBookOrPending, ref int AppointmentsCount, string[] BookedBy, string[] BookedByPassword, string[] DoctorAppointed, string[] DayAppointed, string AppointmentFile)
        {
            string line = "";
            int x = 0;
            string Name, Number, Email, Location, TypeOfPet, petName, Age, Gender, weight, DoctorNumber, status, bookedby, password, AppointedDoctor, AppointedDay;
            
            if (File.Exists(AppointmentFile))
            {
                StreamReader fileVariable = new StreamReader(AppointmentFile);
                while ((line = fileVariable.ReadLine()) != null)
                {
                    Name = parseData(line, 1);
                    Number = parseData(line, 2);
                    Email = parseData(line, 3);
                    Location = parseData(line, 4);
                    TypeOfPet = parseData(line, 5);
                    petName = parseData(line, 6);
                    Age = parseData(line, 7);
                    Gender = parseData(line, 8);
                    weight = parseData(line, 9);
                    DoctorNumber = parseData(line, 10);
                    status = parseData(line, 11);
                    bookedby = parseData(line, 12);
                    password = parseData(line, 13);
                    AppointedDoctor = parseData(line, 14);
                    AppointedDay = parseData(line, 15);
                    PetOwnerName[x] = Name;
                    PetOwnerNumber[x] = Number;
                    PetOwnerEmail[x] = Email;
                    PetOwnerLocation[x] = Location;
                    PetTypeForAppointment[x] = TypeOfPet;
                    PetName[x] = petName;
                    PetAge[x] = Age;
                    PetGender[x] = Gender;
                    PetWeight[x] = weight;
                    Doctor[x] = DoctorNumber;
                    AppointmentBookOrPending[x] = status;
                    BookedBy[x] = bookedby;
                    BookedByPassword[x] = password;
                    DoctorAppointed[x] = AppointedDoctor;
                    DayAppointed[x] = AppointedDay;
                    x++;
                }
                AppointmentsCount = x;
                fileVariable.Close();
            }
            else
            {
                Console.Write("File does not exist!");
            }
        }
        static void loadVetDetails(string[] VetName, string[] VetPassword, string[] VetEmail, string[] VetContact, string[] VetDays, string[] VetService, ref int countVets, ref int countVeterinarians, string VetFile)
        {
            string line = "";
            int x = 0;
            
            string Name, Password, Email, Contact, Day, Service;
            if (File.Exists(VetFile))
            {
                StreamReader fileVariable = new StreamReader(VetFile);
                while ((line = fileVariable.ReadLine()) != null)
                {
                    Name = parseData(line, 1);
                    Password = parseData(line, 2);
                    Email = parseData(line, 3);
                    Contact = parseData(line, 4);
                    Day = parseData(line, 5);
                    Service = parseData(line, 6);
                    VetName[x] = Name;
                    VetPassword[x] = Password;
                    VetEmail[x] = Email;
                    VetContact[x] = Contact;
                    VetDays[x] = Day;
                    VetService[x] = Service;
                    x++;
                }
                countVets = x;
                countVeterinarians = x;
                fileVariable.Close();

            }
            else
            {
                Console.Write("File does not exist!");
            }
        }
        // Printing Functions
        static void printHeader()
        {
            Console.Clear();
            Console.SetCursorPosition(1, 1);
            Console.Write("*************************************************************************************************************************************************************************** ");

            Console.SetCursorPosition(1, 2);
            Console.Write("___________________________________________________________________________________________________________________________________________________________________________  ");

            Console.SetCursorPosition(1, 4);
            Console.Write("                                             :::::::::       ::::::::::   :::::::::::       :::::::::           :::        :::                                 ");

            Console.SetCursorPosition(1, 5);
            Console.Write("                                            :+:    :+:      :+:              :+:           :+:    :+:        :+: :+:      :+:           (\\___/)             ");

            Console.SetCursorPosition(1, 6);
            Console.Write("                                           +:+    +:+      +:+              +:+           +:+    +:+       +:+   +:+     +:+            (_^-^ )__            ");

            Console.SetCursorPosition(1, 7);
            Console.Write("                                          +#++:++#+       +#++:++#         +#+           +#++:++#+       +#++:++#++:    +#+               /      _\\~~        ");

            Console.SetCursorPosition(1, 8);
            Console.Write("                                         +#+             +#+              +#+           +#+             +#+     +#+    +#+                \\/''\\/            ");

            Console.SetCursorPosition(1, 9);
            Console.Write("                                        #+#             #+#              #+#           #+#             #+#     #+#    #+#");

            Console.SetCursorPosition(1, 10);
            Console.Write("                                       ###             ##########       ###           ###             ###     ###    ##########");

            Console.SetCursorPosition(1, 12);
            Console.Write("___________________________________________________________________________________________________________________________________________________________________________  ");

            Console.SetCursorPosition(1, 14);
            Console.Write("***************************************************************************************************************************************************************************  ");
        }
        static void tagline()
        {
            Console.SetCursorPosition(1, 16);
            Console.Write("                                                          \"BECAUSE THE PETS DESERVE THE BEST!\"                                                                   ");
        }
        static void printpet()
        {
            Console.SetCursorPosition(5, 25);
            Console.Write("             ()_()   ");
            Console.SetCursorPosition(5, 26);
            Console.Write("             (^-^)   ");
            Console.SetCursorPosition(5, 27);
            Console.Write("         _____---    ");
            Console.SetCursorPosition(5, 28);
            Console.Write("       ~(     /  )   ");
            Console.SetCursorPosition(5, 29);
            Console.Write("         --------    ");
            Console.SetCursorPosition(5, 30);
            Console.Write("          \\/  \\/   ");
        }

        static void printBox()
        {
            Console.SetCursorPosition(50, 18);
            Console.Write("[][][][][][][][][][][][][][][][][][][][][][][][][][][]");
            Console.SetCursorPosition(50, 19);
            Console.Write("[]                                                  []");
            Console.SetCursorPosition(50, 20);
            Console.Write("[]                                                  []");
            Console.SetCursorPosition(50, 21);
            Console.Write("[]                                                  []");
            Console.SetCursorPosition(50, 22);
            Console.Write("[]                                                  []");
            Console.SetCursorPosition(50, 23);
            Console.Write("[]                                                  []");
            Console.SetCursorPosition(50, 24);
            Console.Write("[]                                                  []");
            Console.SetCursorPosition(50, 25);
            Console.Write("[]                                                  []");
            Console.SetCursorPosition(50, 26);
            Console.Write("[]                                                  []");
            Console.SetCursorPosition(50, 27);
            Console.Write("[]                                                  []");
            Console.SetCursorPosition(50, 28);
            Console.Write("[]                                                  []");
            Console.SetCursorPosition(50, 29);
            Console.Write("[]                                                  []");
            Console.SetCursorPosition(50, 30);
            Console.Write("[][][][][][][][][][][][][][][][][][][][][][][][][][][]");
        }
        static void printLoginScreen()
        {
            Console.SetCursorPosition(55, 18);
            Console.Write("  [][][][][][][][][][][][][][][][][][][][][] ");
            Console.SetCursorPosition(55, 19);
            Console.Write("  []                                      [] ");
            Console.SetCursorPosition(55, 20);
            Console.Write("  []   1. Sign Up                         [] ");
            Console.SetCursorPosition(55, 21);
            Console.Write("  []                                      [] ");
            Console.SetCursorPosition(55, 22);
            Console.Write("  []   2. Login                           [] ");
            Console.SetCursorPosition(55, 23);
            Console.Write("  []                                      [] ");
            Console.SetCursorPosition(55, 24);
            Console.Write("  []   3. Exit                            [] ");
            Console.SetCursorPosition(55, 25);
            Console.Write("  []                                      [] ");
            Console.SetCursorPosition(55, 26);
            Console.Write("  [][][][][][][][][][][][][][][][][][][][][]  ");
        }
        // Sign Up     //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        static void GetSignUpDetails(ref string username, ref string password, ref int role, ref string roleInput)
        {
            Console.SetCursorPosition(60, 20);
            Console.Write("Enter Username: ");
            username = Console.ReadLine();

            while (username.Length == 0)
            {
                Console.SetCursorPosition(60, 24);

                Console.Write("Please Enter a valid username");


                Console.SetCursorPosition(60, 20);
                Console.Write("Enter Username: ");
                username = Console.ReadLine();
            }

            Console.SetCursorPosition(60, 22);
            Console.Write("Enter Password: ");
            password = Console.ReadLine();

            while (password.Length > 16 || password.Length < 8)
            {
                Console.SetCursorPosition(60, 24);
                Console.Write("Password must Contain 8 to 16 characters! ");
                Console.SetCursorPosition(60, 22);
                Console.Write("                                          ");
                Console.SetCursorPosition(60, 22);
                Console.Write("Enter Password: ");
                password = Console.ReadLine();
            }

            Console.SetCursorPosition(60, 24);
            Console.Write("                                         ");
            Console.SetCursorPosition(60, 24);
            Console.Write("Select Role: ");
            Console.SetCursorPosition(60, 26);
            Console.Write("1. Admin");
            Console.SetCursorPosition(60, 27);
            Console.Write("2. Customer");
            Console.SetCursorPosition(60, 28);
            Console.Write("3. Veterinarian");
            Console.SetCursorPosition(73, 24);
            roleInput = Console.ReadLine();

            while (roleInput != "1" && roleInput != "2" && roleInput != "3")
            {
                Console.SetCursorPosition(60, 31);

                Console.Write("Please Enter Correct Option");


                Console.SetCursorPosition(60, 24);
                Console.Write("                                      ");
                Console.SetCursorPosition(60, 24);
                Console.Write("Select Role: ");
                roleInput = Console.ReadLine();
            }
            role = int.Parse(roleInput);
        }
        static bool signUp(string[] ThreeUsers, string Username, string Password, int Role, string[] ValidUsername, string[] ValidPassword, string[] ValidRole, int countUser)
        {
            int j = 0;
            for (int x = 0; x < countUser; x++)
            {
                if (((Password == ValidPassword[x]) && (Username == ValidUsername[x])) || ((ThreeUsers[Role - 1] == ValidRole[x]) && (ThreeUsers[Role - 1] == "Admin")))
                {
                    j++;
                    break;
                }
            }
            if (j == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void saveSignUpDetails(string[] ValidUsername, string[] ValidPassword, int[] Roles, int countUser, string SignUpFile)
        {
            StreamWriter fileVariable = new StreamWriter(SignUpFile);
            for (int i = 0; i < countUser; i++)
            {
                fileVariable.WriteLine(ValidUsername[i]+ "," +ValidPassword[i] + "," + Roles[i]);
            }
            fileVariable.Flush();
            fileVariable.Close();
        }
        // Approval //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        static void saveApprovedUsers(string[] ApprovalStatus, string[] ApprovedUsers, string[] ApprovedPwd, string[] ApprovedRoles, ref int signUpcount, string ApprovedFile)
        {
            StreamWriter fileVariable = new StreamWriter(ApprovedFile);
            for (int i = 0; i < signUpcount; i++)
            {
                fileVariable.WriteLine($"{ApprovalStatus[i]},{ApprovedUsers[i]},{ApprovedPwd[i]},{ApprovedRoles[i]}");
            }
            fileVariable.Flush();
            fileVariable.Close();
        }
        // SignIn////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        static void getSignInDetails(ref string signInUserName, ref string signInPassword)
        {
            Console.SetCursorPosition(58, 20);
            Console.Write( "Enter Username:  ");
            signInUserName = Console.ReadLine();
            Console.SetCursorPosition(58, 22);
            Console.Write( "Enter Password:  ");
            signInPassword = Console.ReadLine();
        }
        static string signIn(string signInUserName, string signInPassword, int Role, string[] ValidUsername, string[] ValidPassword, string[] ValidRole, int countUser, int idx)
        {
            int k = 0;
            for (int x = 0; x < countUser; x++)
            {
                if ((signInUserName == ValidUsername[x]) && (signInPassword == ValidPassword[x]))
                {
                    k++;
                    idx = x;
                    break;
                }
            }
            if (k > 0)
            {
                return ValidRole[idx];
            }
            else
            {
                return "Invalid";
            }
        }
        // ADMIN    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        static void AdminHeader()
        {
            printHeader();
            Console.SetCursorPosition(1, 15);
            Console.Write("___________________________________________________________________________________________________________________________________________________________________________");

            Console.SetCursorPosition(0, 17);
            Console.Write( "                                                                ``.....    A d m i n   .....``");

            Console.SetCursorPosition(1, 18);
            Console.Write( "___________________________________________________________________________________________________________________________________________________________________________");
        }
        static int PrintAdminMenu()
        {
            Console.SetCursorPosition(1, 17);
            Console.Write( "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------" );
            Console.SetCursorPosition(71, 19);
            Console.Write( "1. Add Users");
            Console.SetCursorPosition(71, 21);
            Console.Write( "2. View Users");
            Console.SetCursorPosition(71, 23);
            Console.Write( "3. Delete Users");
            Console.SetCursorPosition(71, 25);
            Console.Write( "4. Appointments");
            Console.SetCursorPosition(71, 27);
            Console.Write( "5. Logout");
            Console.SetCursorPosition(1, 29);
            Console.Write( "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------") ;
            Console.SetCursorPosition(71, 31);
            Console.Write( "Enter Your Requirement: ");
            string Option;
            Option = Console.ReadLine();
            while (Option != "1" && Option != "2" && Option != "3" && Option != "4" && Option != "5")
            {
                Console.SetCursorPosition(71, 33);

                Console.Write( "Please Enter Correct Option!");
                Console.SetCursorPosition(71, 31);
                Console.Write( "                                            ");
                Console.SetCursorPosition(71, 31);
                Console.Write( "Enter Your Requirement: ");
                Option= Console.ReadLine();
                Console.SetCursorPosition(71, 33);
                Console.Write( "                                             ");
            }
            int Admin_Requirement = int.Parse(Option);
            return Admin_Requirement;
        }
        static void AddSelectedUser(ref int approved, ref int unapproved, int AddUsersOption, int countUser, string[] ApprovalStatus, string[] ApprovedRoles)
        {

            string Option;
            for (int x = 0; x < countUser; x++)
            {
                if (ApprovalStatus[x] == "Unapproved")
                {
                    AdminHeader();
                    Console.SetCursorPosition(60, 22);
                    Console.Write("User " + (x + 1) + ": " + ApprovedRoles[x]);
                    Console.SetCursorPosition(60, 24);
                    Console.Write( "Status: " + ApprovalStatus[x]);
                    Console.SetCursorPosition(60, 26);
                    Console.Write( "1. Add         2. Ignore");
                    Console.SetCursorPosition(60, 28);
                    Console.Write( "Enter Option...");
                    Option =  Console.ReadLine();
                    while (Option != "1" && Option != "2")
                    {
                        Console.SetCursorPosition(60, 30);
        
                        Console.Write("Please Enter Correct Option!");
                        Console.SetCursorPosition(60, 28);
                        Console.Write( "                                 ");
                        Console.SetCursorPosition(60, 28);
                        Console.Write( "Enter Option...");
                        Option =  Console.ReadLine();
                        Console.SetCursorPosition(60, 30);
                        Console.Write( "                                              ");
                    }
                    int option = int.Parse(Option);
                    if (option == 1)
                    {
                        approved++;
                        unapproved--;
                        ApprovalStatus[x] = "Approved";
                        Console.SetCursorPosition(60, 30);
                        
                        Console.Write( "User Added!");
                    }
                    else
                    {
                        Console.SetCursorPosition(60, 30);
        
                        Console.Write( "User Ignored!");
                    }
                    Console.SetCursorPosition(60, 32);
                    Console.Write( "Press any key to see next User...");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    continue;
                }
            }
        }
        static int ShowUsers(int countUser, string show, string[] ValidUsername, string[] ValidRole)
        {
            int z = 60;
            int y = 24;
            int i = 0;
            for (int x = 0; x < countUser; x++)
            {
                if (ValidRole[x] == show && ValidRole[x] != "Admin")
                {
                    Console.SetCursorPosition(z, y);
                    Console.Write( show + " " + i + 1 + ": " + ValidUsername[x]);
                    y += 2;
                    i++;
                }
                else
                {
                    continue;
                }
            }
            string Option;
            Console.SetCursorPosition(z, y + 2);
            Console.Write( "1. View Details           2.Exit");
            Console.SetCursorPosition(60, y + 4);
            Console.Write( "Enter Option...");
            Option= Console.ReadLine();
            while (Option != "1" && Option != "2")
            {
                Console.SetCursorPosition(60, y + 6);

                Console.Write( "Please Enter Correct Option!");
                Console.SetCursorPosition(60, y + 4);
                Console.Write( "                                          ");
                Console.SetCursorPosition(60, y + 4);
                Console.Write( "Enter Option...");
                Option = Console.ReadLine();
                Console.SetCursorPosition(60, y + 6);
                Console.Write( "                                              ");
            }
            int option = int.Parse(Option);
            return option;
        }
        static int ViewUsersMenu()
        {
            Console.SetCursorPosition(1, 19);
            Console.Write( "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------" );
            Console.SetCursorPosition(71, 21);
            Console.Write( "1. Customers");
            Console.SetCursorPosition(71, 23);
            Console.Write( "2. Veterinarians");
            Console.SetCursorPosition(71, 25);
            Console.Write( "3. Exit");
            Console.SetCursorPosition(1, 27);
            Console.Write( "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------") ;
            Console.SetCursorPosition(71, 29);
            Console.Write( "Enter Your Requirement: ");
            string Option;
            Option = Console.ReadLine();
            while (Option != "1" && Option != "2" && Option != "3")
            {
                Console.SetCursorPosition(71, 31);

                Console.Write( "Please Enter Correct Option!");
                Console.SetCursorPosition(71, 29);
                Console.Write( "                                              ");
                Console.SetCursorPosition(71, 29);
                Console.Write( "Enter Your Requirement: ");
                Option = Console.ReadLine();
                Console.SetCursorPosition(71, 31);
                Console.Write( "                                              ");
            }
            int Admin_Requirement = int.Parse(Option);
            return Admin_Requirement;
        }
        static void ViewCustomerDetails(int countUser, string[] ValidRole, string show, string[] ValidUsername, string[] ValidPassword, string[] BookedBy, string[] BookedByPassword, int AppointmentsCount, string[] AppointmentBookOrPending, string[] PetOwnerName,
                                 string[] PetOwnerNumber,
                                 string[] PetOwnerEmail,
                                 string[] PetOwnerLocation,
                                 string[] PetTypeForAppointment,
                                 string[] PetName,
                                 string[] PetAge)
        {
            int y = 0;
            int customeridx = 0;
            for (int z = 0; z < countUser; z++)
            {
                if (ValidRole[z] == show)
                {
                    AdminHeader();
                    y++;
                    Console.SetCursorPosition(40, 20);
                    
                    Console.Write( "Customer Name: " + ValidUsername[z]);
                    Console.SetCursorPosition(40, 22);
                    
                    Console.Write( "Customer Account Password: " + ValidPassword[z]);
                    int total = TotalAppointmentsByOneUser(BookedBy, ValidUsername[z], AppointmentsCount);
                    int booked = CountBookedAppointmentsForCustomer(BookedBy, AppointmentsCount, AppointmentBookOrPending, z, ValidUsername);
                    Console.SetCursorPosition(40, 24);
                    
                    Console.Write( "Total Appointments : " + total);
                    Console.SetCursorPosition(40, 26);
                    
                    Console.Write( "Booked Appointments: " + booked);
                    Console.SetCursorPosition(40, 28);
                    
                    Console.Write( "Pending Appointments: " + (total - booked));
                    Console.SetCursorPosition(60, 32);
                    Console.Write( "Press any key to see next Customer Details..");
                    if (total > 0)
                    {
                        checkindex(AppointmentsCount, ref customeridx, ValidUsername[z], ValidPassword[z], BookedBy, BookedByPassword);
                        Console.SetCursorPosition(40, 30);
                        
                        Console.Write( "Customer Contact: " + PetOwnerNumber[customeridx]);
                        Console.SetCursorPosition(80, 20);
                        
                        Console.Write( "Customer Email: " + PetOwnerEmail[customeridx]);
                        Console.SetCursorPosition(80, 22);
                        
                        Console.Write( "Customer Location: " + PetOwnerLocation[customeridx]);
                        Console.SetCursorPosition(80, 24);
                        
                        Console.Write( "Customer Pet Type: " + PetTypeForAppointment[customeridx]);
                        Console.SetCursorPosition(80, 26);
                        Console.Write( "Customer Pet Name: " + PetName[customeridx]);
                        Console.SetCursorPosition(80, 28);
                        
                        Console.Write( "Customer Pet Age: " + PetAge[customeridx]);
                        Console.SetCursorPosition(60, 32);
                        Console.Write( "Press any key to see next Customer Details..");
                    }
                    Console.ReadKey();
                }
                else
                {
                    continue;
                }
            }
            if (y == 1)
            {
                Console.SetCursorPosition(60, 34);
                Console.Write( "                                               ");
                Console.SetCursorPosition(60, 34);
                Console.Write( "There is Only " + y + " Customer");
            }
            else if (y > 1)
            {
                Console.SetCursorPosition(60, 34);
                Console.Write( "                                               ");
                Console.SetCursorPosition(60, 34);
                Console.Write( "There are Only " + y + " Customers");
            }
        }

        static void ViewVetDetails(int countVets, int countUser, string[] ValidRole, string show, string[] ValidUsername, string[] ValidPassword, string[] BookedBy, string[] BookedByPassword, int AppointmentsCount, string[] AppointmentBookOrPending, string[] VetName,
                            string[] VetContact,
                            string[] VetPassword,
                            string[] VetEmail,
                            string[] VetService,
                            string[] VetDays,
                            string[] DoctorName, string[] DoctorAppointed)
        {
            int y = 0;
            int vetidx = 0;
            for (int z = 0; z < countUser; z++)
            {
                if (ValidRole[z] == show)
                {
                    AdminHeader();
                    y++;
                    Console.SetCursorPosition(40, 20);
                    Console.Write( "Veterinarian Name: " + ValidUsername[z]);
                    Console.SetCursorPosition(40, 22);
                    Console.Write( "Veterinarian Account Password: " + ValidPassword[z]);
                    checkindex(countVets, ref vetidx, ValidUsername[z], ValidPassword[z], VetName, VetPassword);
                    int pending = CountPendingAppointments(DoctorAppointed, AppointmentsCount, AppointmentBookOrPending, vetidx, VetService);
                    int booked = CountBookedAppointments(DoctorAppointed, AppointmentsCount, AppointmentBookOrPending, vetidx, VetService);
                    Console.SetCursorPosition(40, 24);
                    Console.Write( "Total Appointments : " + (booked + pending));
                    Console.SetCursorPosition(40, 26);
                    Console.Write( "Booked Appointments: " + booked);
                    Console.SetCursorPosition(40, 28);
                    Console.Write( "Pending Appointments: " + pending);
                    Console.SetCursorPosition(80, 20);
                    Console.Write( "Veterinarian Contact: " + VetContact[vetidx]);
                    Console.SetCursorPosition(80, 22);
                    Console.Write( "Veterinarian Email: " + VetEmail[vetidx]);
                    Console.SetCursorPosition(80, 24);
                    Console.Write( "Offered Service: " + VetService[vetidx]);
                    Console.SetCursorPosition(80, 26);
                    Console.Write( "Service Day: " + VetDays[vetidx]);
                    Console.SetCursorPosition(60, 32);
                    Console.Write( "Press any key to see next Veterinarian Details..");
                    Console.ReadKey();
                }
                else
                {
                    continue;
                }
            }
            if (y == 1)
            {
                Console.SetCursorPosition(60, 34);
                Console.Write( "                                               ");
                Console.SetCursorPosition(60, 34);
                Console.Write( "There is Only " + y + " Veterinarian");
            }
            else if (y > 1)
            {
                Console.SetCursorPosition(60, 34);
                Console.Write( "                                               ");
                Console.SetCursorPosition(60, 34);
                Console.Write( "There are Only " + y + " Veterinarians");
            }
        }
        static void DeleteCustomerDetails(string[] ValidRole,
                                  string[] ValidUsername,
                                  string[] ValidPassword,
                                  ref int BookedAppointmentsTotal,
                                  ref int PendingAppointmentsTotal,
                                  ref int Appointmentidx,
                                  int Total,
                                  ref int Bookingidx,
                                  ref int countCustomers,
                                  ref int countUser,
                                  string[] ThreeUsers,
                                  string[] TimeAppointed,
                                  string[] DoctorAppointed,
                                  string[] DayAppointed,
                                  string[] BookedForPet,
                                  string[] Veterinarians,
                                  string[] PetOwnerName,
                                  string[] PetOwnerNumber,
                                  string[] PetOwnerEmail,
                                  string[] PetOwnerLocation,
                                  string[] PetTypeForAppointment,
                                  string[] PetName,
                                  string[] PetAge,
                                  string[] PetGender,
                                  string[] PetWeight,
                                  string[] Doctor,
                                  string[] DoctorName,
                                  string[] Time,
                                  string[] Day,
                                  ref int AppointmentsCount,
                                  string[] AppointmentBookOrPending,
                                  string[] CustomerName,
                                  string[] CustomerPassword,
                                  string[] BookedBy,
                                  string[] BookedByPassword,
                                  string[] ApprovalStatus,
                                  string[] ApprovedRoles,
                                  string[] ApprovedUsers,
                                  string[] ApprovedPwd,
                                  ref int signUpcount,
                                  ref int approved,
                                  ref int unapproved,
                                  int countVets)
        {
            int y = 0;
            int customeridx = 0;
            string Remove = "";
            int remove = 0;

            for (int z = 0; z < countUser; z++)
            {
                if (ValidRole[z] == "Customer")
                {
                    AdminHeader();
                    y++;
                    Console.SetCursorPosition(40, 20);
                    
                    Console.Write("Customer Name: " + ValidUsername[z]);
                    Console.SetCursorPosition(40, 22);
                    
                    Console.Write("Customer Account Password: " + ValidPassword[z]);
                    int total = TotalAppointmentsByOneUser(BookedBy, ValidUsername[z], AppointmentsCount);
                    int booked = CountBookedAppointmentsForCustomer(BookedBy, AppointmentsCount, AppointmentBookOrPending, z, ValidUsername);
                    Console.SetCursorPosition(40, 24);
                    
                    Console.Write("Total Appointments : " + total);
                    Console.SetCursorPosition(40, 26);
                    
                    Console.Write("Booked Appointments: " + booked);
                    Console.SetCursorPosition(40, 28);
                    
                    Console.Write("Pending Appointments: " + (total - booked));

                    if (total > 0)
                    {
                        checkindex(AppointmentsCount, ref customeridx, ValidUsername[z], ValidPassword[z], BookedBy, BookedByPassword);
                        Console.SetCursorPosition(40, 30);
                        
                        Console.Write("Customer Contact: " + PetOwnerNumber[customeridx]);
                        Console.SetCursorPosition(80, 20);
                        
                        Console.Write("Customer Email: " + PetOwnerEmail[customeridx]);
                        Console.SetCursorPosition(80, 22);
                        
                        Console.Write("Customer Location: " + PetOwnerLocation[customeridx]);
                        Console.SetCursorPosition(80, 24);
                        
                        Console.Write("Customer Pet Type: " + PetTypeForAppointment[customeridx]);
                        Console.SetCursorPosition(80, 26);
                        
                        Console.Write("Customer Pet Name: " + PetName[customeridx]);
                        Console.SetCursorPosition(80, 28);
                        
                        Console.Write("Customer Pet Age: " + PetAge[customeridx]);
                    }

                    Console.SetCursorPosition(80, 32);
                    Console.Write("1. Yes     2. No");
                    Console.SetCursorPosition(80, 30);
                    Console.Write("Remove this Customer...?");
                    Remove = Console.ReadLine();

                    while (Remove != "1" && Remove != "2")
                    {
                        Console.SetCursorPosition(60, 32);
        
                        Console.Write("Please Enter Correct Option! ");
                        Console.SetCursorPosition(80, 30);
                        Console.Write("                                          ");
                        Console.SetCursorPosition(80, 30);
                        Console.Write("Remove this Customer...?");
                        Remove = Console.ReadLine();
                        Console.SetCursorPosition(60, 32);
                        Console.Write("                                          ");
                    }

                    remove = int.Parse(Remove);

                    if (remove == 2)
                    {
                        continue;
                    }
                    else if (remove == 1)
                    {
                        checkindex(signUpcount, ref customeridx, ValidUsername[z], ValidPassword[z], ApprovedUsers, ApprovedPwd);

                        for (int c = customeridx; c < signUpcount ; c++)
                        {
                            ApprovedUsers[c] = ApprovedUsers[c + 1];
                            ApprovedPwd[c] = ApprovedPwd[c + 1];
                            ApprovalStatus[c] = ApprovalStatus[c + 1];
                            ApprovedRoles[c] = ApprovedRoles[c + 1];
                        }

                        checkindex(countCustomers, ref customeridx, ValidUsername[z], ValidPassword[z], CustomerName, CustomerPassword);

                        for (int c = customeridx; c < countCustomers ; c++)
                        {
                            CustomerName[c] = CustomerName[c + 1];
                            CustomerPassword[c] = CustomerPassword[c + 1];
                        }

                        checkindex(AppointmentsCount, ref customeridx, ValidUsername[z], ValidPassword[z], BookedBy, BookedByPassword);

                        for (int c = customeridx; c < AppointmentsCount ; c++)
                        {
                            BookedBy[c] = BookedBy[c + 1];
                            BookedByPassword[c] = BookedByPassword[c + 1];
                            BookedForPet[c] = BookedForPet[c + 1];
                            PetOwnerName[c] = PetOwnerName[c + 1];
                            PetOwnerNumber[c] = PetOwnerNumber[c + 1];
                            PetOwnerEmail[c] = PetOwnerEmail[c + 1];
                            PetOwnerLocation[c] = PetOwnerLocation[c + 1];
                            PetTypeForAppointment[c] = PetTypeForAppointment[c + 1];
                            PetName[c] = PetName[c + 1];
                            PetAge[c] = PetAge[c + 1];
                            PetGender[c] = PetGender[c + 1];
                            PetWeight[c] = PetWeight[c + 1];
                            DoctorAppointed[c] = DoctorAppointed[c + 1];
                            DayAppointed[c] = DayAppointed[c + 1];
                            AppointmentBookOrPending[c] = AppointmentBookOrPending[c + 1];
                            DoctorName[c] = DoctorName[c + 1];
                        }

                        for (int c = z; c < countUser ; c++)
                        {
                            ValidUsername[c] = ValidUsername[c + 1];
                            ValidPassword[c] = ValidPassword[c + 1];
                            ValidRole[c] = ValidRole[c + 1];
                        }

                        if (AppointmentBookOrPending[z] == "Pending")
                        {
                            PendingAppointmentsTotal--;
                        }
                        else if (AppointmentBookOrPending[z] == "Booked")
                        {
                            BookedAppointmentsTotal--;
                        }
                        if (ApprovalStatus[z] == "Approved")
                        {
                            approved--;
                        }
                        else if (ApprovalStatus[z] == "Unapproved")
                        {
                            unapproved--;
                        }
                        if (AppointmentsCount > 0)
                        {
                            AppointmentsCount--;
                        }

                        countCustomers--;
                        countUser--;
                        signUpcount--;
                        AdminHeader();
                        Console.SetCursorPosition(71, 24);
                        Console.Write("                                               ");
                        Console.SetCursorPosition(71, 24);
                        
                        Console.Write("Customer deleted successfully..!");
                        return;
                    }
                }
                else
                {
                    continue;
                }

                y = z;
            }

            Console.SetCursorPosition(71, 34);
            Console.Write("                                               ");
            Console.SetCursorPosition(71, 34);
            
            Console.Write("No more Customers...");
        }

        static void DeleteVetDetails(ref int countVeterinarians, int countCustomers, int vetidx, string[] ValidUsername, string[] ValidRole, string[] ValidPassword, ref int countUser, int idx, string[] ThreeUsers, ref int countVets,
                              string[] VetName, string[] VetPassword, string[] VetEmail, string[] VetContact, string[] VetDays,
                              string[] VetService, ref int signUpcount, string[] DoctorAppointed, int AppointmentsCount, string[] AppointmentBookOrPending,
                              string[] ApprovalStatus, string[] ApprovedRoles, string[] ApprovedUsers, string[] ApprovedPwd)
        {
            int y = 0;
            string Remove = "";
            int remove = 0;
            for (int z = 0; z < countUser; z++)
            {
                if (ValidRole[z] == "Veterinarian")
                {
                    AdminHeader();
                    y++;
                    Console.SetCursorPosition(40, 20);
                    
                    Console.Write("Veterinarian Name: " + ValidUsername[z]);
                    Console.SetCursorPosition(40, 22);
                    
                    Console.Write("Veterinarian Account Password: " + ValidPassword[z]);
                    checkindex(countVets, ref vetidx, ValidUsername[z], ValidPassword[z], VetName, VetPassword);
                    int pending = CountPendingAppointments(DoctorAppointed, AppointmentsCount, AppointmentBookOrPending, vetidx, VetService);
                    int booked = CountBookedAppointments(DoctorAppointed, AppointmentsCount, AppointmentBookOrPending, vetidx, VetService);
                    Console.SetCursorPosition(40, 24);
                    
                    Console.Write("Total Appointments : " + (booked + pending));
                    Console.SetCursorPosition(40, 26);
                    
                    Console.Write("Booked Appointments: " + booked);
                    Console.SetCursorPosition(40, 28);
                    
                    Console.Write("Pending Appointments: " + pending);
                    Console.SetCursorPosition(80, 20);
                    
                    Console.Write("Veterinarian Contact: " + VetContact[vetidx]);
                    Console.SetCursorPosition(80, 22);
                    
                    Console.Write("Veterinarian Email: " + VetEmail[vetidx]);
                    Console.SetCursorPosition(80, 24);
                    
                    Console.Write("Offered Service: " + VetService[vetidx]);
                    Console.SetCursorPosition(80, 26);
                    
                    Console.Write("Service Day: " + VetDays[vetidx]);
                    Console.SetCursorPosition(80, 32);
                    Console.Write("1. Yes     2. No");
                    Console.SetCursorPosition(80, 30);
                    Console.Write("Remove this Veterinarian...?");
                    Remove = Console.ReadLine();
                    while (Remove != "1" && Remove != "2")
                    {
                        Console.SetCursorPosition(60, 34);
        
                        Console.Write("Please Enter Correct Option! ");
                        Console.SetCursorPosition(80, 30);
                        Console.Write("                                              ");
                        Console.SetCursorPosition(80, 30);
                        Console.Write("Remove this Veterinarian...?");
                        Remove = Console.ReadLine();
                        Console.SetCursorPosition(60, 34);
                        Console.Write("                                          ");
                    }
                    remove = int.Parse(Remove);
                    if (remove == 2)
                    {
                        continue;
                    }
                    else if (remove == 1)
                    {
                        checkindex(signUpcount, ref vetidx, ValidUsername[z], ValidPassword[z], ApprovedUsers, ApprovedPwd);
                        for (int v = vetidx; v < signUpcount; v++)
                        {
                            ApprovedUsers[v] = ApprovedUsers[v + 1];
                            ApprovedPwd[v] = ApprovedPwd[v + 1];
                            ApprovalStatus[v] = ApprovalStatus[v + 1];
                            ApprovedRoles[v] = ApprovedRoles[v + 1];
                        }

                        checkindex(countVets, ref vetidx, ValidUsername[z], ValidPassword[z], VetName, VetPassword);
                        for (int v = vetidx; v < countVets; v++)
                        {
                            VetContact[v] = VetContact[v + 1];
                            VetPassword[v] = VetPassword[v + 1];
                            VetName[v] = VetName[v + 1];
                            VetEmail[v] = VetEmail[v + 1];
                            VetService[v] = VetService[v + 1];
                            VetDays[v] = VetDays[v + 1];
                        }

                        checkindex(countUser, ref vetidx, ValidUsername[z], ValidPassword[z], ValidUsername, ValidPassword);
                        for (int v = vetidx; v < countUser; v++)
                        {
                            ValidUsername[v] = ValidUsername[v + 1];
                            ValidPassword[v] = ValidPassword[v + 1];
                            ValidRole[v] = ValidRole[v + 1];
                        }
                        if (AppointmentsCount > 0)
                        {
                            AppointmentsCount--;
                        }
                        countVeterinarians--;
                        countVets--;
                        countUser--;
                        signUpcount--;
                        Console.ReadKey();
                    }
                    continue;
                }
                else
                {
                    continue;
                }
            }
            if (y == 1)
            {
                Console.SetCursorPosition(60, 34);
                Console.Write("                                               ");
                Console.SetCursorPosition(60, 34);
                
                Console.Write("No more Veterinarians...");
            }
            else if (y > 1)
            {
                Console.SetCursorPosition(60, 34);
                Console.Write("                                               ");
                Console.SetCursorPosition(60, 34);
                
                Console.Write("No more Veterinarians...");
            }
        }
        static int ViewAppointmentsMenu()
        {
            Console.SetCursorPosition(1, 19);
            Console.Write("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            Console.SetCursorPosition(71, 21);
            Console.Write("1. Pending  Appointments");
            Console.SetCursorPosition(71, 23);
            Console.Write("2. Booked Appointments");
            Console.SetCursorPosition(71, 25);
            Console.Write("3. Delete Appointments");
            Console.SetCursorPosition(71, 27);
            Console.Write("4. Exit");

            Console.SetCursorPosition(1, 29);
            Console.Write("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            Console.SetCursorPosition(71, 31);
            Console.Write("Enter Your Requirement: ");
            string option = Console.ReadLine();

            while (option != "1" && option != "2" && option != "3" && option != "4")
            {
                Console.SetCursorPosition(71, 33);

                Console.Write("Please Enter Correct Option!");


                Console.SetCursorPosition(71, 31);
                Console.Write("                                                   ");

                Console.SetCursorPosition(71, 33);
                Console.Write("                                                 ");

                Console.SetCursorPosition(71, 31);
                Console.Write("Enter Your Requirement: ");
                option = Console.ReadLine();
            }

            int adminRequirement = int.Parse(option);
            return adminRequirement;
        }
        static void ShowPendingAppointmentsTOAdmin(string showingStatus, string[] DoctorAppointed, string[] DayAppointed,
        string[] PetOwnerName, string[] PetOwnerNumber, string[] PetOwnerEmail,
        string[] PetOwnerLocation, string[] PetTypeForAppointment, string[] PetName,
        string[] PetAge, string[] PetGender, string[] PetWeight, string[] Doctor,
        string[] Time, string[] Day, ref int AppointmentsCount, string[] AppointmentBookOrPending)
        {
            int y = 0;
            for (int z = 0; z < AppointmentsCount; z++)
            {
                AdminHeader();
                if (AppointmentBookOrPending[z] == "Pending")
                {
                    y++;
                    Console.SetCursorPosition(40, 20);
                    
                    Console.Write("Pet Owner Name: " + PetOwnerName[z]);
                    Console.SetCursorPosition(40, 22);
                    
                    Console.Write("Pet Owner Contact: " + PetOwnerNumber[z]);
                    Console.SetCursorPosition(40, 24);
                    
                    Console.Write("Pet Owner Email: " + PetOwnerEmail[z]);
                    Console.SetCursorPosition(40, 26);
                    
                    Console.Write("Pet Owner Location: " + PetOwnerNumber[z]);
                    Console.SetCursorPosition(40, 28);
                    
                    Console.Write("Pet Type: " + PetTypeForAppointment[z]);
                    Console.SetCursorPosition(80, 20);
                    
                    Console.Write("Pet Name: " + PetName[z]);
                    Console.SetCursorPosition(80, 22);
                    
                    Console.Write("Pet Age : " + PetAge[z] + " Months");
                    Console.SetCursorPosition(80, 24);
                    
                    Console.Write("Pet Weight: " + PetWeight[z] + " Pounds");
                    Console.SetCursorPosition(80, 26);
                    
                    Console.Write("Pet Gender: " + PetGender[z]);
                    Console.SetCursorPosition(80, 28);
                    
                    Console.Write("Appointment For: " + DoctorAppointed[z]);
                    Console.SetCursorPosition(40, 30);
                    
                    Console.Write("Appointment Status: " + AppointmentBookOrPending[z]);
                    Console.SetCursorPosition(80, 30);
                    
                    Console.Write("Day For Appointment: " + DayAppointed[z]);
                    Console.SetCursorPosition(60, 32);
                    Console.Write("Press any key to see the next Appointment..");
                    Console.ReadKey();
                }
            }

            if (y == 1)
            {
                Console.SetCursorPosition(60, 24);
                Console.Write("                                               ");
                Console.SetCursorPosition(60, 24);
                
                Console.Write("There is Only " + y + " Pending Appointment");
            }
            else if (y > 1)
            {
                Console.SetCursorPosition(60, 34);
                Console.Write("                                               ");
                Console.SetCursorPosition(60, 34);
                
                Console.Write("There are Only " + y + " Pending Appointments");
            }
        }

        static void ShowBookedAppointmentsTOAdmin(string showingStatus, string[] DoctorAppointed, string[] DayAppointed,
                                          string[] PetOwnerName, string[] PetOwnerNumber, string[] PetOwnerEmail,
                                          string[] PetOwnerLocation, string[] PetTypeForAppointment, string[] PetName,
                                          string[] PetAge, string[] PetGender, string[] PetWeight, string[] Doctor,
                                          string[] Time, string[] Day, ref int AppointmentsCount,
                                          string[] AppointmentBookOrPending)
        {
            int y = 0;

            for (int z = 0; z < AppointmentsCount; z++)
            {
                if (AppointmentBookOrPending[z] == "Booked")
                {
                    AdminHeader();
                    y++;

                    Console.SetCursorPosition(40, 20);
                    
                    Console.Write("Pet Owner Name: " + PetOwnerName[z]);

                    Console.SetCursorPosition(40, 22);
                    
                    Console.Write("Pet Owner Contact: " + PetOwnerNumber[z]);

                    Console.SetCursorPosition(40, 24);
                    
                    Console.Write("Pet Owner Email: " + PetOwnerEmail[z]);

                    Console.SetCursorPosition(40, 26);
                    
                    Console.Write("Pet Owner Location: " + PetOwnerLocation[z]);

                    Console.SetCursorPosition(40, 28);
                    
                    Console.Write("Pet Type: " + PetTypeForAppointment[z]);

                    Console.SetCursorPosition(80, 20);
                    
                    Console.Write("Pet Name: " + PetName[z]);

                    Console.SetCursorPosition(80, 22);
                    
                    Console.Write("Pet Age: " + PetAge[z] + " Months");

                    Console.SetCursorPosition(80, 24);
                    
                    Console.Write("Pet Weight: " + PetWeight[z] + " Pounds");

                    Console.SetCursorPosition(80, 26);
                    
                    Console.Write("Pet Gender: " + PetGender[z]);

                    Console.SetCursorPosition(80, 28);
                    
                    Console.Write("Appointment For: " + DoctorAppointed[z]);

                    Console.SetCursorPosition(40, 30);
                    
                    Console.Write("Appointment Status: " + AppointmentBookOrPending[z]);

                    Console.SetCursorPosition(80, 30);
                    
                    Console.Write("Day For Appointment: " + DayAppointed[z]);

                    Console.SetCursorPosition(60, 32);
                    Console.Write("Press any key to see next Appointment..");
                    Console.ReadKey();
                }
            }

            if (y == 1)
            {
                Console.SetCursorPosition(60, 34);
                Console.Write("                                               ");
                Console.SetCursorPosition(60, 34);
                
                Console.Write("There is Only " + y + " Booked Appointment");
            }
            else if (y > 1)
            {
                Console.SetCursorPosition(60, 34);
                Console.Write("                                               ");
                Console.SetCursorPosition(60, 34);
                
                Console.Write("There are Only " + y + " Booked Appointments");
            }
        }

        static void DeleteAppointments(ref int Bookingidx, ref int BookedAppointmentsTotal, ref int PendingAppointmentsTotal, string[] DoctorAppointed, string[] DayAppointed,
                         string[] PetOwnerName,
                         string[] PetOwnerNumber,
                         string[] PetOwnerEmail,
                         string[] PetOwnerLocation,
                         string[] PetTypeForAppointment,
                         string[] PetName,
                         string[] PetAge,
                         string[] PetGender,
                         string[] PetWeight,
                         string[] Doctor,
                         string[] Time,
                         string[] Day, ref int AppointmentsCount,
                         string[] AppointmentBookOrPending, string[] BookedBy, string[] BookedForPet, string[] BookedByPassword, ref int Appointementdx, string[] DoctorName)
        {
            string Confirmation = "";
            int confirmation = 0;
            int x = 0;
            int z = 0;
            for (; z < AppointmentsCount; z++)
            {
                x++;
                AdminHeader();
                Console.SetCursorPosition(40, 20);
                
                Console.Write("Pet Owner Name: " + PetOwnerName[z]);
                Console.SetCursorPosition(40, 22);
                
                Console.Write("Pet Owner Contact: " + PetOwnerNumber[z]);
                Console.SetCursorPosition(40, 24);
                
                Console.Write("Pet Owner Email: " + PetOwnerEmail[z]);
                Console.SetCursorPosition(40, 26);
                
                Console.Write("Pet Owner Location: " + PetOwnerLocation[z]);
                Console.SetCursorPosition(40, 28);
                
                Console.Write("Pet Type: " + PetTypeForAppointment[z]);
                Console.SetCursorPosition(80, 20);
                
                Console.Write("Pet Name: " + PetName[z]);
                Console.SetCursorPosition(80, 22);
                
                Console.Write("Pet Age : " + PetAge[z] + " Months");
                Console.SetCursorPosition(80, 24);
                
                Console.Write("Pet Weight: " + PetWeight[z] + " Pounds");
                Console.SetCursorPosition(80, 26);
                
                Console.Write("Pet Gender: " + PetGender[z]);
                Console.SetCursorPosition(80, 28);
                
                Console.Write("Appointment For: " + DoctorAppointed[z]);
                Console.SetCursorPosition(40, 30);
                
                Console.Write("Appointment Status: " + AppointmentBookOrPending[z]);
                Console.SetCursorPosition(80, 30);
                Console.SetCursorPosition(50, 34);
                Console.Write("                                                   ");
                Console.SetCursorPosition(50, 36);
                Console.Write("1. Yes    2. No");
                Console.SetCursorPosition(50, 34);
                
                Console.Write("Do You Want To Delete this Appointment? ");
                Confirmation = Console.ReadLine();
                while (Confirmation != "1" && Confirmation != "2")
                {
                    Console.SetCursorPosition(50, 38);
    
                    Console.Write("Please Enter Correct Option! ");
                    Console.SetCursorPosition(50, 34);
                    Console.Write("                                                                        ");
                    Console.SetCursorPosition(50, 34);
                    
                    Console.Write("Do You Want To Delete this Appointment? ");
                    Confirmation = Console.ReadLine();
                    Console.SetCursorPosition(50, 38);
                    Console.Write("                                                    ");
                }
                confirmation = int.Parse(Confirmation);
                if (confirmation == 2)
                {
                    continue;
                }
                else if (confirmation == 1)
                {
                    for (int a = z; a < AppointmentsCount; a++)
                    {
                        BookedBy[a] = BookedBy[a + 1];
                        BookedByPassword[a] = BookedByPassword[a + 1];
                        BookedForPet[a] = BookedForPet[a + 1];
                        PetOwnerName[a] = PetOwnerName[a + 1];
                        PetOwnerNumber[a] = PetOwnerNumber[a + 1];
                        PetOwnerEmail[a] = PetOwnerEmail[a + 1];
                        PetOwnerLocation[a] = PetOwnerLocation[a + 1];
                        PetTypeForAppointment[a] = PetTypeForAppointment[a + 1];
                        PetName[a] = PetName[a + 1];
                        PetAge[a] = PetAge[a + 1];
                        PetGender[a] = PetGender[a + 1];
                        PetWeight[a] = PetWeight[a + 1];
                        DoctorAppointed[a] = DoctorAppointed[a + 1];
                        DayAppointed[a] = DayAppointed[a + 1];
                        AppointmentBookOrPending[a] = AppointmentBookOrPending[a + 1];
                        DoctorName[a] = DoctorName[a + 1];
                        Doctor[a] = Doctor[a + 1];
                        Day[a] = Day[a + 1];
                    }

                    if (AppointmentBookOrPending[z - 1] == "Pending")
                    {
                        PendingAppointmentsTotal--;
                    }
                    else if (AppointmentBookOrPending[z - 1] == "Booked")
                    {
                        BookedAppointmentsTotal--;
                    }
                    AppointmentsCount--;
                    continue;
                }
            }
            if (x == 1)
            {
                Console.SetCursorPosition(50, 34);
                Console.Write("                                               ");
                Console.SetCursorPosition(50, 34);
                
                Console.Write("There was Only " + x + " Appointment");
            }
            else if (x > 1)
            {
                Console.SetCursorPosition(50, 34);
                Console.Write("                                               ");
                Console.SetCursorPosition(50, 34);
                
                Console.Write("There were Only " + x + " Appointments");
            }
        }
        static void AdminMainMenu(string SignUpFile, int[] Roles, string ApprovedFile, string CustomerFile, string AppointmentFile, string VetFile, int useridx, string[] ThreeUsers, ref int countUser, int idx, string Username, string[] ValidUsername, string signInUserName, string Password, string[] ValidPassword, string signInPassword, string role, string[] ValidRole, string Option, ref int countVets, ref int countCustomers, int Role, int vetidx, int customeridx, ref int AppointmentsCount, ref int Appointmentidx, ref int BookedAppointmentsTotal, ref int PendingAppointmentsTotal, ref int countVeterinarians, string[] CustomerName, string[] CustomerPassword, string[] TimeAppointed, string[] DoctorAppointed, string[] DayAppointed, string[] DoctorName, string[] BookedForPet, string[] Veterinarians, string[] PetOwnerName, string[] PetOwnerNumber, string[] PetOwnerEmail, string[] PetOwnerLocation, string[] PetTypeForAppointment, string[] PetName, string[] PetAge, string[] PetGender, string[] PetWeight, string[] Doctor, string[] Time, string[] Day, string[] BookedBy, string[] BookedByPassword, ref int Bookingidx, ref int Total, string[] AppointmentBookOrPending, string[] AvailableService, string[] AvailableDays, string[] VetDays, string[] VetService, string[] VetName, string[] VetPassword, string[] VetEmail, string[] VetContact, string VUserName, string VPassword, string VEmail, string VContact, string[] ApprovalStatus, string[] ApprovedRoles, string[] ApprovedUsers, string[] ApprovedPwd, ref int signUpcount, ref int approved, ref int unapproved)
        {
            int AddUsersOption = 0;
            int ViewUsersOption = 0;
            int deleteOption = 0;
            int AdminRequirement = 0;
            int AppointmentRequirement = 0;
            string showingstatus = "";
            string show = "";
            int details = 0;

            while (true)
            {
                printHeader();
                AdminRequirement = PrintAdminMenu();

                if (AdminRequirement == 1)
                {
                    AdminHeader();

                    if (signUpcount > 0 && unapproved > 0)
                    {
                        AddSelectedUser(ref approved, ref unapproved, AddUsersOption, countUser, ApprovalStatus, ApprovedRoles);
                        saveApprovedUsers(ApprovalStatus, ApprovedUsers, ApprovedPwd, ApprovedRoles, ref signUpcount, ApprovedFile);

                        if (unapproved == 0)
                        {
                            Console.SetCursorPosition(60, 34);
                            Console.Write("No more users to add");
                        }

                        Console.SetCursorPosition(60, 36);
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        AdminHeader();
                        Console.SetCursorPosition(60, 24);
                        Console.Write("There are no users to add");
                        Console.SetCursorPosition(60, 26);
                        Console.Write("Press any key to continue..");
                        Console.ReadKey();
                    }
                }
                else if (AdminRequirement == 2)
                {
                    while (true)
                    {
                        AdminHeader();
                        ViewUsersOption = ViewUsersMenu();

                        if (ViewUsersOption == 1)
                        {
                            show = "Customer";

                            if (countCustomers > 0)
                            {
                                AdminHeader();
                                details = ShowUsers(countUser, show, ValidUsername, ValidRole);

                                if (details == 1)
                                {
                                    AdminHeader();
                                    ViewCustomerDetails(countUser, ValidRole, show, ValidUsername, ValidPassword, BookedBy, BookedByPassword, AppointmentsCount, AppointmentBookOrPending,
                                        PetOwnerName,
                                        PetOwnerNumber,
                                        PetOwnerEmail,
                                        PetOwnerLocation,
                                        PetTypeForAppointment,
                                        PetName,
                                        PetAge);

                                    Console.SetCursorPosition(60, 36);
                                    Console.Write("Press any key to continue..");
                                }
                                else if (details == 2)
                                {
                                    break;
                                }

                                Console.ReadKey();
                            }
                            else
                            {
                                AdminHeader();
                                Console.SetCursorPosition(60, 24);
                                Console.Write("There are no Customers to show");
                                Console.SetCursorPosition(60, 26);
                                Console.Write("Press any key to continue..");
                                Console.ReadKey();
                            }
                        }
                        else if (ViewUsersOption == 2)
                        {
                            show = "Veterinarian";

                            if (countVeterinarians > 0)
                            {
                                AdminHeader();
                                details = ShowUsers(countUser, show, ValidUsername, ValidRole);

                                if (details == 1)
                                {
                                    AdminHeader();
                                    ViewVetDetails(countVets, countUser, ValidRole, show, ValidUsername, ValidPassword, BookedBy, BookedByPassword, AppointmentsCount, AppointmentBookOrPending, VetName,
                                        VetContact,
                                        VetPassword,
                                        VetEmail,
                                        VetService,
                                        VetDays,
                                        DoctorName, DoctorAppointed);

                                    Console.SetCursorPosition(60, 36);
                                    Console.Write("Press any key to continue..");
                                    Console.ReadKey();
                                }
                                else if (details == 2)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                AdminHeader();
                                Console.SetCursorPosition(60, 24);
                                Console.Write("There are no Veterinarians to show");
                                Console.SetCursorPosition(60, 26);
                                Console.Write("Press any key to continue..");
                                Console.ReadKey();
                            }
                        }
                        else if (ViewUsersOption == 3)
                        {
                            break;
                        }
                    }
                }
                else if (AdminRequirement == 3)
                {
                    while (true)
                    {
                        AdminHeader();
                        deleteOption = ViewUsersMenu();

                        if (deleteOption == 1)
                        {
                            show = "Customer";

                            if (countCustomers > 0)
                            {
                                AdminHeader();
                                DeleteCustomerDetails(ValidRole,
                                    ValidUsername,
                                    ValidPassword, ref BookedAppointmentsTotal, ref PendingAppointmentsTotal, ref Appointmentidx,  Total, ref Bookingidx,ref countCustomers, ref countUser, ThreeUsers, TimeAppointed,
                                    DoctorAppointed,
                                    DayAppointed,
                                    BookedForPet,
                                    Veterinarians,
                                    PetOwnerName,
                                    PetOwnerNumber,
                                    PetOwnerEmail,
                                    PetOwnerLocation,
                                    PetTypeForAppointment,
                                    PetName,
                                    PetAge,
                                    PetGender,
                                    PetWeight,
                                    Doctor,
                                    DoctorName,
                                    Time,
                                    Day,
                                    ref AppointmentsCount,
                                    AppointmentBookOrPending,
                                    CustomerName,
                                    CustomerPassword, BookedBy, BookedByPassword, ApprovalStatus, ApprovedRoles, ApprovedUsers, ApprovedPwd,
                                    ref signUpcount,
                                    ref approved,
                                    ref unapproved, countVets);

                                saveCustomerDetails(CustomerName, CustomerPassword, ref countCustomers, CustomerFile);
                                saveCustomerAppointments(CustomerName, ValidUsername, PetOwnerName, PetOwnerNumber, PetOwnerEmail, PetOwnerLocation, PetTypeForAppointment, PetName, PetAge,
                                    PetGender, PetWeight, Doctor, AppointmentBookOrPending, ref AppointmentsCount, BookedBy, BookedByPassword,
                                    DoctorAppointed, DayAppointed, AppointmentFile, customeridx);

                                saveApprovedUsers(ApprovalStatus, ApprovedUsers, ApprovedPwd, ApprovedRoles, ref signUpcount, ApprovedFile);
                                saveSignUpDetails(ValidUsername, ValidPassword, Roles,  countUser, SignUpFile);

                                Console.SetCursorPosition(60, 36);
                                Console.Write("Press any key to continue..");
                                Console.ReadKey();
                            }
                            else
                            {
                                AdminHeader();
                                Console.SetCursorPosition(60, 24);
                                Console.Write("There are no Customers to show");
                                Console.SetCursorPosition(60, 26);
                                Console.Write("Press any key to continue..");
                                Console.ReadKey();
                            }
                        }
                        else if (deleteOption == 2)
                        {
                            show = "Veterinarian";

                            if (countVeterinarians > 0)
                            {
                                while (true)
                                {
                                    AdminHeader();
                                    details = ShowUsers(countUser, show, ValidUsername, ValidRole);

                                    if (details == 1)
                                    {
                                        AdminHeader();
                                        DeleteVetDetails(ref countVeterinarians, countCustomers, vetidx, ValidUsername, ValidRole, ValidPassword, ref countUser, idx, ThreeUsers, ref countVets,
                                            VetName, VetPassword, VetEmail, VetContact, VetDays,
                                            VetService, ref signUpcount, DoctorAppointed,  AppointmentsCount, AppointmentBookOrPending,
                                            ApprovalStatus, ApprovedRoles, ApprovedUsers, ApprovedPwd);

                                        saveVetDetails(VetName, VetPassword, VetEmail, VetContact, VetDays, VetService, ref countVets,ref countVeterinarians, VetFile, DoctorAppointed, AppointmentsCount, AppointmentBookOrPending, vetidx);
                                        saveApprovedUsers(ApprovalStatus, ApprovedUsers, ApprovedPwd, ApprovedRoles, ref signUpcount, ApprovedFile);
                                        saveSignUpDetails(ValidUsername, ValidPassword, Roles,  countUser, SignUpFile);

                                        Console.SetCursorPosition(60, 36);
                                        Console.Write("Press any key to continue..");
                                        Console.ReadKey();
                                    }
                                    else if (details == 2)
                                    {
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                AdminHeader();
                                Console.SetCursorPosition(60, 24);
                                Console.Write("There are no Veterinarians to show");
                                Console.SetCursorPosition(60, 26);
                                Console.Write("Press any key to continue..");
                                Console.ReadKey();
                            }
                        }
                        else if (deleteOption == 3)
                        {
                            break;
                        }
                    }
                }
                else if (AdminRequirement == 4)
                {
                    int pendingAppointments = 0;

                    while (true)
                    {
                        AdminHeader();

                        AppointmentRequirement = ViewAppointmentsMenu();

                        if (AppointmentRequirement == 1)
                        {
                            pendingAppointments = CountPendingAppointmentsForAdmin( AppointmentsCount, AppointmentBookOrPending);

                            if (pendingAppointments > 0)
                            {
                                showingstatus = "Pending";
                                AdminHeader();
                                ShowPendingAppointmentsTOAdmin(showingstatus, DoctorAppointed, DayAppointed,
                                    PetOwnerName,
                                    PetOwnerNumber,
                                    PetOwnerEmail,
                                    PetOwnerLocation,
                                    PetTypeForAppointment,
                                    PetName,
                                    PetAge,
                                    PetGender,
                                    PetWeight,
                                    Doctor,
                                    Time,
                                    Day, ref AppointmentsCount,
                                    AppointmentBookOrPending);

                                Console.SetCursorPosition(60, 36);
                                Console.Write("Press any key to continue..");
                                Console.ReadKey();
                            }
                            else
                            {
                                AdminHeader();
                                Console.SetCursorPosition(60, 24);
                                Console.Write("There are no Pending Appointments !");
                                Console.SetCursorPosition(60, 26);
                                Console.Write("Press any key to continue..");
                                Console.ReadKey();
                            }
                        }
                        else if (AppointmentRequirement == 2)
                        {
                            if ((AppointmentsCount - pendingAppointments) > 0)
                            {
                                showingstatus = "Booked";
                                AdminHeader();
                                ShowBookedAppointmentsTOAdmin(showingstatus, DoctorAppointed, DayAppointed,
                                    PetOwnerName,
                                    PetOwnerNumber,
                                    PetOwnerEmail,
                                    PetOwnerLocation,
                                    PetTypeForAppointment,
                                    PetName,
                                    PetAge,
                                    PetGender,
                                    PetWeight,
                                    Doctor,
                                    Time,
                                    Day, ref AppointmentsCount,
                                    AppointmentBookOrPending);

                                Console.SetCursorPosition(60, 36);
                                Console.Write("Press any key to continue..");
                                Console.ReadKey();
                            }
                            else
                            {
                                AdminHeader();
                                Console.SetCursorPosition(60, 24);
                                Console.Write("There are no Booked Appointments !");
                                Console.SetCursorPosition(60, 26);
                                Console.Write("Press any key to continue..");
                                Console.ReadKey();
                            }
                        }
                        else if (AppointmentRequirement == 3)
                        {
                            DeleteAppointments(ref Bookingidx, ref BookedAppointmentsTotal, ref PendingAppointmentsTotal, DoctorAppointed, DayAppointed,
                                PetOwnerName,
                                PetOwnerNumber,
                                PetOwnerEmail,
                                PetOwnerLocation,
                                PetTypeForAppointment,
                                PetName,
                                PetAge,
                                PetGender,
                                PetWeight,
                                Doctor,
                                Time,
                                Day,ref AppointmentsCount,
                                AppointmentBookOrPending, BookedBy, BookedByPassword, BookedForPet, ref Appointmentidx, DoctorName);

                            saveCustomerAppointments(CustomerName, ValidUsername, PetOwnerName, PetOwnerNumber, PetOwnerEmail, PetOwnerLocation, PetTypeForAppointment, PetName, PetAge,
                                PetGender, PetWeight, Doctor, AppointmentBookOrPending, ref AppointmentsCount, BookedBy, BookedByPassword,
                                DoctorAppointed, DayAppointed, AppointmentFile, customeridx);

                            saveVetDetails(VetName, VetPassword, VetEmail, VetContact, VetDays, VetService,ref countVets,ref countVeterinarians, VetFile, DoctorAppointed, AppointmentsCount, AppointmentBookOrPending, vetidx);

                            Console.SetCursorPosition(50, 36);
                            Console.Write("                                   ");
                            Console.SetCursorPosition(50, 36);
                            Console.Write("Press any key to continue..");
                            Console.ReadKey();
                        }
                        else if (AppointmentRequirement == 4)
                        {
                            break;
                        }
                    }
                }
                else if (AdminRequirement == 5)
                {
                    break;
                }
            }
        }
        /// CUSTOMER /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        static void saveCustomerDetails(string[] CustomerName, string[] CustomerPassword, ref int countCustomers, string CustomerFile)
        {
            StreamWriter fileVariable = new StreamWriter(CustomerFile);
            for (int i = 0; i < countCustomers; i++)
            {
                fileVariable.WriteLine(CustomerName[i] + "," + CustomerPassword[i]);
            }
            fileVariable.Flush();
            fileVariable.Close();
        }
        static void CustomerHeader()
        {
            printHeader();
            Customer_MenuBar();
        }
        static void Customer_MenuBar()
        {
            Console.SetCursorPosition(1, 15);
            Console.Write( "___________________________________________________________________________________________________________________________________________________________________________");

            Console.SetCursorPosition(0, 17);
            Console.Write( "                                                               ``.....    \033[1;4mC u s t o m e r\033[0m   .....``");

            Console.SetCursorPosition(1, 18);
            Console.Write( "___________________________________________________________________________________________________________________________________________________________________________");
        }
        static int PrintCustomerMenu()
        {
            string Option;
            Console.SetCursorPosition(1, 17);
            Console.Write( "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------" );
            Console.SetCursorPosition(71, 19);
            Console.Write( "1. About Us");
            Console.SetCursorPosition(71, 21);
            Console.Write( "2. Services");
            Console.SetCursorPosition(71, 23);
            Console.Write( "3. Find a Veterinarian");
            Console.SetCursorPosition(71, 25);
            Console.Write( "4. Appointments Status");
            Console.SetCursorPosition(71, 27);
            Console.Write( "5. Logout");
            Console.SetCursorPosition(1, 29);
            Console.Write("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(71, 31);
            Console.Write( "Enter Your Requirement: ");
            Option = Console.ReadLine();
            while (Option != "1" && Option != "2" && Option != "3" && Option != "4" && Option != "5")
            {
                Console.SetCursorPosition(71, 33);

                Console.Write( "Please Enter Correct Option!");
                Console.SetCursorPosition(71, 31);
                Console.Write( "                                                                                                                                                                            ");
                Console.SetCursorPosition(71, 31);
                Console.Write( "Enter Your Requirement: ");
                Option = Console.ReadLine();
            }
            int Customer_Requirement = int.Parse(Option);
            return Customer_Requirement;
        }
        static void AboutUs()
        {
            Console.SetCursorPosition(40, 21);
            Console.Write("Welcome to PetPal, where our passion for pets drives everything we do. Founded by a team of ");
            Console.SetCursorPosition(40, 22);
            Console.Write("dedicated animal lovers, we understand that your furry, feathered, or scaly companions are ");
            Console.SetCursorPosition(40, 23);
            Console.Write("more than just pets; they're family. With years of experience in providing top-notch pet care");
            Console.SetCursorPosition(40, 24);
            Console.Write("services, we are committed to ensuring the happiness, health, and well-being of your beloved");
            Console.SetCursorPosition(40, 25);
            Console.Write("animals.                                                                                    ");
            Console.SetCursorPosition(40, 26);
            Console.Write("                                                                                             ");
            Console.SetCursorPosition(40, 27);
            Console.Write("Our dedication to excellence extends beyond our services. We maintain a clean and safe environment,");
            Console.SetCursorPosition(40, 28);
            Console.Write("use the best products and techniques for grooming, and employ compassionate and certified staff ");
            Console.SetCursorPosition(40, 29);
            Console.Write("members who are passionate about animals. We prioritize open communication with our clients, ensuring ");
            Console.SetCursorPosition(40, 30);
            Console.Write("you are always informed and comfortable with the care your pet is receiving.");
            Console.SetCursorPosition(40, 32);
            Console.Write("Press any key to continue.....");
            Console.ReadKey();
        }
        static int Services()
        {
            Console.SetCursorPosition(71, 21);
            Console.Write("*____________________*");
            Console.SetCursorPosition(71, 22);
            Console.Write("|                    |");
            Console.SetCursorPosition(71, 23);
            Console.Write("| 1. Overnight Care  |");
            Console.SetCursorPosition(71, 24);
            Console.Write("|                    |");
            Console.SetCursorPosition(71, 25);
            Console.Write("| 2. Medical Checkup |");
            Console.SetCursorPosition(71, 26);
            Console.Write("|                    |");
            Console.SetCursorPosition(71, 27);
            Console.Write("| 3. Pet Training    |");
            Console.SetCursorPosition(71, 28);
            Console.Write("|                    |");
            Console.SetCursorPosition(71, 29);
            Console.Write("| 4. Go Back         |");
            Console.SetCursorPosition(71, 30);
            Console.Write("*____________________*");
            Console.SetCursorPosition(71, 33);
            Console.Write("Enter option to continue.....");

            string option = Console.ReadLine();

            while (option != "1" && option != "2" && option != "3" && option != "4")
            {
                Console.SetCursorPosition(71, 35);

                Console.Write("Please Enter Correct Option!");

                Console.SetCursorPosition(71, 33);
                Console.Write("                                              ");
                Console.SetCursorPosition(71, 33);
                Console.Write("Enter option to continue.....");
                option = Console.ReadLine();
                Console.SetCursorPosition(71, 35);
                Console.Write("                                              ");
            }

            return int.Parse(option);
        }
        static int OverNightCare()
        {
            Console.SetCursorPosition(71, 23);
            Console.Write("Enter Name of Your Pet: ");
            string name = Console.ReadLine();

            Console.SetCursorPosition(71, 27);
            Console.Write("1. Dog");
            Console.SetCursorPosition(71, 29);
            Console.Write("2. Cat");
            Console.SetCursorPosition(71, 31);
            Console.Write("3. Rabbit");
            Console.SetCursorPosition(71, 25);
            Console.Write("Enter type of Your Pet: ");
            string type = Console.ReadLine();

            while (type != "1" && type != "2" && type != "3")
            {
                Console.SetCursorPosition(71, 33);

                Console.Write("Please Enter Correct Option!");

                Console.SetCursorPosition(71, 25);
                Console.Write("                                                                                                                          ");
                Console.SetCursorPosition(71, 25);
                Console.Write("Enter type of Your Pet: ");
                type = Console.ReadLine();
                Console.SetCursorPosition(71, 33);
                Console.Write("                                             ");
            }
            int SelectedType = int.Parse(type);
            Console.SetCursorPosition(71, 33);
            Console.Write("Enter Sleeping Hours of your pet: ");
            string shours = Console.ReadLine();
            return SelectedType;
        }
        static void DogCare()
        {
            Console.SetCursorPosition(40, 21);
            Console.Write("1. Continue to feed your puppy a high-quality puppy formula or milk replacer specifically ");
            Console.SetCursorPosition(40, 22);
            Console.Write("designed for puppies. ");
            Console.SetCursorPosition(40, 24);
            Console.Write("2. Follow the manufacturer's instructions for feeding quantities and frequency.");
            Console.SetCursorPosition(40, 26);
            Console.Write("3. Begin gentle socialization by exposing the puppy to different people, gentle handling, ");
            Console.SetCursorPosition(40, 27);
            Console.Write("and safe, age-appropriate toys.");
            Console.SetCursorPosition(40, 29);
            Console.Write("4. Puppies are not able to regulate their body temperature well. Keep the environment warm  ");
            Console.SetCursorPosition(40, 30);
            Console.Write("(around 85-90 F or 29-32 C) using heating pads or a heat lamp. ");

            Console.SetCursorPosition(71, 40);
            Console.Write("Press any key to continue.....");
        }

        static void CatCare()
        {
            Console.SetCursorPosition(40, 21);
            Console.Write("1. Cats appreciate a quiet and comfortable sleeping area. Ensure your cat's bed or sleeping   ");
            Console.SetCursorPosition(40, 22);
            Console.Write("spot is clean, cozy, and away from noisy or high-traffic areas.  ");
            Console.SetCursorPosition(40, 24);
            Console.Write("2. Feed your cat its evening meal a few hours before bedtime. Interactive playtime is an   ");
            Console.SetCursorPosition(40, 25);
            Console.Write("excellent way to engage your cat and burn off excess energy. ");
            Console.SetCursorPosition(40, 27);
            Console.Write("3. If your cat seems active at night, consider engaging in a short play session before you  ");
            Console.SetCursorPosition(40, 28);
            Console.Write("go to bed. This can help tire them out and encourage them to rest during the night.");
            Console.SetCursorPosition(40, 30);
            Console.Write("4. If your cat goes outdoors, ensure they are safely indoors during the night to protect   ");
            Console.SetCursorPosition(40, 31);
            Console.Write(" them from night-time dangers and predators. ");
            Console.SetCursorPosition(71, 40);
            Console.Write("Press any key to continue.....");
        }

        static void RabbitCare()
        {
            Console.SetCursorPosition(40, 21);
            Console.Write("1. Rabbits need a quiet, secure, and comfortable sleeping area. Ensure their hutch or enclosure    ");
            Console.SetCursorPosition(40, 22);
            Console.Write("is clean and cozy,  with bedding or hay for them to rest on. ");
            Console.SetCursorPosition(40, 24);
            Console.Write("2. Rabbits can see in low light, but you can provide a small, dim nightlight in their sleeping ");
            Console.SetCursorPosition(40, 25);
            Console.Write(" area to help them navigate if they need to move around at night.");
            Console.SetCursorPosition(40, 27);
            Console.Write("3. Keep the noise level in your home to a minimum during the night to avoid disturbing your ");
            Console.SetCursorPosition(40, 28);
            Console.Write("rabbit's rest.");
            Console.SetCursorPosition(40, 30);
            Console.Write("4. Leave a few safe and engaging toys or chewing items in your rabbit's enclosure to keep ");
            Console.SetCursorPosition(40, 31);
            Console.Write("them entertained during their active hours. ");
            Console.SetCursorPosition(71, 40);
            Console.Write("Press any key to continue.....");
        }
        static bool MedicalCheckup()
        {
            Console.SetCursorPosition(50, 21);
            Console.Write("Provide us some information about your pet. ");

            string vac;
            string play;
            string chck;
            string eat;

            Console.SetCursorPosition(50, 23);
            Console.Write("Is your pet vaccinated?                            1. Yes  2. No   ");
            vac = Console.ReadLine();

            while (true)
            {
                if (vac == "1" || vac == "2")
                {
                    break;
                }
                else
                {
                    Console.SetCursorPosition(50, 31);
                    Console.Write("Please Enter Correct Option!");
                    Console.SetCursorPosition(50, 23);
                    Console.Write("                                                                                                                    ");
                    Console.SetCursorPosition(50, 23);
                    Console.Write("Is your pet vaccinated?                            1. Yes  2. No   ");
                    vac = Console.ReadLine();
                    Console.SetCursorPosition(50, 31);
                    Console.Write("                                              ");
                    continue;
                }
            }

            Console.SetCursorPosition(50, 25);
            Console.Write("Does your pet walk or play well?                   1. Yes  2. No   ");
            play = Console.ReadLine();

            while (true)
            {
                if (play == "1" || play == "2")
                {
                    break;
                }
                else
                {
                    Console.SetCursorPosition(50, 31);
                    Console.Write("Please Enter Correct Option!");
                    Console.SetCursorPosition(50, 25);
                    Console.Write("                                                                                                           ");
                    Console.SetCursorPosition(50, 25);
                    Console.Write("Does your pet walk or play well?                   1. Yes  2. No   ");
                    play = Console.ReadLine();
                    Console.SetCursorPosition(50, 31);
                    Console.Write("                                                    ");
                    continue;
                }
            }

            Console.SetCursorPosition(50, 27);
            Console.Write("Do you bring your pet for monthly checkup?         1. Yes  2. No   ");
            chck = Console.ReadLine();

            while (true)
            {
                if (chck == "1" || chck == "2")
                {
                    break;
                }
                else
                {
                    Console.SetCursorPosition(50, 31);
                    Console.Write("Please Enter Correct Option! ");
                    Console.SetCursorPosition(50, 27);
                    Console.Write("                                                                                                                            ");
                    Console.SetCursorPosition(50, 27);
                    Console.Write("Do you bring your pet for monthly checkup?         1. Yes  2. No   ");
                    chck = Console.ReadLine();
                    Console.SetCursorPosition(50, 31);
                    Console.Write("                                             ");
                    continue;
                }
            }

            Console.SetCursorPosition(50, 29);
            Console.Write("Does your pet eat well?                            1. Yes  2. No   ");
            eat = Console.ReadLine();

            while (true)
            {
                if (eat == "1" || eat == "2")
                {
                    break;
                }
                else
                {
                    Console.SetCursorPosition(50, 31);
                    Console.Write("Please Enter Correct Option!");
                    Console.SetCursorPosition(50, 29);
                    Console.Write("                                                                                                                     ");
                    Console.SetCursorPosition(50, 29);
                    Console.Write("Does your pet eat well?                            1. Yes  2. No   ");
                    eat = Console.ReadLine();
                    Console.SetCursorPosition(50, 31);
                    Console.Write("                                             ");
                    continue;
                }
            }

            if (vac == "1" && eat == "1" && chck == "1" && play == "1")
            {
                return true;
            }
            else if (vac == "2" || eat == "2" || chck == "2" || play == "2")
            {
                return false;
            }

            return false;
        }
        static void PetTraining()
        {
            Console.SetCursorPosition(40, 21);
            Console.Write("Need assistance? Our pet trainers are just a few taps away on the app, ready ");
            Console.SetCursorPosition(40, 22);
            Console.Write("to lend a helping hand - or paw - whenever you need it, ensuring your pet's ");
            Console.SetCursorPosition(40, 23);
            Console.Write("continuous growth and well-being ");
            Console.SetCursorPosition(40, 25);
            
            Console.Write("--------------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.SetCursorPosition(40, 26);
            Console.Write("|                                  TRAINING SCHEDULE                                       |");
            Console.SetCursorPosition(40, 27);
            Console.Write("--------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(40, 28);
            Console.Write("|            AGE           |            WEEKLY             |            MONTHLY            |  ");
            Console.SetCursorPosition(40, 29);
            Console.Write("--------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(40, 30);
            Console.Write("|       1-6 Months         |            20,000 Rs          |             50,000            |  ");
            Console.SetCursorPosition(40, 31);
            Console.Write("--------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(40, 32);
            Console.Write("|       6-12 Months        |            15,000 Rs          |             40,000            |  ");
            Console.SetCursorPosition(40, 33);
            Console.Write("--------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(40, 34);
            Console.Write("|   Elder than 1 Year      |            7 ,000 Rs          |             25,000            |  ");
            Console.SetCursorPosition(40, 35);
            Console.Write("--------------------------------------------------------------------------------------------");
            
            Console.SetCursorPosition(40, 37);
            Console.Write("We are providing 50% discount for fast learning pets!");
            Console.ResetColor();
            Console.SetCursorPosition(40, 39);
            Console.Write("Press any key to continue...");
        }
        // ///////////////////////////////////   FINDING A VET    ////////////////////////////////////////////////////////

        static int FindVet()
        {
            Console.SetCursorPosition(40, 21);
            Console.Write("Looking for a Veterinarian? We have a dedicated team of veterinarians, the heart and soul ");
            Console.SetCursorPosition(40, 22);
            Console.Write("of PetPal app. With years of experience and a deep love for animals, our veterinarians are ");
            Console.SetCursorPosition(40, 23);
            Console.Write("here to provide top-notch healthcare and guidance for your beloved furry companions. ");
            Console.SetCursorPosition(50, 28);
            Console.Write("1. Yes");
            Console.SetCursorPosition(50, 30);
            Console.Write("2. No");
            Console.SetCursorPosition(50, 26);
            Console.Write("Want to see available Veterinarians (Yes/No)?  ");
            string option = Console.ReadLine();
            while (option != "1" && option != "2")
            {

                Console.SetCursorPosition(71, 35);
                Console.Write("Please Enter Correct Option! ");

                Console.SetCursorPosition(50, 26);
                Console.Write("                                                                                                              ");
                Console.SetCursorPosition(50, 26);
                Console.Write("Want to see available Veterinarians (Yes/No)?  ");
                option = Console.ReadLine();
            }
            return int.Parse(option);
        }

        static int OptionForAppointment()
        {
            Console.SetCursorPosition(40, 22);
            Console.Write("1. Check Appointment Status    2. Go Back");
            Console.SetCursorPosition(40, 24);
            Console.Write("Select Option to continue...");
            string option = Console.ReadLine();
            while (option != "1" && option != "2")
            {

                Console.SetCursorPosition(80, 28);
                Console.Write("Please Enter Correct Option! ");

                Console.SetCursorPosition(40, 24);
                Console.Write("                                               ");
                Console.SetCursorPosition(40, 24);
                Console.Write("Select Option to continue...");
                option = Console.ReadLine();
                Console.SetCursorPosition(80, 28);
                Console.Write("                                             ");
            }
            return int.Parse(option);
        }

        static int CustomerAppointmentOptions()
        {
            Console.SetCursorPosition(1, 20);
            Console.Write("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(71, 22);
            Console.Write("1. Pending Appointments");
            Console.SetCursorPosition(71, 24);
            Console.Write("2. Booked Appointments");
            Console.SetCursorPosition(71, 26);
            Console.Write("3. Edit Appointments");
            Console.SetCursorPosition(71, 28);
            Console.Write("4. Delete Appointments");
            Console.SetCursorPosition(71, 30);
            Console.Write("5. Exit");
            Console.SetCursorPosition(1, 32);
            Console.Write("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(71, 34);
            Console.Write("Enter Your Requirement: ");
            string option = Console.ReadLine();
            while (option != "1" && option != "2" && option != "3" && option != "4" && option != "5")
            {

                Console.SetCursorPosition(71, 36);
                Console.Write("Please Enter Correct Option! ");

                Console.SetCursorPosition(71, 34);
                Console.Write("                                                                                                                       ");
                Console.SetCursorPosition(71, 34);
                Console.Write("Enter Your Requirement: ");
                option = Console.ReadLine();
            }
            return int.Parse(option);
        }
        static void BookingAppointment(ref int SelectDoctorType, ref int SelectDay, ref int SelectedTime,
        string[] PetOwnerName, string[] PetOwnerNumber, string[] PetOwnerEmail, string[] PetOwnerLocation,
        string[] PetTypeForAppointment, string[] PetName, string[] PetAge, string[] PetGender, string[] PetWeight,
        string[] Doctor, string[] Time, string[] Day, string[] AppointmentBookedOrPending, ref int AppointmentsCount, string[] BookedBy)
        {
            Console.SetCursorPosition(40, 20);
            Console.Write("Enter Your Name: ");
            PetOwnerName[AppointmentsCount] = Console.ReadLine();

            Console.SetCursorPosition(40, 22);
            Console.Write("Enter Your Phone Number: ");
            string Contact = Console.ReadLine();
            while (Contact.Length != 11)
            {

                Console.SetCursorPosition(60, 28);
                Console.Write("Please add a valid Contact Number of length 11!");

                Console.SetCursorPosition(40, 22);
                Console.Write("                                                        ");
                Console.SetCursorPosition(40, 22);
                Console.Write("Enter Your Phone Number: ");
                Contact = Console.ReadLine();
                Console.SetCursorPosition(60, 28);
                Console.Write("                                                    ");
            }

            while (!checkContactValidity(Contact))
            {
                Console.SetCursorPosition(40, 24);

                Console.Write("Contact Number can only contain digits!");

                Console.SetCursorPosition(40, 22);
                Console.Write("                                     ");
                Console.SetCursorPosition(40, 22);
                Console.Write("Enter Your Phone Number: ");
                Contact = Console.ReadLine();
                Console.SetCursorPosition(40, 24);
                Console.Write("                                           ");
            }

            PetOwnerNumber[AppointmentsCount] = Contact;

            Console.SetCursorPosition(40, 24);
            Console.Write("Enter Your Email: ");
            PetOwnerEmail[AppointmentsCount] = Console.ReadLine();

            Console.SetCursorPosition(40, 26);
            Console.Write("Enter Your Location: ");
            PetOwnerLocation[AppointmentsCount] = Console.ReadLine();

            Console.SetCursorPosition(40, 28);
            Console.Write("Enter Your Pet Type: ");
            PetTypeForAppointment[AppointmentsCount] = Console.ReadLine();

            Console.SetCursorPosition(40, 30);
            Console.Write("Enter Your Pet Name: ");
            PetName[AppointmentsCount] = Console.ReadLine();

            Console.SetCursorPosition(40, 32);
            Console.Write("Enter Your Pet Age (in months): ");
            PetAge[AppointmentsCount] = Console.ReadLine();

            Console.SetCursorPosition(40, 34);
            Console.Write("Enter Your Pet Gender: ");
            PetGender[AppointmentsCount] = Console.ReadLine();

            Console.SetCursorPosition(40, 36);
            Console.Write("Enter Your Pet Weight (in Pounds): ");
            PetWeight[AppointmentsCount] = Console.ReadLine();

            Console.SetCursorPosition(80, 22);
            Console.Write("1. Dermatology");
            Console.SetCursorPosition(80, 24);
            Console.Write("2. Primary Care");
            Console.SetCursorPosition(80, 26);
            Console.Write("3. Internal Medicine");
            Console.SetCursorPosition(80, 20);
            Console.Write("What is your requirement? ");
            Doctor[AppointmentsCount] = Console.ReadLine();

            while (Doctor[AppointmentsCount] != "1" && Doctor[AppointmentsCount] != "2" && Doctor[AppointmentsCount] != "3")
            {
                Console.SetCursorPosition(80, 28);

                Console.Write("Please Enter Correct Option!");

                Console.SetCursorPosition(80, 20);
                Console.Write("                                          ");
                Console.SetCursorPosition(80, 20);
                Console.Write("What is your requirement? ");
                Doctor[AppointmentsCount] = Console.ReadLine();
                Console.SetCursorPosition(80, 20);
                Console.Write("                                          ");
                Console.SetCursorPosition(80, 28);
            }

            SelectDoctorType = int.Parse(Doctor[AppointmentsCount]);
            AppointmentsCount++;
        }
        static int Bookingindex(string[] BookedBy, string currentCustomer, int AppointmentsCount)
        {
            int bookingidx = -1;
            for (int v = 0; v < AppointmentsCount; v++)
            {
                if (currentCustomer == BookedBy[v])
                {
                    bookingidx = v;
                }
            }
            return bookingidx;
        }
        static int CountBookedAppointmentsForCustomer(string[] BookedBy, int AppointmentsCount, string[] AppointmentBookOrPending, int customeridx, string[] CustomerName)
        {
            int x = 0;
            for (int z = 0; z < AppointmentsCount; z++)
            {
                if (AppointmentBookOrPending[z] == "Booked" && CustomerName[customeridx] == BookedBy[z])
                {
                    x++;
                }
                else
                {
                    continue;
                }
            }

            return x;
        }
        static int CountPendingAppointmentsForCustomer(string[] BookedBy, int AppointmentsCount, string[] AppointmentBookOrPending, int customeridx, string[] CustomerName)
        {
            int x = 0;
            for (int z = 0; z < AppointmentsCount; z++)
            {
                if (AppointmentBookOrPending[z] == "Pending" && CustomerName[customeridx] == BookedBy[z])
                {
                    x++;
                }
                else
                {
                    continue;
                }
            }

            return x;
        }
        static int CountPendingAppointmentsForAdmin(int AppointmentsCount, string[] AppointmentBookOrPending)
        {
            int x = 0;
            for (int z = 0; z < AppointmentsCount; z++)
            {
                if (AppointmentBookOrPending[z] == "Pending")
                {
                    x++;
                }
                else
                {
                    continue;
                }
            }

            return x;
        }
        static void ShowPendingAppointmetsToCustomer(ref int Appointmentidx, int Total, string[] DoctorAppointed, string[] DayAppointed, int Bookingidx,
                                      string[] Veterinarians, ref int SelectDoctorType, ref int SelectDay, ref int SelectedTime, string[] PetOwnerName,
                                      string[] PetOwnerNumber, string[] PetOwnerEmail, string[] PetOwnerLocation, string[] PetTypeForAppointment,
                                      string[] PetName, string[] PetAge, string[] PetGender, string[] PetWeight, string[] Doctor, string[] Time,
                                      string[] Day, ref int AppointmentsCount, string[] AppointmentBookOrPending, string[] BookedBy, string[] CustomerName,
                                      int customeridx)
        {
            int y = 0;
            for (int z = 0; z < AppointmentsCount; z++)
            {
                if ((CustomerName[customeridx] == BookedBy[z]) && (AppointmentBookOrPending[z] == "Pending"))
                {
                    CustomerHeader();
                    y++;
                    Console.SetCursorPosition(40, 20);
                    
                    Console.Write("Pet Owner Name: " + PetOwnerName[z]);

                    Console.SetCursorPosition(40, 22);
                    
                    Console.Write("Pet Owner Contact: " + PetOwnerNumber[z]);

                    Console.SetCursorPosition(40, 24);
                    
                    Console.Write("Pet Owner Email: " + PetOwnerEmail[z]);

                    Console.SetCursorPosition(40, 26);
                    
                    Console.Write("Pet Owner Location: " + PetOwnerNumber[z]);

                    Console.SetCursorPosition(40, 28);
                    
                    Console.Write("Pet Type: " + PetTypeForAppointment[z]);

                    Console.SetCursorPosition(80, 20);
                    
                    Console.Write("Pet Name: " + PetName[z]);

                    Console.SetCursorPosition(80, 22);
                    
                    Console.Write("Pet Age: " + PetAge[z] + " Months");

                    Console.SetCursorPosition(80, 24);
                    
                    Console.Write("Pet Weight: " + PetWeight[z] + " Pounds");

                    Console.SetCursorPosition(80, 26);
                    
                    Console.Write("Pet Gender: " + PetGender[z]);

                    Console.SetCursorPosition(80, 28);
                    
                    Console.Write("Appointment For: " + DoctorAppointed[z]);

                    Console.SetCursorPosition(40, 30);
                    
                    Console.Write("Appointment Status: " + AppointmentBookOrPending[z]);

                    Console.SetCursorPosition(80, 30);
                    
                    Console.Write("Day For Appointment: " + DayAppointed[z]);

                    Console.SetCursorPosition(60, 32);
                    Console.Write("Press any key to see next Appointment..");
    
                    Console.ReadKey();
                }
                else
                {
                    continue;
                }
            }
            if (y == 1)
            {
                Console.SetCursorPosition(60, 34);
                Console.Write("                                               ");
                Console.SetCursorPosition(60, 34);
                
                Console.Write($"There is Only {y} Pending Appointment");
            }
            else if (y > 1)
            {
                Console.SetCursorPosition(60, 34);
                Console.Write("                                               ");
                Console.SetCursorPosition(60, 34);
                
                Console.Write($"There are Only {y} Pending Appointments");
            }

            Console.ResetColor();

        }
        static void ShowBookedAppointmetsToCustomer(int Total, string[] DoctorAppointed, string[] DayAppointed, int Bookingidx, string[] Veterinarians,
                                             ref int SelectDoctorType, ref int SelectDay, ref int SelectedTime, string[] PetOwnerName, string[] PetOwnerNumber,
                                             string[] PetOwnerEmail, string[] PetOwnerLocation, string[] PetTypeForAppointment, string[] PetName, string[] PetAge, string[] PetGender, string[] PetWeight, string[] Doctor, string[] Time, string[] Day,
                                             ref int AppointmentsCount, string[] AppointmentBookOrPending, string[] BookedBy, string[] CustomerName, int customeridx)
        {
            int y = 0;
            for (int z = 0; z < AppointmentsCount; z++)
            {
                if ((CustomerName[customeridx] == BookedBy[z]) && (AppointmentBookOrPending[z] == "Booked"))
                {
                    CustomerHeader();
                    y++;
                    Console.SetCursorPosition(40, 20);
                    Console.Write("Pet Owner Name: " + PetOwnerName[z]);
                    Console.SetCursorPosition(40, 22);
                    Console.Write("Pet Owner Contact: " + PetOwnerNumber[z]);
                    Console.SetCursorPosition(40, 24);
                    Console.Write("Pet Owner Email: " + PetOwnerEmail[z]);
                    Console.SetCursorPosition(40, 26);
                    Console.Write("Pet Owner Location: " + PetOwnerLocation[z]);
                    Console.SetCursorPosition(40, 28);
                    Console.Write("Pet Type: " + PetTypeForAppointment[z]);
                    Console.SetCursorPosition(80, 20);
                    Console.Write("Pet Name: " + PetName[z]);
                    Console.SetCursorPosition(80, 22);
                    Console.Write("Pet Age: " + PetAge[z] + " Months");
                    Console.SetCursorPosition(80, 24);
                    Console.Write("Pet Weight: " + PetWeight[z] + " Pounds");
                    Console.SetCursorPosition(80, 26);
                    Console.Write("Pet Gender: " + PetGender[z]);
                    Console.SetCursorPosition(80, 28);
                    Console.Write("Appointment For: " + DoctorAppointed[z]);
                    Console.SetCursorPosition(40, 30);
                    Console.Write("Appointment Status: " + AppointmentBookOrPending[z]);
                    Console.SetCursorPosition(80, 30);
                    Console.Write("Day For Appointment: " + DayAppointed[z]);
                    Console.SetCursorPosition(60, 32);
                    Console.Write("Press any key to see the next Appointment..");
                    Console.ReadKey();
                }
                else
                {
                    continue;
                }
            }
            if (y == 1)
            {
                Console.SetCursorPosition(60, 34);
                Console.Write("                                               ");
                Console.SetCursorPosition(60, 34);
                Console.Write("You Have Only " + y + " Booked Appointment");
            }
            else if (y > 1)
            {
                Console.SetCursorPosition(60, 34);
                Console.Write("                                               ");
                Console.SetCursorPosition(60, 34);
                Console.Write("You Have " + y + " Booked Appointments");
            }
        }
        static void CheckAppointment(int total, string[] doctorAppointed, string[] dayAppointed, int bookingIdx, string[] petOwnerName, string[] petOwnerNumber, string[] petOwnerEmail,
                                 string[] petOwnerLocation, string[] petTypeForAppointment, string[] petName, string[] petAge, string[] petGender, string[] petWeight, string[] doctor,
                                 string[] time, string[] day, ref int appointmentsCount, string[] appointmentBookOrPending, string[] bookedBy, string[] customerName, int customerIdx)
        {
            Console.SetCursorPosition(40, 20);
            Console.Write("Pet Owner Name: " + petOwnerName[bookingIdx]);
            Console.SetCursorPosition(40, 22);
            Console.Write("Pet Owner Contact: " + petOwnerNumber[bookingIdx]);
            Console.SetCursorPosition(40, 24);
            Console.Write("Pet Owner Email: " + petOwnerEmail[bookingIdx]);
            Console.SetCursorPosition(40, 26);
            Console.Write("Pet Owner Location: " + petOwnerLocation[bookingIdx]);
            Console.SetCursorPosition(40, 28);
            Console.Write("Pet Type: " + petTypeForAppointment[bookingIdx]);
            Console.SetCursorPosition(80, 20);
            Console.Write("Pet Name: " + petName[bookingIdx]);
            Console.SetCursorPosition(80, 22);
            Console.Write("Pet Age : " + petAge[bookingIdx] + " Months");
            Console.SetCursorPosition(80, 24);
            Console.Write("Pet Weight: " + petWeight[bookingIdx] + " Pounds");
            Console.SetCursorPosition(80, 26);
            Console.Write("Pet Gender: " + petGender[bookingIdx]);
            Console.SetCursorPosition(80, 28);
            Console.Write("Appointment For: " + doctorAppointed[bookingIdx]);
            Console.SetCursorPosition(40, 30);
            Console.Write("Appointment Status: " + appointmentBookOrPending[bookingIdx]);
            Console.SetCursorPosition(80, 30);
            Console.Write("Day For Appointment: " + dayAppointed[bookingIdx]);
        }
        static void DeleteAppointmentsByCustomer(string[] CustomerName, int customeridx, ref int Bookingidx, ref int BookedAppointmentsTotal,
        ref int PendingAppointmentsTotal, string[] DoctorAppointed, string[] DayAppointed, string[] PetOwnerName, string[] PetOwnerNumber,
        string[] PetOwnerEmail, string[] PetOwnerLocation, string[] PetTypeForAppointment, string[] PetName, string[] PetAge, string[] PetGender,
        string[] PetWeight, string[] Doctor, string[] Time, string[] Day, ref int AppointmentsCount, string[] AppointmentBookOrPending,
        string[] BookedBy, string[] BookedForPet, string[] BookedByPassword, ref int Appointmentidx, string[] DoctorName)
        {
            int x = 0;
            string Confirmation = "";
            for (int z = 0; z < AppointmentsCount; z++)
            {
                if ((CustomerName[customeridx] == BookedBy[z]) && (AppointmentBookOrPending[z] == "Pending"))
                {
                    x++;
                    CustomerHeader();
                    Console.SetCursorPosition(40, 20);
                    Console.Write( "Pet Owner Name: " + PetOwnerName[z]);
                    Console.SetCursorPosition(40, 22);
                    Console.Write( "Pet Owner Contact: " + PetOwnerNumber[z]);
                    Console.SetCursorPosition(40, 24);
                    Console.Write( "Pet Owner Email: " + PetOwnerEmail[z]);
                    Console.SetCursorPosition(40, 26);
                    Console.Write( "Pet Owner Location: " + PetOwnerLocation[z]);
                    Console.SetCursorPosition(40, 28);
                    Console.Write( "Pet Type: " + PetTypeForAppointment[z]);
                    Console.SetCursorPosition(80, 20);
                    Console.Write( "Pet Name: " + PetName[z]);
                    Console.SetCursorPosition(80, 22);
                    Console.Write( "Pet Age : " + PetAge[z] + " Months");
                    Console.SetCursorPosition(80, 24);
                    Console.Write( "Pet Weight: " + PetWeight[z] + " Pounds");
                    Console.SetCursorPosition(80, 26);
                    Console.Write( "Pet Gender: " + PetGender[z]);
                    Console.SetCursorPosition(80, 28);
                    Console.Write( "Appointment For: " + DoctorAppointed[z]);
                    Console.SetCursorPosition(40, 30);
                    Console.Write( "Appointment Status: " + AppointmentBookOrPending[z]);
                    Console.SetCursorPosition(80, 30);
                    Console.SetCursorPosition(50, 34);
                    Console.Write( "                                                   ");
                    Console.SetCursorPosition(50, 36);
                    Console.Write( "1. Yes    2. No");
                    Console.SetCursorPosition(50, 34);
                    Console.Write( "Do You Want To Delete this Appointment? ");
                    Confirmation =  Console.ReadLine();
                    while (Confirmation != "1" && Confirmation != "2")
                    {
                        Console.SetCursorPosition(50, 38);
                        Console.Write( "Please Enter Correct Option! ");
                        Console.SetCursorPosition(50, 34);
                        Console.Write( "                                                   ");
                        Console.SetCursorPosition(50, 34);
                        Console.Write( "Do You Want To Delete this Appointment? ");
                        Confirmation =  Console.ReadLine();
                    }
                    int confirmation = STOI(Confirmation);
                    if (confirmation == 1)
                    {
                        for (int a = z; a < AppointmentsCount; a++)
                        {
                            BookedBy[a] = BookedBy[a + 1];
                            BookedByPassword[a] = BookedByPassword[a + 1];
                            BookedForPet[a] = BookedForPet[a + 1];
                            PetOwnerName[a] = PetOwnerName[a + 1];
                            PetOwnerNumber[a] = PetOwnerNumber[a + 1];
                            PetOwnerEmail[a] = PetOwnerEmail[a + 1];
                            PetOwnerLocation[a] = PetOwnerLocation[a + 1];
                            PetTypeForAppointment[a] = PetTypeForAppointment[a + 1];
                            PetName[a] = PetName[a + 1];
                            PetAge[a] = PetAge[a + 1];
                            PetGender[a] = PetGender[a + 1];
                            PetWeight[a] = PetWeight[a + 1];
                            DoctorAppointed[a] = DoctorAppointed[a + 1];
                            DayAppointed[a] = DayAppointed[a + 1];
                            AppointmentBookOrPending[a] = AppointmentBookOrPending[a + 1];
                            DoctorName[a] = DoctorName[a + 1];
                            Doctor[a] = Doctor[a + 1];
                            Day[a] = Day[a + 1];
                        }

                        if (AppointmentBookOrPending[z] == "Pending")
                        {
                            PendingAppointmentsTotal--;
                        }
                        else if (AppointmentBookOrPending[z] == "Booked")
                        {
                            BookedAppointmentsTotal--;
                        }
                        AppointmentsCount--;
                        continue;
                    }
                    else if (confirmation == 2)
                    {
                        continue;
                    }
                }
                if (x == 1)
                {
                    Console.SetCursorPosition(50, 34);
                    Console.Write( "                                               ");
                    Console.SetCursorPosition(50, 34);
                    Console.Write( "There was Only " + x + " Appointment");
                }
                else if (x > 1)
                {
                    Console.SetCursorPosition(50, 34);
                    Console.Write( "                                               ");
                    Console.SetCursorPosition(50, 34);
                    Console.Write( "There were Only " + x + " Appointments");
                }
            }
        }
        static int AskForEdit(ref int Appointmentidx, int Total, string[] DoctorAppointed, string[] DayAppointed, int Bookingidx, string[] Veterinarians, ref int SelectDoctorType,
        ref int SelectDay, ref int SelectedTime, string[] PetOwnerName, string[] PetOwnerNumber, string[] PetOwnerEmail, string[] PetOwnerLocation, string[] PetTypeForAppointment, string[] PetName, string[] PetAge, string[] PetGender, string[] PetWeight, string[] Doctor, string[] Time, string[] Day,
        ref int AppointmentsCount, string[] AppointmentBookOrPending, string[] BookedBy, string[] CustomerName, int customeridx)
            {
            int SelectedOption = 0;
            for (int z = 0; z < AppointmentsCount; z++)
            {
                if ((CustomerName[customeridx] == BookedBy[z]) && (AppointmentBookOrPending[z] == "Pending"))
                {
                    CustomerHeader();
                    Appointmentidx = z;
                    Console.SetCursorPosition(40, 20);
                    Console.Write("Pet Owner Name: " + PetOwnerName[z]);
                    Console.SetCursorPosition(40, 22);
                    Console.Write("Pet Owner Contact: " + PetOwnerNumber[z]);
                    Console.SetCursorPosition(40, 24);
                    Console.Write("Pet Owner Email: " + PetOwnerEmail[z]);
                    Console.SetCursorPosition(40, 26);
                    Console.Write("Pet Owner Location: " + PetOwnerNumber[z]); // Assuming it's a mistake in the original code and it should be PetOwnerLocation[z]
                    Console.SetCursorPosition(40, 28);
                    Console.Write("Pet Type: " + PetTypeForAppointment[z]);
                    Console.SetCursorPosition(80, 20);
                    Console.Write("Pet Name: " + PetName[z]);
                    Console.SetCursorPosition(80, 22);
                    Console.Write("Pet Age : " + PetAge[z] + " Months");
                    Console.SetCursorPosition(80, 24);
                    Console.Write("Pet Weight: " + PetWeight[z] + " Pounds");
                    Console.SetCursorPosition(80, 26);
                    Console.Write("Pet Gender: " + PetGender[z]);
                    Console.SetCursorPosition(80, 28);
                    Console.Write("Appointment For: " + DoctorAppointed[z]);
                    Console.SetCursorPosition(40, 30);
                    Console.Write("Appointment Status: " + AppointmentBookOrPending[z]);
                    Console.SetCursorPosition(80, 30);
                    Console.Write("Day For Appointment: " + DayAppointed[z]);
                    Console.SetCursorPosition(60, 34);
                    Console.Write("1. Yes          2. No");
                    Console.SetCursorPosition(60, 32);
                    Console.Write("Edit This Appointment? ");
                    string option = Console.ReadLine();

                    while (option != "1" && option != "2")
                    {
                        Console.SetCursorPosition(60, 36);
                        Console.Write("\u001b[0;31mPlease Enter Correct Option! ");
                        Console.SetCursorPosition(60, 32);
                        Console.Write("                                               ");
                        Console.SetCursorPosition(60, 32);
                        Console.Write("Edit This Appointment? ");
                        option = Console.ReadLine();
                        Console.SetCursorPosition(60, 36);
                        Console.Write("                                             ");
                    }

                    int selectedOption = int.Parse(option);
                    if (SelectedOption == 1)
                    {
                        break;
                    }
                    else if (SelectedOption == 2)
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }
            return SelectedOption;
        }
        static void EditAppointMent(int appointmentIdx, int total, string[] doctorAppointed, string[] dayAppointed, int bookingIdx, string[] veterinarians, ref int selectDoctorType,
                     ref int selectDay, ref int selectedTime, string[] petOwnerName, string[] petOwnerNumber, string[] petOwnerEmail, string[] petOwnerLocation, string[] petTypeForAppointment,
                     string[] petName, string[] petAge, string[] petGender, string[] petWeight, string[] doctor, string[] time, string[] day, ref int appointmentsCount, string[] appointmentBookOrPending, string[] bookedBy, string[] customerName, int customerIdx)
        {
            CustomerHeader();
            Console.SetCursorPosition(40, 20);
            Console.Write("1. Edit Pet Owner Name ");
            Console.SetCursorPosition(40, 22);
            Console.Write("2. Edit Pet Owner Contact ");
            Console.SetCursorPosition(40, 24);
            Console.Write("3. Edit Pet Owner Email ");
            Console.SetCursorPosition(40, 26);
            Console.Write("4. Edit Pet Owner Location ");
            Console.SetCursorPosition(40, 28);
            Console.Write("5. Edit Pet Type ");
            Console.SetCursorPosition(80, 20);
            Console.Write("6. Edit Pet Name ");
            Console.SetCursorPosition(80, 22);
            Console.Write("7. Edit Pet Age  ");
            Console.SetCursorPosition(80, 24);
            Console.Write("8. Edit Pet Weight ");
            Console.SetCursorPosition(80, 26);
            Console.Write("9. Edit Pet Gender ");
            Console.SetCursorPosition(80, 28);
            Console.Write("10. Edit Appointment Requirement ");
            Console.SetCursorPosition(60, 32);
            Console.Write("Select Option You Want to Edit... ");
            string option = Console.ReadLine();

            while (option != "1" && option != "2" && option != "3" && option != "4" && option != "5" && option != "6" && option != "7" && option != "8" && option != "9" && option != "10")
            {
                Console.SetCursorPosition(60, 34);
                Console.Write("Please Enter Correct Option! ");
                Console.SetCursorPosition(60, 32);
                Console.Write("                                                        ");
                Console.SetCursorPosition(60, 32);
                Console.Write("Select Option You Want to Edit... ");
                option = Console.ReadLine();
                Console.SetCursorPosition(60, 34);
                Console.Write("                                             ");
            }

            CustomerHeader();
            int selectedOption = int.Parse(option);

            if (selectedOption == 1)
            {
                Console.SetCursorPosition(60, 24);
                Console.Write("                                   ");
                Console.SetCursorPosition(60, 24);
                Console.Write("Enter Pet Owner Name: ");
                petOwnerName[appointmentIdx] = Console.ReadLine();
                Console.SetCursorPosition(60, 26);
                Console.Write("Pet Owner Name Edited!");
            }
            else if (selectedOption == 2)
            {
                Console.SetCursorPosition(60, 24);
                Console.Write("                                   ");
                Console.SetCursorPosition(60, 24);
                Console.Write("Enter Pet Owner Contact: ");
                petOwnerNumber[appointmentIdx] = Console.ReadLine();
                Console.SetCursorPosition(60, 26);
                Console.Write("Pet Owner Contact Edited!");
            }
            else if (selectedOption == 3)
            {
                Console.SetCursorPosition(60, 24);
                Console.Write("                                   ");
                Console.SetCursorPosition(60, 24);
                Console.Write("Enter Pet Owner Email: ");
                petOwnerEmail[appointmentIdx] = Console.ReadLine();
                Console.SetCursorPosition(60, 26);
                Console.Write("Pet Owner Email Edited!");
            }
            else if (selectedOption == 4)
            {
                Console.SetCursorPosition(60, 24);
                Console.Write("                                   ");
                Console.SetCursorPosition(60, 24);
                Console.Write("Enter Pet Owner Location: ");
                petOwnerLocation[appointmentIdx] = Console.ReadLine();
                Console.SetCursorPosition(60, 26);
                Console.Write("Pet Owner Location Edited!");
            }
            else if (selectedOption == 5)
            {
                Console.SetCursorPosition(60, 24);
                Console.Write("                                   ");
                Console.SetCursorPosition(60, 24);
                Console.Write("Enter Pet Type: ");
                petTypeForAppointment[appointmentIdx] = Console.ReadLine();
                Console.SetCursorPosition(60, 26);
                Console.Write("Pet Type Edited!");
            }
            else if (selectedOption == 6)
            {
                Console.SetCursorPosition(60, 24);
                Console.Write("                                   ");
                Console.SetCursorPosition(60, 24);
                Console.Write("Enter Pet Name: ");
                petName[appointmentIdx] = Console.ReadLine();
                Console.SetCursorPosition(60, 26);
                Console.Write("Pet Name Edited!");
            }
            else if (selectedOption == 7)
            {
                Console.SetCursorPosition(60, 24);
                Console.Write("                                   ");
                Console.SetCursorPosition(60, 24);
                Console.Write("Enter Pet Age: ");
                petAge[appointmentIdx] = Console.ReadLine();
                Console.SetCursorPosition(60, 26);
                Console.Write("Pet Age Edited!");
            }
            else if (selectedOption == 8)
            {
                Console.SetCursorPosition(60, 24);
                Console.Write("                                   ");
                Console.SetCursorPosition(60, 24);
                Console.Write("Enter Pet Weight: ");
                petWeight[appointmentIdx] = Console.ReadLine();
                Console.SetCursorPosition(60, 26);
                Console.Write("Pet Weight Edited!");
            }
            else if (selectedOption == 9)
            {
                Console.SetCursorPosition(60, 24);
                Console.Write("                                   ");
                Console.SetCursorPosition(60, 24);
                Console.Write("Enter Pet Gender: ");
                petGender[appointmentIdx] = Console.ReadLine();
                Console.SetCursorPosition(60, 26);
                Console.Write("Pet Gender Edited!");
            }
            else if (selectedOption == 10)
            {
                Console.Write("1. Dermatology");
                Console.Write("2. Primary Care");
                Console.Write("3. Internal Medicine");
                Console.SetCursorPosition(60, 22);
                Console.Write("                                   ");
                Console.SetCursorPosition(60, 22);
                Console.Write("Select Requirement For Appointment: ");
                string selectedDoctor = Console.ReadLine();

                while (selectedDoctor != "1" && selectedDoctor != "2" && selectedDoctor != "3")
                {
                    Console.SetCursorPosition(60, 30);
                    Console.Write("Please Enter Correct Doctor! ");
                    Console.SetCursorPosition(60, 22);
                    Console.Write("                                                                      ");
                    Console.SetCursorPosition(60, 22);
                    Console.Write("Select Requirement For Appointment: ");
                    selectedDoctor = Console.ReadLine();
                    Console.SetCursorPosition(60, 30);
                    Console.Write("                                             ");
                }

                int doctorIdx = int.Parse(selectedDoctor);
                doctorAppointed[appointmentIdx] = veterinarians[doctorIdx - 1];
                Console.SetCursorPosition(60, 30);
                Console.Write("Requirement Edited!");
            }
        }
        static int TotalAppointmentsByOneUser(string[] BookedBy, string currentCustomer, int AppointmentsCount)
        {
            int total = 0;
            for (int v = 0; v < AppointmentsCount; v++)
            {
                if (currentCustomer == BookedBy[v])
                {
                    total++;
                }
            }
            return total;
        }
        static void saveCustomerAppointments(string[] CustomerName, string[] ValidUsername, string[] PetOwnerName, string[] PetOwnerNumber, string[] PetOwnerEmail, string[] PetOwnerLocation, string[] PetTypeForAppointment,
                                      string[] PetName, string[] PetAge, string[] PetGender, string[] PetWeight, string[] Doctor, string[] AppointmentBookOrPending,
                                     ref int AppointmentsCount, string[] BookedBy, string[] BookedByPassword, string[] DoctorAppointed, string[] DayAppointed, string AppointmentFile, int customeridx)
        {
            StreamWriter file = new StreamWriter(AppointmentFile);
            int idx=0;
            for (int i = 0; i < AppointmentsCount; i++)
            {
                checkindex(AppointmentsCount,ref idx, BookedBy[i], BookedByPassword[i], BookedBy, BookedByPassword);
                int total = TotalAppointmentsByOneUser(BookedBy, BookedBy[i], AppointmentsCount);
                int booked = CountBookedAppointmentsForCustomer(BookedBy, AppointmentsCount, AppointmentBookOrPending, customeridx, CustomerName);

                file.Write( PetOwnerName[i] + "," + PetOwnerNumber[i] + "," + PetOwnerEmail[i] + "," + PetOwnerLocation[i] + "," + PetTypeForAppointment[i] + "," + PetName[i] + "," + PetAge[i] + "," + PetGender[i] + "," + PetWeight[i] + "," + Doctor[i] + "," + AppointmentBookOrPending[i] + "," + BookedBy[i] + "," + BookedByPassword[i] + "," + DoctorAppointed[i] + "," + DayAppointed[i]
                     + ",");
                if (BookedBy[idx] == BookedBy[i])
                {
                    file.WriteLine((total - booked) + "," + booked + "," + total);
                }
            }
            file.Flush();
            file.Close();
        }
        static void CustomerMainMenu(string[] ValidUsername,ref int BookedAppointmentsTotal,ref int PendingAppointmentsTotal, int Appointmentidx, int Total, int Bookingidx, int countCustomers, int customeridx, int countUser,
                      string[] ThreeUsers, string[] TimeAppointed, string[] DoctorAppointed, string[] DayAppointed, string[] BookedForPet, string[] Veterinarians, string[] PetOwnerName,
                      string[] PetOwnerNumber, string[] PetOwnerEmail, string[] PetOwnerLocation, string[] PetTypeForAppointment, string[] PetName, string[] PetAge, string[] PetGender,
                      string[] PetWeight, string[] Doctor, string[] DoctorName, string[] Time, string[] Day, int SelectDoctorType, int SelectDay, int SelectedTime, int condition,
                     ref int AppointmentsCount, string[] AppointmentBookOrPending, string[] CustomerName, string[] CustomerPassword, string[] BookedBy, string[] BookedByPassword,
                      string AppointmentFile, string[] VetName, string[] VetPassword, string[] VetEmail, string[] VetContact, string[] VetDays, string[] VetService,ref int countVets,
                     ref int countVeterinarians, string VetFile, int vetidx)
        {
            int CustomerPendingCount = 0;
            int CustomerBookedCount = 0;
            int EditChoice = 0;
            while (true)
            {
                printHeader();
                int CustomerRequirment = PrintCustomerMenu();
                if (CustomerRequirment == 5)
                {
                    break;
                }
                else if (CustomerRequirment == 1)
                {
                    CustomerHeader();
                    AboutUs();
                    Console.ReadKey();
                }
                else if (CustomerRequirment == 2)
                {
                    int SelectedService = 0;
                    while (true)
                    {
                        CustomerHeader();
                        SelectedService = Services();
                        int PetType = 0;
                        if (SelectedService == 1)
                        {
                            CustomerHeader();
                            PetType = OverNightCare();
                            if (PetType == 1)
                            {
                                CustomerHeader();
                                DogCare();
                                Console.ReadKey();
                            }
                            else if (PetType == 2)
                            {
                                CustomerHeader();
                                CatCare();
                                Console.ReadKey();
                            }
                            else if (PetType == 3)
                            {
                                CustomerHeader();
                                RabbitCare();
                                Console.ReadKey();
                            }
                        }
                        else if (SelectedService == 2)
                        {
                            CustomerHeader();
                            if (MedicalCheckup())
                            {
                                Console.SetCursorPosition(50, 31);
                                Console.Write( "No need to worry! Your pet is medically fit. ");
                            }
                            else
                            {
                                Console.SetCursorPosition(50, 31);
                                Console.Write( "Your pet is not medically fit. Consult a Veterinarian!");
                            }
                            Console.SetCursorPosition(71, 50);
                            Console.Write( "Press any key to continue.....");
                            Console.ReadKey();
                        }
                        else if (SelectedService == 3)
                        {
                            CustomerHeader();
                            PetTraining();
                            Console.ReadKey();
                        }
                        else if (SelectedService == 4)
                        {
                            break;
                        }
                    }
                }
                else if (CustomerRequirment == 3)
                {
                    int SeeVets = 0;
                    while (true)
                    {
                        CustomerHeader();
                        SeeVets = FindVet();
                        if (SeeVets == 1)
                        {

                            CustomerHeader();
                            BookingAppointment(ref SelectDoctorType, ref SelectDay, ref SelectedTime, PetOwnerName, PetOwnerNumber, PetOwnerEmail, PetOwnerLocation,
                                               PetTypeForAppointment, PetName, PetAge, PetGender, PetWeight,
                                               Doctor, Time, Day, AppointmentBookOrPending, ref AppointmentsCount, BookedBy);

                            BookedBy[AppointmentsCount - 1] = CustomerName[customeridx];
                            BookedByPassword[AppointmentsCount - 1] = CustomerPassword[customeridx];
                            DoctorAppointed[AppointmentsCount - 1] = Veterinarians[SelectDoctorType - 1];
                            DayAppointed[AppointmentsCount - 1] = "Not Decided";
                            AppointmentBookOrPending[AppointmentsCount - 1] = "Pending";
                            PendingAppointmentsTotal = CountPendingAppointmentsForAdmin(AppointmentsCount, AppointmentBookOrPending);
                            saveCustomerAppointments(CustomerName, ValidUsername, PetOwnerName, PetOwnerNumber, PetOwnerEmail, PetOwnerLocation, PetTypeForAppointment,
                                       PetName, PetAge, PetGender, PetWeight, Doctor, AppointmentBookOrPending,
                                     ref AppointmentsCount, BookedBy, BookedByPassword, DoctorAppointed, DayAppointed, AppointmentFile, customeridx);
                            saveVetDetails(VetName, VetPassword, VetEmail, VetContact, VetDays, VetService, ref  countVets, ref countVeterinarians, VetFile, DoctorAppointed, AppointmentsCount, AppointmentBookOrPending, vetidx);
                            CustomerHeader();
                            Console.SetCursorPosition(40, 20);
                            Console.Write( "Great! Your Appointment has been lineed for " + Veterinarians[SelectDoctorType - 1]);
                            int ForAppointment = OptionForAppointment();
                            if (ForAppointment == 1)
                            {
                                CustomerHeader();
                                Bookingidx = Bookingindex(BookedBy, CustomerName[customeridx], AppointmentsCount);
                                CheckAppointment(Total, DoctorAppointed, DayAppointed, Bookingidx, PetOwnerName, PetOwnerNumber, PetOwnerEmail, PetOwnerLocation,
                                                 PetTypeForAppointment, PetName, PetAge, PetGender, PetWeight,
                                                 Doctor, Time, Day,ref  AppointmentsCount, AppointmentBookOrPending, BookedBy, CustomerName, customeridx);
                                Console.SetCursorPosition(60, 34);
                                Console.Write( "Press any key to continue...");
                            }
                            else if (ForAppointment == 2)
                            {
                                break;
                            }
                            Console.ReadKey();
                        }
                        else if (SeeVets == 2)
                        {
                            break;
                        }
                    }
                }
                else if (CustomerRequirment == 4)
                {
                    while (true)
                    {
                        CustomerHeader();
                        int AppointmentOption = CustomerAppointmentOptions();
                        if (AppointmentOption == 1)
                        {
                            CustomerPendingCount = CountPendingAppointmentsForCustomer(BookedBy, AppointmentsCount, AppointmentBookOrPending, customeridx, CustomerName);
                            if (CustomerPendingCount == 0)
                            {
                                CustomerHeader();
                                Console.SetCursorPosition(65, 26);
                                Console.Write( "You have no pending Appointment !");
                                Console.SetCursorPosition(65, 36);
                                Console.Write( "Press any key to continue...");
                                Console.ReadKey();
                            }
                            else
                            {
                                CustomerHeader();
                                ShowPendingAppointmetsToCustomer(ref Appointmentidx, Total, DoctorAppointed, DayAppointed, Bookingidx, Veterinarians, ref SelectDoctorType, ref SelectDay, ref SelectedTime,
                                                                 PetOwnerName,
                                                                 PetOwnerNumber,
                                                                 PetOwnerEmail,
                                                                 PetOwnerLocation,
                                                                 PetTypeForAppointment,
                                                                 PetName,
                                                                 PetAge,
                                                                 PetGender,
                                                                 PetWeight,
                                                                 Doctor,
                                                                 Time,
                                                                 Day, ref AppointmentsCount,
                                                                 AppointmentBookOrPending, BookedBy, CustomerName, customeridx);
                                Console.SetCursorPosition(65, 36);
                                Console.Write( "Press any key to continue...");
                                Console.ReadKey();
                            }
                        }
                        else if (AppointmentOption == 2)
                        {
                            CustomerBookedCount = CountBookedAppointmentsForCustomer(BookedBy, AppointmentsCount, AppointmentBookOrPending, customeridx, CustomerName);
                            if (CustomerBookedCount == 0)
                            {
                                CustomerHeader();
                                Console.SetCursorPosition(65, 26);
                                Console.Write( "You have no booked Appointment !");
                                Console.SetCursorPosition(65, 36);
                                Console.Write( "Press any key to continue...");
                                Console.ReadKey();
                            }
                            else
                            {
                                ShowBookedAppointmetsToCustomer(Total, DoctorAppointed, DayAppointed, Bookingidx, Veterinarians, ref SelectDoctorType, ref SelectDay,ref  SelectedTime,
                                                                PetOwnerName,
                                                                PetOwnerNumber,
                                                                PetOwnerEmail,
                                                                PetOwnerLocation,
                                                                PetTypeForAppointment,
                                                                PetName,
                                                                PetAge,
                                                                PetGender,
                                                                PetWeight,
                                                                Doctor,
                                                                Time,
                                                                Day, ref AppointmentsCount,
                                                                AppointmentBookOrPending, BookedBy, CustomerName, customeridx);
                                Console.SetCursorPosition(65, 36);
                                Console.Write( "Press any key to continue...");
                                Console.ReadKey();
                            }
                        }
                        else if (AppointmentOption == 3)
                        {
                            CustomerPendingCount = CountPendingAppointmentsForCustomer(BookedBy, AppointmentsCount, AppointmentBookOrPending, customeridx, CustomerName);
                            if (CustomerPendingCount == 0)
                            {
                                CustomerHeader();
                                Console.SetCursorPosition(65, 26);
                                Console.Write( "You have no Appointment To Edit!");
                                Console.SetCursorPosition(65, 36);
                                Console.Write( "Press any key to continue...");
                                Console.ReadKey();
                            }
                            else
                            {
                                CustomerHeader();
                                EditChoice = AskForEdit(ref Appointmentidx, Total, DoctorAppointed, DayAppointed, Bookingidx, Veterinarians, ref SelectDoctorType, ref SelectDay, ref SelectedTime,
                                                        PetOwnerName,
                                                        PetOwnerNumber,
                                                        PetOwnerEmail,
                                                        PetOwnerLocation,
                                                        PetTypeForAppointment,
                                                        PetName,
                                                        PetAge,
                                                        PetGender,
                                                        PetWeight,
                                                        Doctor,
                                                        Time,
                                                        Day, ref AppointmentsCount,
                                                        AppointmentBookOrPending, BookedBy, CustomerName, customeridx);
                                Console.Clear();
                                Console.Write(EditChoice);
                                Console.Read();
                                if (EditChoice == 1)
                                {
                                    EditAppointMent(Appointmentidx, Total, DoctorAppointed, DayAppointed, Bookingidx, Veterinarians, ref SelectDoctorType, ref SelectDay, ref SelectedTime,
                                                    PetOwnerName,
                                                    PetOwnerNumber,
                                                    PetOwnerEmail,
                                                    PetOwnerLocation,
                                                    PetTypeForAppointment,
                                                    PetName,
                                                    PetAge,
                                                    PetGender,
                                                    PetWeight,
                                                    Doctor,
                                                    Time,
                                                    Day, ref AppointmentsCount,
                                                    AppointmentBookOrPending, BookedBy, CustomerName, customeridx);
                                    saveCustomerAppointments(CustomerName, ValidUsername, PetOwnerName, PetOwnerNumber, PetOwnerEmail, PetOwnerLocation, PetTypeForAppointment, PetName, PetAge,
                                                     PetGender, PetWeight, Doctor, AppointmentBookOrPending, ref AppointmentsCount, BookedBy, BookedByPassword,
                                                     DoctorAppointed, DayAppointed, AppointmentFile, customeridx);
                                }
                                Console.SetCursorPosition(65, 36);
                                Console.Write( "Press any key to continue...");
                                Console.ReadKey();
                            }
                        }
                        else if (AppointmentOption == 4)
                        {
                            CustomerPendingCount = CountPendingAppointmentsForCustomer(BookedBy, AppointmentsCount, AppointmentBookOrPending, customeridx, CustomerName);
                            if (CustomerPendingCount == 0)
                            {
                                CustomerHeader();
                                Console.SetCursorPosition(65, 26);
                                Console.Write( "There is no Appointment to delete!");
                                Console.SetCursorPosition(65, 28);
                                Console.Write( "Press any key to continue...");
                                Console.ReadKey();
                            }
                            else
                            {
                                DeleteAppointmentsByCustomer(CustomerName, customeridx, ref Bookingidx, ref BookedAppointmentsTotal, ref PendingAppointmentsTotal,
                                                             DoctorAppointed, DayAppointed, PetOwnerName, PetOwnerNumber, PetOwnerEmail,
                                                             PetOwnerLocation, PetTypeForAppointment, PetName, PetAge, PetGender,
                                                             PetWeight, Doctor, Time, Day, ref  AppointmentsCount, AppointmentBookOrPending,
                                                             BookedBy, BookedForPet, BookedByPassword, ref Appointmentidx, DoctorName);
                                saveCustomerAppointments(CustomerName, ValidUsername, PetOwnerName, PetOwnerNumber, PetOwnerEmail, PetOwnerLocation, PetTypeForAppointment, PetName, PetAge,
                                                     PetGender, PetWeight, Doctor, AppointmentBookOrPending, ref  AppointmentsCount, BookedBy, BookedByPassword,
                                                     DoctorAppointed, DayAppointed, AppointmentFile, customeridx);
                                saveVetDetails(VetName, VetPassword, VetEmail, VetContact, VetDays, VetService,ref countVets,ref countVeterinarians, VetFile, DoctorAppointed, AppointmentsCount, AppointmentBookOrPending, vetidx);
                            }
                        }
                        else if (AppointmentOption == 5)
                        {
                            break;
                        }
                    }
                }
            }
        }
        static // VETERINARIAN //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void CreateProfile(ref string UserName, ref string Password, ref string Email, ref string Contact, ref int VetDay, ref int VetService)
        {
            string Day = "";
            string Service = "";
            Console.SetCursorPosition(60, 20);
            Console.Write( "Username: " + UserName);
            Console.SetCursorPosition(60, 22);
            Console.Write( "Password: " + Password);
            Console.SetCursorPosition(60, 24);
            Console.Write( "Email: ");
            Email =  Console.ReadLine();
            Console.SetCursorPosition(60, 26);
            Console.Write( "Contact: ");
            Contact  = Console.ReadLine();
            while (Contact.Length != 11)
            {
                Console.SetCursorPosition(60, 28);
                Console.Write( "Please add valid Contact Number of length 11!");
                Console.SetCursorPosition(60, 26);
                Console.Write( "                                           ");
                Console.SetCursorPosition(60, 26);
                Console.Write( "Contact: ");
                Contact = Console.ReadLine();
                Console.SetCursorPosition(60, 28);
                Console.Write( "                                                ");
            }
            while (!(checkContactValidity(Contact)))
            {
                Console.SetCursorPosition(60, 28);
                Console.Write( "Contact Number can only contain digits!");
                Console.SetCursorPosition(60, 26);
                Console.Write( "                                           ");
                Console.SetCursorPosition(60, 26);
                Console.Write( "Contact: ");
                Contact = Console.ReadLine();
                Console.SetCursorPosition(60, 28);
                Console.Write( "                                                ");
            }
            Console.SetCursorPosition(90, 22);
            Console.Write( "1. Dermatology");
            Console.SetCursorPosition(90, 24);
            Console.Write( "2. Primary Care");
            Console.SetCursorPosition(90, 26);
            Console.Write( "3. Internal Medicine");
            Console.SetCursorPosition(90, 20);
            Console.Write( "Providing Service For: ");
            Service = Console.ReadLine();
            while (Service != "1" && Service != "2" && Service != "3")
            {
                Console.SetCursorPosition(90, 28);
                Console.Write( "Please Enter Correct Option! ");
                Console.SetCursorPosition(90, 20);
                Console.Write( "                                        ");
                Console.SetCursorPosition(90, 20);
                Console.Write( "Providing Service For: ");
                Console.SetCursorPosition(90, 28);
                Console.Write( "                                             ");
            }
            VetService = int.Parse(Service);
            Console.SetCursorPosition(60, 30);
            Console.Write( "1.Monday   2.Tuesday   3.Wednesday");
            Console.SetCursorPosition(60, 32);
            Console.Write( "4.Thursday 5.Friday    6.Saturday");
            Console.SetCursorPosition(60, 28);
            Console.Write( "Day Availablily: ");
            Day = Console.ReadLine();
            while (Day != "1" && Day != "2" && Day != "3" && Day != "4" && Day != "5" && Day != "6")
            {
                Console.SetCursorPosition(60, 34);
                Console.Write( "Please Enter Correct Option! ");
                Console.SetCursorPosition(60, 28);
                Console.Write( "                                          ");
                Console.SetCursorPosition(60, 28);
                Console.Write( "Day Availablily: ");
                Day = Console.ReadLine();
                Console.SetCursorPosition(60, 34);
                Console.Write( "                                              ");
            }
            VetDay = int.Parse(Day);
        }
        static bool checkContactValidity(string contact)
        {
            int y = 0;
            for (int x = 0; x < contact.Length; x++)
            {
                if (char.IsDigit(contact[x]))
                {
                    y++;
                }
            }
            if (y == 11)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void saveVetDetails(string[] VetName, string[] VetPassword, string[] VetEmail, string[] VetContact, string[] VetDays, string[] VetService, ref int countVets, ref int countVeterinarians, string VetFile, string[] DoctorAppointed, int AppointmentsCount, string[] AppointmentBookOrPending, int vetidx)
        {
           StreamWriter file = new StreamWriter(VetFile);
            for (int i = 0; i < countVets; i++)
            {
                checkindex(countVets,ref vetidx, VetName[i], VetPassword[i], VetName, VetPassword);
                int pending = CountPendingAppointments(DoctorAppointed, AppointmentsCount, AppointmentBookOrPending, vetidx, VetService);
                int booked = CountBookedAppointments(DoctorAppointed, AppointmentsCount, AppointmentBookOrPending, vetidx, VetService);
                file.Write( VetName[i] + "," + VetPassword[i] + "," + VetEmail[i] + "," + VetContact[i] + "," + VetDays[i] + "," + VetService[i] + ",");
                if (VetName[vetidx] == VetName[i])
                {
                    file.WriteLine(pending + "," + booked + "," + (pending + booked));
                }
            }
            file.Flush();
            file.Close();
        }
        static void VetHeader()
        {
            printHeader();
            Vet_MenuBar();
        }
        static void Vet_MenuBar()
        {
            Console.SetCursorPosition(1, 15);
            Console.Write("___________________________________________________________________________________________________________________________________________________________________________");

            Console.SetCursorPosition(0, 17);
            Console.Write("                                                          ``.....    V e t e r i n a r i a n   .....``");

            Console.SetCursorPosition(1, 18);
            Console.Write("___________________________________________________________________________________________________________________________________________________________________________");
        }
        static int PrintVetMenu()
        {
            string option;
            Console.SetCursorPosition(1, 17);
            Console.Write("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");

            Console.SetCursorPosition(71, 19);
            Console.Write("1. Profile Options");
            Console.SetCursorPosition(71, 21);
            Console.Write("2. Appointments");
            Console.SetCursorPosition(71, 23);
            Console.Write("3. Logout");

            Console.SetCursorPosition(1, 25);
            Console.Write("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");

            Console.SetCursorPosition(71, 27);
            Console.Write("Enter Your Requirement: ");
            option = Console.ReadLine();

            while (option != "1" && option != "2" && option != "3")
            {
                Console.SetCursorPosition(71, 29);
                Console.Write("Please Enter Correct Option!");
                Console.SetCursorPosition(71, 27);
                Console.Write(new string(' ', Console.WindowWidth - 71));
                Console.SetCursorPosition(71, 27);
                Console.Write("Enter Your Requirement: ");
                option = Console.ReadLine();
            }

            int vetRequirement = int.Parse(option);
            return vetRequirement;
        }
        static int VetProfileOptions()
        {
            Console.SetCursorPosition(1, 20);
            Console.Write("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
            Console.SetCursorPosition(71, 22);
            Console.Write("1. View Profile");
            Console.SetCursorPosition(71, 24);
            Console.Write("2. Edit Profile");
            Console.SetCursorPosition(71, 26);
            Console.Write("3. Delete Profile");
            Console.SetCursorPosition(71, 28);
            Console.Write("4. Exit");
            Console.SetCursorPosition(1, 30);
            Console.Write("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");

            Console.SetCursorPosition(71, 32);
            Console.Write("Enter Your Requirement: ");

            string option = Console.ReadLine();

            while (option != "1" && option != "2" && option != "3" && option != "4")
            {
                Console.SetCursorPosition(71, 34);

                Console.Write("Please Enter Correct Option! ");


                Console.SetCursorPosition(71, 32);
                Console.Write("                                                 ");
                Console.SetCursorPosition(71, 32);
                Console.Write("Enter Your Requirement: ");
                option = Console.ReadLine();
                Console.SetCursorPosition(71, 34);
                Console.Write("                                                 ");
            }

            int vetRequirement = int.Parse(option);
            return vetRequirement;
        }

        static void ShowVetProfile(int vetIdx, int countVets, string[] vetName, string[] vetPassword, string[] vetEmail,
                                    string[] vetContact, string[] vetDays, string[] vetService)
        {
            Console.SetCursorPosition(60, 20);
            Console.Write($"UserName: {vetName[vetIdx]}");
            Console.SetCursorPosition(60, 22);
            Console.Write($"Password: {vetPassword[vetIdx]}");
            Console.SetCursorPosition(60, 24);
            Console.Write($"Email: {vetEmail[vetIdx]}");
            Console.SetCursorPosition(60, 26);
            Console.Write($"Contact: {vetContact[vetIdx]}");
            Console.SetCursorPosition(60, 28);
            Console.Write($"Day: {vetDays[vetIdx]}");
            Console.SetCursorPosition(60, 30);
            Console.Write($"Service: {vetService[vetIdx]}");
            Console.SetCursorPosition(60, 32);
            Console.Write("Press any key to continue...");
        }
        static void EditVetProfile(int useridx, int vetidx, int countVets, int countUser, string[] ValidUsername, string[] ValidPassword, string[] VetName, string[] VetPassword, string[] VetEmail,
                    string[] VetContact, string[] VetDays, string[] VetService, string[] AvailableDays, string[] AvailableService)
        {
            string Option;
            Console.SetCursorPosition(60, 20);
            Console.Write("1. UserName");
            Console.SetCursorPosition(60, 22);
            Console.Write("2. Password");
            Console.SetCursorPosition(60, 24);
            Console.Write("3. Email");
            Console.SetCursorPosition(60, 26);
            Console.Write("4. Contact");
            Console.SetCursorPosition(60, 28);
            Console.Write("5. Day");
            Console.SetCursorPosition(60, 30);
            Console.Write("6. Service");
            Console.SetCursorPosition(60, 32);
            Console.Write("Select option you want to edit...");
            Option =  Console.ReadLine();
            while (Option != "1" && Option != "2" && Option != "3" && Option != "5" && Option != "6" && Option != "4")
            {
                Console.SetCursorPosition(71, 33);
                Console.Write("Please Enter Correct Option! ");
                Console.SetCursorPosition(60, 32);
                Console.Write("                                                       ");
                Console.SetCursorPosition(60, 32);
                Console.Write("Select option you want to edit...");
                Option = Console.ReadLine();
                Console.SetCursorPosition(71, 33);
                Console.Write("                                             ");
            }
            int SelectedOption = int.Parse(Option);
            if (SelectedOption == 1)
            {
                Console.SetCursorPosition(60, 20);
                Console.Write("               ");
                Console.SetCursorPosition(60, 20);
                Console.Write("Enter Username: ");
                VetName[vetidx] = Console.ReadLine();
                Console.SetCursorPosition(60, 32);
                Console.Write("                                       ");
                Console.SetCursorPosition(60, 32);
                Console.Write("Username Edited!");
            }
            else if (SelectedOption == 2)
            {
                Console.SetCursorPosition(60, 22);
                Console.Write("                    ");
                Console.SetCursorPosition(60, 22);
                Console.Write("Enter Old Password: ");
                string oldpassword  = Console.ReadLine();
                if (oldpassword == VetPassword[vetidx])
                {
                    Console.SetCursorPosition(60, 22);
                    Console.Write("                                        ");
                    Console.SetCursorPosition(60, 22);
                    Console.Write("Enter New Password: ");
                    VetPassword[vetidx]=Console.ReadLine();
                    ;
                    while (VetPassword[vetidx].Length > 16 || VetPassword[vetidx].Length < 8)
                    {
                        Console.SetCursorPosition(60, 32);
                        Console.Write("                                ");
                        Console.SetCursorPosition(60, 32);
                        Console.Write("Password must Contain 8 to 16 characters! ");
                        Console.SetCursorPosition(90, 22);
                        Console.Write("                                                    ");
                        Console.SetCursorPosition(90, 22);
                        VetPassword[vetidx]=Console.ReadLine();
                        ;
                    }
                }
                else
                {
                    Console.SetCursorPosition(60, 32);
                    Console.Write("                                ");
                    Console.SetCursorPosition(60, 32);
                    Console.Write("Incorrect Password! ");
                    Console.SetCursorPosition(60, 34);
                    Console.Write("Press any key to continue..");
                    Console.ReadKey();
                }
            }
            else if (SelectedOption == 3)
            {
                Console.SetCursorPosition(60, 24);
                Console.Write("               ");
                Console.SetCursorPosition(60, 24);
                Console.Write("Enter Email: ");

                VetEmail[vetidx] = Console.ReadLine();
                Console.SetCursorPosition(60, 32);
                Console.Write("                                       ");
                Console.SetCursorPosition(60, 32);
                Console.Write("Email Edited!");
            }
            else if (SelectedOption == 4)
            {
                Console.SetCursorPosition(60, 26);
                Console.Write("               ");
                Console.SetCursorPosition(60, 26);
                Console.Write("Enter Contact: ");

                VetContact[vetidx]= Console.ReadLine();
                ;
                Console.SetCursorPosition(60, 32);
                Console.Write("                                       ");
                Console.SetCursorPosition(60, 32);
                Console.Write("Contact Edited!");
            }
            else if (SelectedOption == 5)
            {
                Console.SetCursorPosition(60, 28);
                Console.Write("               ");
                Console.SetCursorPosition(60, 28);
                Console.Write("Select Day: ");
                Console.SetCursorPosition(60, 30);
                Console.Write("                                  ");
                Console.SetCursorPosition(60, 30);
                Console.Write("1.Monday  2.Tuesday   3.Wednesday");
                Console.SetCursorPosition(60, 30);
                Console.Write("                                  ");
                Console.SetCursorPosition(60, 30);
                Console.Write("4.Thursday  5.Friday   6.Saturday");
                string Day = Console.ReadLine();

                while (Day != "1" && Day != "2" && Day != "3" && Day != "4" && Day != "5" && Day != "6")
                {
                    Console.SetCursorPosition(60, 32);
                    Console.Write("                                       ");
                    Console.SetCursorPosition(60, 32);
                    Console.Write("Please Enter Correct Option! ");
                    Console.SetCursorPosition(82, 28);
                    Console.Write("                                             ");
                    Console.SetCursorPosition(82, 28);
                    Day = Console.ReadLine();
                }
                int EditedDay = int.Parse(Day);
                VetDays[vetidx] = AvailableDays[EditedDay - 1];
                Console.SetCursorPosition(60, 32);
                Console.Write("                                       ");
                Console.SetCursorPosition(60, 32);
                Console.Write("Day Edited!");
            }
            else if (SelectedOption == 6)
            {
                Console.SetCursorPosition(60, 30);
                Console.Write("               ");
                Console.SetCursorPosition(60, 30);
                Console.Write("Select Service: ");
                Console.SetCursorPosition(60, 32);
                Console.Write("                                                   ");
                Console.SetCursorPosition(60, 32);
                Console.Write("1.Dermatology  2.Primary Care  3.Internal Medicine ");
                Console.SetCursorPosition(86, 30);
                string Service = Console.ReadLine();
                while (Service != "1" && Service != "2" && Service != "3")
                {
                    Console.SetCursorPosition(60, 34);
                    Console.Write("                                       ");
                    Console.SetCursorPosition(60, 34);
                    Console.Write("Please Enter Correct Option! ");
                    Console.SetCursorPosition(86, 30);
                    Console.Write("                                             ");
                    Console.SetCursorPosition(86, 30);
                    Service = Console.ReadLine();
                }
                int EditedService = int.Parse(Service);
                VetService[vetidx] = AvailableService[EditedService - 1];
            }
            Console.SetCursorPosition(60, 34);
            Console.Write("Press any key to continue!");
        }
        static void DeleteVetProfile(string signInUserName,string signInPassword, int[] Roles, string[] ValidRole, ref int signUpcount, int useridx, string[] ApprovedUsers, string[] ApprovedPwd, string[] ApprovalStatus, string[] ApprovedRoles, int valididx, ref int countVeterinarians, int vetidx, ref int countVets, ref int countUser, string[] ValidUsername, string[] ValidPassword, string[] VetName, string[] VetPassword, string[] VetEmail, string[] VetContact, string[] VetDays, string[] VetService, string[] AvailableDays, string[] AvailableService)
        {
            checkindex(countVets,ref vetidx, signInUserName, signInPassword, VetName, VetPassword);
            for (int x = vetidx; x < countVets; x++)
            {
                VetName[x] = VetName[x + 1];
                VetPassword[x] = VetPassword[x + 1];
                VetEmail[x] = VetEmail[x + 1];
                VetContact[x] = VetContact[x + 1];
                VetDays[x] = VetName[x + 1];
                VetService[x] = VetService[x + 1];
            }
            checkindex(countUser,ref vetidx, signInUserName, signInPassword, ValidUsername, ValidPassword);
            for (int x = vetidx; x < countUser; x++)
            {
                ValidUsername[x] = ValidUsername[x + 1];
                ValidPassword[x] = ValidPassword[x + 1];
                ValidRole[x] = ValidRole[x + 1];
                Roles[x] = Roles[x + 1];
            }
            checkindex(signUpcount,ref vetidx, signInUserName, signInPassword, ApprovedUsers, ApprovedPwd);
            for (int x = vetidx; x < (signUpcount); x++)
            {
                ApprovedUsers[x] = ApprovedUsers[x + 1];
                ApprovedPwd[x] = ApprovedPwd[x + 1];
                ApprovalStatus[x] = ApprovalStatus[x + 1];
                ApprovedRoles[x] = ApprovedRoles[x + 1];
            }
            countVets--;
            countUser--;
            countVeterinarians--;
            signUpcount--;
        }
        static int ConfirmDeletion()
        {
            string option;
            Console.SetCursorPosition(55, 22);
            Console.Write( "???????????????????????????????????????????????????");
            Console.SetCursorPosition(55, 23);
            Console.Write( "|                                                 |");
            Console.SetCursorPosition(55, 24);
            Console.Write( "|         Delete Your PetPal Profile?             |");
            Console.SetCursorPosition(55, 25);
            Console.Write( "|                                                 |");
            Console.SetCursorPosition(55, 26);
            Console.Write( "|              1. YES      2. NO                  |");
            Console.SetCursorPosition(55, 27);
            Console.Write( "|                                                 |");
            Console.SetCursorPosition(55, 28);
            Console.Write( "|                                                 |");
            Console.SetCursorPosition(55, 29);
            Console.Write( "|                Enter Option...                  |");
            Console.SetCursorPosition(55, 30);
            Console.Write( "|                                                 |");
            Console.SetCursorPosition(55, 31);
            Console.Write( "???????????????????????????????????????????????????");
            Console.SetCursorPosition(87, 29);
            option = Console.ReadLine();
            while (option != "1" && option != "2")
            {
                Console.SetCursorPosition(55, 34);
                Console.Write( "Please Enter Correct Option! ");
                Console.SetCursorPosition(87, 29);
                Console.Write( "            ");
                Console.SetCursorPosition(87, 29);
                option = Console.ReadLine();
                Console.SetCursorPosition(55, 34);
                Console.Write( "                                             ");
            }
            int Option = int.Parse(option);
            return Option;
        }
        static int VetAppointmentOptions()
        {
            Console.SetCursorPosition(1, 20);
            Console.Write( "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(71, 22);
            Console.Write( "1. View Pending Appointments");
            Console.SetCursorPosition(71, 24);
            Console.Write( "2. View Booked Appointments");
            Console.SetCursorPosition(71, 26);
            Console.Write( "3. Exit");
            Console.SetCursorPosition(1, 28);
            Console.Write( "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            string Option;
            Console.SetCursorPosition(71, 30);
            Console.Write( "Enter Your Requirement: ");

            Option = Console.ReadLine(); 
            while (Option != "1" && Option != "2" && Option != "3")
            {
                Console.SetCursorPosition(71, 32);
                Console.Write( "Please Enter Correct Option!");
                Console.SetCursorPosition(71, 30);
                Console.Write( "                                        ");
                Console.SetCursorPosition(71, 30);
                Console.Write( "Enter Your Requirement: ");
                Option = Console.ReadLine();
                Console.SetCursorPosition(71, 32);
                Console.Write( "                                        ");
            }
            int Vet_Requirement = int.Parse(Option);
            return Vet_Requirement;
        }
        static void ViewPendingAppointments(string[] CustomerName, ref int BookedAppointmentsTotal, string[] DoctorAppointed, string[] DayAppointed, string[] PetOwnerName, string[] PetOwnerNumber,
                                        string[] PetOwnerEmail, string[] PetOwnerLocation, string[] PetTypeForAppointment, string[] PetName, string[] PetAge, string[] PetGender,
                                        string[] PetWeight, string[] Doctor, string[] Time, string[] Day, int AppointmentsCount, string[] AppointmentBookOrPending, string[] BookedBy,
                                        int vetidx, string[] VetService, ref int BookedByCurrentVet, string[] VetDays, string[] VetName, string[] DoctorName, string[] ValidUsername,
                                        string[] BookedByPassword, string AppointmentFile, string[] VetPassword, string[] VetEmail, string[] VetContact, int countVets, int countVeterinarians,
                                        string VetFile, int customeridx)
        {
            string Confirmation = "";
            int confirmation = 0;
            int x = 0;
            int y = 0;

            for (int z = 0; z < AppointmentsCount; z++)
            {
                if (AppointmentBookOrPending[z] == "Pending" && VetService[vetidx] == DoctorAppointed[z])
                {
                    x++;
                    VetHeader();

                    Console.SetCursorPosition(40, 20);
                    
                    Console.Write("Pet Owner Name: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(PetOwnerName[z]);

                    Console.SetCursorPosition(40, 22);
                    
                    Console.Write("Pet Owner Contact: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(PetOwnerNumber[z]);

                    Console.SetCursorPosition(40, 24);
                    
                    Console.Write("Pet Owner Email: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(PetOwnerEmail[z]);

                    Console.SetCursorPosition(40, 26);
                    
                    Console.Write("Pet Owner Location: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(PetOwnerLocation[z]);

                    Console.SetCursorPosition(40, 28);
                    
                    Console.Write("Pet Type: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(PetTypeForAppointment[z]);

                    Console.SetCursorPosition(80, 20);
                    
                    Console.Write("Pet Name: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(PetName[z]);

                    Console.SetCursorPosition(80, 22);
                    
                    Console.Write("Pet Age: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{PetAge[z]} Months");

                    Console.SetCursorPosition(80, 24);
                    
                    Console.Write("Pet Weight: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{PetWeight[z]} Pounds");

                    Console.SetCursorPosition(80, 26);
                    
                    Console.Write("Pet Gender: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(PetGender[z]);

                    Console.SetCursorPosition(80, 28);
                    
                    Console.Write("Appointment For: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(DoctorAppointed[z]);

                    Console.SetCursorPosition(40, 30);
                    
                    Console.Write("Appointment Status: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(AppointmentBookOrPending[z]);

                    Console.SetCursorPosition(80, 30);
                    
                    Console.Write("Day For Appointment: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(DayAppointed[z]);
                }
                else
                {
                    continue;
                }

                    Console.SetCursorPosition(50, 34);
                    Console.Write("                                                   ");
                    Console.SetCursorPosition(50, 36);
                    Console.Write("1. Yes    2. No");
                    Console.SetCursorPosition(50, 34);
                    Console.Write("Do You Want To Confirm this Appointment? ");
                    Confirmation = Console.ReadLine();

                    while (Confirmation != "1" && Confirmation != "2")
                    {
                        Console.SetCursorPosition(50, 38);
                        Console.Write("Please Enter Correct Option! ");
                        Console.SetCursorPosition(50, 34);
                        Console.Write("                                                   ");
                        Console.SetCursorPosition(50, 34);
                        Console.Write("Do You Want To Confirm this Appointment? ");
                        Confirmation = Console.ReadLine();
                    }

                    confirmation = int.Parse(Confirmation);

                    if (confirmation == 1)
                    {
                        AppointmentBookOrPending[z] = "Booked";
                        DayAppointed[z] = VetDays[vetidx];
                        DoctorName[z] = VetName[vetidx];

                    saveCustomerAppointments(CustomerName, ValidUsername, PetOwnerName, PetOwnerNumber, PetOwnerEmail, PetOwnerLocation, PetTypeForAppointment, PetName, PetAge,
                                                                PetGender, PetWeight, Doctor, AppointmentBookOrPending,ref AppointmentsCount, BookedBy, BookedByPassword,
                                                                DoctorAppointed, DayAppointed, AppointmentFile, customeridx);
                    saveVetDetails(VetName, VetPassword, VetEmail, VetContact, VetDays, VetService, ref countVets, ref countVeterinarians, VetFile, DoctorAppointed, AppointmentsCount, AppointmentBookOrPending, vetidx);
                    y++;
                        BookedAppointmentsTotal++;
                    }
                }

            BookedByCurrentVet = x - y;
        }
        static void ViewBookedAppointments(string[] DoctorAppointed, string[] DayAppointed, string[] PetOwnerName, string[] PetOwnerNumber, string[] PetOwnerEmail, string[] PetOwnerLocation, string[] PetTypeForAppointment, string[] PetName, string[] PetAge, string[] PetGender, string[] PetWeight, string[] Doctor, string[] Time, string[] Day, int AppointmentsCount, string[] AppointmentBookOrPending, string[] BookedBy, int vetidx, string[] VetService, ref int BookedByCurrentVet, string[] VetDays)
        {
            for (int z = 0; z < AppointmentsCount; z++)
            {
                if (AppointmentBookOrPending[z] == "Booked" && VetService[vetidx] == DoctorAppointed[z])
                {
                    VetHeader();
                    Console.SetCursorPosition(40, 20);
                    
                    Console.Write("Pet Owner Name: ");
    
                    Console.Write(PetOwnerName[z]);

                    Console.SetCursorPosition(40, 22);
                    
                    Console.Write("Pet Owner Contact: ");
    
                    Console.Write(PetOwnerNumber[z]);

                    Console.SetCursorPosition(40, 24);
                    
                    Console.Write("Pet Owner Email: ");
    
                    Console.Write(PetOwnerEmail[z]);

                    Console.SetCursorPosition(40, 26);
                    
                    Console.Write("Pet Owner Location: ");
    
                    Console.Write(PetOwnerLocation[z]);

                    Console.SetCursorPosition(40, 28);
                    
                    Console.Write("Pet Type: ");
    
                    Console.Write(PetTypeForAppointment[z]);

                    Console.SetCursorPosition(80, 20);
                    
                    Console.Write("Pet Name: ");
    
                    Console.Write(PetName[z]);

                    Console.SetCursorPosition(80, 22);
                    
                    Console.Write("Pet Age: ");
    
                    Console.Write($"{PetAge[z]} Months");

                    Console.SetCursorPosition(80, 24);
                    
                    Console.Write("Pet Weight: ");
    
                    Console.Write($"{PetWeight[z]} Pounds");

                    Console.SetCursorPosition(80, 26);
                    
                    Console.Write("Pet Gender: ");
    
                    Console.Write(PetGender[z]);

                    Console.SetCursorPosition(80, 28);
                    
                    Console.Write("Appointment For: ");
    
                    Console.Write(DoctorAppointed[z]);

                    Console.SetCursorPosition(40, 30);
                    
                    Console.Write("Appointment Status: ");
    
                    Console.Write(AppointmentBookOrPending[z]);

                    Console.SetCursorPosition(80, 30);
                    
                    Console.Write("Day For Appointment: ");
    
                    Console.Write(DayAppointed[z]);

                    Console.SetCursorPosition(80, 32);
                    Console.Write("Press any key to see next booked appointment.. ");
                    Console.ReadKey();
                }
                else
                {
                    continue;
                }
            }

            Console.SetCursorPosition(80, 32);
            Console.Write("                                                        ");
            Console.SetCursorPosition(50, 32);
            Console.Write("Press any key to continue...");
        }
        static int CountPendingAppointments(string[] DoctorAppointed, int AppointmentsCount, string[] AppointmentBookOrPending, int vetidx, string[] VetService)
        {
            int x = 0;
            for (int z = 0; z < AppointmentsCount; z++)
            {
                if (AppointmentBookOrPending[z] == "Pending" && VetService[vetidx] == DoctorAppointed[z])
                {
                    x++;
                }
                else
                {
                    continue;
                }
            }

            return x;
        }
        static int CountBookedAppointments(string[] DoctorAppointed, int AppointmentsCount, string[] AppointmentBookOrPending, int vetidx, string[] VetService)
        {
            int x = 0;
            for (int z = 0; z < AppointmentsCount; z++)
            {
                if (AppointmentBookOrPending[z] == "Booked" && VetService[vetidx] == DoctorAppointed[z])
                {
                    x++;
                }
                else
                {
                    continue;
                }
            }

            return x;
        }
        static void VetMainMenu(string signInUserName, string[] CustomerName, string signInPassword,
        string[] ValidRole, int valididx, int useridx, ref int BookedAppointmentsTotal,
        ref int PendingAppointmentsTotal, int vetidx, string[] ValidUsername, string[] ValidPassword,
        ref int countUser, int idx, string[] ThreeUsers, ref int countVets, string[] VetName,
        string[] VetPassword, string[] VetEmail, string[] VetContact, string[] VetDays,
        string[] VetService, string[] AvailableDays, string[] AvailableService,
        string[] DoctorAppointed, string[] DayAppointed, string[] DoctorName,
        string[] PetOwnerName, string[] PetOwnerNumber, string[] PetOwnerEmail,
        string[] PetOwnerLocation, string[] PetTypeForAppointment, string[] PetName,
        string[] PetAge, string[] PetGender, string[] PetWeight, string[] Doctor,
        string[] Time, string[] Day, ref int AppointmentsCount, string[] AppointmentBookOrPending,
        string[] BookedBy, string VetFile, ref int countVeterinarians, string[] BookedByPassword,
        string AppointmentFile, string SignUpFile, int[] Roles, string[] ApprovalStatus,
        string[] ApprovedUsers, string[] ApprovedPwd, string[] ApprovedRoles, ref int signUpcount,
        string ApprovedFile, int customeridx)
        {

            int VetRequirement = 0;
            int ProfileOption = 0;
            int AppointmentOption = 0;
            int del = 0;
            int confirmation = 0;
            int BookedByCurrentVet = 0;
            string Confirmation;
            string ProfileStatus = "Exists";
            while (true)
            {
                printHeader();
                VetRequirement = PrintVetMenu();
                if (VetRequirement == 1)
                {
                    while (true)
                    {
                        VetHeader();
                        ProfileOption = VetProfileOptions();
                        if (ProfileOption == 1)
                        {
                            VetHeader();
                            ShowVetProfile(vetidx, countVets, VetName, VetPassword, VetEmail, VetContact, VetDays, VetService);
                            Console.ReadKey();
                        }
                        else if (ProfileOption == 2)
                        {
                            VetHeader();
                            EditVetProfile(useridx, vetidx, countVets, countUser, ValidUsername, ValidPassword, VetName, VetPassword, VetEmail, VetContact, VetDays, VetService, AvailableDays, AvailableService);
                            ValidPassword[valididx] = VetPassword[vetidx];
                            ValidUsername[valididx] = VetName[vetidx];
                            ApprovedUsers[useridx] = VetName[vetidx];
                            ApprovedPwd[useridx] = VetPassword[vetidx];
                            saveVetDetails(VetName, VetPassword, VetEmail, VetContact, VetDays, VetService, ref countVets, ref countVeterinarians, VetFile, DoctorAppointed, AppointmentsCount, AppointmentBookOrPending, vetidx);
                            saveSignUpDetails(ValidUsername, ValidPassword, Roles, countUser, SignUpFile);
                            saveApprovedUsers(ApprovalStatus, ApprovedUsers, ApprovedPwd, ApprovedRoles, ref signUpcount, ApprovedFile);
                            Console.ReadKey();
                        }
                        else if (ProfileOption == 3)
                        {
                            VetHeader();
                            del = ConfirmDeletion();
                            if (del == 1)
                            {
                                DeleteVetProfile(signInUserName,
                                                 signInPassword, Roles, ValidRole, ref signUpcount, useridx, ApprovedUsers, ApprovedPwd, ApprovalStatus, ApprovedRoles,
                                                 valididx, ref countVeterinarians, vetidx, ref countVets, ref countUser, ValidUsername, ValidPassword, VetName, VetPassword, VetEmail,
                                                 VetContact, VetDays, VetService, AvailableDays, AvailableService);
                                saveVetDetails(VetName, VetPassword, VetEmail, VetContact, VetDays, VetService, ref countVets, ref countVeterinarians, VetFile, DoctorAppointed, AppointmentsCount, AppointmentBookOrPending, vetidx);
                                saveApprovedUsers(ApprovalStatus, ApprovedUsers, ApprovedPwd, ApprovedRoles, ref signUpcount, ApprovedFile);
                                saveSignUpDetails(ValidUsername, ValidPassword, Roles, countUser, SignUpFile);
                                ProfileStatus = "Deleted";
                                break;
                            }
                            else if (del == 2)
                            {
                                continue;
                            }
                        }
                        else if (ProfileOption == 4)
                        {
                            break;
                        }
                        if (ProfileStatus == "Deleted")
                        {
                            break; // checking if the user has deleted the profile or not
                        }
                    }
                }
                if (VetRequirement == 2)
                {
                    while (true)
                    {
                        VetHeader();
                        AppointmentOption = VetAppointmentOptions();
                        if (AppointmentOption == 1)
                        {
                            VetHeader();
                            int Pending = CountPendingAppointments(DoctorAppointed, AppointmentsCount, AppointmentBookOrPending, vetidx, VetService);
                            if (Pending > 0)
                            {
                                Console.SetCursorPosition(50, 26);
                                Console.Write( "                                                   ");
                                Console.SetCursorPosition(50, 26);
                                Console.Write( "1. Yes    2. No");
                                Console.SetCursorPosition(50, 22);
                                Console.Write( "There are " + Pending + " Pending Appointments");
                                Console.SetCursorPosition(50, 24);
                                Console.Write( "Do you want to see details? ");
                                Confirmation = Console.ReadLine();
                                while (Confirmation != "1" && Confirmation != "2")
                                {
                                    Console.SetCursorPosition(50, 38);
                                    Console.Write( "Please Enter Correct Option! ");
                                    Console.SetCursorPosition(50, 34);
                                    Console.Write( "                                                   ");
                                    Console.SetCursorPosition(50, 24);
                                    Console.Write( "Do you want to see details? ");
                                    Confirmation = Console.ReadLine();
                                }
                                confirmation = int.Parse(Confirmation);
                                if (confirmation == 1)
                                {
                                    VetHeader();
                                    ViewPendingAppointments(CustomerName, ref BookedAppointmentsTotal, DoctorAppointed, DayAppointed,
                                                            PetOwnerName,
                                                            PetOwnerNumber,
                                                            PetOwnerEmail,
                                                            PetOwnerLocation,
                                                            PetTypeForAppointment,
                                                            PetName,
                                                            PetAge,
                                                            PetGender,
                                                            PetWeight,
                                                            Doctor,
                                                            Time,
                                                            Day, AppointmentsCount,
                                                            AppointmentBookOrPending, BookedBy, vetidx, VetService, ref BookedByCurrentVet, VetDays, VetName, DoctorName,
                                                            ValidUsername, BookedByPassword, AppointmentFile, VetPassword, VetEmail, VetContact, countVets, countVeterinarians,
                                                            VetFile, customeridx);
                                    saveCustomerAppointments(CustomerName, ValidUsername, PetOwnerName, PetOwnerNumber, PetOwnerEmail, PetOwnerLocation, PetTypeForAppointment, PetName, PetAge, PetGender,
                                                     PetWeight, Doctor, AppointmentBookOrPending, ref AppointmentsCount, BookedBy, BookedByPassword, DoctorAppointed, DayAppointed, AppointmentFile, customeridx);
                                    saveVetDetails(VetName, VetPassword, VetEmail, VetContact, VetDays, VetService, ref countVets, ref countVeterinarians, VetFile, DoctorAppointed, AppointmentsCount, AppointmentBookOrPending, vetidx);
                                }
                            }
                            else
                            {
                                Console.SetCursorPosition(50, 22);
                                Console.Write( "There are no Pending Appointments");
                                Console.SetCursorPosition(50, 24);
                                Console.Write( "Press any key to continue...");
                            }
                            Console.ReadKey();
                        }
                        else if (AppointmentOption == 2)
                        {
                            VetHeader();
                            int Booked = CountBookedAppointments(DoctorAppointed, AppointmentsCount, AppointmentBookOrPending, vetidx, VetService);
                            if (Booked > 0)
                            {
                                Console.SetCursorPosition(50, 26);
                                Console.Write( "                                                   ");
                                Console.SetCursorPosition(50, 26);
                                Console.Write( "1. Yes    2. No");
                                Console.SetCursorPosition(50, 22);
                                Console.Write( "There are " + Booked + " Booked Appointments");
                                Console.SetCursorPosition(50, 24);
                                Console.Write( "Do you want to see details? ");
                                Confirmation = Console.ReadLine();
                                while (Confirmation != "1" && Confirmation != "2")
                                {
                                    Console.SetCursorPosition(50, 38);
                                    Console.Write( "Please Enter Correct Option! ");
                                    Console.SetCursorPosition(50, 34);
                                    Console.Write( "                                                   ");
                                    Console.SetCursorPosition(50, 24);
                                    Console.Write( "Do you want to see details? ");
                                    Confirmation = Console.ReadLine();
                                }
                                confirmation = int.Parse(Confirmation);
                                if (confirmation == 1)
                                {
                                    VetHeader();
                                    ViewBookedAppointments(DoctorAppointed, DayAppointed,
                                                           PetOwnerName,
                                                           PetOwnerNumber,
                                                           PetOwnerEmail,
                                                           PetOwnerLocation,
                                                           PetTypeForAppointment,
                                                           PetName,
                                                           PetAge,
                                                           PetGender,
                                                           PetWeight,
                                                           Doctor,
                                                           Time,
                                                           Day, AppointmentsCount,
                                                           AppointmentBookOrPending, BookedBy, vetidx, VetService, ref BookedByCurrentVet, VetDays);
                                }
                            }
                            else
                            {
                                Console.SetCursorPosition(50, 22);
                                Console.Write( "You have not booked any Appointment!");
                                Console.SetCursorPosition(50, 24);
                                Console.Write( "Press any key to continue...");
                            }
                            Console.ReadKey();
                        }
                        else if (AppointmentOption == 3)
                        {
                            break;
                        }
                    }
                    Console.ReadKey();
                }
                else if (VetRequirement == 3)
                {
                    break;
                }
                if (ProfileStatus == "Deleted")
                {
                    break; // checking if the user has deleted the profile so go to login screen
                }
            }
        }
        static string ParseData(string line, int field)
        {
            string item="";
            int commaCount = 1;
            int length = line.Length;
            for (int x = 0; x < length; x++)
            {
                if (line[x] == ',')
                {
                    commaCount++;
                }
                else if (field == commaCount)
                {
                    item += line[x];
                }
            }
            return item;
        }
        static void checkindex(int count, ref int idx, string name, string password, string[] Name, string[] Password)
        {
            for (int v = 0; v <= count; v++)
            {
                if ((name == Name[v]) && (password == Password[v]))
                {
                    idx = v;
                    break;
                }
            }
        }
    }
}
