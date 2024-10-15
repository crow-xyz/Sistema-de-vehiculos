public abstract class Vehiculo
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Año { get; set; }
    public int Velocidad { get; set; }
    public Vehiculo(string marca, string modelo, int año, int velocidad)
    {
        Marca = marca;
        Modelo = modelo;
        Año = año;
        Velocidad = velocidad;
    }
    public abstract void Acelerar();
    public abstract void Frenar();
    public virtual string MostrarInfo()
    {
        return $"Marca: {Marca}, Modelo: {Modelo}, Año: {Año}, Velocidad máx: {Velocidad}";
    }
}

interface IVehiculo
{
    public bool Iniciar {  get; set; }
    public bool Detener { get; set; }
}

public class Automovil : Vehiculo, IVehiculo
{
    public int Puertas { get; set; }
    public Automovil(string marca, int puertas, string modelo, int año, int velocidad) : base(marca, modelo, año, velocidad)
    {
        Puertas = puertas;
    }
    public bool Iniciar { get; set; }
    public bool Detener { get; set; }
    public override void Acelerar()
    {
        Console.WriteLine("Acelerando...");
    }
    public override void Frenar()
    {
        Console.WriteLine("Frenando...");
    }
    public override string MostrarInfo()
    {
        return base.MostrarInfo()+$"Puertas: {Puertas}";
    }
}

public class Motocicleta : Vehiculo, IVehiculo
{
    public int Cilindrada { get; set; }
    public Motocicleta(string marca, string modelo, int cilindrada, int año, int velocidad) : base(marca, modelo, año, velocidad)
    {
        Cilindrada = cilindrada;
    }
    public bool Iniciar { get; set; }
    public bool Detener { get; set; }
    public override void Acelerar()
    {
        Console.WriteLine("Acelerando...");
    }
    public override void Frenar()
    {
        Console.WriteLine("Frenando...");
    }
}

public class Camion : Vehiculo, IVehiculo
{
    public int CapacidadDeCarga { get; set; }
    public Camion(string marca, string modelo, int capacidad, int año, int velocidad) : base(marca, modelo, año, velocidad)
    {
        CapacidadDeCarga = capacidad;
    }
    public bool Iniciar { get; set; }
    public bool Detener { get; set; }
    public override void Acelerar()
    {
        Console.WriteLine("Acelerando...");
    }
    public override void Frenar()
    {
        Console.WriteLine("Frenando...");
    }
}

class Program
{
    static void Main()
    {
        List<Vehiculo> Vehiculos = new List<Vehiculo>();
        bool Power = true;
        bool EnSubmenu = true;
        while (Power)
        {
            string menu = @"*** Sistema de vehiculos ***
    1. Agregar nuevo vehículo
    2. Mostrar información de todos los vehículos
    3. Iniciar/Detener un vehículo
    4. Acelerar/Frenar un vehículo
    5. Salir";
            Console.WriteLine(menu);
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    string submenu = @"*** Agregar vehículo ***
    Selecciona qué tipo de vehículo quieres agregar:
        1. Automóvil
        2. Motocicleta
        3. Camión

        4. Volver al menú principal";
                    Console.Clear();
                        Console.WriteLine(submenu);
                        switch (Convert.ToInt32(Console.ReadLine()))
                        {
                            case 1:
                                Vehiculos.Add(AgregarAutomóvil());
                                break;
                            case 2:
                                Vehiculos.Add(AgregarMotocicleta());
                                break;
                            case 3:
                                Vehiculos.Add(AgregarMotocicleta());
                                break;
                            case 4:
                                EnSubmenu = false;
                                break;
                        }
             
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Lista actualizada de vehículos: ");
                    Console.WriteLine("---------------------------------------------------------");
                    foreach(Vehiculo vehiculo in Vehiculos)
                    {
                        vehiculo.MostrarInfo();
                        Console.WriteLine("---------------------------------------------------------");
                    }
                    break;
            }
        }
    }
    static Automovil AgregarAutomóvil()
    {
        Console.Clear();
        Console.WriteLine("Introduzca la información requerida del automóvil:");
        Console.Write("Marca: ");
        string marca = Console.ReadLine();
        Console.Write("Puertas: ");
        int puertas = Convert.ToInt32(Console.ReadLine());
        Console.Write("Modelo: ");
        string modelo = Console.ReadLine();
        Console.Write("Año: ");
        int año = Convert.ToInt32(Console.ReadLine());
        Console.Write("Velocidad máxima: ");
        int velocidad = Convert.ToInt32(Console.ReadLine());
        return new Automovil(marca,puertas,modelo,año,velocidad);
    }
    static Motocicleta AgregarMotocicleta()
    {
        Console.Clear();
        Console.WriteLine("Introduzca la información requerida de la motocicleta:");
        Console.Write("Marca: ");
        string marca = Console.ReadLine();
        Console.Write("Modelo: ");
        string modelo = Console.ReadLine();
        Console.Write("Cilindrada: ");
        int cilindrada = Convert.ToInt32(Console.ReadLine());
        Console.Write("Año: ");
        int año = Convert.ToInt32(Console.ReadLine());
        Console.Write("Velocidad máxima: ");
        int velocidad = Convert.ToInt32(Console.ReadLine());
        return new Motocicleta(marca, modelo, cilindrada, año, velocidad);
    }
    static Camion AgregarCamion()
    {
        Console.Clear();
        Console.WriteLine("Introduzca la información requerida del camión:");
        Console.Write("Marca: ");
        string marca = Console.ReadLine();
        Console.Write("Modelo: ");
        string modelo = Console.ReadLine();
        Console.Write("Capacidad: ");
        int capacidad = Convert.ToInt32(Console.ReadLine());
        Console.Write("Año: ");
        int año = Convert.ToInt32(Console.ReadLine());
        Console.Write("Velocidad máxima: ");
        int velocidad = Convert.ToInt32(Console.ReadLine());
        return new Camion(marca, modelo, capacidad, año, velocidad);
    }
}