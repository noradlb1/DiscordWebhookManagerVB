Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace DWM
	Friend Class DefaultThemes
		Public themes As New Dictionary(Of String, String)()
		Public Sub New()
			themes.Add("default", "[Gradient 1 Color 1]" & ControlChars.CrLf & "#FF516395" & ControlChars.CrLf & "[Gradient 1 Color 2]" & ControlChars.CrLf & "#FF2B5876" & ControlChars.CrLf & "[Gradient 2 Color 1]" & ControlChars.CrLf & "#FF2B5876" & ControlChars.CrLf & "[Gradient 2 Color 2]" & ControlChars.CrLf & "#FF4E4376" & ControlChars.CrLf & "[Background Gradient Color 1]" & ControlChars.CrLf & "#FF04619F" & ControlChars.CrLf & "[Background Gradient Color 2]" & ControlChars.CrLf & "#000000" & ControlChars.CrLf & "[Sidebar Gradient Color 1]" & ControlChars.CrLf & "#FF232220" & ControlChars.CrLf & "[Sidebar Gradient Color 2]" & ControlChars.CrLf & "#FF232220" & ControlChars.CrLf)
			themes.Add("sunset", "[Gradient 1 Color 1]" & ControlChars.CrLf & "#000048" & ControlChars.CrLf & "[Gradient 1 Color 2]" & ControlChars.CrLf & "#830048" & ControlChars.CrLf & "[Gradient 2 Color 1]" & ControlChars.CrLf & "#000048" & ControlChars.CrLf & "[Gradient 2 Color 2]" & ControlChars.CrLf & "#830048" & ControlChars.CrLf & "[Background Gradient Color 1]" & ControlChars.CrLf & "#FF232220" & ControlChars.CrLf & "[Background Gradient Color 2]" & ControlChars.CrLf & "#00002A" & ControlChars.CrLf & "[Sidebar Gradient Color 1]" & ControlChars.CrLf & "#FF232220" & ControlChars.CrLf & "[Sidebar Gradient Color 2]" & ControlChars.CrLf & "#FF232220" & ControlChars.CrLf)
			themes.Add("solid", "[Gradient 1 Color 1]" & ControlChars.CrLf & "#38383d" & ControlChars.CrLf & "[Gradient 1 Color 2]" & ControlChars.CrLf & "#38383d" & ControlChars.CrLf & "[Gradient 2 Color 1]" & ControlChars.CrLf & "#38383d" & ControlChars.CrLf & "[Gradient 2 Color 2]" & ControlChars.CrLf & "#38383d" & ControlChars.CrLf & "[Background Gradient Color 1]" & ControlChars.CrLf & "#2a2a2e" & ControlChars.CrLf & "[Background Gradient Color 2]" & ControlChars.CrLf & "#2a2a2e" & ControlChars.CrLf & "[Sidebar Gradient Color 1]" & ControlChars.CrLf & "#2a2a2e" & ControlChars.CrLf & "[Sidebar Gradient Color 2]" & ControlChars.CrLf & "#2a2a2e" & ControlChars.CrLf)
		End Sub
	End Class
End Namespace