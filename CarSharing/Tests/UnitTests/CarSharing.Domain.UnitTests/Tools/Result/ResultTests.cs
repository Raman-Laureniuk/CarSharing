namespace CarSharing.Domain.UnitTests.Tools.Result
{
    using System;
    using CarSharing.Domain.Tools.Result;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ResultTests
    {
        [TestMethod]
        public void Constructor_IsSuccessFalse_ErrorDetailsNull_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Result(false, null));
        }

        [TestMethod]
        public void Constructor_IsSuccessTrue_ErrorDetailsHasValue_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Result(true, new ErrorDetails(ErrorType.Unknown, "Test")));
        }

        [TestMethod]
        public void Constructor_IsSuccessTrue_ErrorDetailsNull_ResultCreated()
        {
            Result result = new Result(true, null);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSuccess);
            Assert.IsNull(result.ErrorDetails);
        }

        [TestMethod]
        public void Constructor_IsSuccessFalse_ErrorDetailsHasValue_ResultCreated()
        {
            Result result = new Result(false, new ErrorDetails(ErrorType.Unknown, "Test"));

            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.IsNotNull(result.ErrorDetails);
            Assert.AreEqual(ErrorType.Unknown, result.ErrorDetails.ErrorType);
            Assert.AreEqual("Test", result.ErrorDetails.Message);
        }

        [TestMethod]
        public void Static_Success_ResultCreated()
        {
            Result result = Result.Success();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSuccess);
            Assert.IsNull(result.ErrorDetails);
        }

        [TestMethod]
        public void Static_Error_ResultCreated()
        {
            Result result = Result.Error(new ErrorDetails(ErrorType.Validation, "Test"));

            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.IsNotNull(result.ErrorDetails);
            Assert.AreEqual(ErrorType.Validation, result.ErrorDetails.ErrorType);
            Assert.AreEqual("Test", result.ErrorDetails.Message);
        }

        [TestMethod]
        public void Implicit_ErrorDetails_Error_ResultCreated()
        {
            Result result = new ErrorDetails(ErrorType.Validation, "Test");

            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.IsNotNull(result.ErrorDetails);
            Assert.AreEqual(ErrorType.Validation, result.ErrorDetails.ErrorType);
            Assert.AreEqual("Test", result.ErrorDetails.Message);
        }

        [TestMethod]
        public void Generic_Constructor_IsSuccessFalse_ErrorDetailsNull_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Result<int>(false, null, default));
        }

        [TestMethod]
        public void Generic_Constructor_IsSuccessTrue_ErrorDetailsHasValue_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Result<int>(true, new ErrorDetails(ErrorType.Unknown, "Test"), default));
        }

        [TestMethod]
        public void Generic_Constructor_IsSuccessTrue_ErrorDetailsNull_ResultCreated()
        {
            Result<int> result = new Result<int>(true, null, 1);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(1, result.Value);
            Assert.IsNull(result.ErrorDetails);
        }

        [TestMethod]
        public void Generic_Constructor_IsSuccessFalse_ErrorDetailsHasValue_ResultCreated()
        {
            Result<int> result = new Result<int>(false, new ErrorDetails(ErrorType.Unknown, "Test"), 1);

            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(1, result.Value);
            Assert.IsNotNull(result.ErrorDetails);
            Assert.AreEqual(ErrorType.Unknown, result.ErrorDetails.ErrorType);
            Assert.AreEqual("Test", result.ErrorDetails.Message);
        }

        [TestMethod]
        public void Generic_Static_Success_ResultCreated()
        {
            Result<int> result = Result<int>.Success(1);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(1, result.Value);
            Assert.IsNull(result.ErrorDetails);
        }

        [TestMethod]
        public void Generic_Static_Error_ResultCreated()
        {
            Result<int> result = Result<int>.Error(new ErrorDetails(ErrorType.Validation, "Test"));
            
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(default, result.Value);
            Assert.IsNotNull(result.ErrorDetails);
            Assert.AreEqual(ErrorType.Validation, result.ErrorDetails.ErrorType);
            Assert.AreEqual("Test", result.ErrorDetails.Message);
        }

        [TestMethod]
        public void Generic_Implicit_Value_Success_ResultCreated()
        {
            Result<int> result = 1;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(1, result.Value);
            Assert.IsNull(result.ErrorDetails);
        }

        [TestMethod]
        public void Generic_Implicit_ErrorDetails_Error_ResultCreated()
        {
            Result<int> result = new ErrorDetails(ErrorType.Validation, "Test");

            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(default, result.Value);
            Assert.IsNotNull(result.ErrorDetails);
            Assert.AreEqual(ErrorType.Validation, result.ErrorDetails.ErrorType);
            Assert.AreEqual("Test", result.ErrorDetails.Message);
        }
    }
}
