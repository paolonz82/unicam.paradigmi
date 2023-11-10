// See https://aka.ms/new-console-template for more information
//REFERENZIO I NAMESPACE O CON LO USING O LA CLASSE SPECIFICA CON IL NOME COMPLETO
//using Unicam.Paradigmi.Test.Models;

using Unicam.Paradigmi.Abstractions;
using Unicam.Paradigmi.Test.Examples;

var examples = new List<IExample>();
examples.Add(new InizialializzazioneClassiExample());
examples.Add(new GestioneEventiExample());

foreach(var example in examples)
{
    //InizialializzazioneClassiExample test = (InizialializzazioneClassiExample)example;
    example.RunExample();
}

Console.ReadLine();




