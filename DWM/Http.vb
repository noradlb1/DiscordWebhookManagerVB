Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Net
Imports System.Collections.Specialized

Namespace DWM
	Friend Class Http
		Public Shared Function Post(ByVal uri As String, ByVal pairs As NameValueCollection) As Byte()
			Using webClient As New WebClient()
				Return webClient.UploadValues(uri, pairs)
			End Using
		End Function
	End Class
End Namespace