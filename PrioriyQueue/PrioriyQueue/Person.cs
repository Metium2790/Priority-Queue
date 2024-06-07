using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrioriyQueue
{
    class PersonNode
    {
        private int Age;
        private int Skill;
        public int skillnum;
        public PersonNode next;

        public int age
        {
            get
            {
                return Age;
            }
            set
            {
                if (value < 100 && value > 0)
                {
                    Age = value;
                }
                else
                    throw new Exception("The Age cannot be more than 100 or less than 0");
            }
        }
        public string skill
        {
            get 
            { 
                switch(Skill)
                {
                    case 1:
                        return "A";
                    case 2:
                        return "B";
                    case 3:
                        return "C";
                    case 4:
                        return "D";
                    case 5:
                        return "E";
                    case 6:
                        return "F";
                    default:
                        return null;
                }
            }
            set
            {
                switch(value)
                {
                    case "A":
                        Skill = 1;
                        skillnum = 1;
                        break;
                    case "B":
                        Skill = 2;
                        skillnum = 2;
                        break;
                    case "C":
                        Skill = 3;
                        skillnum = 3;
                        break;
                    case "D":
                        Skill = 4;
                        skillnum = 4;
                        break;
                    case "E":
                        Skill = 5;
                        skillnum = 5;
                        break;
                    case "F":
                        Skill = 6;
                        skillnum = 6;
                        break;
                    default:
                        throw new Exception("The skill should be set between A and F");  
                }
            }
        }

        public PersonNode(int a,string s)
        {
            skill = s;
            age = a;
            next = null;
        }
    }

    class Queue_Priority
    {
        PersonNode head;
        int size;

        public Queue_Priority()
        {
            head = null;
            size = 0;
        }

        public void Add(PersonNode x)
        {
            if (this.isEmpty())
            {
                head = x;
                size++;
            }

            else
            {
                PersonNode temp = head;

                if (x.skillnum > head.skillnum)
                {
                    x.next = head;
                    head = x;
                    size++;
                }
                else
                {
                    if (x.skillnum == head.skillnum && x.age <= head.age)
                    {
                        if (x.age <= head.age)
                        {
                            x.next = head;
                            head = x;
                            size++;
                        }
                    }

                    else
                    {

                        while (temp.next != null && temp.next.skillnum > x.skillnum)
                            temp = temp.next;

                        if (temp.next != null && temp.next.skillnum < x.skillnum)
                        {
                            x.next = temp.next;
                            temp.next = x;
                            size++;
                        }

                        else
                        {
                            if (temp.next != null && temp.next.age < x.age)
                            {
                                while (temp.next != null && temp.next.age <= x.age)
                                    temp = temp.next;
                            }

                            x.next = temp.next;
                            temp.next = x;
                            size++;
                        }
                    }
                }
            }
        }

        public void removehead()
        {
            head = head.next;
            size--;
        }

        public void skillup(int target)
        {
            PersonNode temp = head;
            if (target <= size && target != 1)
            {
                for (int i = 0; i < target - 2; i++)
                    temp = temp.next;
                if (temp.next != null && temp.skillnum < 6)
                {
                    PersonNode temp2 = temp.next;
                    temp.next = temp.next.next;

                    temp2.skillnum++;
                    PersonNode newnode;

                    switch (temp2.skillnum)
                    {
                        case 1:
                            newnode = new PersonNode(temp2.age, "A");
                            this.Add(newnode);
                            break;
                        case 2:
                            newnode = new PersonNode(temp2.age, "B");
                            this.Add(newnode);
                            break;
                        case 3:
                            newnode = new PersonNode(temp2.age, "C");
                            this.Add(newnode);
                            break;
                        case 4:
                            newnode = new PersonNode(temp2.age, "D");
                            this.Add(newnode);
                            break;
                        case 5:
                            newnode = new PersonNode(temp2.age, "E");
                            this.Add(newnode);
                            break;
                        case 6:
                            newnode = new PersonNode(temp2.age, "F");
                            this.Add(newnode);
                            break;
                        default:
                            Console.WriteLine("Can't upgrade the skill more than that");
                            break;
                    }
                }
                else if(temp.skillnum > 6)
                    Console.WriteLine("Can't upgrade the skill more than that");
                else if (temp.next == null)
                {

                }
            }
            else if (target == 1)
            {
                if (head != null)
                {
                    if (head.skillnum < 6)
                    {
                        head.skillnum++;
                        switch (head.skillnum)
                        {
                            case 1:
                                head.skill = "A";
                                break;
                            case 2:
                                head.skill = "B";
                                break;
                            case 3:
                                head.skill = "C";
                                break;
                            case 4:
                                head.skill = "D";
                                break;
                            case 5:
                                head.skill = "E";
                                break;
                            case 6:
                                head.skill = "F";
                                break;
                            default:
                                Console.WriteLine("Can't upgrade the skill more than that");
                                break;
                        }
                    }
                    else
                        Console.WriteLine("Can't upgrade the skill more than that");
                }
            }
            else
                Console.WriteLine("your chosen target is bigger than the size of the list");
        }

        public bool isEmpty()
        {
            if (head == null)
                return true;

            else
                return false;
        }

        public void display()
        {
            PersonNode temp = head;
            int i = 1;

            while (temp != null)
            {
                Console.Write(i+"-("+temp.skill+","+temp.age+") ");
                temp = temp.next;
                i++;
            }
        }
    }
}
