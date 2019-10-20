using Challenge.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;


namespace Challenge.Tests.Entities.FluentValidation
{
    [TestClass]
    public class CategoryTest
    {
        private Category category;

        string stringNull = null;
        string stringOK = "Category";
        string stringGreate150 = string.Concat(Enumerable.Repeat("category", 40));


        [TestMethod]
        public void CreateCategoryValidation_Succes()
        {
            category = new Category(stringOK);
            category.IsValid();
            Assert.IsTrue(category.ValidationResult.IsValid);
        }

        [TestMethod]
        public void CreateCategoryValidation_NameNotCanBeNull()
        {
            category = new Category(stringNull);
            category.IsValid();
            Assert.IsTrue(!category.ValidationResult.IsValid);
        }

        [TestMethod]
        public void CreateCategoryValidation_NameMustNotBeGreaterThan()
        {
            category = new Category(stringGreate150);
            category.IsValid();
            Assert.IsTrue(!category.ValidationResult.IsValid);
        }

    }
}