using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech;
using System.Speech.Synthesis;

namespace Presenter
{
    internal class ControlFormation
    {
        private readonly List<ControlButtonInfo> info = null;
        private readonly int height;
        private readonly int width;

        private double singleButtonHeight;
        private double singleButtonWidth;
        public ControlFormation(List<ControlButtonInfo> info, int height, int width)
        {
            this.info = info ?? throw new ArgumentNullException(nameof(info));
            this.height = height;
            this.width = width;
        }

        
        public List<Button> CreateControls()
        {
            List<Button> buttons = new List<Button>();
            this.info.ForEach(x =>
            {
                buttons.Add(CreateControl(x));
            });
            return buttons;
        }

        private Button CreateControl(ControlButtonInfo info)
        {
            
            var button =  new Button();
            button.Name = info.Caption;
            button.Height = info.Height;
            button.Width = info.Width;
            button.BackgroundImage = Image.FromFile(info.Image);
            button.BackgroundImageLayout = ImageLayout.Stretch;
            button.Click += Button_Click;
            return button;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            
            
            Button button = (sender as Button);

            button.Text = "Playing";

            PromptBuilder promptBuilder = new PromptBuilder ( new System.Globalization.CultureInfo("en-US"));
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();
            synth.Speak(button.Name);
            synth.Speak(button.Name);
            synth.Dispose();

            button.Text = "";


        }

       
    }

    
    internal class ControlButtonInfo
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string Image { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }   
        public string PlayFile { get; set; }
    }


    public class Pest
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string Image { get; set; }
        
    }

    public class Configuration
    {
        public List<Pest> Pests { get; set; }
    }
}
