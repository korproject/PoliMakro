using System;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;
using Poli.Makro.Core.Controllers;
using Poli.Makro.Core.Database;
using Poli.Makro.Core.Helpers.String;
using Poli.Makro.Core.Json.Login1;
using Poli.Makro.Core.Json.Login2;
using Poli.Makro.Core.ViewModel.Base;
using RestSharp;

namespace Poli.Makro.Core.ViewModel.LogRegRem
{
    public class Login : BaseViewModel
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Login()
        {
            ShowHideLoginInputs(true, false);

            // check username
            CheckUsernameCom = new RelayParameterizedCommand(async (parameter) => await CheckUsername(parameter));
            // login
            LoginCom = new RelayParameterizedCommand(async (parameter) => await LoginP(parameter));
            // login as text
            LoginComText = new RelayParameterizedCommand(async (parameter) => await LoginT(parameter));

            BacktoUsername = new RelayCommand(BackyoUsernameArea);

			OpenRegisterPageComm = new RelayCommand(OpenRegisterPage);
			OpenForgotPageComm = new RelayCommand(OpenForgotPage);

		}

        /// <summary>
        /// Operations status and short info shows
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// User ID
        /// </summary>
        private string Userid { get; set; }


        #region Username Area
        
        /// <summary>
        /// Username loader arc visibility
        /// </summary>
        public Visibility UsernameLoaderVisibility { get; set; }

        /// <summary>
        /// Username area visibility
        /// </summary>
        public Visibility UsernameVisibility { get; set; }

        /// <summary>
        /// Username area is enabled status
        /// </summary>
        public bool UsernameIsEnabled { get; set; }

        /// <summary>
        /// Username is focused state
        /// </summary>
        public bool UsernameIsFocused { get; set; }

        #endregion

        #region Password Area

        /// <summary>
        /// Password loader arc visibility
        /// </summary>
        public Visibility PasswordLoaderVisibility { get; set; }

        /// <summary>
        /// Password area visiblity
        /// </summary>
        public Visibility PasswordVisibility { get; set; }

        /// <summary>
        /// Password area is enabled status
        /// </summary>
        public bool PasswordIsEnabled { get; set; }

        /// <summary>
        /// PasswodBox is focused state
        /// </summary>
        public bool PasswordBoxIsFocused { get; set; }

        #endregion

        #region for Requests

        /// <summary>
        /// Response Http Status Code
        /// </summary>
        public static HttpStatusCode ResponseStatus { get; set; }

        /// <summary>
        /// Response data from API request
        /// </summary>
        public static string ResponseData { get; set; }

        #endregion


        #region Username Check
        /// <summary>
        /// Username Check Command
        /// </summary>
        public ICommand CheckUsernameCom { get; set; }

        /// <summary>
        /// JSON deseialized response data
        /// </summary>
        public static RootobjectforUsername RespDataJsonObjforUsernameCheck { get; set; }

