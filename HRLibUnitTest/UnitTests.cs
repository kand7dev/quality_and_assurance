using QualityAndAssurance.HRLib;
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
            {1, "Viktor Romanyuk", false, notEmpty },
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
                    Console.WriteLine($"Failed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 3]} \n \t Reason: {ex.Message}");
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
            {1, "Viktor Romanyuk", false, hasNameAndSurname },
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
                    Console.WriteLine($"Failed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 3]} \n \t Reason: {ex.Message}");
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
            {1, "Viktor Romanyuk1", true, hasDigitOrSymbol },
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
                    Console.WriteLine($"Failed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 3]} \n \t Reason: {ex.Message}");
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
                    Console.WriteLine($"Failed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 3]} \n \t Reason: {ex.Message}");
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
                    Console.WriteLine($"Failed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 3]} \n \t Reason: {ex.Message}");
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
            {1, "A32131nbkr^$@5x10", true, upperStartNumberEnd },
            {2, "N83dxZwet#$$5551076d2", true, upperStartNumberEnd },
            {3, "A321$mbro3ΩΩΥΥΥ321312", false, upperStartNumberEnd },
            {4, "Dβ3213xcED31&&2510b2", false, upperStartNumberEnd },
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
                    Console.WriteLine($"Failed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 3]} \n \t Reason: {ex.Message}");
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
                    Console.WriteLine($"Failed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 3]} \n \t Reason: {ex.Message}");
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
                    Console.WriteLine($"Failed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 3]} \n \t Reason: {ex.Message}");
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
        [TestMethod]
        public void ValidPasswordForEncryption()
        {
            object[,] testCases =
            {
            {1, "B4232sxge#!56#fgs531c5", "G4232xclj#!56#klx531h5", passwordMustBeValid },
            {2, "z321  3126gbt^&321523EG", null!, passwordMustBeValid },
            {3, "907$%213vt432f321567321", null!, passwordMustBeValid },
            {4, "ZZZ32!@3byy565f423@3", "EEE32!@3gdd565k423@3", passwordMustBeValid },
            {5, "BnmhRgxEW3567@@31gbGHR4!@#5", "GsrmWlcJB3567@@31lgLMW4!@#5", passwordMustBeValid },
            };
            bool failed = false;
            string? encryptedPW = string.Empty;
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    HRLib.HRLib.EncryptPassword((string)testCases[i, 1], ref encryptedPW);
                    Assert.AreEqual((string?)testCases[i, 2], encryptedPW);
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine($"Failed Test Case: {(int)testCases[i, 0]} \n \t Hint: {(string)testCases[i, 3]} \n \t Reason: {ex.Message}");
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

    }
    [TestClass]
    public class InfoEmployee
    {

    }
    [TestClass]
    public class LiveInAthens
    {

    }
}