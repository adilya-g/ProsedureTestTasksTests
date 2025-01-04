using ProcedureTestTasks;

namespace ProsedureTestTasks.Tests
{
    public class ProcedureTasksTests
    {
        [Theory]
        [InlineData(new object[] { new string[] {"qwer", "tyqer", "ywoiyyqu"}})] //new object[] чтобы можно было передавать массив    
        [InlineData(new object[] { new string[] {"ahasf", "ahjdghkk", "h"}})]
        [InlineData(new object[] { new string[] {"zcxbnvc", "b", "mmvvnmnbvcxcvbnm"}})]
        public void FindWords_Send_One_Row_Only_Words_Return_All(string[] OneRowOnlyWords)
        {
            //Aggregrate
            var expectedResult = OneRowOnlyWords;

            //Act
            var result = TaskExecutor.FindWords(OneRowOnlyWords);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void FindWords_Send_First_Second_Third_Rows_Only_Words_Return_All()
        {
            //Aggregate
            var allRowsOnlyWords = new string[] { "rtwy", "gdjsh", "vcnbx", "shdgs", "cxbnb" };
            var expectedResult = allRowsOnlyWords;

            //Act
            var result = TaskExecutor.FindWords(allRowsOnlyWords);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void FindWords_Send_3_Incorrect_and_4_Correct__Words_Return_4_Correct_Words()
        {
            //Aggregate
            var differrentWords = new string[] {"qywtre", "xbhysvbhjd", "vbnbvcc", "xdftygvhuj", "aggfsdfghj", "cfgygujn", "rttyuuyre"};
            var expectedResult =  new string[] { "qywtre", "vbnbvcc", "aggfsdfghj", "rttyuuyre"};

            //Act
            var result = TaskExecutor.FindWords(differrentWords);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void FindWords_Send_Empty_Array_Throw_Exception()
        {
            //Aggregate
            var emptyArray = Array.Empty<string>();

            //Assert
            Assert.Throws<NotSupportedException>(() => TaskExecutor.FindWords(emptyArray)); 
        }

        [Fact]
        public void GetCounntUniqueemails_Send_All_Different_Normalised_Return_Input_Length()
        {
            //Aggregate
            var differrentNormilisedEmails = new string[] { "asdwerf@email.com", "vferttgd@email.com", "erfdvbnmloiuyh@email.com" };
            var expectedResult = differrentNormilisedEmails.Length;

            //Act
            var result = TaskExecutor.GetCountUniqueEmails(differrentNormilisedEmails);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GetCountUniqueEmails_Send_All_Simmilar_Not_Normilised_Return_1()
        {
            //Aggregate
            var simmilarNotNormilisedEmails = new string[] {"apple.donut@email.com", "appledonut+bhgsgbch@email.com", "apple...donut+jnjmj@email.com"};
            var expectedCount = simmilarNotNormilisedEmails.Length;

            //Act
            var result = TaskExecutor.GetCountUniqueEmails(simmilarNotNormilisedEmails);

            //Assert
            Assert.Equal(expectedCount, result);
        }

        [Fact]
        public void GetCountUniqueEmails_Send_3_Unique_2_Similar_Emails_Return_3()
        {
            //Aggregate
            var emails = new string[] {"ascawd@jsnd.ru", "bsgxt@qmail.com", "fhgghj@gmail.com", "qwerty+gyujnbgj@gmail.com", "qwerty@gmail.com"};
            int expectedResult = emails.Length - 2;
            
            //Act
            var result = TaskExecutor.GetCountUniqueEmails(emails);

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}