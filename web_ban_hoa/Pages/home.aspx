<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/home.Master" AutoEventWireup="true"
    CodeBehind="home.aspx.cs" Inherits="web_ban_hoa.pages.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Publics/css/home_page.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="category">
        <div class="container">
            <h2 class="category__title">Mẫu hoa mới 2023</h2>
            <div class="wrapper-item-category">
                <asp:Repeater runat="server" ID="rptCategories">
                    <ItemTemplate>
                        <div class="category-item">
                            <div class="category-item-top">
                                <a href="#">
                                    <img src="<%# Eval("ThumbnailPath") %>" alt="hoa tình yêu" />
                                </a>
                            </div>
                            <div class="category-item-bot">
                                <h2 class="category-item-bot__name">
                                    <a href="#"><%# Eval("Name") %></a>
                                </h2>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>

    <div class="container">
        <section class="product">
            <h2 class="product__title">Khuyến mãi
            </h2>
            <div class="wrapper-product-list">
                <asp:Repeater runat="server" ID="rptProduct">
                    <ItemTemplate>
                        <div class="product-item">
                            <div class="product-item-top">
                                <img src="../Publics/images/10258_white-roses.jpg" alt="hoa" />
                                <%# Eval("Sale").ToString().ToUpper() == "TRUE" ? "<div class='product-item-top__tag product-item-top__tag--sale'><span>Sale</span></div>" :""%>
                            </div>
                            <div class="product-item-bot">
                                <h3 class="product-item-bot__name">
                                    <a href="#"><%# Eval("Name") %></a>
                                </h3>
                                <div class="product-item-bot-price">
                                    <%# Eval("Sale").ToString().ToUpper() == "TRUE" ? 
    "<span class='product-item-bot-price__price product-item-bot-price__price--old'>" + Eval("OldPrice") + " đ</span>" : "" %>
                                    <span class="product-item-bot-price__price product-item-bot-price__price--current">
                                        <%# Eval("CurrentPrice") %> đ
                                    </span>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </section>
    </div>
</asp:Content>
