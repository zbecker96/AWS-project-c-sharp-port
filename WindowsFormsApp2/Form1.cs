using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using System.Windows.Forms;


namespace WindowsFormsApp2 {


    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }


        //get credentials from file 
        public String[] getCredentials() {
            String[] credentials = { "", "" };

            //set up astream reader
            StreamReader csvReader = new StreamReader(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "accessKeys.csv"));
            String data = csvReader.ReadLine();
            String[] splitData;
            
            data = csvReader.ReadLine();

            splitData = data.Split(',');

            credentials[0] = splitData[0];//0th pos is accesskey 1th secretkey
            credentials[1] = splitData[1];//0th pos is accesskey 1th secretkey

            return credentials;
        }
       
        //gets login credentials for aws and uses them to get labels on an image
        public void processFile(Amazon.Rekognition.Model.Image imageData) {

            String[] loginCreds = getCredentials();

            var credentials = new Amazon.Runtime.BasicAWSCredentials(loginCreds[0],loginCreds[1]);

            AmazonRekognitionClient rekognitionClient = new AmazonRekognitionClient(credentials, Amazon.RegionEndpoint.USEast2);

            DetectLabelsRequest detectlabelsRequest = new DetectLabelsRequest() {
                Image = imageData,
                MaxLabels = 10,
                MinConfidence = 77F
            };

            try {
                DetectLabelsResponse detectLabelsResponse = rekognitionClient.DetectLabels(detectlabelsRequest);

                //string builder to store labels
                StringBuilder labels = new StringBuilder();

                bool isHotdog = false;
                foreach (Amazon.Rekognition.Model.Label label in detectLabelsResponse.Labels) {
                    if (label.Name == "Hot Dog") { isHotdog = true; }

                    //adds all the labels to a string
                    labels.AppendFormat("{0}: {1} \n", label.Name, label.Confidence);

                }
                //test if it is a hot dog or not
                if (isHotdog) {
                    labels.Append("\n is a hotdog\n");
                } else {
                    labels.Append("\n is not a hotdog\n");
                }

                ResultsTextBox.Text = labels.ToString();


            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }



        Amazon.Rekognition.Model.Image imgData = new Amazon.Rekognition.Model.Image();

        private void ChooseFileButton_Click(object sender, EventArgs e) {

            //upon click load a new file
            OpenFileDialog newFile = new OpenFileDialog();

            if (newFile.ShowDialog() == DialogResult.OK) {
                //get the image bit map
                Bitmap imgBits = new Bitmap(newFile.FileName);
                pictureBox1.Image = imgBits;//set the picture box to the image
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                FilePathBox.Text = newFile.FileName;

                try {
                    using (FileStream fs = new FileStream(newFile.FileName, FileMode.Open, FileAccess.Read)) {
                        byte[] data = null;
                        data = new byte[fs.Length];
                        fs.Read(data, 0, (int)fs.Length);
                        imgData.Bytes = new MemoryStream(data);

                    }
                } catch (Exception) {
                    Console.WriteLine("Failed to load file " + newFile.FileName);
                    return;
                }
            }

            this.LabelButton.Visible = true;
            return;

        }

        private void LabelButton_Click(object sender, EventArgs e) {

            processFile(imgData);
        }

        private void pictureBox1_Click(object sender, EventArgs e) {

        }

        private void Form1_Load(object sender, EventArgs e) {

        }
    }
}
