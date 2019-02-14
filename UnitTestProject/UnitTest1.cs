using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Controllers;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetItemsTestMethod()
        {
            ValuesController values = new ValuesController();
            var httpResult = values.GetItems();
            var contentResult = httpResult as OkNegotiatedContentResult<List<WebApi.Models.ITEM>>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            //Assert.AreEqual(HttpStatusCode.OK, (OkResult)httpResult);
        }

        [TestMethod]
        public void GetItemsByIdTestMethod()
        {
            ValuesController values = new ValuesController();
            var httpResult = values.GetItem(1);
            var contentResult = httpResult as OkNegotiatedContentResult<WebApi.Models.ITEM>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
        }

        [TestMethod]
        public void PostItemTestMethod()
        {
            ValuesController values = new ValuesController();
            var httpResult = values.PostItem("6", "FFF", "30");
            var contentResult = httpResult as OkResult;
            Assert.IsNotNull(contentResult);
            //Assert.IsNotNull(contentResult.Content);
        }

        [TestMethod]
        public void PutItemTestMethod()
        {
            ValuesController values = new ValuesController();
            var httpResult = values.PutItem("5", "1FFF", "30");
            var contentResult = httpResult as OkResult;
            Assert.IsNotNull(contentResult);
            //Assert.IsNotNull(contentResult.Content);
        }

        [TestMethod]
        public void DeleteItemTestMethod()
        {
            ValuesController values = new ValuesController();
            var httpResult = values.DeleteItem("5");
            var contentResult = httpResult as OkResult;
            Assert.IsNotNull(contentResult);
            //Assert.IsNotNull(contentResult.Content);
        }
    }
}
