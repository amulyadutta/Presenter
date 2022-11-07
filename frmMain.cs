

using System.Text.Json;
using System;

namespace Presenter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            //var file = File.Open("Presenter.json", FileMode.Open, FileAccess.Read);

            string text = File.ReadAllText("Presenter.json");
            AConfiguration Acontrols = JsonSerializer.Deserialize<AConfiguration>(text);

          
           
            int currentRow = 1;
            int currentCol = 1;

            

            List<ControlButtonInfo> controls = Acontrols.Configuration;

            controls.ForEach(x =>
            {
                x.Height = Acontrols.Buttonheight;
                x.Width = Acontrols.ButtonWidth;
            });

           
            ControlFormation controlFormation = new ControlFormation(controls, this.Height, this.Width);
            List<Button> items = controlFormation.CreateControls();

            foreach(var item in items)
            {
                item.Left =  (currentCol - 1) * (item.Width + Acontrols.HorizontolGap);
                item.Top = (currentRow - 1) * (item.Height + Acontrols.VerticleGap);
                item.Parent = this;
                item.Visible = true;

                
                if (currentCol >= Acontrols.MaxButtonInRow)
                {
                    currentRow++;
                    currentCol = 1;
                }
                else
                {
                    currentCol++;
                }
            }
        }
    }
}