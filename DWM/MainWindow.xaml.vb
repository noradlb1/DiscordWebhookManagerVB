Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Collections.Specialized
Imports System.Windows.Threading
Imports Color = System.Windows.Media.Color
Imports System.Diagnostics
Imports ColorConverter = System.Windows.Media.ColorConverter

Namespace DWM
	''' <summary>
	''' Логика взаимодействия для MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window

		Private Url As New List(Of String)()
		Private names1 As New List(Of String)()
		Private avatars As New List(Of String)()
		Private avatarnames As New List(Of String)()
		Private themenames As New List(Of String)()
		Private Const namepath As String = "./names.txt"
		Private Const urlpath As String = "./urls.txt"
		Private Const avatarspath As String = "./avatars.txt"
		Private Const avatarnamespath As String = "./avatarnames.txt"
		Private Const setpath As String = "./settings.txt"
		Private Const foldpath As String = "./Themes"
		Private urls2 As String ' VARIABLE FOR CHECK IF THE ENTERED URL IS CORRECT
		Private delmode As Boolean = False ' DELETE MODE
		Private slctd As Boolean = False ' FALSE WHEN SEND SCREEN OPENED
		Private avsel As Boolean = True ' AVATAR SELECTION
		Private selth As Integer = 0
		Private cg1c1 As String
		Private cg1c2 As String
		Private cg2c1 As String
		Private cg2c2 As String
		Private cgbc1 As String
		Private cgbc2 As String
		Private cgsc1 As String
		Private cgsc2 As String
		Private mg1c1 As Color = Color.FromArgb(100, 97, 67, 133)
		Private mg1c2 As Color = Color.FromArgb(100, 81, 99, 149)
		Private mg2c1 As Color = Color.FromArgb(100, 43, 88, 118)
		Private mg2c2 As Color = Color.FromArgb(100, 78, 67, 118)
		Private mgbc1 As Color = Color.FromArgb(100, 35, 34, 32)
		Private mgbc2 As Color
		Private mgsc1 As Color
		Private mgsc2 As Color

		Public Sub New()
			InitializeComponent()

			Dim d As New DefaultThemes()
			If (File.Exists(urlpath)) AndAlso (File.Exists(namepath)) AndAlso (File.Exists(avatarspath)) AndAlso (File.Exists(avatarnamespath)) AndAlso (File.Exists(setpath)) AndAlso (Directory.Exists(foldpath)) AndAlso (File.Exists("./Themes/default.dwmtheme")) AndAlso (File.Exists("./Themes/sunset.dwmtheme")) AndAlso (File.Exists("./Themes/solid.dwmtheme")) Then
				Url.AddRange(File.ReadAllLines(urlpath))
				names1.AddRange(File.ReadAllLines(namepath))
				avatars.AddRange(File.ReadAllLines(avatarspath))
				avatarnames.AddRange(File.ReadAllLines(avatarnamespath))
				Dim tempset() As String = File.ReadAllLines(setpath)
				If tempset(0) = "false" OrElse tempset(0) = "False" OrElse tempset(0) = "0" Then
					avsel = False
				Else
					avsel = True
				End If
				Try
					selth = Convert.ToInt32(tempset(1))
				Catch e1 As Exception
					Dim file4 As FileStream = File.Create(setpath)
					Dim f4() As Byte = Encoding.UTF8.GetBytes(avsel & ControlChars.CrLf & selth & ControlChars.CrLf)
					file4.Write(f4, 0, f4.Length)
					file4.Close()
				End Try
				themenames.AddRange(Directory.GetFiles(foldpath))
				themeload()
				If cg1c1 = "" OrElse cg1c2 = "" OrElse cg2c1 = "" OrElse cg2c2 = "" OrElse cgbc1 = "" OrElse cgbc2 = "" OrElse cg1c1 Is Nothing OrElse cg1c2 Is Nothing OrElse cg2c1 Is Nothing OrElse cg2c2 Is Nothing OrElse cgbc1 Is Nothing OrElse cgbc2 Is Nothing Then
					mg1c1 = DirectCast(ColorConverter.ConvertFromString("#FF516395"), Color)
					mg1c2 = DirectCast(ColorConverter.ConvertFromString("#FF614385"), Color)
					mg2c1 = DirectCast(ColorConverter.ConvertFromString("#FF2B5876"), Color)
					mg2c2 = DirectCast(ColorConverter.ConvertFromString("#FF4E4376"), Color)
					mgbc1 = DirectCast(ColorConverter.ConvertFromString("#FF04619F"), Color)
					mgbc2 = DirectCast(ColorConverter.ConvertFromString("Black"), Color)
					mgsc1 = DirectCast(ColorConverter.ConvertFromString("#FF232220"), Color)
					mgsc2 = DirectCast(ColorConverter.ConvertFromString("#FF232220"), Color)
					ThemeApply()
				Else
					mg1c1 = DirectCast(ColorConverter.ConvertFromString(cg1c1), Color)
					mg1c2 = DirectCast(ColorConverter.ConvertFromString(cg1c2), Color)
					mg2c1 = DirectCast(ColorConverter.ConvertFromString(cg2c1), Color)
					mg2c2 = DirectCast(ColorConverter.ConvertFromString(cg2c2), Color)
					mgbc1 = DirectCast(ColorConverter.ConvertFromString(cgbc1), Color)
					mgbc2 = DirectCast(ColorConverter.ConvertFromString(cgbc2), Color)
					mgsc1 = DirectCast(ColorConverter.ConvertFromString(cgsc1), Color)
					mgsc2 = DirectCast(ColorConverter.ConvertFromString(cgsc2), Color)
					ThemeApply()
				End If
				listBox3.SelectedIndex = selth
			Else
				If ((Not File.Exists(urlpath))) Then 'Creating Files
					Dim names As FileStream = File.Create(urlpath)
					names.Close()
				End If

				If ((Not File.Exists(namepath))) Then
					Dim names2 As FileStream = File.Create(namepath)
					names2.Close()
				End If
				If ((Not File.Exists(avatarspath))) Then
					Dim names3 As FileStream = File.Create(avatarspath)
					names3.Close()
				End If
				If ((Not File.Exists(avatarnamespath))) Then
					Dim names4 As FileStream = File.Create(avatarnamespath)
					names4.Close()
				End If
				If ((Not File.Exists(setpath))) Then
					Dim names5 As FileStream = File.Create(setpath)
					names5.Close()
				End If
				If Not Directory.Exists(foldpath) Then
					Dim di As DirectoryInfo = Directory.CreateDirectory(foldpath)
				End If
				For Each i As KeyValuePair(Of String, String) In d.themes
					If ((Not File.Exists($"./Themes/{i.Key}.dwmtheme"))) Then
						Dim file5 As FileStream = File.Create($"./Themes/{i.Key}.dwmtheme")
						Dim f4() As Byte = Encoding.UTF8.GetBytes(i.Value)
						file5.Write(f4, 0, f4.Length)
						file5.Close()
					End If
				Next i
			End If

			For i As Integer = 0 To Math.Min(Url.Count, names1.Count) - 1 'Listbox fill
				listBox1.Items.Add(names1(i))
			Next i
			For i As Integer = 0 To Math.Min(avatars.Count, avatarnames.Count) - 1
				listBox2.Items.Add(avatarnames(i))
			Next i
			For i As Integer = 0 To themenames.Count - 1
				listBox3.Items.Add(themenames(i).Remove(0,9))
			Next i
			If avsel = False Then
				listBox2.Visibility = Visibility.Hidden
				listBox1.Height = 368
				avLabel.Visibility = Visibility.Hidden
				AvSelSet.IsChecked = False
			End If
		End Sub

		Public Sub sendWebHook(ByVal URL As String, ByVal msg As String, ByVal username As String, ByVal avatarurl As String)
			Http.Post(URL, New NameValueCollection() From { { "username", username }, { "content", msg }, { "avatar_url", avatarurl } })
		End Sub

		Public Sub sendWebHook(ByVal URL As String, ByVal msg As String, ByVal username As String)
			Http.Post(URL, New NameValueCollection() From { { "username", username }, { "content", msg }})
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				If textBox2.Text <> "" AndAlso textBox1.Text <> "" Then
					urls2 = Url(listBox1.SelectedIndex)
					If urls2.StartsWith("https://discordapp.com/api/webhooks/") OrElse urls2.StartsWith("https://discord.com/api/webhooks/") Then
						If listBox2.SelectedIndex <> -1 Then
							sendWebHook(Url(listBox1.SelectedIndex), textBox2.Text, textBox1.Text, avatars(listBox2.SelectedIndex))
							textBox2.Text = ""
						Else
							sendWebHook(Url(listBox1.SelectedIndex), textBox2.Text, textBox1.Text)
							textBox2.Text = ""
						End If
					Else
						MessageBox.Show("You saved invalid Discord Webhook URL in file!")
					End If
				Else
					MessageBox.Show("Error: Check input fields", "Error")
				End If
			Catch e1 As Exception
					MessageBox.Show("Webhook/Avatar URL not specified or is incorrect!", "Error")
			End Try
		End Sub

		Private Sub SendCatBtn_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			SendGrid.Visibility = Visibility.Visible
			AddGrid.Visibility = Visibility.Hidden
			SetGrid.Visibility = Visibility.Hidden
			slctd = False
		End Sub

		Private Sub AddcCatBtn_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) 'Choosing Category
			AddGrid.Visibility = Visibility.Visible
			SendGrid.Visibility = Visibility.Hidden
			SetGrid.Visibility = Visibility.Hidden
			slctd = True
		End Sub

		Private Sub DeleteCatBtn_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If avsel = True Then

				If slctd = False Then
					If delmode = False Then

						DelWHBtn.Visibility = Visibility.Visible
						DelChBtn.Visibility = Visibility.Visible
						delmode = True
					Else
						DelWHBtn.Visibility = Visibility.Hidden
						DelChBtn.Visibility = Visibility.Hidden
						delmode = False
					End If
				Else
					SendGrid.Visibility = Visibility.Visible
					AddGrid.Visibility = Visibility.Hidden
					SetGrid.Visibility = Visibility.Hidden
					slctd = False
					If delmode = False Then

						DelWHBtn.Visibility = Visibility.Visible
						DelChBtn.Visibility = Visibility.Visible
						delmode = True
					Else
						DelWHBtn.Visibility = Visibility.Hidden
						DelChBtn.Visibility = Visibility.Hidden
						delmode = False
					End If
				End If
			Else
				DelWHBtn.Margin = New Thickness(632, 378, 0, 0)
				If slctd = False Then
					If delmode = False Then

						DelWHBtn.Visibility = Visibility.Visible
						DelChBtn.Visibility = Visibility.Visible
						delmode = True
					Else
						DelWHBtn.Visibility = Visibility.Hidden
						DelChBtn.Visibility = Visibility.Hidden
						delmode = False
					End If
				Else
					SendGrid.Visibility = Visibility.Visible
					AddGrid.Visibility = Visibility.Hidden
					SetGrid.Visibility = Visibility.Hidden
					slctd = False
					If delmode = False Then

						DelWHBtn.Visibility = Visibility.Visible
						DelChBtn.Visibility = Visibility.Visible
						delmode = True
					Else
						DelWHBtn.Visibility = Visibility.Hidden
						DelChBtn.Visibility = Visibility.Hidden
						delmode = False
					End If
				End If
			End If
		End Sub

		Private Sub AddChBtn_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) 'Adding Avatar
			If (ChIDBox.Text <> "") AndAlso (ChNameBox.Text <> "") Then
					listBox2.Items.Add(ChNameBox.Text)
					avatars.Add(ChIDBox.Text)
					avatarnames.Add(ChNameBox.Text)
					ChIDBox.Text = ""
					ChNameBox.Text = ""
			Else
				MessageBox.Show("Error: Check input fields.", "Error")
			End If
		End Sub

		Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If (textBox3.Text <> "") AndAlso (textBox4.Text <> "") Then
				urls2 = textBox3.Text
				If urls2.StartsWith("https://discordapp.com/api/webhooks/") OrElse urls2.StartsWith("https://discord.com/api/webhooks/") Then
					listBox1.Items.Add(textBox4.Text)
					names1.Add(textBox4.Text)
					Url.Add(textBox3.Text)
					textBox3.Text = ""
					textBox4.Text = ""
				Else
					MessageBox.Show("Invalid Discord Webhook URL entered!")
				End If
			Else
				MessageBox.Show("Error: Check input fields", "Error")
			End If
		End Sub

		Private Sub Window_Closed(ByVal sender As Object, ByVal e As EventArgs)
			Dim file As FileStream = System.IO.File.Create(urlpath) 'Saving URLs
			For Each i As String In Url
				Dim f() As Byte = Encoding.UTF8.GetBytes(i & ControlChars.CrLf)
				file.Write(f, 0, f.Length)
			Next i
			file.Close()

			Dim file1 As FileStream = System.IO.File.Create(namepath) 'Saving Names
			For Each i As String In names1
				Dim f1() As Byte = Encoding.UTF8.GetBytes(i & ControlChars.CrLf)
				file1.Write(f1, 0, f1.Length)
			Next i
			file1.Close()

			Dim file2 As FileStream = System.IO.File.Create(avatarspath) 'Saving Avatars ID
			For Each i As String In avatars
				Dim f2() As Byte = Encoding.UTF8.GetBytes(i & ControlChars.CrLf)
				file2.Write(f2, 0, f2.Length)
			Next i
			file2.Close()

			Dim file3 As FileStream = System.IO.File.Create(avatarnamespath) 'Saving Avatars Names
			For Each i As String In avatarnames
				Dim f3() As Byte = Encoding.UTF8.GetBytes(i & ControlChars.CrLf)
				file3.Write(f3, 0, f3.Length)
			Next i
			file3.Close()

			Dim file4 As FileStream = System.IO.File.Create(setpath)
			Dim f4() As Byte = Encoding.UTF8.GetBytes(avsel & ControlChars.CrLf & selth & ControlChars.CrLf)
			file4.Write(f4, 0, f4.Length)
			file4.Close()
		End Sub

		Private Sub listBox1_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
			Try
				textBox1.Text = names1(listBox1.SelectedIndex)
			Catch e1 As Exception

			End Try
		End Sub

		Private Sub DelWHBtn_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If listBox1.SelectedItem IsNot Nothing Then
				Dim i As Integer = listBox1.SelectedIndex
				listBox1.Items.RemoveAt(i)
				names1.RemoveAt(i)
				Url.RemoveAt(i)
				textBox1.Text = ""
			Else
				MessageBox.Show("You can't delete nothing!", "Error")
			End If
		End Sub

		Private Sub DelChBtn_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If listBox2.SelectedItem IsNot Nothing Then
				Dim i As Integer = listBox2.SelectedIndex
				listBox2.Items.RemoveAt(i)
				avatars.RemoveAt(i)
				avatarnames.RemoveAt(i)
			Else
				MessageBox.Show("You can't delete nothing!", "Error")
			End If
		End Sub

		Private Sub SetCatBtn_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			AddGrid.Visibility = Visibility.Hidden
			SendGrid.Visibility = Visibility.Hidden
			SetGrid.Visibility = Visibility.Visible
			slctd = True
		End Sub

		Private Sub AvSelSet_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			avsel = True
			listBox2.Visibility = Visibility.Visible
			listBox1.Height = 169
			avLabel.Visibility = Visibility.Visible
		End Sub

		Private Sub AvSelSet_Unchecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			avsel = False
			listBox2.Visibility = Visibility.Hidden
			listBox1.Height = 368
			avLabel.Visibility = Visibility.Hidden
			listBox2.SelectedIndex = -1
		End Sub

		Private Sub listBox1_MouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			listBox1.SelectedIndex = -1
		End Sub

		Private Sub listBox2_MouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			listBox2.SelectedIndex = -1
		End Sub

		Private Sub ThemeApply()
			g1c1.Color = mg1c1
			g1c2.Color = mg1c2

			g2c1.Color = mg1c1
			g2c2.Color = mg1c2

			g3c1.Color = mg1c1
			g3c2.Color = mg1c2

			g4c1.Color = mg1c1
			g4c2.Color = mg1c2

			g5c1.Color = mg1c1
			g5c2.Color = mg1c2

			g6c1.Color = mg1c1
			g6c2.Color = mg1c2

			g7c1.Color = mg1c1
			g7c2.Color = mg1c2

			g8c1.Color = mg1c1
			g8c2.Color = mg1c2

			g9c1.Color = mg1c1
			g9c2.Color = mg1c2

			g10c1.Color = mg1c1
			g10c2.Color = mg1c2

			g11c1.Color = mg1c1
			g11c2.Color = mg1c2

			g12c1.Color = mg1c1
			g12c2.Color = mg1c2

			'Gradient 2

			g1c1v2.Color = mg2c1
			g1c2v2.Color = mg2c2

			g1c1v2.Color = mg2c1
			g1c2v2.Color = mg2c2

			g2c1v2.Color = mg2c1
			g2c2v2.Color = mg2c2

			g3c1v2.Color = mg2c1
			g3c2v2.Color = mg2c2

			g4c1v2.Color = mg2c1
			g4c2v2.Color = mg2c2

			g5c1v2.Color = mg2c1
			g5c2v2.Color = mg2c2
										'Background

			gbc1.Color = mgbc1
			gbc2.Color = mgbc2
										'Sidebar

			gsc1.Color = mgsc1
			gsc2.Color = mgsc2
		End Sub

		Private Sub ThemeOpenBtn_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				Process.Start(Directory.GetCurrentDirectory() & "\themes")
			Catch
				Directory.CreateDirectory(Directory.GetCurrentDirectory() & "\themes")
				Process.Start(Directory.GetCurrentDirectory() & "\themes")
			End Try
		End Sub

		Private Sub ThemeButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			selth = Convert.ToInt32(listBox3.SelectedIndex)
			themeload()
			If cg1c1 = "" OrElse cg1c2 = "" OrElse cg2c1 = "" OrElse cg2c2 = "" OrElse cgbc1 = "" OrElse cgbc2 = "" OrElse cg1c1 Is Nothing OrElse cg1c2 Is Nothing OrElse cg2c1 Is Nothing OrElse cg2c2 Is Nothing OrElse cgbc1 Is Nothing OrElse cgbc2 Is Nothing Then
				mg1c1 = DirectCast(ColorConverter.ConvertFromString("#FF516395"), Color)
				mg1c2 = DirectCast(ColorConverter.ConvertFromString("#FF614385"), Color)
				mg2c1 = DirectCast(ColorConverter.ConvertFromString("#FF2B5876"), Color)
				mg2c2 = DirectCast(ColorConverter.ConvertFromString("#FF4E4376"), Color)
				mgbc1 = DirectCast(ColorConverter.ConvertFromString("#FF04619F"), Color)
				mgbc2 = DirectCast(ColorConverter.ConvertFromString("Black"), Color)
				mgsc1 = DirectCast(ColorConverter.ConvertFromString("#FF232220"), Color)
				mgsc2 = DirectCast(ColorConverter.ConvertFromString("#FF232220"), Color)
				themenames.Clear()
				themenames.AddRange(Directory.GetFiles(foldpath))
				listBox3.Items.Clear()
				For i As Integer = 0 To themenames.Count - 1
					listBox3.Items.Add(themenames(i).Remove(0, 9))
				Next i

				ThemeApply()
			Else
				mg1c1 = DirectCast(ColorConverter.ConvertFromString(cg1c1), Color)
				mg1c2 = DirectCast(ColorConverter.ConvertFromString(cg1c2), Color)
				mg2c1 = DirectCast(ColorConverter.ConvertFromString(cg2c1), Color)
				mg2c2 = DirectCast(ColorConverter.ConvertFromString(cg2c2), Color)
				mgbc1 = DirectCast(ColorConverter.ConvertFromString(cgbc1), Color)
				mgbc2 = DirectCast(ColorConverter.ConvertFromString(cgbc2), Color)
				mgsc1 = DirectCast(ColorConverter.ConvertFromString(cgsc1), Color)
				mgsc2 = DirectCast(ColorConverter.ConvertFromString(cgsc2), Color)
				themenames.Clear()
				themenames.AddRange(Directory.GetFiles(foldpath))
				listBox3.Items.Clear()
				For i As Integer = 0 To themenames.Count - 1
					listBox3.Items.Add(themenames(i).Remove(0, 9))
				Next i
				ThemeApply()

			End If
		End Sub

		Private Sub RefreshTheme_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			themenames.Clear()
			themenames.AddRange(Directory.GetFiles(foldpath))
			listBox3.Items.Clear()
			For i As Integer = 0 To themenames.Count - 1
				listBox3.Items.Add(themenames(i).Remove(0, 9))
			Next i
		End Sub

		Private Sub themeload()
			If selth < 0 Then
				MessageBox.Show("You must select something!", "Error")
				Return
			End If

			Dim temp() As String = File.ReadAllLines(themenames(selth))
			cg1c1 = temp(1)
			cg1c2 = temp(3)
			cg2c1 = temp(5)
			cg2c2 = temp(7)
			cgbc1 = temp(9)
			cgbc2 = temp(11)
			cgsc1 = temp(13)
			cgsc2 = temp(15)
		End Sub
	End Class
End Namespace
