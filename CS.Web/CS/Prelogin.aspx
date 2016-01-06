<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prelogin.aspx.cs" Inherits=".Prelogin" ClientIDMode="Static" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
  <link rel="stylesheet" href="css/style.css" />
    
  <!--[if lt IE 9]><script src="//html5shim.googlecode.com/svn/trunk/html5.js">
</script><![endif]-->

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>MAB Login</title>
</head>
<body>
    <form method="get" action="Default.aspx" name="LoginForm" runat="server" id="LoginForm">
     <section class="container">
    <div class="login">
      <h1>Kunden Login</h1>
        <p><input type="text" name="KaLogin" value="" placeholder="Kundennummer" runat="server" id="KaLogin" /></p>
          &nbsp;&nbsp;<asp:label runat="server" id="ErrorLabel2" Visible="false" Text ="" ForeColor="Red" ></asp:label>
        <p class="remember_me">
          <label>
            <input type="checkbox" name="KaRememberMe" id="KaRememberMe" runat="server" />
            Anmeldeinformationen merken?
          </label>
        </p>
        <p class="submit"><input type="submit" name="KaSubmit" value="Login" runat="server" id="KaSubmit" /></p>
    </div>
  </section>
  <section class="container">
    <div class="login" id="madiv" >
      <h1>Mitarbeiter Login</h1>
        <p><input type="text" name="MaLogin" value="" placeholder="Benutzername oder E-Mail" runat="server" id="MaLogin" /></p>
        <p><input type="text" name="MaPass" value="" placeholder="Passwort" runat="server" id="MaPass" /></p>
        &nbsp;&nbsp;<asp:label runat="server" id="ErrorLabel" Visible="false" Text ="" ForeColor="Red" ></asp:label>
        <p class="remember_me">
          <label>
            <input type="checkbox" name="MaRememberMe" id="MaRememberMe" runat="server" checked="checked"  />
            Anmeldeinformationen merken?
          </label>
        </p>
        <p class="submit"><input type="submit" name="MaSubmit" value="Login" runat="server"  id="MaSubmit" /></p>     
    </div>

    <div class="login-help">
      <%-
-System.Xml.Linq.XElement.Parse("<p>Passwort vergessen? <a href=\"index.html\">Hier clicken um ein neues anzufordern</a>.</p>")--;
%>
      <asp:label runat="server" id="customerror" Visible="false" Text ="" ForeColor="Red" ></asp:label>
    </div>
  </section>
         </form>
</body>
</html>


