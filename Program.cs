/*Realizar una aplicación que permita registrar contactos telefónicos, también editarlo , listarlo y eliminarlo. Del contacto se debe 
pedir los siguientes datos: su nombre, apellido y numero telefónico. El sistema debe de validar que el contacto que se este ingresado 
no tenga un numero de teléfono que ya este registrado ,si existe alguien con ese numero de teléfono debe indicarle que existe y enviarlo
al menu principal , en caso de que sea valido pues lo permite agregar, solo se validara los teléfonos al momento de agregar un nuevo contacto
para el editar no lo tomaremos en cuenta por cuestiones de tiempo.*/
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Examen
{
    class Program
    {
        public struct Contactos
        {
            public string pN { get; set; }
            public string pA { get; set; }
            public string tN { get; set; }
        }
        public static List<Contactos> Contactos1 = new List<Contactos>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("CONTACTOS");
                Console.WriteLine("DIGITE LA OPCION:\n1.Agregar Contactos\n2.Listar Contactos\n3.Editar contactos almacenados\n4.Eliminar Contactos");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        agregarC();
                        break;
                    case "2":
                        listC(Contactos1);
                        Console.WriteLine("Presione enter para volver al menu principal");
                        Console.ReadKey();
                        break;
                    case "3":
                        editarC();
                        break;
                    case "4":
                        eliminarC();
                        break;
                    default:
                        Console.ReadKey();
                        break;
                }
            }
            static void agregarC()
            {
                Console.Clear();
                Contactos contact = new Contactos();
                Console.WriteLine("AGREGAR CONTACTOS");
                Console.WriteLine("NOMBRE DEL CONTACTO: ");
                contact.pN = Console.ReadLine();
                Console.WriteLine("APELLIDO DEL CONTACTO: ");
                contact.pA = Console.ReadLine();
                Console.WriteLine("NUMERO DE TELFONO DEL CONTACTO DE 10 DIGITOS: ");
                contact.tN = Console.ReadLine();

                if (contact.tN.Length == 10)
                {
                    if (compN(Contactos1, contact.tN) == true)
                    {
                        Console.WriteLine(" ESTE NUMERO YA EXISTE, PULSA UNA TECLA PARA VOLVER AL MENU PRINCIPAL");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Contacto guardado");
                        Add(Contactos1, contact);
                    }
                }
            }
            static void listC<Contactos>(List<Contactos> lista)
            {
                Console.WriteLine("MOSTRAR CONTACTOS");
                int index = 1;
                Console.WriteLine($"{"Indice",-20}{"NOMBRE",-20}{"APELLIDO",-20}{"NUMERO TELEFONICO",-20}");
                foreach (Contactos i in lista)
                {
                    Console.Write($"{index,-20}|");
                    foreach (PropertyDescriptor ds in TypeDescriptor.GetProperties(i))
                    {
                        object value = ds.GetValue(i);
                        Console.Write($"{value,-20}|");
                    }
                    index++;
                    Console.WriteLine();
                }
            }
            static void Add<T>(List<T> lista, T valor)
            {
                lista.Add(valor);
            }
            static void editarC()
            {
                if (Contactos1.Count != 0)
                {
                    int index;
                    Console.WriteLine("EDITAR CONTACTOS");
                    listC(Contactos1);
                    Console.WriteLine("INDICE DEL CONTACTO A EDITAR:");
                    index = Convert.ToInt32(Console.ReadLine());
                    if (index <= Contactos1.Count)
                    {
                        editar(Contactos1[index - 1]);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("EL INDICE NO EXISTE");
                    }
                }
                else
                {
                    Console.WriteLine("NO HAY CONTACTOS");
                    Console.ReadKey();
                }
            }
            static void eliminarC()
            {
                if (Contactos1.Count != 0)
                {
                    int index;
                    Console.WriteLine("ELIMINAR CONTACTOS");
                    listC(Contactos1);
                    Console.WriteLine("INDICE DEL CONTACTO A ELIMINAR:");
                    index = Convert.ToInt32(Console.ReadLine());
                    if (index <= Contactos1.Count)
                    {
                        Contactos1.RemoveAt(index - 1);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("EL INDICE NO EXISTE");
                    }
                }
                else
                {
                    Console.WriteLine("NO HAY CONTACTOS");
                    Console.ReadKey();
                }
            }
            static bool compN(List<Contactos> lista, string n)
            {
                foreach (Contactos i in lista)
                {
                    foreach (PropertyDescriptor ds in TypeDescriptor.GetProperties(i))
                    {
                        object value = ds.GetValue(i);
                        if (n == value.ToString())
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            static Contactos editar(Contactos contacto)
            {
                string opcion;
                Console.WriteLine("INGRESE EL DATO QUE DESEA EDITAR:");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "nombre":
                        Console.WriteLine("INGRESE EL NUEVO NOMBRE");
                        contacto.pN = Console.ReadLine();
                        break;
                    case "apellido":
                        Console.WriteLine("INGRESE EL NUEVO APELLIDO");
                        contacto.pA = Console.ReadLine();
                        break;
                    case "numero":
                        Console.WriteLine("INGRESE EL NUEVO NUMERO DE TELEFONO");
                        contacto.tN = Console.ReadLine();
                        break;
                }
                return contacto;
            }
        }
    }
}