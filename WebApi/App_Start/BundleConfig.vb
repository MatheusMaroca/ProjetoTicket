Imports System.Web
Imports System.Web.Optimization

Public Module BundleConfig
    ' Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)
        bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
                   "~/Scripts/jquery-{version}.js"))

        ' Use a versão em desenvolvimento do Modernizr para desenvolver e aprender com ela. Após isso, quando você estiver
        ' pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"))

        bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include(
                    "~/Scripts/bootstrap.js"))

        bundles.Add(New StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/site.css"))
    End Sub
End Module