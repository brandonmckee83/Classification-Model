using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using SoundExample;
using System.Text;

namespace ClassificationModel
{
    public partial class Main : System.Web.UI.Page
    {
        // declare variables for total number within a quality, per instrument family
        int Ttl_Bass_Count, Ttl_Brass_Count, Ttl_Flute_Count, Ttl_Guitar_Count,
            Ttl_Keyboard_Count, Ttl_Mallet_Count, Ttl_Organ_Count, Ttl_Reed_Count,
            Ttl_String_Count, Ttl_Synth_Count, Ttl_Vocal_Count = 0;

        // declare variables for total value of each family instrument based on the qualities
        decimal Ttl_Bass_Val, Ttl_Brass_Val, Ttl_Flute_Val, Ttl_Guitar_Val,
            Ttl_Keyboard_Val, Ttl_Mallet_Val, Ttl_Organ_Val, Ttl_Reed_Val,
            Ttl_String_Val, Ttl_Synth_Val, Ttl_Vocal_Val = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            int total_length; // value to use for identifying the total sample quantity

            // create an array that will 
            Dictionary<string, string> ComputationalArray = new Dictionary<string, string>();

            // load the training data for the model
            var trainingdata = LoadTrainingData();

            // assign the total in the dictionary to a variable, to be used later
            total_length = trainingdata.Count();

            //Declare the string builder object to store the data that will be displayed in browser
            StringBuilder sb = new StringBuilder();

            // We must loop through the dictionary once, obtain our numerical data, before we loop and spit out some output
            foreach (KeyValuePair<string, Sound> ComputationData in trainingdata)
            {
                Sound value = ComputationData.Value;
                switch (value.InstrumentFamilyStr.ToString())
                {
                    case "Bass":
                        Ttl_Bass_Count += 1;
                        decimal Bass_Counter = 1;
                        foreach (long q in value.Qualities)
                        {
                            if (q.ToString() == "1") { Ttl_Bass_Val = Ttl_Bass_Val + (Bass_Counter / 10); }
                            Bass_Counter += 1;
                        }
                        break;
                    case "Brass":
                        Ttl_Brass_Count += 1;
                        decimal Brass_Counter = 1;
                        foreach (long q in value.Qualities)
                        {
                            if (q.ToString() == "1") { Ttl_Brass_Val = Ttl_Brass_Val + (Brass_Counter / 10); }
                            Brass_Counter += 1;
                        }
                        break;
                    case "Flute":
                        Ttl_Flute_Count += 1;
                        decimal Flute_Counter = 1;
                        foreach (long q in value.Qualities)
                        {
                            if (q.ToString() == "1") { Ttl_Flute_Val = Ttl_Flute_Val + (Flute_Counter / 10); }
                            Flute_Counter += 1;
                        }
                        break;
                    case "Guitar":
                        Ttl_Guitar_Count += 1;
                        decimal Guitar_Counter = 1;
                        foreach (long q in value.Qualities)
                        {
                            if (q.ToString() == "1") { Ttl_Guitar_Val = Ttl_Guitar_Val + (Guitar_Counter / 10); }
                            Guitar_Counter += 1;
                        }
                        break;
                    case "Keyboard":
                        Ttl_Keyboard_Count += 1;
                        decimal Keyboard_Counter = 1;
                        foreach (long q in value.Qualities)
                        {
                            if (q.ToString() == "1") { Ttl_Keyboard_Val = Ttl_Keyboard_Val + (Keyboard_Counter / 10); }
                            Keyboard_Counter += 1;
                        }
                        break;
                    case "Mallet":
                        Ttl_Mallet_Count += 1;
                        decimal Mallet_Counter = 1;
                        foreach (long q in value.Qualities)
                        {
                            if (q.ToString() == "1") { Ttl_Mallet_Val = Ttl_Mallet_Val + (Mallet_Counter / 10); }
                            Mallet_Counter += 1;
                        }
                        break;
                    case "Organ":
                        Ttl_Organ_Count += 1;
                        decimal Organ_Counter = 1;
                        foreach (long q in value.Qualities)
                        {
                            if (q.ToString() == "1") { Ttl_Organ_Val = Ttl_Organ_Val + (Organ_Counter / 10); }
                            Organ_Counter += 1;
                        }
                        break;
                    case "Reed":
                        Ttl_Reed_Count += 1;
                        decimal Reed_Counter = 1;
                        foreach (long q in value.Qualities)
                        {
                            if (q.ToString() == "1") { Ttl_Reed_Val = Ttl_Reed_Val + (Reed_Counter / 10); }
                            Reed_Counter += 1;
                        }
                        break;
                    case "String":
                        Ttl_String_Count += 1;
                        decimal String_Counter = 1;
                        foreach (long q in value.Qualities)
                        {
                            if (q.ToString() == "1") { Ttl_String_Val = Ttl_String_Val + (String_Counter / 10); }
                            String_Counter += 1;
                        }
                        break;
                    case "Synth Lead":
                        Ttl_Synth_Count += 1;
                        decimal Synth_Counter = 1;
                        foreach (long q in value.Qualities)
                        {
                            if (q.ToString() == "1") { Ttl_Synth_Val = Ttl_Synth_Val + (Synth_Counter / 10); }
                            Synth_Counter += 1;
                        }
                        break;
                    case "Vocal":
                        Ttl_Vocal_Count += 1;
                        decimal Vocal_Counter = 1;
                        foreach (long q in value.Qualities)
                        {
                            if (q.ToString() == "1") { Ttl_Vocal_Val = Ttl_Vocal_Val + (Vocal_Counter / 10); }
                            Vocal_Counter += 1;
                        }
                        break;
                }
            }

