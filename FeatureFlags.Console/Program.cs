// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

IFeatureManager FeatureManager;

InitializeFeatures();


Console.WriteLine("Hola al demo de Feature Flags!");
Console.WriteLine("---------------------------------------------");

var exceuteOn = true;

while (exceuteOn)
{


    Console.WriteLine("[C] Crear un cliente");
    Console.WriteLine("[A] Actualizar un cliente");
    Console.WriteLine("[B] Borrar un cliente");

    if(await FeatureManager.IsEnabledAsync("Imprimir")) { 
        Console.WriteLine("[P] Imprimir listado de clientes");
    }

    Console.WriteLine("[S] Salir");
    Console.WriteLine("---------------------------------------------");
    Console.WriteLine("Selecciona una opcion:");

    var letterSelected = Console.ReadKey().Key.ToString().ToUpper();

    switch (letterSelected)
    {

        case "C":
            CrearCliente();
            break;
        case "A":
            ActualizarCliente();
            break;
        case "B":
            BorrarCliente();
            break;
        case "P":
            ImprimirListado();
            break;
        case "S":
            exceuteOn = false;
            break;

    }

}

Console.WriteLine("Gracias, vuelva pronto!");
Console.ReadKey();


void ImprimirListado()
{
    ShowMessage("Listado de clientes Impreso!!!!!!");
}

void BorrarCliente()
{
    ShowMessage("Cliente Borrado!!!!!!");
}

void ActualizarCliente()
{
    ShowMessage("Cliente Actualizado!!!!!!");
}

void CrearCliente()
{
    ShowMessage("Cliente Creado!!!!!!");
}

void ShowMessage(string message)
{
    Console.WriteLine();
    Console.WriteLine(")--------------------------------------------(");
    Console.WriteLine(message.ToUpper());
    Console.WriteLine(")--------------------------------------------(");
    Console.WriteLine();
}

void InitializeFeatures()
{
    //var flags = new Dictionary<string, string>()
    //{
    //    { "FeatureManagement:Imprimir", "false" }
    //};

    IConfigurationBuilder builder = new ConfigurationBuilder();
    //builder.AddInMemoryCollection(flags);
    builder.AddJsonFile("appsettings.json");

    IConfigurationRoot configuration = builder.Build();

    IServiceCollection services = new ServiceCollection();
    services.AddFeatureManagement(configuration);
    IServiceProvider serviceProvider = services.BuildServiceProvider();
    FeatureManager = serviceProvider.GetRequiredService<IFeatureManager>();
}
