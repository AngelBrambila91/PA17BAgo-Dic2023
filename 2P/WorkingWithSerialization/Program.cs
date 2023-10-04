using PA17B.Shared;
using System.Xml.Serialization; //XmlSerializer
using static System.Environment;
using static System.IO.Path;
//alias
using FastJson = System.Text.Json.JsonSerializer;



internal class Program
{
    private static async Task Main(string[] args)
    {
        // Explicit declaration
        List<Person> people = new()
{
    new (30000M)
    {
        Name = "Gretta",
        LastName = "Medrano",
        DateOfBirth = new(year: 2005, month: 11, day: 12)
    },
    new(20000M)
    {
        Name = "Jared",
        LastName = "Flores",
        DateOfBirth = new(year: 2001, month: 03, day:12)
    },
    new(40000M)
    {
        Name = "Denahi",
        LastName = "Lopez",
        DateOfBirth = new(year: 2004, month: 08, day:10)
    },
    new(8000M)
    {

        Name = "Fernando",
        LastName = "Garcia",
        DateOfBirth = new(year: 2005, month: 10, day:04),
        Children = new()
        {
            new(0M)
            {
                Name = "Marisol",
                LastName = "Garcia",
                DateOfBirth = new(year: 2023, month:10, day:01)
            },
            new(0M)
            {
                Name = "Cesar",
                LastName = "Apolinar",
                DateOfBirth = new(year: 2021, month: 08, day:20)
            }
        }
    }
};



        // Dude that speaks XML
        XmlSerializer xs = new(type: people.GetType());
        string path = Combine(CurrentDirectory, "people.xml");
        // 3 birds 1 stone
        // Explicit declaration
        using (FileStream stream = File.Create(path))
        {
            // serialize
            xs.Serialize(stream, people);
        }
        WriteLine($"Written {new FileInfo(path).Length:N0} bytes of XML on {path}");

        // READ
        WriteLine(File.ReadAllText(path));

        #region De-serialize
        WriteLine($"Deserialize XML file");
        using (FileStream xmlLoad = File.Open(path, FileMode.Open))
        {
            // DEserialize
            List<Person> loadedPeople = xs.Deserialize(xmlLoad) as List<Person>;
            if (loadedPeople is not null)
            {
                foreach (Person p in loadedPeople)
                {
                    WriteLine($"{p.Name} has {p.Children.Count} children");
                }
            }
        }
        #endregion

        #region Serialize Json
        string jsonPath = Combine(CurrentDirectory, "people.json");
        using (StreamWriter jsonStream = File.CreateText(jsonPath))
        {
            // Json object that speaks JSON
            Newtonsoft.Json.JsonSerializer jss = new();
            // serialize
            jss.Serialize(jsonStream, people);
        }

        WriteLine($"Written {new FileInfo(jsonPath).Length:N0} bytes of JSON on {jsonPath}");
        // READ
        WriteLine(File.ReadAllText(jsonPath));
        #endregion

        WriteLine("Deserialize JSON");
        using (FileStream jsonLoad = File.Open(jsonPath, FileMode.Open))
        {
            // deserialize the graph object into a LIST <Person>
            List<Person>? loadedPeople = await FastJson.DeserializeAsync(utf8Json: jsonLoad,
            returnType: typeof(List<Person>)) as List<Person>;
            if (loadedPeople is not null)
            {
                foreach (Person p in loadedPeople)
                {
                    WriteLine($"{p.Name} has {p.Children?.Count} children");
                }
            }
        }
    }
}