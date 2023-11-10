// See https://aka.ms/new-console-template for more information
//REFERENZIO I NAMESPACE O CON LO USING O LA CLASSE SPECIFICA CON IL NOME COMPLETO
//using Unicam.Paradigmi.Test.Models;
using System.Collections;
using Unicam.Paradigmi.Test.Examples;
using Unicam.Paradigmi.Test.Models;

var persona = new Unicam.Paradigmi.Test.Models.Persona();
persona.Nome = "Federico";
persona.Cognome = "Paoloni";
persona.Eta = 40;
//****************************************//

//DICHIARAZIONI DI ARRAY
string[] stagioni = new string[4];
stagioni[0] = "Primavera";
stagioni[1] = "Estate";
stagioni[2] = "Autunno";
stagioni[3] = "Inverno";
foreach (var stagione in stagioni)
{
    Console.WriteLine($"Ciclo sulla stagione {stagione}");
}
//**********************************//

//PROVA PASSAGGIO PER VALORE/RIFERIMENTO
var miaEta = 40;
var nome = "Federico";
var cognome = "Paoloni";
ModificaValore(miaEta);
Console.WriteLine($"Ciao mi chiamo {nome} {cognome}.La mia età è : {miaEta}");
ModificaValorePerRiferimento(ref miaEta);
Console.WriteLine($"Ciao mi chiamo {nome} {cognome}.La mia età è : {miaEta}");
var annoNascita = 0;
IsMaggiorenne(miaEta, out annoNascita);
Console.WriteLine($"Sono nato nell'anno {annoNascita}");

void ModificaValore(int eta)
{
    //Essendo eta un tipo di dato primitivo (int) viene passato per valore
    eta = 20;
}
void ModificaValorePerRiferimento(ref int eta)
{
    eta = 20;
}

bool IsMaggiorenne(int eta, out int annoNascita)
{
    annoNascita = DateTime.Now.Year - eta;
    return eta >= 18;
}


GestioneEventi.RunExample();




