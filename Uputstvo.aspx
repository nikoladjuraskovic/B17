<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Uputstvo.aspx.cs" Inherits="B17.Uputstvo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Veb Prodavnica</title>
    <link href="style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div class="header">
            <div class="hcol1">
                Zadatak 8
            </div>
            <div class="hcol2">
                Veb prodavnica           
            </div>           
        </div>
        <div class="main">
            <div class="container">                
                <div class="uputstvo">
                    
                    <h3>Uputstvo</h3>
                    <br />

                    Veb aplikacija za prikaz i pretragu artikala u asortimanu. Biranjem parametara iz padajućih listi i klikom
                    na dugme traži u tabeli ispod se ispisuju podaci zajedno sa slikom telefona u prodavnici koji odgovaraju traženim specifikacijama.
                    Na prvoj stranici se mogu pretražiti telefoni, a na drugoj je uputstvo za upotrebu. Aplikacije je rađena korišćenjem
                    ASP.NET Web Forms tehnologije(.NET Framework 4.8).

                   
                </div>            

            </div>
        </div>
        <div class="footer">
            <div class="fcol1">
                Elektrotehnička škola Zemun Beograd
            </div>
            <div class="fcol2">              
                <!--<a class="a" href="Prodavnica">Početna</a>-->
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="a" PostBackUrl="~/Prodavnica.aspx">Prodavnica</asp:LinkButton>
                <a class="a" href="">O autoru</a>
                
            </div>           
        </div>


        </div>
    </form>
</body>
</html>
