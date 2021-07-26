using SoccerBet.Controls;
using SoccerBet.Models;
using SoccerBet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Data.SqlClient;
using System.Data;
using System.Threading;

namespace SoccerBet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public int progress = 0;
        public Login()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }

        public async void ButtonClickedLogin(object sender, EventArgs e)
        {
            if (nick.Text != null && pass.Text != null)
            {
                if (nick.Text.Replace(" ", "").ToLower() != "" && pass.Text.Replace(" ", "").ToLower() != "")
                {
                    DatabaseUser dbu = new DatabaseUser();
                    Utente us = new Utente();
                    us.Nome = nick.Text.Replace(" ", "").ToLower();
                    us.Password = pass.Text.Replace(" ", "").ToLower();
                    if (check.IsChecked == true)
                    {
                        us.Mantain = 1;
                        await dbu.setMantainUserDisable();
                    }
                    else
                    {
                        us.Mantain = 0;
                    }

                    int enter = await dbu.existUser(us);


                    if (enter > 0)
                    {
                        await dbu.updateUserMantain(us.Nome, us.Mantain);
                        Preferences.Set("Nome", us.Nome);
                        Application.Current.MainPage = new Menu();
                    }
                    else
                    {
                        await DisplayAlert("Errore", "Username o password non validi!", "OK");
                        nick.Text = "";
                        pass.Text = "";
                    }
                }
                else
                {
                    await DisplayAlert("Errore", "Inserire un Username e una password validi", "OK");
                    nick.Text = "";
                    pass.Text = "";
                }
            }
            else
            {
                await DisplayAlert("Errore", "Inserire un Username e una password validi", "OK");
                nick.Text = "";
                pass.Text = "";
            }

        }

        public async void ButtonClickedSignin(object sender, EventArgs e)
        {
            progressBar.IsVisible = true;
            progressBar.SetProgress(progress, 0, Easing.SinIn);
            bool popola = false;
            if (nick.Text != null && pass.Text != null)
            {
                if (nick.Text.Replace(" ", "").ToLower() != "" && pass.Text.Replace(" ", "").ToLower() != "")
                {
                    Utente us = new Utente();
                    us.Nome = nick.Text.Replace(" ", "").ToLower();
                    us.Password = pass.Text.Replace(" ", "").ToLower();
                    if (check.IsChecked == true)
                    {
                        us.Mantain = 1;
                    }
                    else
                    {
                        us.Mantain = 0;
                    }

                    bool inserimento = await enterUser(us);

                    if (inserimento)
                    {
                        DatabaseUser dbu = new DatabaseUser(); await dbu.CreateTableUser();
                        await dbu.InsUser(us);
                        Preferences.Set("Nome", us.Nome);
                        popola = await popolaDb();


                        progress++;
                        if (progress > 100)
                            progress = 100;
                        progressBar.SetProgress(progress, 20, Easing.SpringIn);

                        Application.Current.MainPage = new Menu();
                    }
                    else
                    {
                        progressBar.IsVisible = false;
                        progressBar.SetProgress(0, 0, Easing.SpringIn);
                        await DisplayAlert("Errore", "NickName già scelto!", "OK");
                        nick.Text = "";
                        pass.Text = "";
                    }
                }
                else
                {
                    progressBar.IsVisible = false;
                    progressBar.SetProgress(0, 0, Easing.SinIn);
                    await DisplayAlert("Errore", "Inserire un NickName valido", "OK");
                    nick.Text = "";
                    pass.Text = "";
                }
            }
            else
            {
                progressBar.IsVisible = false;
                progressBar.SetProgress(0, 0, Easing.SinIn);
                await DisplayAlert("Errore", "Inserire un NickName valido", "OK");
                nick.Text = "";
                pass.Text = "";
            }

        }
        public async Task<bool> popolaDb()
        {
            await popolaDbCountries();
            //await popolaDbLeague();
            return true;
        }

        public async Task<bool> enterUser(Utente u)
        {
            DatabaseUser dbu = new DatabaseUser();
            SqlConnection connection;
            string connectionString;
            connectionString = @"Data Source=pinexp.ns0.it\MIOSERVER,65004;" + "Initial Catalog=Soccer;" + @"User id=sa;" + "Password=Pinexp93;";
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    string query = "SELECT Count(*) FROM Utente WHERE Nome =  '" + u.Nome + "' AND Password = '" + u.Password + "'";
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int exist = reader.GetInt32(0);
                            reader.Close();

                            if (exist == 0)
                            {
                                command = new SqlCommand("INSERT INTO Utente (Nome,Password,Saldo,AddressIp) values (@Nome, @Password, @Saldo, @AddressIp)", connection);
                                command.Parameters.AddWithValue("@Nome", u.Nome);
                                command.Parameters.AddWithValue("@Password", u.Password);
                                command.Parameters.AddWithValue("@Saldo", 100);
                                command.Parameters.AddWithValue("@AddressIp", u.Ip);

                                command.ExecuteNonQuery();

                                if (dbu.TableExist("Utente"))
                                {
                                    await dbu.InsUser(u);
                                    return true;
                                }
                                else
                                {

                                    await dbu.CreateTableUser();
                                    await dbu.InsUser(u);
                                    progress++;
                                    if (progress > 100)
                                          progress = 100;
                                    progressBar.SetProgress(progress, 0, Easing.SpringIn);


                                    return true;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    connection.Close();
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task popolaDbCountries()
        {
            DatabasePaesi dbc = new DatabasePaesi();

            if (!dbc.TableExist("Paese"))
            {
                await dbc.CreateTablePaese();
            }
            else
            {
                await dbc.DropTablePaese();
                await dbc.CreateTablePaese();
            }

            Paese paese = new Paese();

            SqlConnection connection;
            string connectionString;
            connectionString = @"Data Source=pinexp.ns0.it\MIOSERVER,65004;" + "Initial Catalog=Soccer;" + @"User id=sa;" + "Password=Pinexp93;";
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    string query = "SELECT Id, Nome, LinkImage, Valida FROM Paese WHERE Valida = 1";
                    SqlCommand command = new SqlCommand(query, connection);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            paese = new Paese();
                            paese.Id = reader.GetInt32(0);
                            paese.Nome = reader.GetString(1);
                            paese.LinkImage = reader.GetString(2);
                            paese.Valido = reader.GetInt32(3);
                            paese.Preferito = 0;

                            await dbc.InsPaese(paese);

                            progress++;
                            if (progress > 100)
                                progress = 100;
                            progressBar.SetProgress(progress, 0, Easing.SinIn);

                        }
                        Thread.Sleep(1000);

                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}