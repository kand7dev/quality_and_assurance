using QualityAndAssurance.HRLib;
[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]
namespace QualityAndAssurance.UnitTest
{


    [TestClass]
    public class ValidName
    {
        const string notEmpty = "Name must not be empty";
        const string notOnlyWhiteSpace = "Name can't contain only whitespaces";
        const string hasNameAndSurname = "Splitted Name must contain a name and a surname only";
        const string hasOnlyOneName = "Name can't contain only a name. A surname is needed";
        const string containsOnlyLetter = "Each character in Name is a letter";
        const string hasDigitOrSymbol = "Name can't contain digits or symbols";
        [TestMethod]
        public void NameNotEmpty()
        {
            object[,] testCases =
            {
            {1, "Viktor Romanyuk", true, notEmpty },
            {2, "THEODOSIOU THEO", true, notEmpty },
            {3, "", false, notEmpty },
            {4, " ", false, notOnlyWhiteSpace },
            {5, "                  ", false, notOnlyWhiteSpace },
            };
            bool failed = false;
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    Assert.AreEqual(testCases[i, 2], HRLib.HRLib.ValidName((string)testCases[i, 1]));
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine($"Failed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 3]} \n \t Reason: {ex.Message}\n");
                }
            }
            if (failed)
            {
                Assert.Fail();
            }

        }
        [TestMethod]
        public void NameContainsSurname()
        {
            object[,] testCases =
            {
            {1, "Viktor Romanyuk", true, hasNameAndSurname },
            {2, "Giwrgos Georgioy", true, hasNameAndSurname },
            {3, "Giwrgos", false, hasOnlyOneName },
            {4, "Dimitris Dimitriou Dimitriadis", false, hasNameAndSurname },
            {5, "Ivan Ivanonv", true, hasNameAndSurname },
            };
            bool failed = false;
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    Assert.AreEqual((bool)testCases[i, 2], HRLib.HRLib.ValidName((string)testCases[i, 1]));
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine($"Failed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 3]} \n \t Reason: {ex.Message}\n");
                }
            }
            if (failed)
            {
                Assert.Fail();
            }

        }
        [TestMethod]
        public void NameHasOnlyLetters()
        {
            object[,] testCases =
            {
            {1, "Viktor Romanyuk1", false, hasDigitOrSymbol },
            {2, "V!iktor Romanyuk", false, hasDigitOrSymbol },
            {3, "Ivanov Pavlov", true, containsOnlyLetter },
            {4, "3232 311", false, hasDigitOrSymbol },
            {5, "Vasilios Vasiliouuu2", false, hasDigitOrSymbol },
            };
            bool failed = false;
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    Assert.AreEqual((bool)testCases[i, 2], HRLib.HRLib.ValidName((string)testCases[i, 1]));
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine($"Failed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 3]} \n \t Reason: {ex.Message}\n");
                }
            }
            if (failed)
            {
                Assert.Fail();
            }
        }
    }
    [TestClass]
    public class ValidPassword
    {
        const string greaterOrEq12 = "Password's length must be greater or equal to 12";
        const string upperStartNumberEnd = "Password must start with an upper case letter and end with a number";
        const string onlyASCIILetters = "Password must contain only ASCII letters";
        const string andASCIIAndDigitAndSymbol = "Password must contain at least one letter, one digit and one symbol. In short, a combination of those";
        const string hasWhiteSpace = "Password contains a whitespace character";
        [TestMethod]
        public void PasswordLengthLargerThan12()
        {
            object[,] testCases =
            {
            {1, "A32htg@6410322Ax3216zz#3", true, greaterOrEq12 },
            {2, "B3896@547h1", false, greaterOrEq12 },
            {3, "P$%@axEfu2", false, greaterOrEq12 },
            {4, "A32@3", false, greaterOrEq12 },
            {5, "ZB32^%!ju105", true, greaterOrEq12 },
            };
            bool failed = false;
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    Assert.AreEqual((bool)testCases[i, 2], HRLib.HRLib.ValidPassword((string)testCases[i, 1]));
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine($"Failed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 3]} \n \t Reason: {ex.Message}\n");
                }
            }
            if (failed)
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void StartsWithUpperEndsInNumber()
        {
            object[,] testCases =
            {
            {1, "A3vfht@4310a", false, upperStartNumberEnd },
            {2, "Abnb32131#6432341!", false, upperStartNumberEnd },
            {3, "321xbef321gg3", false, upperStartNumberEnd },
            {4, "M33j@#ok105L3&2", true, upperStartNumberEnd },
            {5, "Ikzd312@#684mvDB621x5", true, upperStartNumberEnd },
            };
            bool failed = false;
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    Assert.AreEqual((bool)testCases[i, 2], HRLib.HRLib.ValidPassword((string)testCases[i, 1]));
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine($"Failed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 3]} \n \t Reason: {ex.Message}\n");
                }
            }
            if (failed)
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void ContainsOnlyASCIILetters()
        {
            object[,] testCases =
            {
            {1, "A32131nbkr^$@5x10", true, onlyASCIILetters },
            {2, "N83dxZwet#$$5551076d2", true, onlyASCIILetters },
            {3, "A321$mbro3ΩΩΥΥΥ321312", false, onlyASCIILetters },
            {4, "Dβ3213xcED31&&2510b2", false, onlyASCIILetters },
            {5, "OPннусяцкBB321$$$25@1@5", false, upperStartNumberEnd },
            };
            bool failed = false;
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    Assert.AreEqual((bool)testCases[i, 2], HRLib.HRLib.ValidPassword((string)testCases[i, 1]));
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine($"Failed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 3]} \n \t Reason: {ex.Message}\n");
                }
            }
            if (failed)
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void ContainsDigitAndLetterAndSymbol()
        {
            object[,] testCases =
            {
            {1, "A654bdbnk32131bhbo6", false, andASCIIAndDigitAndSymbol },
            {2, "MKkkoKR3231jjZE275", false, andASCIIAndDigitAndSymbol },
            {3, "M10038231643242326412", false, andASCIIAndDigitAndSymbol },
            {4, "Za313^$1@bh!22256", true, andASCIIAndDigitAndSymbol },
            {5, "UppBVBdah22130te5", false, andASCIIAndDigitAndSymbol },
            };
            bool failed = false;
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    Assert.AreEqual((bool)testCases[i, 2], HRLib.HRLib.ValidPassword((string)testCases[i, 1]));
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine($"Failed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 3]} \n \t Reason: {ex.Message}\n");
                }
            }
            if (failed)
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void ContainsWhiteSpace()
        {
            object[,] testCases =
            {
            {1, "A31231btgnrkn^&321321 5", false, hasWhiteSpace },
            {2, "Y321@!xvgr   32131@ht%10", false, hasWhiteSpace },
            {3, "VBgg@#1534Klop#%256", true, hasWhiteSpace },
            {4, "B  3213@#     43dxdEG21", false, hasWhiteSpace },
            {5, "Klop10hb@#190530xv@h541", true, hasWhiteSpace },
            };
            bool failed = false;
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    Assert.AreEqual((bool)testCases[i, 2], HRLib.HRLib.ValidPassword((string)testCases[i, 1]));
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine($"Failed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 3]} \n \t Reason: {ex.Message}\n");
                }
            }
            if (failed)
            {
                Assert.Fail();
            }
        }

    }
    [TestClass]
    public class EncryptPassword
    {
        const string passwordMustBeValid = "Password must be greater or equal than 12. Start with an upper case letter and end with a number. " +
            "Contain only ASCII letters, no whitespaces, and combine letters, digits and symbols";
        const string wrongEncryption = "Ceasars encryption returs a different result";
        [TestMethod]
        public void ValidPasswordForEncryption()
        {
            object[,] testCases =
            {
            {1, "B4232  sxge#!56#fgs531c5", null!, passwordMustBeValid },
            {2, "z321  3126gbt^&321523EG", null!, passwordMustBeValid },
            {3, "907$%21   3vt432f321567321", null!, passwordMustBeValid },
            {4, "     337321", null!, passwordMustBeValid },
            {5, "BnmhRgxEW3δδ3567@@31gbGHR4!@#5", null!, passwordMustBeValid },
            };
            bool failed = false;
            string? encryptedPW = string.Empty;
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                HRLib.HRLib.EncryptPassword((string)testCases[i, 1], ref encryptedPW);
                try
                {
                    Assert.AreEqual((string?)testCases[i, 2], encryptedPW);
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine($"ref encryptedPW\nFailed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 3]} \n \t Reason: {ex.Message}\n");
                }
            }
            if (failed)
            {
                Assert.Fail();
            }

        }
        [TestMethod]
        public void EncryptedCorrectly()
        {
            object[,] testCases =
            {
            {1, "Bnm3215sdw3$5", "Gsr3215xib3$5", wrongEncryption },
            {2, "Z321%32d44321312bt6", "E321%32i44321312gy6", wrongEncryption },
            {3, "O3213@#dadw3312d!zc231pg3", "T3213@#ifib3312i!eh231ul3", wrongEncryption },
            {4, "M321@#ax3321321dadfafardw3133", "R321@#fc3321321ifikfkfwib3133", wrongEncryption },
            {5, "P3ccg^32131adasb432^#$#25", "U3hhl^32131fifxg432^#$#25", wrongEncryption },
            };
            bool failed = false;
            string? encryptedPW = string.Empty;
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                HRLib.HRLib.EncryptPassword((string)testCases[i, 1], ref encryptedPW);
                try
                {
                    Assert.AreEqual((string?)testCases[i, 2], encryptedPW);
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine($"ref encryptedPW\nFailed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 3]} \n \t Reason: {ex.Message}\n");
                }
            }
            if (failed)
            {
                Assert.Fail();
            }

        }

    }
    [TestClass]
    public class CheckPhone
    {
        const string phoneHasLength10 = "Phone must have a length of 10";
        const string phoneContainsDigits = "Phone must contain only digits. No letters";
        const string validPhone = "Phone must belong to a cellphone or landphone zone";
        [TestMethod]
        public void PhoneLength10()
        {
            object[,] testCases =
            {
            {1, "2108935430321315", -1, null!, phoneHasLength10 },
            {2, "2121029476545", -1, null!, phoneHasLength10 },
            {3, "21234", -1, null!, phoneHasLength10 },
            {4, "69340123965", -1, null!,  phoneHasLength10 },
            {5, "69311235", -1, null!, phoneHasLength10 },
            };
            bool failed = false;
            int TypePhone = 0;
            string? InfoPhone = String.Empty;
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                HRLib.HRLib.CheckPhone((string)testCases[i, 1], ref TypePhone, ref InfoPhone);
                try
                {
                    Assert.AreEqual((int)testCases[i, 2], TypePhone);

                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine($"ref TypePhone\nFailed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 4]} \n \t Reason: {ex.Message}\n");
                }
                try
                {
                    Assert.AreEqual((string?)testCases[i, 3], InfoPhone);
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine($"ref InfoPhone\nFailed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 4]} \n \t Reason: {ex.Message}\n");
                }
            }
            if (failed)
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void PhoneContainsOnlyDigits()
        {
            object[,] testCases =
            {
            {1, "210864102x", -1, null!, phoneContainsDigits },
            {2, "6953bng601", -1, null!, phoneContainsDigits },
            {3, "690z23610e", -1, null!, phoneContainsDigits },
            {4, "243035621a", -1, null!,  phoneContainsDigits },
            {5, "zcdehyrlp3", -1, null!, phoneContainsDigits },
            };
            bool failed = false;
            int TypePhone = 0;
            string? InfoPhone = String.Empty;
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                HRLib.HRLib.CheckPhone((string)testCases[i, 1], ref TypePhone, ref InfoPhone);
                try
                {
                    Assert.AreEqual((int)testCases[i, 2], TypePhone);
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine($"ref TypePhone\nFailed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 4]} \n \t Reason: {ex.Message}\n");
                }
                try
                {
                    Assert.AreEqual((string?)testCases[i, 3], InfoPhone);
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine($"ref InfoPhone\nFailed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 4]} \n \t Reason: {ex.Message}\n");
                }
            }
            if (failed)
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void ValidPhone()
        {
            object[,] testCases =
            {
            {1, "2121029476", 0, "Μητροπολιτική Περιοχή Αθήνας - Πειραιά",
                validPhone},
            {2, "2238650120", 0, "Ανατολική Στερεά Ελλάδα, Αττική, Νησιά Αιγαίου", validPhone },
            {3, "6983102301", 1, "COSMOTE", validPhone },
            {4, "6906169189", 1, "NOVA",  validPhone },
            {5, "6910674201", -1, null!, validPhone },
            {6, "2031026013", -1, null!, validPhone },
            {7, "2931064012", -1, null!, validPhone },
            {8, "6950102364", 1, "VODAFONE", validPhone },
            {9, "6013701203", -1, null!, validPhone },
            {10, "9013920710", -1, null!, validPhone },
            };
            bool failed = false;
            int TypePhone = 0;
            string? InfoPhone = String.Empty;
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                HRLib.HRLib.CheckPhone((string)testCases[i, 1], ref TypePhone, ref InfoPhone);
                try
                {
                    Assert.AreEqual((int)testCases[i, 2], TypePhone);
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine($"ref TypePhone\nFailed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 4]} \n \t Reason: {ex.Message}\n");
                }
                try
                {
                    Assert.AreEqual((string?)testCases[i, 3], InfoPhone);
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine($"ref InfoPhone\nFailed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 4]} \n \t Reason: {ex.Message}\n");


                }
            }
            if (failed)
            {
                Assert.Fail();
            }
        }

    }
    [TestClass]
    public class InfoEmployee
    {
        const string adultEmployee = "Employee's age must be greater or equal to 18";
        const string notBornYet = "Employee's birthday can't be after today's year";
        const string hiredIfEmployeeIsAdult = "To hire an employee and calculate his years of experience, the employee must be an adult before he/she got hired";
        const string invalidHiringDate = "The hiring date can't be larger than today's date";
        [TestMethod]
        public void EmployeeIsAdult()
        {
            HRLib.HRLib.Employee[] employees = [
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2121029461", "6906169183", new DateTime(2026, 10, 6), DateTime.Today),
                new HRLib.HRLib.Employee("Pavlos Romanov", "2121029876", "6906107931", new DateTime(1990, 10, 10), DateTime.Today),
                new HRLib.HRLib.Employee("Dimitris Dimitriou", "2103954012", "6930123012", new DateTime(2015, 12, 1), DateTime.Today),
                new HRLib.HRLib.Employee("Alex Alexandrou", "2121068491", "6943012312", new DateTime(2020, 3, 24), DateTime.Today),
                new HRLib.HRLib.Employee("Giwrgos Georgiou", "2121064213", "6906213023", new DateTime(2003, 5, 1), DateTime.Today)
                ];
            object[,] testCases =
            {
            {1, employees[0]!, -1, notBornYet },
            {2, employees[1]!, 33, adultEmployee },
            {3, employees[2]!, -1, adultEmployee },
            {4, employees[3]!, -1, adultEmployee },
            {5, employees[4]!, 20, adultEmployee },
            };
            bool failed = false;
            int Age = 0;
            int YearsOfExperience = 0;
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    HRLib.HRLib.InfoEmployee((HRLib.HRLib.Employee)testCases[i, 1], ref Age, ref YearsOfExperience);
                    Assert.AreEqual((int)testCases[i, 2], Age);
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine($"Failed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 3]} \n \t Reason: {ex.Message}\n");

                }
            }
            if (failed)
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void EmployeeHiredWhenBecameAdult()
        {
            HRLib.HRLib.Employee[] employees = [
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2121029461", "6906169183", new DateTime(2000, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Pavlos Romanov", "2121029876", "6906107931", new DateTime(1990, 10, 10), new DateTime(2005, 5, 5)),
                new HRLib.HRLib.Employee("Dimitris Dimitriou", "2103954012", "6930123012", new DateTime(2005, 12, 1), new DateTime(2024, 1, 1)),
                new HRLib.HRLib.Employee("Alex Alexandrou", "2121068491", "6943012312", new DateTime(2003, 3, 24), new DateTime(2023, 1, 1)),
                new HRLib.HRLib.Employee("Giwrgos Georgiou", "2121064213", "6906213023", new DateTime(2004, 5, 1), new DateTime(2020, 2, 2))
                ];
            object[,] testCases =
            {
                {1, employees[0]!, 23, 2, hiredIfEmployeeIsAdult },
                {2, employees[1]!, -1, -1, hiredIfEmployeeIsAdult },
                {3, employees[2]!, 18, 0, hiredIfEmployeeIsAdult },
                {4, employees[3]!, 20, 1, hiredIfEmployeeIsAdult },
                {5, employees[4]!, -1, -1, hiredIfEmployeeIsAdult },
                };
            bool failed = false;
            int Age = 0;
            int YearsOfExperience = 0;
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                HRLib.HRLib.InfoEmployee((HRLib.HRLib.Employee)testCases[i, 1], ref Age, ref YearsOfExperience);
                try
                {
                    Assert.AreEqual((int)testCases[i, 2], Age);
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine($"ref Age\nTest Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 4]} \n \t Reason: {ex.Message}\n");
                }
                try
                {
                    Assert.AreEqual((int)testCases[i, 3], YearsOfExperience);
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine($"ref YearsOfExperience\nTest Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 4]} \n \t Reason: {ex.Message}\n");
                }
            }
            if (failed)
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void ValidHiringDate()
        {
            HRLib.HRLib.Employee[] employees = [
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2121029461", "6906169183", new DateTime(1999, 10, 6), new DateTime(2023, 12, 1)),
                new HRLib.HRLib.Employee("Pavlos Romanov", "2121029876", "6906107931", new DateTime(1999, 10, 10), new DateTime(2057, 1, 5)),
                new HRLib.HRLib.Employee("Dimitris Dimitriou", "2103954012", "6930123012", new DateTime(1999, 12, 1), new DateTime(2024, 10, 1)),
                new HRLib.HRLib.Employee("Alex Alexandrou", "2121068491", "6943012312", new DateTime(1999, 3, 24), new DateTime(2035, 5, 15)),
                new HRLib.HRLib.Employee("Giwrgos Georgiou", "2121064213", "6906213023", new DateTime(1999, 5, 1), new DateTime(2025, 10, 1))
                ];
            object[,] testCases =
                {
                {1, employees[0]!, 1, invalidHiringDate },
                {2, employees[1]!, -1, invalidHiringDate },
                {3, employees[2]!, -1, invalidHiringDate },
                {4, employees[3]!, -1, invalidHiringDate },
                {5, employees[4]!, -1, invalidHiringDate },
                };
            int Age = 0;
            int YearsOfExperience = 0;
            bool failed = false;

            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                HRLib.HRLib.InfoEmployee((HRLib.HRLib.Employee)testCases[i, 1], ref Age, ref YearsOfExperience);
                try
                {
                    Assert.AreEqual((int)testCases[i, 2], YearsOfExperience);
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine($"Failed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 3]} \n \t Reason: {ex.Message}\n");
                }
            }
            if (failed)
            {
                Assert.Fail();
            }

        }
    }
    [TestClass]
    public class LiveInAthens
    {
        const string validPhone = "Phone must have a length of 10, contain only digits and belong to a cellphone or landphone zone";
        const string phoneBelongsToAthensRegion = "Phones that belong to Athens start with 21";
        [TestMethod]
        public void EmployeePhoneIsValid()
        {
            HRLib.HRLib.Employee[] employeesCase1 = [
                new HRLib.HRLib.Employee("Viktor Romanyuk", "30642103512", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "03216402103", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "21210356041", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2931032071", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "219320103533", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1))
                ];
            HRLib.HRLib.Employee[] employeesCase2 = [
                new HRLib.HRLib.Employee("Viktor Romanyuk", "30643212103512", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "22333216402103", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "292041", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2931032071", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2196", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1))
             ];
            HRLib.HRLib.Employee[] employeesCase3 = [
                new HRLib.HRLib.Employee("Viktor Romanyuk", "3064ddde321512", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "22xz336402103", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "21", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "1", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2abd2", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1))
            ];
            HRLib.HRLib.Employee[] employeesCase4 = [
                new HRLib.HRLib.Employee("Viktor Romanyuk", "21210294600", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2002003012", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "B", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "#%21322", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "290", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1))
            ];
            HRLib.HRLib.Employee[] employeesCase5 = [
                new HRLib.HRLib.Employee("Viktor Romanyuk", "212287042A", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2108983612310323232", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "BAD312xc@", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "3mcew32103231", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", " ", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1))
            ];
            object[,] testCases =
                {
                {1, employeesCase1, 0, validPhone },
                {2, employeesCase2, 0, validPhone },
                {3, employeesCase3, 0, validPhone },
                {4, employeesCase4, 0, validPhone },
                {5, employeesCase5, 0, validPhone },
                };

            bool failed = false;
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    Assert.AreEqual((int)testCases[i, 2], HRLib.HRLib.LiveInAthens((HRLib.HRLib.Employee[])testCases[i, 1]));
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine($"Failed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 3]} \n \t Reason: {ex.Message}\n");
                }
            }
            if (failed)
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void EmployeeHomePhoneInAthens()
        {
            HRLib.HRLib.Employee[] employeesCase1 = [
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2231230315", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2370102301", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2896031002", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2130731074", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                ];
            HRLib.HRLib.Employee[] employeesCase2 = [
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2731060128", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2130754023", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2106700310", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2130731074", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
             ];
            HRLib.HRLib.Employee[] employeesCase3 = [
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2230105301", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2406301203", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2883012031", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2652031062", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
            ];
            HRLib.HRLib.Employee[] employeesCase4 = [
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2109301235", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2106420193", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2653120351", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2391030502", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
            ];
            HRLib.HRLib.Employee[] employeesCase5 = [
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2321070421", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2603021031", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2153122151", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
                new HRLib.HRLib.Employee("Viktor Romanyuk", "2191030332", "6906169183", new DateTime(1999, 10, 6), new DateTime(2022, 1, 1)),
            ];
            object[,] testCases =
                {
                {1, employeesCase1, 1, phoneBelongsToAthensRegion },
                {2, employeesCase2, 3, phoneBelongsToAthensRegion },
                {3, employeesCase3, 0, phoneBelongsToAthensRegion },
                {4, employeesCase4, 2, phoneBelongsToAthensRegion },
                {5, employeesCase5, 2, phoneBelongsToAthensRegion },
                };
            bool failed = false;
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    Assert.AreEqual((int)testCases[i, 2], HRLib.HRLib.LiveInAthens((HRLib.HRLib.Employee[])testCases[i, 1]));
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine($"Failed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 3]} \n \t Reason: {ex.Message}\n");
                }
            }
            if (failed)
            {
                Assert.Fail();
            }
        }
    }
}