        public async Task CheckUsername(object parameter)
        {
            try
            {
                Status = "";

                var username = parameter as string;
                if (string.IsNullOrEmpty(username))
                {
                    Status = "Kullanıcı Adı boş olmamalıdır.";
                    return;
                }

                var regex = new Regex(@"^[0-9A-Za-z]{4,24}$");
                var match = regex.Match(username ?? "?");
                if (!match.Success)
                {
                    Status = "Kullanıcı Adı şu kurala uymalıdır: [0-9A-Za-z]{4,24}";
                    return;
                }

                UsernameLoaderVisibility = Visibility.Visible;

                if (InternetController.InternetCheck())
                {
                    // request host
                    var client = new RestClient("http://api.kor.onl/");
                    // request relative url
                    var request = new RestRequest("apps/kor/login.php", Method.POST);

                    // add important parameters
                    request.AddOrUpdateParameter("type", "json");
                    request.AddOrUpdateParameter("request", "primary_credential");
                    request.AddOrUpdateParameter("primary_credential", (string) parameter);

                    // get query result
                    var response = client.Execute(request);

                    ResponseStatus = response.StatusCode;

                    if (!string.IsNullOrEmpty(response.Content))
                    {
                        Debug.WriteLine(response.Content);

                        var settings = new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore,
                            MissingMemberHandling = MissingMemberHandling.Ignore,
                            PreserveReferencesHandling = PreserveReferencesHandling.Objects
                        };

                        RespDataJsonObjforUsernameCheck = JsonConvert.DeserializeObject<RootobjectforUsername>(response.Content, settings);

                        if (RespDataJsonObjforUsernameCheck.code == 1 && RespDataJsonObjforUsernameCheck.result != null)
                        {
                            Userid = RespDataJsonObjforUsernameCheck.result.userid;

                            await Task.Delay(1000);

                            ShowHideLoginInputs(false, true);
                        }
                        else
                        {
                            if (RespDataJsonObjforUsernameCheck.messages.error)
                            {
                                Status = RespDataJsonObjforUsernameCheck.messages.error_message;
                            }
                            else if (RespDataJsonObjforUsernameCheck.messages.warning)
                            {
                                Status = RespDataJsonObjforUsernameCheck.messages.warning_message;
                            }
                        }
                    }
                    else
                    {
                        Status = "Sunucu yanıt verdi ancak veri döndürmedi. İstek eksik veya sunucuda bir sorun var. Tekrar deneyin.";
                    }
                }
                else
                {
                    Status = "İnternet bağlantısı yok, sunucuya bağlanılamadı.";
                }

                await Task.Delay(1000);
                UsernameLoaderVisibility = Visibility.Hidden;
            }
            catch (Exception exp)
            {
                UsernameLoaderVisibility = Visibility.Hidden;

                Debug.WriteLine(exp.ToString());
                // save error record
            }
        }

        #endregion

        #region Login Process

        public event EventHandler OnRequestClose;

        /// <summary>
        /// Login Command
        /// </summary>
        public ICommand LoginCom { get; set; }

        /// <summary>
        /// JSON deseialized response data
        /// </summary>
        public RootobjectforLogin LoginJsonObj { get; set; }

        public async Task LoginP(object parameter)
        {
            try
            {
                Status = "";


                var passwordBox = parameter as PasswordBox;
                var password = passwordBox?.Password;

                var regex = new Regex(@"^(?=.{2,}[A-Z])(?=.{2,}[a-z])(?=.{2,}[0-9])(?=.{2,}[\w\s]).{8,128}$");
                var match = regex.Match(password ?? "?");
                if (string.IsNullOrEmpty(password))
                {
                    Status = "Şifre boş olmamalıdır.";
                    return;
                }
                if (!match.Success)
                {
                    Status = "Şifre şu kurala uymalıdır: [A-Z][a-z][0-9][Özel Karakterler]{8,128} (Her birinden en az 2 tane olmalı.)";
                    return;
                }

                PasswordLoaderVisibility = Visibility.Visible;

                if (InternetController.InternetCheck())
                {
                    // request host
                    var client = new RestClient("http://api.kor.onl/");
                    // request relative url
                    var request = new RestRequest("apps/kor/login.php", Method.POST);

                    // add important parameters
                    request.AddOrUpdateParameter("type", "json");
					request.AddOrUpdateParameter("request", "login");
					request.AddOrUpdateParameter("primary_credential", Userid);
                    request.AddOrUpdateParameter("password", password);

                    passwordBox = null;
                    password = null;


                    // get query result
                    var response = client.Execute(request);

                    ResponseStatus = response.StatusCode;

                    if (!string.IsNullOrEmpty(response.Content))
                    {
                        Debug.WriteLine(response.Content);

                        var settings = new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore,
                            MissingMemberHandling = MissingMemberHandling.Ignore,
                            PreserveReferencesHandling = PreserveReferencesHandling.Objects
                        };

                        LoginJsonObj = JsonConvert.DeserializeObject<RootobjectforLogin>(response.Content, settings);

						if (LoginJsonObj.code == 1 && LoginJsonObj.result.token != null)
						{
							if (User.SaveUserToken(LoginJsonObj.result.userid, LoginJsonObj.result.username, LoginJsonObj.result.token, LoginJsonObj.result.expire, LoginJsonObj.result.user_image))
							{
								await Task.Delay(1000);

                                ShowHideLoginInputs(false, false);

                                Close();
                            }
                            else
                            {
                                Status = "Login failed, could not save user credentials or update. Retry to login.";
                            }
                        }
                        else
                        {
                            if (LoginJsonObj.messages.error)
                            {
                                Status = LoginJsonObj.messages.error_message;
                            }
                            else if (LoginJsonObj.messages.warning)
                            {
                                Status = LoginJsonObj.messages.warning_message;
                            }
                        }
                    }
                    else
                    {
                        Status = "Sunucu yanıt verdi ancak veri döndürmedi. İstek eksik veya sunucuda bir sorun var. Tekrar deneyin.";
                    }
                }
                else
                {
                    Status = "İnternet bağlantısı yok, sunucuya bağlanılamadı.";
                }

                await Task.Delay(1000);
                PasswordLoaderVisibility = Visibility.Hidden;
            }
            catch (Exception exp)
            {
                PasswordLoaderVisibility = Visibility.Hidden;

                Debug.WriteLine(exp.ToString());
                // save error record
            }
        }

        /// <summary>
        /// Login Command for textbox form
        /// </summary>
        public ICommand LoginComText { get; set; }

        public async Task LoginT(object parameter)
        {
            try
            {
                Status = "";

                var password = parameter as string;

                var regex = new Regex(@"^(?=.{2,}[A-Z])(?=.{2,}[a-z])(?=.{2,}[0-9])(?=.{2,}[\w\s]).{8,128}$");
                var match = regex.Match(password ?? "?");
                if (string.IsNullOrEmpty(password))
                {
                    Status = "Şifre boş olmamalıdır.";
                    return;
                }
                if (!match.Success)
                {
                    Status = "Şifre şu kurala uymalıdır: [A-Z][a-z][0-9][Özel Karakterler]{8,128} (Her birinden en az 2 tane olmalı.)";
                    return;
                }

                PasswordLoaderVisibility = Visibility.Visible;

                if (InternetController.InternetCheck())
                {
					// request host
					var client = new RestClient("http://api.kor.onl/");
					// request relative url
					var request = new RestRequest("apps/kor/login.php", Method.POST);

					// add important parameters
					request.AddOrUpdateParameter("type", "json");
					request.AddOrUpdateParameter("request", "login");
					request.AddOrUpdateParameter("primary_credential", Userid);
					request.AddOrUpdateParameter("password", password);

					password = null;


                    // get query result
                    var response = client.Execute(request);

                    ResponseStatus = response.StatusCode;

                    if (!string.IsNullOrEmpty(response.Content))
                    {
                        Debug.WriteLine(response.Content);

                        var settings = new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore,
                            MissingMemberHandling = MissingMemberHandling.Ignore,
                            PreserveReferencesHandling = PreserveReferencesHandling.Objects
                        };

                        LoginJsonObj = JsonConvert.DeserializeObject<RootobjectforLogin>(response.Content, settings);

                        if (LoginJsonObj.code == 1 && LoginJsonObj.result.token != null)
                        {
                            if (User.SaveUserToken(LoginJsonObj.result.userid, LoginJsonObj.result.username, LoginJsonObj.result.token, LoginJsonObj.result.expire, LoginJsonObj.result.user_image))
                            {
                                await Task.Delay(1000);

                                ShowHideLoginInputs(false, false);

                                Close();
                            }
                            else
                            {
                                Status = "Login failed, could not save user credentials or update. Retry to login.";
                            }
                        }
                        else
                        {
                            if (LoginJsonObj.messages.error)
                            {
                                Status = LoginJsonObj.messages.error_message;
                            }
                            else if (LoginJsonObj.messages.warning)
                            {
                                Status = LoginJsonObj.messages.warning_message;
                            }
                        }
                    }
                    else
                    {
                        Status = "Sunucu yanıt verdi ancak veri döndürmedi. İstek eksik veya sunucuda bir sorun var. Tekrar deneyin.";
                    }
                }
                else
                {
                    Status = "İnternet bağlantısı yok, sunucuya bağlanılamadı.";
                }

                await Task.Delay(1000);
                PasswordLoaderVisibility = Visibility.Hidden;
            }
            catch (Exception exp)
            {
                PasswordLoaderVisibility = Visibility.Hidden;

                Debug.WriteLine(exp.ToString());
                // save error record
            }
        }

        #endregion

        #region Return to Username

        /// <summary>
        /// Back to Username
        /// </summary>
        public ICommand BacktoUsername { get; set; }

        public void BackyoUsernameArea()
        {
            ShowHideLoginInputs(true, false);
        }

        #endregion

		public ICommand OpenRegisterPageComm { get; set; }

		public void OpenRegisterPage()
		{
			Process.Start("https://kor.onl/register");
		}

		public ICommand OpenForgotPageComm { get; set; }

		public void OpenForgotPage()
		{
			Process.Start("https://kor.onl/forgot");
		}


		public void ShowHideLoginInputs(bool username, bool password)
        {
            UsernameLoaderVisibility = Visibility.Hidden;
            PasswordLoaderVisibility = Visibility.Hidden;

            if (username)
            {
                UsernameVisibility = Visibility.Visible;
                UsernameIsEnabled = true;
                UsernameIsFocused = true;
            }
            else
            {
                UsernameVisibility = Visibility.Hidden;
                UsernameIsEnabled = false;
                UsernameIsFocused = false;
            }


            if (password)
            {
                PasswordVisibility = Visibility.Visible;
                PasswordIsEnabled = true;
                PasswordBoxIsFocused = true;

            }
            else
            {
                PasswordVisibility = Visibility.Hidden;
                PasswordIsEnabled = false;
                PasswordBoxIsFocused = false;
            }

            Status = "";
        }

        private void Close()
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this) item.Close();
            }
        }
    }
}
