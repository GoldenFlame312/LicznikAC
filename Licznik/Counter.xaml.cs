using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace Licznik
{
    public partial class Counter : ContentPage
    {
        public int count { get; set; }
        public string name { get; set; }
        public Counter()
        {
            InitializeComponent();
          
        }

        public Counter(string name,int count)
        {
            InitializeComponent();

            this.name = name;
            this.count = count;
            CounterLabel.Text = this.count.ToString();
        }

       
        private void ClickedBtn(object sender, EventArgs e)
        {
            count++;
            CounterLabel.Text = count.ToString();
       
        }

        
        private void ClickedBtnMin(object sender, EventArgs e)
        {
            count--;
            CounterLabel.Text = count.ToString();
         
        }

        private void ClickedSave(object sender, EventArgs e)
        {
            for (int i =0;i<MainPage.allCounters.Count;i++)
            {
                if (MainPage.allCounters[i].name==this.name)
                {
                    MainPage.allCounters[i].count = this.count;
                    MainPage.serializedCounters();
                }
            }
        }
    }
}
