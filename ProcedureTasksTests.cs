using ProcedureTestTasks;

namespace ProsedureTestTasks.Tests
{
    public class ProcedureTasksTests
    {
        private readonly object TaskExrcutor;

        [Fact]
        public void FindWords_Send_First_Row_Only_Words_Return_All()
        {
            //Aggregrate
            var firstRowOnlyWords = new string[] { "qweqw", "urywu", "ruiuur", "ruioeyye"};
            var expectedResult = firstRowOnlyWords;

            //Act
            var result = TaskExecutor.FindWords(firstRowOnlyWords);

            //Assert
            Assert.Equal(expectedResult, result);
        }

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
    }
}