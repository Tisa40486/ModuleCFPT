namespace geometrie.Tests
{

    public class geometrieTests
    {
        [Fact]
        public void estEquilateral_TroisCoté_ClasseTriangleEquilateral()
        {
            //Arrange
            int a = 15;
            int b = a;
            int c = b;

            //Act 
            var classeTriangle = Triangle.Classer(a, b, c);

            //Assert
            Assert.Equal("équilatéral", classeTriangle);
        }

        [Fact]
        public void estIsocèle_TroisCoté_ClasseTriangleIsocèle()
        {
            //Arrange
            int a = 15;
            int b = a;
            int c = 10;

            //Act 
            var classeTriangle = Triangle.Classer(a, b, c);

            //Assert
            Assert.Equal("isocèle", classeTriangle);
        }

        [Fact]
        public void estScalène_TroisCoté_ClasseTriangleScalène()
        {
            //Arrange
            int a = 15;
            int b = 25;
            int c = 10;

            //Act 
            var classeTriangle = Triangle.Classer(a, b, c);

            //Assert
            Assert.Equal("scalène", classeTriangle);
        }

        [Fact]
        public void TriangleCoteZero_TroisCoté_Invalid()
        {
            //Arrange
            int a = 15;
            int b = 0;
            int c = 10;

            //Act 
            var classeTriangle = Triangle.Classer(a, b, c);

            //Assert
            Assert.Equal("invalide", classeTriangle);
        }


        [Fact]
        public void TriangleCoteNegatif_TroisCoté_Invalid()
        {
            //Arrange
            int a = 15;
            int b = 15;
            int c = -10;

            //Act 
            var classeTriangle = Triangle.Classer(a, b, c);

            //Assert
            Assert.Equal("invalide", classeTriangle);
        }

        [Fact]
        public void TriangleInvalideCote_TroisCoté_Invalid()
        {
            //Arrange
            int a = 1;
            int b = 2;
            int c = 3;

            //Act 
            var classeTriangle = Triangle.Classer(a, b, c);

            //Assert
            Assert.Equal("scalène", classeTriangle);
        }
    }
}

