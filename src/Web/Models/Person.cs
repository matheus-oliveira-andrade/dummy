namespace Web.Models;

public class Person
{
    public string Name { get; private set; }
    public DateTime BirthDate { get; private set; }

    public Person(string name, DateTime birthDate)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentException("name is invalid");
        if (birthDate == default) throw new ArgumentException("birth date is invalid");

        Name = name;
        BirthDate = birthDate;
    }

    public int GetAge(DateTime currentDateTime)
    {
        var age = currentDateTime.Year - BirthDate.Year;

        if (!AlreadyHadABirthdate(currentDateTime))
        {
            age--;
        }

        return age;
    }

    private bool AlreadyHadABirthdate(DateTime currentDateTime)
    {
        return currentDateTime.Month > BirthDate.Month ||
               currentDateTime.Month >= BirthDate.Month && currentDateTime.Day >= BirthDate.Day;
    }
}