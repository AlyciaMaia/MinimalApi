using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Infraestrutura.Db;

namespace Test.Domain.Entidades;

[TestClass]
public sealed class Test1
{
    private DbContexto ContextoDaClasse()
{
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        var Configuration = builder.Build();

        return new DbContexto(Configuration);
}

    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        //arrange
        var adm = new Administrador();
        adm.Id = 1;
        adm.Email = "Teste@teste.com";
        adm.Senha = "Senha";
        adm.Perfil = "Adm";

        //Act
       

        //Assert
        Assert.AreEqual(1, adm.Id);
        Assert.AreEqual("Teste@teste.com", adm.Email);
        Assert.AreEqual("Adm", adm.Perfil);
        Assert.AreEqual("Senha", adm.Senha);
    }
}
