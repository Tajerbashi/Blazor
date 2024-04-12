﻿using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit.Abstractions;

namespace Blazor_Domain_Library_Test.Security.UserTest
{
    [CollectionDefinition("UserCollection")]
    public class UserTestContainer //: IClassFixture<UserFixture>
    {
        private readonly ITestOutputHelper OutPut;
        private readonly UserFixture UserFixture;
        private readonly UserModelGenerator UserModelGenerator;
        public UserTestContainer(ITestOutputHelper outPut)
        {
            UserFixture = new UserFixture();
            OutPut = outPut;
            UserModelGenerator = UserFixture.Generator;

        }
        [Trait("CRUD", "Create")]
        [Fact]
        public void Create()
        {
            //  Arrange
            var model = UserModelGenerator.GetUserEntity();
            //  Act
            var result = model.Name.Count() > 6 && model.Family.Count() > 6 && !model.IsDeleted && model.IsActive;
            //  Assert
            Assert.True(result);
        }

        [Trait("CRUD", "Update")]
        [Fact]
        public void Update()
        {
            //  Arrange
            var model = UserModelGenerator.GetUserEntity();
            var newModel = UserModelGenerator.GetUserEntityForUpdate();
            //  Act
            var result = model.Name.Count() > 6 && !newModel.Name.Equals(model.Name) &&
                         model.Family.Count() > 6 && !newModel.Family.Equals(model.Family) &&
                         !model.IsDeleted &&
                         model.IsActive;
            //  Assert
            Assert.True(result);
        }
        [Trait("CRUD", "Delete")]
        [Fact]
        public void Delete()
        {
            //  Arrange
            //  Act
            var result = true;
            //  Assert
            Assert.True(result);
        }
        [Trait("CRUD", "Read")]
        [Fact]
        public void Read()
        {
            //  Arrange
            //  Act
            var result = UserModelGenerator.GetUserEntity();
            //  Assert
            Assert.NotNull(result);
        }


        [Trait("CRUD", "Exception")]
        [Fact(Skip = "This is a Check Test")]
        public void Exception()
        {
            //  Arrange
            //  Act
            var result =UserModelGenerator.GetUserEntity();
            //  Assert
            Assert.Throws<Exception>(() => UserModelGenerator.ExceptionHandler());
        }

        [Trait("Console", "Write")]
        [Fact]
        public void Console()
        {
            //  Arrange
            OutPut.WriteLine("Arrange : Console ");
            //  Act
            var result = UserModelGenerator.GetUserEntity();
            //  Assert
            Assert.NotNull(result);
        }
    }
}
