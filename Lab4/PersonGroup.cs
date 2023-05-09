

namespace Lab4
{
    public class PersonGroup
    {
        public List<Person> Persons { get; set; } = new List<Person>();

        public char? StartingLetter {
            get {
                // if Persons is SORTED
                return Persons[0].FirstName[0];
            }
        }

        // TODO
        public char? EndingLetter {
            get
            {
                return Persons[Count - 1].FirstName[Count - 1];
            }
        }

        public int Count => Persons.Count;

        // Added late
        public void Add(Person person)
        {
            Persons.Add(person);
        }


        public Person this[int i]
        {
            get
            {
                if (Persons == null)
                    throw new NullReferenceException("Persons is null");

                if (i < 0 || i > Persons.Count)
                    throw new IndexOutOfRangeException();

                Persons.Sort();
                return Persons[i];
            }
        }

        public PersonGroup(List<Person> persons = null)
        {
            if( persons != null)
            {
                foreach(var p in persons)
                {
                    Persons.Add(p);
                }
            }

            Persons.Sort();
        }

        public override string ToString()
        {
            return "[" + String.Join(", ", Persons)+ "]";
        }


        // TODO
        public static List<PersonGroup> GeneratePersonGroups(List<Person> persons, int distance)
        {
            List<PersonGroup> peoplesgroup = new List<PersonGroup>();

            persons.Sort();

            var newGroup = new PersonGroup();

            foreach (var person in persons)
            {
                if (newGroup.Count == 0)
                {
                    newGroup.Persons.Add(person);
                }
                else if (person.Distance(newGroup[0]) <= distance)
                {
                    newGroup.Persons.Add(person);
                }
                else
                {
                    peoplesgroup.Add(newGroup);

                    var newerGroup = new PersonGroup();

                    newGroup = newerGroup;

                    newerGroup.Persons.Add(person);
                }
            }
            return peoplesgroup;
            
        }

    }
}
