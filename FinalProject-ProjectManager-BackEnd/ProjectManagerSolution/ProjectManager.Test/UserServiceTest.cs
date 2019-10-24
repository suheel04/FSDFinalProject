using System;
using System.Linq;
using NUnit.Framework;
using ProjectManager.Contracts;
using ProjectManager.Entities;
using ProjectManager.BusinessService;


namespace ProjectManager.Test
{
    public class UserServiceTest
    {
        UserService _service;
        public UserServiceTest()
        {
            _service = new UserService();
        }
        [SetUp]
        public void SetUp()
        {
            AutoMapperConfig.Initialize();
        }
        [Test]
        public void GetAllUser()
        {
            var userList = _service.GetAllUsers();
            Assert.IsNotNull(userList);
            Assert.IsInstanceOf(typeof(UserEntity), userList.FirstOrDefault());
        }
        [Test]
        public void GetUser()
        {
            var userList = _service.GetAllUsers().FirstOrDefault();
            var user = _service.GetUser(userList.UserID);
            Assert.IsNotNull(user);
            Assert.IsInstanceOf(typeof(UserEntity), user);
            Assert.AreEqual(user.UserID, userList.UserID);
        }
        [Test]
        public void AddUser()
        {
            var addEntity = new UserEntity
            {
                FirstName = "NUnit",
                LastName = "User",
                EmployeeID = 5678
            };

            var value = _service.AddUser(addEntity);
            Assert.IsTrue(value > 0);
        }
        [TestCase]
        public void UpdateUser()
        {
            var updateEntity = _service.GetAllUsers().Where(x => x.EmployeeID != 1255).FirstOrDefault();
            if (updateEntity != null)
            {
                updateEntity.EmployeeID = 1255;
                var value = _service.UpdateUser(updateEntity);
                var result = _service.GetUser(updateEntity.UserID);
                Assert.IsTrue(value > 0);
                Assert.IsTrue(result.EmployeeID == 1255);
                Assert.AreEqual(result.EmployeeID, 1255);

            }
            else
            {
                Assert.Ignore();
            }
        }
    }
}
