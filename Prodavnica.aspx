<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prodavnica.aspx.cs" Inherits="B17.Prodavnica" %>

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

                <div class="logoHeading">

                    <img src="Images/webShopCart.png" alt="Web Shop Logo" />

                    <h1 id="naslov">Web prodavnica</h1>

                    <h1></h1>

                </div>

                <hr class="gray_line" />

                <div class="labelsHeading">

                    <span>Parametri za pretragu:</span>

                </div>

                <div class="firstRow">

                    <div class="item">

                        <div class="dropdownList">
                        <asp:Label ID="Label1" runat="server" Text="Proizvođač:"></asp:Label>
                        <asp:DropDownList ID="DropDownListProizvodjaci" runat="server" AutoPostBack="false"></asp:DropDownList>
                        </div>
                        <div class="dropdownList">
                        <asp:Label ID="Label4" runat="server" Text="RAM:"></asp:Label>
                        <asp:DropDownList ID="DropDownListRAM" runat="server" AutoPostBack="false"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="item">
                        <div class="dropdownList">
                            <asp:Label ID="Label2" runat="server" Text="Kamera:"></asp:Label>
                            <asp:DropDownList ID="DropDownListKamere" runat="server" AutoPostBack="false"></asp:DropDownList>
                        </div>
                        <div class="dropdownList">
                            <asp:Label ID="Label5" runat="server" Text="Dual SIM:"></asp:Label>
                            <asp:DropDownList ID="DropDownListDualSim" runat="server" AutoPostBack="false"></asp:DropDownList>
                        </div>
                    </div>


                    <div class="item">
                        <div class="dropdownList">
                        <asp:Label ID="Label3" runat="server" Text="Ekran:"></asp:Label>
                        <asp:DropDownList ID="DropDownListEkrani" runat="server" AutoPostBack="false"></asp:DropDownList>
                        </div>
                        <div class="dropdownList">
                        <asp:Label ID="Label6" runat="server" Text="Procesor:"></asp:Label>
                        <asp:DropDownList ID="DropDownListProcesori" runat="server" AutoPostBack="false"></asp:DropDownList>
                        </div>
                    
                    </div>

                        <asp:Button ID="ButtonSearchPhones" runat="server" Text="Traži" Width ="5%" Height="30" OnClick="ButtonSearchPhones_Click"/>
                        
            
                </div>

                <hr class="gray_line" />

                <!--ne radi bootstrap klasa jer stranica ne koristi site master tj. nije importovan bootstrap, boja header-a: RGB 38, 76, 115-->
                <!--slika u GridView: https://www.youtube.com/watch?v=PS-EGL6Qe8o&list=PL6n9fhu94yhW1NryGv6LxX4U4b07T4RlI&index=30-->
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="Ne postoji telefon sa izabranim parametrima."
                    BorderStyle="Solid" BorderColor="Gray" BorderWidth="1px" HeaderStyle-BackColor="#264c73" HeaderStyle-ForeColor="White" RowStyle-BorderColor="Gray"
                     RowStyle-BorderWidth="1px" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("putanjaSlike") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="karakteristike" HeaderText="Karakteristike" ItemStyle-HorizontalAlign="Left"/>
                        <asp:BoundField DataField="cena" HeaderText="Cena" />
                    </Columns>
                    
                </asp:GridView>
                


            </div>
        </div>
        <div class="footer">
            <div class="fcol1">
                Elektrotehnička škola Zemun Beograd
            </div>
            <div class="fcol2">              
                <a class="a" href="Uputstvo">Uputstvo</a>
                <a class="a" href="">O autoru</a>               
            </div>           
        </div>


        </div>
    </form>
</body>
</html>
