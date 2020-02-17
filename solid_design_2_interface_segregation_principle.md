# C# - 2. SOLID - Interface Segregation Principle

*Après cette quête, tu comprendras le concept de ségrégation d'interfaces*

## Objectifs

* Comprendre le principe de ségrégation d'interface
* Repérer une violation du principe
* Trouver une solution pour corriger une violation du principe

## Etapes

### Le principe en tant que tel

Le principe de ségrégation d'interface énoncé par Robert C. Martins est décrit comme suit:
**Aucun client ne devrait dépendre d'interfaces qu'il n'utilise pas**

Par *client*, l'énoncé du principe entend *classe*. Ce principe énonce donc qu'on ne devrait pas faire *dépendre* une classe d'une interface dont elle ne se sert pas.

Pris de l'autre sens, ce principe pourrait être énoncé de la façon suivante: **Aucune interface ne devrait définir de méthodes qu'un de ses enfants n'utilise pas**. De manière concrète - une classe héritant d'une interface devant définir toutes les méthodes spécifiées par celle-ci - aucune méthode de l'interface dont dépend une classe en question ne doit être superflue.

Par exemple, si deux classes `Car` et `SpaceShip` dépendent toutes les deux d'une interface `IDrivable`, l'interface `IDrivable` doit définir des méthodes qui seront utilisées par les deux classes. Une méthode `LaunchRocket` ne serait pas adaptée dans la classe `Car` mais plus adaptée dans la classe `SpaceShip` puisqu'il s'agit d'un vaisseau spatial. La méthode `LaunchRocket` ne devrait pas être déclarée dans l'interface `IDrivable` puisqu'un objet de classe `Car` n'en aurait aucune utilité. Cependant `LaunchRocket` pourrait être nécessaire dans d'autres véhicules conduisibles. 

![ISP](https://i0.wp.com/blogs.innovationm.com/wp-content/uploads/2017/11/InterfaceSegregationPrinciple.jpg?resize=624%2C499) 

> Alors, comment puis-je faire pour garder des interfaces claires et concises sans violer le principe ?

#### Ressources


* [Article sur l'ISP](https://hackernoon.com/interface-segregation-principle-bdf3f94f1d11)

### Une responsabilité par interface

Chaque interface que tu définis concerne une responsabilité en particulier. Dans l'exemple de l'étape précédente, un véhicule spatial est conduisible mais est quand même assez différent d'une voiture. Un véhicule spatial et une voiture partagent une interface en commun parce que tous deux sont conduisibles, mais un véhicule spatial possède d'autres méthodes comme celle d'amorcer le lancement en allumant les missiles placés à l'arrière d'une fusée.

Puisqu'il serait illogique de rajouter dans l'interface `IDrivable` une méthode `LaunchRocket`, absurde pour une voiture (à moins qu'elle soit volante elle aussi), une solution simple serait de créer une nouvelle interface `IDrivableSpaceship` forçant l'implémentation de méthodes propres au fonctionnement d'un véhicule spatial, tout en implémentant celles d'un véhicule standard.

> N'aurais-je pas de duplication en décrivant deux interfaces définissant des méthodes en commun ?

Oui, il y aurait une duplication de code inutile si tu devais écrire deux fois une interface semblable, mais il y a un moyen de ne pas réecrire le code de tes interfaces et ce mécanisme est l'héritage.

> Je peux donc faire hériter des interfaces entre elles ?

Oui, cela sans soucis et c'est d'ailleurs plutôt recommandé si tu veux suivre les bonnes pratiques d'abstraction et notamment celui de la ségrégation d'interfaces.

> Mais je ne risque pas d'avoir une méga-interface à laquelle plusieurs responsabilités serait attribuées ?

#### Ressources

* [Interface inheritance](https://www.geeksforgeeks.org/c-sharp-inheritance-in-interfaces/)

### De petites interfaces s'il vous plaît

Notre cerveau gère naturellement plus rapidement de petites choses dans un grand ensemble que de grandes choses dans un petit. Il en va de même pour les interfaces, les interfaces énormes rendent le code inintelligible et occultent l'intention première avec laquelle une interface a été conçue. Il arrive souvent qu'au fur et à mesure des ajouts de fonctionnalités dans une application les interfaces grossissent jusqu'à devenir des mastodontes ayant une douzaine de responsabilités.

Pour éviter le fiasco total (une interface avec trop de méthodes qui n'ont rien à voir ensembles) il vaut mieux concevoir de petites interfaces répondant à un besoin particulier qu'une énorme interface répondant à tous les besoins. Cela permet un meilleur contrôle de la base de code et permet aussi d'éviter de déclarer du code *inutile* dans les classes implémentant des interfaces mal-conçues, c'est-à-dire des interfaces étant implémentées par des objets n'ayant **pas besoin d'au moins une de ses méthodes**.

#### Ressources 

* [Interface pollution](https://medium.com/@severinperez/avoiding-interface-pollution-with-the-interface-segregation-principle-5d3859c21013)

## Challenge

### Corriger une violation

Tu dois corriger la violation du principe de ségrégation d'interfaces présente dans le code suivant:
```C#
interface IDrivable
{
    void Drive(long miles);
    void LaunchRocket();
}

class Car : IDrivable
{
    public void Drive(long miles)
    {
        Console.WriteLine("I am driven to {0} miles away ...", miles);
    }

    public void LaunchRocket()
    {
        Console.WriteLine("I don't have any rocket to launch ...");
    }
}

class FlyingCar : IDrivable
{
    private bool _isRocketLaunched;

    public void Drive(long miles)
    {
        if (!_isRocketLaunched)
        {
            Console.WriteLine("Launch the rocket first or this flying car can not get driven.");
        }
        else
        {
            Console.WriteLine("I am flying to {0} miles away ...", miles);
        }
    }

    public void LaunchRocket()
    {
        _isRocketLaunched = true;
    }
}

class SpaceShip : IDrivable
{
    private bool _isRocketLaunched;

    public void Drive(long miles)
    {
        if (!_isRocketLaunched)
        {
            Console.WriteLine("Spaceship can't leave Earth if its rocket is not launched !");
        }
        else
        {
            Console.WriteLine("The spaceship is going {0} miles away", miles);
        }
    }

    public void LaunchRocket()
    {
        _isRocketLaunched = true;
    }
}
```


### Critères de validation

* Un lien vers ta solution sur [GitHub](https://github.com)
* Le comportement des classes ne change pas
* Aucune méthode déclarée par une interface reste inutilisée par une classe l'implémentant