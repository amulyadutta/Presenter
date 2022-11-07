

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
            var buttonConfig = JsonSerializer.Deserialize<Configuration>(text);

            int MaxCols=5;
            int HorizontolGap = 100;
            int VerticleGap = 100;
            int currentRow = 1;
            int currentCol = 1;

            int buttonHeight = 500;
            int buttonWidth = 500;

            List<ControlButtonInfo> controls = new List<ControlButtonInfo>();
            controls.Add(
                new ControlButtonInfo {
                    Id = 1,
                    Caption = "Water",
                    Image = "D:\\Working\\Code\\Guide\\Icons\\Bathroom.jpeg",
                    Height = buttonHeight,
                    Width = buttonWidth,
                });
            controls.Add(
                new ControlButtonInfo
                {
                    Id = 2,
                    Caption = "TOIlET",
                    Image = "D:\\Working\\Code\\Guide\\Icons\\Water.png",
                    Height = buttonHeight,
                    Width = buttonWidth,
                });

            controls.Add(
                new ControlButtonInfo
                {
                    Id = 2,
                    Caption = "Water",
                    Image = "D:\\Working\\Code\\Guide\\Icons\\Bathroom.jpeg",
                    Height = buttonHeight,
                    Width = buttonWidth,
                });

            controls.Add(
                new ControlButtonInfo
                {
                    Id = 2,
                    Caption = "Water",
                    Image = "D:\\Working\\Code\\Guide\\Icons\\Bathroom.jpeg",
                    Height = buttonHeight,
                    Width = buttonWidth,
                });
            controls.Add(
                new ControlButtonInfo
                {
                    Id = 2,
                    Caption = "2-2",
                    Image = "D:\\Working\\Code\\Guide\\Icons\\Bathroom.jpeg",
                    Height = buttonHeight,
                    Width = buttonWidth,
                });

            controls.Add(
                new ControlButtonInfo
                {
                    Id = 2,
                    Caption = "2-3",
                    Image = "D:\\Working\\Code\\Guide\\Icons\\Bathroom.jpeg",
                    Height = buttonHeight,
                    Width = buttonWidth,
                });

            controls.Add(
                new ControlButtonInfo
                {
                    Id = 2,
                    Caption = "2-3",
                    Image = "D:\\Working\\Code\\Guide\\Icons\\Bathroom.jpeg",
                    Height = buttonHeight,
                    Width = buttonWidth,
                });


            controls.Add(
                new ControlButtonInfo
                {
                    Id = 2,
                    Caption = "2-3",
                    Image = "D:\\Working\\Code\\Guide\\Icons\\Bathroom.jpeg",
                    Height = buttonHeight,
                    Width = buttonWidth,
                });
            ControlFormation controlFormation = new ControlFormation(controls, this.Height, this.Width);
            List<Button> items = controlFormation.CreateControls();

            foreach(var item in items)
            {
                item.Left =  (currentCol - 1) * (item.Width + HorizontolGap);
                item.Top = (currentRow - 1) * (item.Height + VerticleGap);
                item.Parent = this;
                item.Visible = true;

                
                if (currentCol >= MaxCols)
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