            // line break twice, just for spacing
            sb.Append("<br /><br />");

            // append describer
            sb.Append("Qualities: bright | dark | distortion | fast_decay | long_release | multiphonic | nonlinear_env | percussive | reverb | temp-synced | --> Instrument Classification");

            // line break twice, just for spacing
            sb.Append("<br /><br />");

            // identify each family average
            decimal bass_avg = Ttl_Bass_Val / (Ttl_Bass_Count + 1);
            decimal brass_avg = Ttl_Brass_Val / (Ttl_Brass_Count + 1);
            decimal flute_avg = Ttl_Flute_Val / (Ttl_Flute_Count + 1);
            decimal guitar_avg = Ttl_Guitar_Val / (Ttl_Guitar_Count + 1);
            decimal keyboard_avg = Ttl_Keyboard_Val / (Ttl_Keyboard_Count + 1);
            decimal mallet_avg = Ttl_Mallet_Val / (Ttl_Mallet_Count + 1);
            decimal organ_avg = Ttl_Organ_Val / (Ttl_Organ_Count + 1);
            decimal reed_avg = Ttl_Reed_Val / (Ttl_Reed_Count + 1);
            decimal string_avg = Ttl_String_Val / (Ttl_String_Count + 1);
            decimal synth_avg = Ttl_Synth_Val / (Ttl_Synth_Count + 1);
            decimal vocal_avg = Ttl_Vocal_Val / (Ttl_Vocal_Count + 1);

            // Add the averages to an array
            decimal[] avgs = new decimal[11];
            avgs[0] = bass_avg;
            avgs[1] = brass_avg;
            avgs[2] = flute_avg;
            avgs[3] = guitar_avg;
            avgs[4] = keyboard_avg;
            avgs[5] = mallet_avg;
            avgs[6] = organ_avg;
            avgs[7] = reed_avg;
            avgs[8] = string_avg;
            avgs[9] = synth_avg;
            avgs[10] = vocal_avg;

            // loop through the JSON object, obtain the values and output them
            foreach (KeyValuePair<string, Sound> OutputData in trainingdata)
            {
                // instantiate into sound object, add to key variables, and print line
                Sound test = OutputData.Value;

                // decalre variable to identify current record val
                decimal current_val = 0;

                // declare the counter that will be used to iterate through the qualities array
                decimal q_counter = 1;

                // Get the value of the current record, based on how we are valuating it
                foreach (long q in test.Qualities)
                {
                    if (q.ToString() == "1")
                    { current_val += q_counter / 10; }
                    q_counter += 1;
                }

                // now we need to compare this value to our built array of averages
                var nearest = avgs.OrderBy(x => Math.Abs((long)x - current_val)).First();

                // now that we have a match, we need to use if statements to identify the family label we will apply
                // (this isn't very elegant - I apologize!)
                string family = "";

                if (nearest == avgs[0]) { family = "Bass"; }
                if (nearest == avgs[1]) { family = "Brass"; }
                if (nearest == avgs[2]) { family = "Flute"; }
                if (nearest == avgs[3]) { family = "Guitar"; }
                if (nearest == avgs[4]) { family = "Keyboard"; }
                if (nearest == avgs[5]) { family = "Mallet"; }
                if (nearest == avgs[6]) { family = "Organ"; }
                if (nearest == avgs[7]) { family = "Reed"; }
                if (nearest == avgs[8]) { family = "String"; }
                if (nearest == avgs[9]) { family = "Synth Lead"; }
                if (nearest == avgs[10]) { family = "Vocal"; }


                sb.Append(test.Qualities[0].ToString() + " | " +
                    test.Qualities[1].ToString() + " | " +
                    test.Qualities[2].ToString() + " | " +
                    test.Qualities[3].ToString() + " | " +
                    test.Qualities[4].ToString() + " | " +
                    test.Qualities[5].ToString() + " | " +
                    test.Qualities[6].ToString() + " | " +
                    test.Qualities[7].ToString() + " | " +
                    test.Qualities[8].ToString() + " | " +
                    test.Qualities[9].ToString() + " | " + 
                    test.InstrumentFamilyStr.ToString());  // the formula was inaccurate, needs correction
                sb.Append("<br />");
            }

            // once everything has been added to the string builder, let's throw it onto the page
            lblContent.Text = sb.ToString();
        }

        public static Dictionary<string, Sound> LoadTrainingData(string path = null)
        {
            // object declarations
            Dictionary<string, Sound> exampleset = new Dictionary<string, Sound>();

            string appPath = Path.GetDirectoryName(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);

            if (path == null) { path = System.Web.Hosting.HostingEnvironment.MapPath(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath + "/Files/examples.json"); } 

            if (!File.Exists(path)) throw new FileNotFoundException("Cannot locate the data file:\n   \"" + path + "\"\nPlease check the path and try again.");
            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string jsonstring = r.ReadToEnd();
                    exampleset = Sound.FromJson(jsonstring);
                }
                    
            }
            catch (Exception ex)
            {
                throw new FileLoadException("Unable to read the JSON data.\nThe file \"" + path + "\" does not load correctly.", ex);
            }

            return exampleset;   

        }
    }
}