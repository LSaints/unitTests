

namespace UnitTestsExample.PersonClasses
{
    public class PersonManager
    {
        public Person CreatePerson(string firstName, string lastName, bool isSupervisor)
        {
            Person ret = null;

            if(!string.IsNullOrEmpty(firstName))
            {
                if (isSupervisor) 
                    ret = new Supervisor();
                else
                    ret = new Employee();
                ret.firstName = firstName;
                ret.lastName = lastName;
                
            }
            return ret;
        }
    }
}
