Public Class CeVIO

    Public Sub Talk(Scenario As String)

        Dim service = Activator.CreateInstance(Type.GetTypeFromProgID("CeVIO.Talk.RemoteService2.ServiceControl2"))
        service.StartHost(False)

        Dim talker = Activator.CreateInstance(Type.GetTypeFromProgID("CeVIO.Talk.RemoteService2.Talker2"))
        talker.Cast = "さとうささら"

        Dim result = talker.Speak(Scenario)
        'result.Wait()

        Runtime.InteropServices.Marshal.ReleaseComObject(talker)
        Runtime.InteropServices.Marshal.ReleaseComObject(service)



    End Sub

End Class
