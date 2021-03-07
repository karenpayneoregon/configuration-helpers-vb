Option Infer On

Imports System.IO
Imports Classes
Imports Newtonsoft.Json

Namespace Classes
	Public Class ProtoTypeConfiguration
		''' <summary>
		''' This class really belongs in another class project but to keep things
		''' simple it's in the same project.
		''' </summary>
		Public Shared Sub CreateJson()
			Dim data = New List(Of Settings) From {
				New Settings() With {
					.Environment = "Development",
					.ReloadApplicationOnEveryRequest = True,
					.Reload = "reload",
					.Password = True,
					.ConnectionString = "Data Source=DevServer;Initial Catalog=NorthWindAzure;Integrated Security=True",
					.DiConfiguration = New DiConfiguration() With {
						.Dsn = "ABC",
						.Globals = "globals",
						.Globals2 = "globals2",
						.MailTo = "karen.payne@someDomain.com;fred.smith@comcast.net;billAdams@gmail.com",
						.ExitLink = "",
						.BaseServerAddress = "ocs4",
						.UseGeoLocation = True,
						.MfLink = "Link 1",
						.MfPass = "Pass 1",
						.ResetPinLocation = "/pinchange/main/begin/",
						.UirTakeTest = False,
						.QryCacheLong = New TimeSpan(0, 0, 0, 5),
						.QryCacheShort = New TimeSpan(0, 0, 0, 10)
					}
				},
				New Settings() With {
					.Environment = "Test",
					.ReloadApplicationOnEveryRequest = False,
					.Reload = "reload",
					.Password = True,
					.ConnectionString = "Data Source=TestServer;Initial Catalog=NorthWindAzure;Integrated Security=True",
					.DiConfiguration = New DiConfiguration() With {
						.Dsn = "DEF",
						.Globals = "globals",
						.Globals2 = "globals2",
						.MailTo = "karen.payne@someDomain.com;fred.smith@comcast.net;billAdams@gmail.com",
						.ExitLink = "/ocs4/",
						.BaseServerAddress = "ocs4",
						.UseGeoLocation = True,
						.MfLink = "Link 2",
						.MfPass = "Pass 2",
						.ResetPinLocation = "/pinchange/main/begin/",
						.UirTakeTest = False,
						.QryCacheLong = New TimeSpan(0, 0, 1, 0),
						.QryCacheShort = New TimeSpan(0, 0, 10, 0)
					}
				},
				New Settings() With {
					.Environment = "Production",
					.ReloadApplicationOnEveryRequest = False,
					.Reload = "reload",
					.Password = True,
					.ConnectionString = "Data Source=ProdServer;Initial Catalog=NorthWindAzure;Integrated Security=True",
					.DiConfiguration = New DiConfiguration() With {
						.Dsn = "GHI",
						.Globals = "globals",
						.Globals2 = "globals2",
						.MailTo = "karen.payne@someDomain.com;fred.smith@comcast.net;billAdams@gmail.com",
						.ExitLink = "/ocs4/",
						.BaseServerAddress = "ocs4",
						.UseGeoLocation = True,
						.MfLink = "Link 3",
						.MfPass = "Pass 3",
						.ResetPinLocation = "/pinchange/main/begin/",
						.UirTakeTest = False,
						.QryCacheLong = New TimeSpan(0, 0, 30, 0),
						.QryCacheShort = New TimeSpan(0, 6, 0, 0)
					}
				}
			}

			Dim mainFileName = "appsettings.json"

			Dim json As String = JsonConvert.SerializeObject(data, Formatting.Indented,
				New JsonSerializerSettings With {
									.NullValueHandling = NullValueHandling.Include,
									.Formatting = Formatting.Indented
				})

			File.WriteAllText(mainFileName, json)

			'Dim applicationSettingsList As List(Of Settings) = JsonConvert.DeserializeObject(Of List(Of Settings))(File.ReadAllText("Dump.txt"))

			Dim currentEnvironment = New Environment With {.Name = "Development"}

			json = JsonConvert.SerializeObject(currentEnvironment, Formatting.Indented,
														 New JsonSerializerSettings With {
															.NullValueHandling = NullValueHandling.Include,
															.Formatting = Formatting.Indented
															})

			Dim environmentFileName = "env.json"
			File.WriteAllText(environmentFileName, json)

		End Sub
	End Class
End Namespace
