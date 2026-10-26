namespace CarSharing.WebApi.Common.UnitTests.Validation.Attributes
{
    using System;
    using CarSharing.WebApi.Common.Validation.Attributes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ForbidDefaultValueAttributeTests
    {
        [TestMethod]
        public void NonDefault_Int_IsValid()
        {
            ForbidDefaultValueAttribute attribute = new ForbidDefaultValueAttribute();
            int                         value     = default(int) + 1;
            bool                        isValid   = attribute.IsValid(value);
            
            Assert.IsTrue(isValid);
        }


        [TestMethod]
        public void NonDefault_NullableInt_IsValid()
        {
            ForbidDefaultValueAttribute attribute = new ForbidDefaultValueAttribute();
            int?                        value     = default(int) + 1;
            bool                        isValid   = attribute.IsValid(value);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void NonDefault_Decimal_IsValid()
        {
            ForbidDefaultValueAttribute attribute = new ForbidDefaultValueAttribute();
            decimal                     value     = default(decimal) + 1.0m;
            bool                        isValid   = attribute.IsValid(value);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void NonDefault_Guid_IsValid()
        {
            ForbidDefaultValueAttribute attribute = new ForbidDefaultValueAttribute();
            Guid                        value     = Guid.NewGuid();
            bool                        isValid   = attribute.IsValid(value);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void NonNull_Instance_IsValid()
        {
            ForbidDefaultValueAttribute attribute = new ForbidDefaultValueAttribute();
            InstanceTestClass           value     = new InstanceTestClass();
            bool                        isValid   = attribute.IsValid(value);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void Default_Int_IsNotValid()
        {
            ForbidDefaultValueAttribute attribute = new ForbidDefaultValueAttribute();
            int                         value     = default;
            bool                        isValid   = attribute.IsValid(value);

            Assert.IsFalse(isValid);
        }

        // TODO: Should it fail validation?
        [TestMethod]
        public void Default_NullableInt_IsNotValid()
        {
            ForbidDefaultValueAttribute attribute = new ForbidDefaultValueAttribute();
            int?                        value     = default(int);
            bool                        isValid   = attribute.IsValid(value);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Null_NullableInt_IsNotValid()
        {
            ForbidDefaultValueAttribute attribute = new ForbidDefaultValueAttribute();
            int?                        value     = null;
            bool                        isValid   = attribute.IsValid(value);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Default_Decimal_IsNotValid()
        {
            ForbidDefaultValueAttribute attribute = new ForbidDefaultValueAttribute();
            decimal                     value     = default;
            bool                        isValid   = attribute.IsValid(value);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Default_Guid_IsNotValid()
        {
            ForbidDefaultValueAttribute attribute = new ForbidDefaultValueAttribute();
            Guid                        value     = default;
            bool                        isValid   = attribute.IsValid(value);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Empty_Guid_IsNotValid()
        {
            ForbidDefaultValueAttribute attribute = new ForbidDefaultValueAttribute();
            Guid                        value     = Guid.Empty;
            bool                        isValid   = attribute.IsValid(value);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Null_Instance_IsNotValid()
        {
            ForbidDefaultValueAttribute attribute = new ForbidDefaultValueAttribute();
            InstanceTestClass           value     = null;
            bool                        isValid   = attribute.IsValid(value);

            Assert.IsFalse(isValid);
        }
    }

    internal class InstanceTestClass
    {
    }
}
