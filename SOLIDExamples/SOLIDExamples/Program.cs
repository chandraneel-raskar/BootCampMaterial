namespace SOLIDExamples
{
    // Parent Class
    public class Player         
    {
        string name;
        double height;
        double weight;
        int age;
    }
    //All of the players need the above basic Details but instead of reassigning the 
    //same values in each of the player classes we make one class and inherit all of its 
    //properties across the funcionalities of the code thus Implementing the DRY Principle.

    // Derived Class 1
    public class Setter : Player, ISet
    {
        
        public void Set()
        {
            Console.WriteLine("The ball has been Set");
        }
        public void CounterBall()
        {
            Console.WriteLine("Counter Ball Set!!!");
        }        
        public void BackCounterBall()
        {
            Console.WriteLine("Back Counter Ball Set!!!");
        }        
        public void ShortBall()
        {
            Console.WriteLine("Short Ball Set!!!");
        }        
        //public void ArcBall()
        //{
        //    Console.WriteLine("Arc Ball Set!!!");
        //    return null;
        //}        
        //public void HalfBall()
        //{
        //    Console.WriteLine("Half Ball Set!!!");            ****Commented Section which shows that classes are Open to Extension****
        //    return null;
        //}        
        //public void FastBall()
        //{
        //    Console.WriteLine("Fast Ball Set!!!");
        //    return null;
        //}

    }

    // Derived Class 2
    public class Attacker : Player,IAttack
    {
        public void Attack()
        {
            Console.WriteLine("The Ball has been Attacked");
        }
        public void LineBall()
        {
            Console.WriteLine("Smashed on the Line!!!");
        }        
        public void CutBall()
        {
            Console.WriteLine("Cut the Blockers!!!");
        }        
        public void DropBall()
        {
            Console.WriteLine("Dropped the Ball!!!");
        }
       //public void WashOut()
       // {
       //     Console.WriteLine("Dropped the Ball!!!");
       //     return null;
       // }

    }

    // Derived Class 3
    public class Libero : Player, IRecieve
    {
        public void Recieve()
        {
            Console.WriteLine("The Ball has been Recieved");
        }
        public void PancakeRecieve()                                           
        {
            Console.WriteLine("Ball picked with Pancake!!!");
        }        
        public void ServeRecieve()  
        {
            Console.WriteLine("Service Recieved!!!");
        }        
        public void SmashRecieve()
        {
            Console.WriteLine("Smash Recieved!!!");
        }
    }
    //We have used different classes for different forms of players all these methods 
    //in a single player class would also have worked but it would have unnecessarily 
    //increased the complexity of the code, hence by segregating the functionalities 
    //we keep the code Simple impelementing the KISS Principle
   
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}




/* Entities:-


 * >Libero
 * -Responsibilities
 *    -Recieve the Smash, Serve and Drop balls so that they are supplied to the Setter.
 * -Not allowed to attack, serve and set.
 * 
 * 
 * >Setter
 * -Responsibilities
 *    -Set the ball to the attackers for an efficient Finish from the Attacker.
 * - Not allowed to attack the ball
 * 
 * >Attacker
 * -Responsibilities
 *    -smash the ball into opponent's court
 *    
 * 
 * 
 * SOLID Principles
 * S- Single Dependency Principle
 * -States that A Class should have only one job or responsilbility
 * -in this code we have 1 parent class Player with the attributes name, age, weight and height.
 * -the other classes Setter, Attacker and Libero are derived from this class.
 * -each of the Children classes have their own responsibility where they each simulate the player 
 *  positions of Attacker, Setter and Libero in a volleyball team.
 * 
 *    Player---->Setter,Attacker,Libero
 * 
 * O- Open Close Principle
 * -States that a class should be open to extension and close to modification.
 * -Each of the team players have their own responsibility but each of them may need to adapt and add on to their skillset
 *  based on the situation of the Game.
 * -We can see that there can be skills added to each player. I have specifically commented the extended functionalities of 
 *  the players showcasing this Principle
 * -The base class or the parent class is Closed to Modification as there is no need to make any changes in the basic 
 *  attributes of the player
 *  
 * L- Liskov's Principle
 * - States that a Subclass S must be able to replace all Instances of the parent class in the Program.
 * - We can say that in this code each of the players can replace the occurences of objects created out of the player class
 *   which satisfies the Liskov's Principle
 *   
 * I- Interface Segregation
 * - States that no entity must be forced to implement as interface that it doesn't use
 * - From the Interface1 file we can see a interface Volleyball Actions which has all the actions.
 * - in that case where the libero doesn't need to implement the attack function or the set function if that interface is used
 *   then we will have to use those unwanted methods too.
 * - we have hence made segregated interfaces for each different characteristics for each type of Player
 * 
 * D- Dependency Inversion
 * - States that High level entities must not be dependent on low level entities but should Depend on abstractions.
 * - In our code the Base Class Player is not dependent on any of the derived classes and since our use case does not require any
 * - dependency on a base class we dont need an abstraction or an interface to produce an implementation.