using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.CognitoIdentity;
using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.Extensions.CognitoAuthentication;

namespace WindowsFormsApp2 {
    public partial class Form2 : Form {
        public Form2() {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e) {

        }
        //set up identities for awsCognito and get access token, not i dont use the access token with federated identities because its a headache and took me over 8 hours to fail at figureing out

        const string PoolID = "us-east-1_4xw7ZGY9h";
        const string appClientID = "4g1sgqvg39se3o3t5n44kr095j";
        static Amazon.RegionEndpoint Region = Amazon.RegionEndpoint.USEast1;
        string accessToken = string.Empty;


        private async void GetLoginResponse(string Uname, string Passwd) {


            Amazon.CognitoIdentityProvider.AmazonCognitoIdentityProviderClient provider =
                        new Amazon.CognitoIdentityProvider.AmazonCognitoIdentityProviderClient
                                                                           (new Amazon.Runtime.AnonymousAWSCredentials(), Region);

            CognitoUserPool userPool = new CognitoUserPool(PoolID, appClientID, provider);



            CognitoUser user = new CognitoUser(Uname, appClientID, userPool, provider);
            InitiateSrpAuthRequest authRequest = new InitiateSrpAuthRequest() {
                Password = Passwd
            };
            AuthFlowResponse authResponse = null;
            try {
                authResponse = await user.StartWithSrpAuthAsync(authRequest).ConfigureAwait(false);
                accessToken = authResponse.AuthenticationResult.AccessToken;

            } catch (Exception ex) {
                Console.WriteLine("error!" + ex.Message);
            }

            if (accessToken != string.Empty) {
                
                Console.WriteLine("login was successful with access token:  " + accessToken.ToString());
            }
        }

            private void button1_Click(object sender, EventArgs e) {
            //login
            string Uname = UserNameBox.Text;

            string Passwd = PasswordBox.Text;

            try {
                //if you can login show the form otherwise exception
                GetLoginResponse(Uname, Passwd);
                if (accessToken != string.Empty) { 
                Form1 mainProg = new Form1();
                mainProg.Show();
                    richTextBox1.Text = "user logged in, you should be redirected to the application shortly";


                }
            } catch (Exception ex) {
                richTextBox1.Text = "oof error! " + ex.Message;

            }

            
           
        }

        private void button2_Click(object sender, EventArgs e) {
            //register

            Amazon.CognitoIdentityProvider.AmazonCognitoIdentityProviderClient provider =
                new Amazon.CognitoIdentityProvider.AmazonCognitoIdentityProviderClient
                                                                   (new Amazon.Runtime.AnonymousAWSCredentials(), Region);
            string email = emailBox.Text;
            string Uname = UserNameBox.Text;
            string Passwd = PasswordBox.Text;

            Amazon.CognitoIdentityProvider.Model.SignUpRequest signUpRequest = new Amazon.CognitoIdentityProvider.Model.SignUpRequest() {
                ClientId = appClientID,
                Username = Uname,
                Password = Passwd
            };


            List<AttributeType> attributes = new List<AttributeType>() {
                new AttributeType(){Name = "email", Value = email}
            };

            signUpRequest.UserAttributes = attributes;

            try {
                SignUpResponse result = provider.SignUp(signUpRequest);
            } catch (Exception ex) {
                richTextBox1.Text = "oof error!" + ex.Message;
            }
            richTextBox1.Text = "user registered, please check your email for a verification link";

        }
    }
}
