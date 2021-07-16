using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using Xunit;

namespace NetCoreXUnitTests.Tests
{
    public class VeichlesTestMock
    {
        [Fact]
        public void TestGetPersonExists()
        {
            var notExists = false;

            try
            {
                // Moca o comportamento da classe de pessoas
                var mock = new Mock<IPeople>();

                // Moca o comportamento para qualquer id que for enviado
                mock.Setup(x => x.Get(It.IsAny<int>())).Returns(value: null);

                // Moca o comportamento para id's em específico
                // mock.Setup(x => x.Get(1)).Returns(value: new Person{Id = 1, Name = "Matias"});
                // mock.Setup(x => x.Get(2)).Returns(value: new Person{Id = 2, Name = "Joao"});
                // mock.Setup(x => x.Get(3)).Returns(value: null);

                // Cria a classe de veiculos, passando por parametro o objeto que teve seus metodos mocados
                var veichle = new Veichles(mock.Object);

                // Busca os dados dos veiculos
                var veichles = veichle.GetFromPerson(personId: 1);
            }
            catch (Exception ex)
            {
                notExists = ex.Message == "Pessoa não encontrada";
            }

            Assert.True(notExists);
        }
    }
}
