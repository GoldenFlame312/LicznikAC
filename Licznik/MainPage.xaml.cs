using System.Diagnostics.Metrics;
using System.Xml.Serialization;
using System.IO;
namespace Licznik
{
    public partial class MainPage : ContentPage
    {
        public static string pathToFile=Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\Local";
        public static string fileName = "counters.xml";
        public static List<CounterModel> allCounters = new List<CounterModel>();
        public MainPage()
        {

            //sprawdzanie czy pliki istnieja
            InitializeComponent();
            if (!Directory.Exists(pathToFile))
            {
                Directory.CreateDirectory(pathToFile);
            }
            if (!File.Exists(pathToFile + "\\" + fileName))
            {
                File.Create(pathToFile + "\\" + fileName);
            }
            
            deserializedCounters();
            countersLoad();
        }
        //dodawanie nowego licznika
        private void OnCounterClicked(object sender, EventArgs e)
        {

            if (App.Current.MainPage is AppShell shell)
            {
                shell.AddNewShellContent(entry.Text,0);
                allCounters.Add(new CounterModel(entry.Text, 0));
                serializedCounters();
            }
        }
        //zapisywanie do pliku wartości
        public static void serializedCounters()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<CounterModel>));

            using (FileStream fileStream = new FileStream(pathToFile + "\\" + fileName, FileMode.Create))
            {
                serializer.Serialize(fileStream, allCounters);
            }
        }
        //odczytywanie z pliku wartosci
        public static void deserializedCounters()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<CounterModel>));

                using (FileStream fileStream = new FileStream(pathToFile + "\\" + fileName, FileMode.Open))
                {
                    allCounters = (List<CounterModel>)serializer.Deserialize(fileStream);
                }
            }
            catch { }
        }
        //ladowanie licznikow
        private void countersLoad()
        {
            foreach(CounterModel x in allCounters)
            {
                if (App.Current.MainPage is AppShell shell)
                {
                    shell.AddNewShellContent(x.name, x.count);
                }
            }
        }
      
    }


}
