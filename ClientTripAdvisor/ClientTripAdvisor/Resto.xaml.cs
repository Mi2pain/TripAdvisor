using ClientTripAdvisor.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ClientTripAdvisor
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string urlAPI = "http://localhost:2729/api/";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAPI + "Restaurant");

           if(comboBox.SelectedIndex == 1)
                // XML
            {
                request.Accept = "application/xml";
            }
            else
            //JSON
            {
                request.Accept = "application/json";
            }
            // Set some reasonable limits on resources used by this request 
            request.MaximumAutomaticRedirections = 4;
            request.MaximumResponseHeadersLength = 4;
            // Set credentials to use for this request. 
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Get the stream associated with the response. 
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format.  
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            textBox.Clear();
            textBox.AppendText(readStream.ReadToEnd());

            response.Close();
            readStream.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();


            if (comboBox.SelectedIndex == 1)
            // XML
            {
                StringReader sr = new StringReader(textBox.Text.ToString());
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dt = ds.Tables[0];
            }
            else
            //JSON
            {
                dt = JsonConvert.DeserializeObject<DataTable>(textBox.Text.ToString(), new DataTableConverter());
            }

            this.dataGrid.DataContext = dt.DefaultView;
            this.Id_ComboBox.DataContext = dt.DefaultView;
        }

        private void Id_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Afficher_Click(object sender, RoutedEventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAPI + "Restaurant/" + Id_ComboBox.Text);
            
                request.Accept = "application/json";
            
            // Set some reasonable limits on resources used by this request 
            request.MaximumAutomaticRedirections = 4;
            request.MaximumResponseHeadersLength = 4;
            // Set credentials to use for this request. 
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Get the stream associated with the response. 
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format.  
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            Restaurant reponse = JsonConvert.DeserializeObject<Restaurant>(readStream.ReadToEnd());

            if(reponse.PRX_PRIX != null)
            {
                Prix_TextBox.Clear();
                Prix_TextBox.AppendText(reponse.PRX_PRIX);
            }

            if(reponse.RES_NOM != null)
            {
                Nom_TextBox.Clear();
                Nom_TextBox.AppendText(reponse.RES_NOM);
            }

            if (reponse.RES_CATEGORIEPRIX != null)
            {
                Cat_TextBox.Clear();
                Cat_TextBox.AppendText(reponse.RES_CATEGORIEPRIX);
            }

            if (reponse.RES_DESCRIPTION != null)
            {
                Description_TextBox.Clear();
                Description_TextBox.AppendText(reponse.RES_DESCRIPTION);
            }

            if (reponse.res_adr != null)
            {
                Adresse_TextBox.Clear();
                Adresse_TextBox.AppendText(reponse.res_adr);
            }

            if (reponse.RES_CP != null)
            {
                CP_TextBox.Clear();
                CP_TextBox.AppendText(reponse.RES_CP);
            }

            if (reponse.RES_VILLE != null)
            {
                Ville_TextBox.Clear();
                Ville_TextBox.AppendText(reponse.RES_VILLE);
            }

            if (reponse.RES_PAYS != null)
            {
                Pays_TextBox.Clear();
                Pays_TextBox.AppendText(reponse.RES_PAYS);
            }

            if (reponse.RES_TEL != null)
            {
                Tel_TextBox.Clear();
                Tel_TextBox.AppendText(reponse.RES_TEL);
            }

            if (reponse.RES_MEL != null)
            {
                Mail_TextBox.Clear();
                Mail_TextBox.AppendText(reponse.RES_MEL);
            }

            if (reponse.RES_SITEWEB != null)
            {
                Web_TextBox.Clear();
                Web_TextBox.AppendText(reponse.RES_SITEWEB);
            }

            response.Close();
            readStream.Close();
        }

        private async void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            Restaurant postResto = new Restaurant();

            postResto.RES_NOM = Nom_TextBox_Copy.Text;
            postResto.RES_MEL = Mail_TextBox_Copy.Text;
            postResto.RES_PAYS = Pays_TextBox_Copy.Text;
            postResto.RES_TEL = Tel_TextBox_Copy.Text;
            postResto.RES_CP = CP_TextBox_Copy.Text;
            postResto.RES_CATEGORIEPRIX = Cat_TextBox_Copy.Text;
            postResto.RES_DESCRIPTION = Description_TextBox_Copy.Text;
            postResto.PRX_PRIX = comboBox1.Text;
            postResto.RES_VILLE = Ville_TextBox_Copy.Text;
            postResto.RES_SITEWEB = Web_TextBox_Copy.Text;
            postResto.res_adr = Adresse_TextBox_Copy.Text;

            var json = JsonConvert.SerializeObject(postResto);


            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {

                // Do the actual request and await the response
                var httpResponse = await httpClient.PostAsync(urlAPI + "Restaurant/", httpContent);

                // If the response contains content we want to read it!
                if (httpResponse.Content != null)
                {
                    var responseContent = await httpResponse.Content.ReadAsStringAsync();

                    // From here on you could deserialize the ResponseContent back again to a concrete C# type using Json.Net
                }
            }
        }
    }
}
